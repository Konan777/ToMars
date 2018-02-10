using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using ToMars.Model.Entities;
using System.Threading.Tasks;
using ToMars.Model.Settings;
using System.Collections.Generic;
using PagedList;

namespace ToMars.Model
{
    public interface ITMRepositary
    {
        AnketaFile GetFile(string name);
        List<AnketaFile> GetFiles();
        Task<List<AnketaFile>> GetFilesAsync();
        List<Anketa> GetAnketas(int FileID);
        IPagedList<Anketa> GetAnketasByPage(int FileID, int page, int pageSize, string order);
        Task<List<Anketa>> GetAnketasAsync(int FileID);
        Anketa GetAnketa(int ID);
        Task<Anketa> GetAnketaAsync(int ID);
        Task InsertFileAsync(AnketaFile _anketaFile);
        void Update(Anketa _anketa);
        void Remove(Anketa _anketa);
        void Add(Anketa _anketa);
    }

    public class AnketaKeeper : ITMRepositary
    {
        // dbContext lifetime should be limited to the transaction you are running.
        // we need new context each time because all operations is unit of work
        // new context created by calling _Setting.GetNewContext() 
        // GetNewContext gets context from currently selected database
        private readonly ISettings _Setting;

        public AnketaKeeper(ISettings _setting)
        {
            _Setting = _setting;
        }

        public AnketaFile GetFile(string name)
        {
            using (var context = _Setting.GetNewContext())
            {
                return context.AnketaFile.Where(x => x.FileName == name).AsNoTracking().FirstOrDefault();
            }
        }

        public List<AnketaFile> GetFiles()
        {
            using (var context = _Setting.GetNewContext())
            {
                return context.AnketaFile.AsNoTracking().ToList();
            }
        }

        public Task<List<AnketaFile>> GetFilesAsync()
        {
            return Task.Run<List<AnketaFile>>(() =>
            {
                return GetFiles();
            });
        }

        public List<Anketa> GetAnketas(int FileID)
        {
            using (var context = _Setting.GetNewContext())
            {
                return context.Anketa.Where(w => w.FileId == FileID).AsNoTracking().ToList();
            }
        }

        public IPagedList<Anketa> GetAnketasByPage(int FileID, int page, int pageSize, string order)
        {
            order = (order.Length==0) ? "ID" : order;
            using (var context = _Setting.GetNewContext())
            {
                // ToPagedList takes only pageSize rows from database
                return context.Anketa.Where(w => w.FileId == FileID).OrderBy(order).ToPagedList(page, pageSize);
            }
        }

        public Task<List<Anketa>> GetAnketasAsync(int FileID)
        {
            return Task<List<Anketa>>.Factory.StartNew(() =>
            {
                return GetAnketas(FileID);
            });
        }

        public Anketa GetAnketa(int ID)
        {
            using (var context = _Setting.GetNewContext())
            {
                return context.Anketa.Where(w => w.ID == ID).AsNoTracking().FirstOrDefault();
            }
        }

        public Task<Anketa> GetAnketaAsync(int ID)
        {
            return Task<Anketa>.Factory.StartNew(() => {
                return GetAnketa(ID);
            });
        }

        public Task InsertFileAsync(AnketaFile _anketaFile)
        {
            return Task.Run(() =>
            {
                using (var context = _Setting.GetNewContext())
                {
                    var trans = context.Database.BeginTransaction();
                    try
                    {
                        context.AnketaFile.Add(_anketaFile); // Saves both AnketaFile and Anketa rows
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                    trans.Commit();
                }
            });
        }

        public void Update(Anketa _anketa)
        {
            using (var context = _Setting.GetNewContext())
            {
                context.Entry(_anketa).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remove(Anketa _anketa)
        {
            using (var context = _Setting.GetNewContext())
            {
                context.Entry(_anketa).State = EntityState.Deleted;
                //context.Anketa.Remove(_anketa);
                context.SaveChanges();
            }
        }

        public void Add(Anketa _anketa)
        {
            using (var context = _Setting.GetNewContext())
            {
                context.Entry(_anketa).State = EntityState.Added;
                context.Anketa.Add(_anketa);
                context.SaveChanges();
            }
        }
    }
}
 

