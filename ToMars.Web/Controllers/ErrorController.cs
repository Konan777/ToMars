using System;
using System.Web;
using System.Web.Mvc;

namespace ToMars.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("NotFound", 
                new HandleErrorInfo(new HttpException(403, "Dont allow access the error pages"), "Error", "Index")
            );
        }

        public ViewResult GenericError(HandleErrorInfo exception)
        {
            ViewBag.Title = "Internal error";
            return View("Error", exception);
        }

        public ViewResult AjaxError(string exception)
        {
            ViewBag.Title = "Ajax error";
            var exc = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<AjaxException>(exception);
            HandleErrorInfo hei = new HandleErrorInfo(new Exception(exc.Message), exc.Controller, exc.Action);
            return View("Error", hei);
        }

        public ViewResult NotFound()
        {
            ViewBag.Title = "Page Not Found";
            return View("Error", null);
        }
        public ViewResult Forbidden()
        {
            ViewBag.Title = "Access forbidden";
            return View("Error", null);
        }
    }

    public class AjaxException
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
    }
}