using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using ToMars.Model;
using ToMars.Web.Models;
using ToMars.Model.Models;
using ToMars.Model.Entities;
using PagedList;
using AutoMapper;
using System.Web;
using System.IO;
using System.Threading;
using ToMars.Web.Hubs;
using System.Threading.Tasks;

namespace ToMars.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IGeneralFacade _Facade;
        private readonly int pageSize = 10;

        public HomeController(IGeneralFacade _facade)
        {
            _Facade = _facade;
        }

        private string GetSortOrder(int page, string column)
        {
            // Храним модель сортировки в SessionState
            SortModel sm = new SortModel(); // Stable dependency
            if (Session["SortModel"] != null)
                sm = (Session["SortModel"] as SortModel);
            string sort = ""; // Порядок сортировки
            if (page == -1) {
                // Выбран новый файл. Сброс сортировки
                sm.Clear();
            } else {
                sm.UpdateModel(column);
                sort = sm.GetSortOrder();
            }
            Session["SortModel"] = sm;
            ViewBag.SortModel = sm;
            return sort;
        }

        //[NonAction]
        public ActionResult Index(int fileId = 0, int page = 1, string column = "")
        {
            //throw new ArgumentException("Специальная ошибка для теста");
            // Получим список файлов или подкрасим неверную строку соединения
            ViewBag.Files = new List<AnketaFile>();
            if (_Facade.Settings.SelectedDatabase.ConnectionIsValid())
            {
                ViewBag.Files = new SelectList(_Facade.Keeper.GetFiles(), "ID", "FileName");
                ViewBag.WrongConnection = false;
            }
            else
            {
                ViewBag.WrongConnection = true;
            }
            // Выбран новый файл
            var sort = GetSortOrder(page, column);
            if (page == -1) page = 1;

            ViewBag.FileId = fileId;
            ViewBag.ConnectionString = _Facade.Settings.SelectedDatabase.ConnectionString;

            // Заполним IPagedList данными
            IPagedList<Anketa> anketas = null;
            if (fileId > 0) anketas = _Facade.Keeper.GetAnketasByPage(fileId, page, pageSize, sort);

            if (Request != null) {
                //if (Request.IsAjaxRequest()) { throw new Exception("error"); } // Ajax Request error test
                return Request.IsAjaxRequest()
                    ? (ActionResult) PartialView("AnketaList", anketas) // В случае Ajax вернем только AnketaList.cshtml
                    : View(anketas); // Вернем Index.cshtml 
            } else {
                return View(anketas); // Unit testing. Request always null. Return Index.cshtml 
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ApplySettings(string cnnstr)
        {
            var oldcnn = _Facade.Settings.SelectedDatabase.ConnectionString;
            try
            {
                _Facade.Settings.SelectedDatabase.ConnectionString = cnnstr;
                if (_Facade.Settings.SelectedDatabase.ConnectionIsValid())
                {
                    _Facade.Settings.Save();
                }
            }
            catch (Exception ex)
            {
                _Facade.Settings.SelectedDatabase.ConnectionString = oldcnn;
                return Content("<p>Настройки не верные!</p><p>"+ex.Message+"</p>");
            }
            return Content("<p>Настройки применены успешно!</p>");
        }

        [HttpPost] 
        public ActionResult SaveAnketa(Anketa ank)
        {
            if (ank.ID != 0)
                _Facade.Keeper.Update(ank);
            else
                _Facade.Keeper.Add(ank);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult RemoveAnketa(int ID)
        {
            var ank = _Facade.Keeper.GetAnketa(ID);
            if (ank.ID != 0)
                _Facade.Keeper.Remove(ank);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult EditAnketa(int FileID, int ID) {
            // throw new ArgumentException("Специальная ошибка для теста");
            AnketaModel ankm = new AnketaModel() { FileId = FileID, Birthday = DateTime.Now };
            if (ID > 0) {
                // сопоставление
                ankm = Mapper.Map<AnketaModel>(_Facade.Keeper.GetAnketa(ID));
            }
            return PartialView(ankm);
        }

        [HttpPost]
        public ActionResult Upload(object obj)
        {
            var length = Request.ContentLength;
            var bytes = new byte[length];
            Request.InputStream.Read(bytes, 0, length);
            // bytes has byte content here. what do do next?

            var fileName = HttpUtility.UrlDecode(Request.Headers["X-File-Name"]);

            var saveToFileLoc = string.Format("{0}\\{1}", Server.MapPath("/Files"), fileName);
            //var saveToFileLoc = System.Web.Hosting.HostingEnvironment.MapPath("/Files")+ fileName;
            
            // save the file.
            try
            {
                if (!Directory.Exists(Server.MapPath("~/Files")))
                    Directory.CreateDirectory(Server.MapPath("~/Files"));
                var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write(bytes, 0, length);
                fileStream.Close();
                Session["FileName"] = saveToFileLoc;
            } catch (Exception ex)  {
                Session["FileName"] = "";
            }

            return Content("success", "text/plain");
            
        }

        private void Process(bool multithread, string connectionID)
        {
            // Prepare
            var _Cancel = new CancellationTokenSource();
            Session["_Cancel"] = _Cancel;
            var FileName = Session["FileName"]?.ToString();
            var Parser = _Facade.Parser;
            if (Parser.FileAlreadyParsed(FileName))
            {
                ProgressHub.SendMessage(connectionID, "File already parsed!");
                return;
            }
            // Fire and forget
            Task<bool>.Run(() =>
            {
                var progress = new Progress<int>();
                try
                {
                    var ProgressBarMaximum = Parser.RowsInAnketa(FileName).Result;
                    progress.ProgressChanged += (sender, args) =>
                    {
                        ProgressHub.SendProgress(connectionID, args, ProgressBarMaximum);
                    };
                    if (!multithread)
                        Parser.Parse_SigleAsync(FileName, progress, _Cancel).Wait();
                    else
                        Parser.Parse_MultipleAsync(FileName, progress, _Cancel).Wait();
                }
                catch (Exception ex)
                {
                    ProgressHub.SendMessage(connectionID, ex.InnerException.Message);
                }
                int fileId = _Facade.Keeper.GetFile(Path.GetFileName(FileName)).ID;
                ProgressHub.ParsingCompleted(connectionID, fileId);
                return true;
            });
        }

        [HttpPost]
        public ActionResult ParseSingleThread(string connectionID)
        {
            Process(false, connectionID);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult ParseMultithread(string connectionID)
        {
            Process(true, connectionID);
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult StopParsing(string connectionID)
        {
            if (Session["_Cancel"] != null)
            {
                var _Cancel = (Session["_Cancel"] as CancellationTokenSource);
                _Cancel.Cancel();
                ProgressHub.HideProgress(connectionID);
            }
            return new EmptyResult();
        }

        public FileResult DeployAnketa(int fileId)
        {
            var fileName = "_"+_Facade.Keeper.GetFiles().Where(w => w.ID == fileId).FirstOrDefault().FileName;
            var dir = Server.MapPath("~/Files");
            var anklist = _Facade.Keeper.GetAnketas(fileId);
            _Facade.Reader.Export(dir + fileName, anklist).Wait();
            byte[] mas = System.IO.File.ReadAllBytes(dir+fileName);

            return File(mas, "csv", fileName);
        }
    }
}