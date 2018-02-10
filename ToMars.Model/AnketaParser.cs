using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToMars.Model.Entities;
using ToMars.Model.Parser;

namespace ToMars.Model
{
    public interface IParser
    {
        bool FileAlreadyParsed(string FileName);
        Task<int> RowsInAnketa(string FileName);
        Task Parse_SigleAsync(string FileName, IProgress<int> Progress, CancellationTokenSource _cancel);
        Task Parse_MultipleAsync(string FileName, IProgress<int> Progress, CancellationTokenSource _cancel);
    }
    public class AnketaParser : IParser
    {
        private readonly IGeneralFacade Facade;     // Facade
        private readonly ITMRepositary Keeper;      // Save/Load data to Repository
        private readonly IReader Reader;            // Read data from any source (now it's CSV)
        private readonly ILogger Logger;            // Logging interface
        private AnketaFile _AnketaFile;
        private CancellationTokenSource _Cancel;
        private int MaxRows;
        private int RowNum;

        public AnketaParser(IGeneralFacade _facade)
        {
            Facade = _facade;
            Keeper = Facade.Keeper;
            Reader = Facade.Reader;
            Logger = Facade.Logger;
        }

        public Task<int> RowsInAnketa(string FileName)
        {
            return Task.Run<int>(() =>
            {
                MaxRows = Reader.CountLinesInFile(FileName);
                return MaxRows;
            });
        }

        private void Initialise(string FileName)
        {
            RowNum = 0;
            Reader.Open(FileName, Encoding.GetEncoding(1251));
            Reader.ReadLine(); // skip header
            _AnketaFile = new AnketaFile(); // Stable dependency
            _AnketaFile.FileName = System.IO.Path.GetFileName(FileName);
            _AnketaFile.Rows = new List<Anketa>();
        }

        // Single Thread parser thread part
        private void Parse_SigleThread(string FileName, IProgress<int> Progress)
        {
            Initialise(FileName);
            while (!Reader.EndOfStream())
            {
                if (_Cancel.IsCancellationRequested)
                    _Cancel.Token.ThrowIfCancellationRequested();
                var line = Reader.ReadLine();
                try
                {
                    var converter = Facade.Converter;
                    _AnketaFile.Rows.Add(converter.ConvertIt<Anketa>(line));
                }
                catch (Exception ex)
                {
                    Logger.Log("\n   "+ex.Message + "\r\n   At line:" + line);
                }
                Task.Delay(5).Wait();
                RowNum++;
                Progress.Report(RowNum);
            }
            Reader.Close();
            if (_AnketaFile.Rows.Count == 0)
                throw new Exception("The file does not contain any good records!");
        }
        public async Task Parse_SigleAsync(string FileName, IProgress<int> Progress, CancellationTokenSource _cancel)
        {
            _Cancel = _cancel;
            Logger.Log("Begin parding of file: " + System.IO.Path.GetFileName(FileName));
            await Task.Run(() => Parse_SigleThread(FileName, Progress));
            Logger.Log("Parsing is done. Writing parsed data to database");
            await Keeper.InsertFileAsync(_AnketaFile);
            Logger.Log("Writing done.");
        }

        // Multiple Thread parser thread part
        private Task<Anketa> Get_SingleThread(string line, IProgress<int> Progress)
        {
            return Task.Run<Anketa>(() =>
            {
                Anketa ank = null;
                try
                {
                    var Converter = Facade.Converter;
                    ank = Converter.ConvertIt<Anketa>(line);
                }
                catch (Exception ex)
                {
                    Logger.Log("\n   "+ex.Message + "\r\n   At line:" + line);
                }
                Interlocked.Increment(ref this.RowNum);
                Thread.Sleep(10);
                Progress.Report(RowNum);
                return ank;
            }, _Cancel.Token);
        }
        public async Task Parse_MultipleAsync(string FileName, IProgress<int> Progress, CancellationTokenSource _cancel)
        {
            Initialise(FileName);
            _Cancel = _cancel;
            Logger.Log("Begin parding of file: " + System.IO.Path.GetFileName(FileName));
            // Create Task for each line(row) in file
            List<Task<Anketa>> tasks = new List<Task<Anketa>>();
            while (!Reader.EndOfStream())
            {
                var line = Reader.ReadLine();
                tasks.Add(Get_SingleThread(line, Progress));
            }
            Reader.Close();
            try
            {
                _AnketaFile.Rows = await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                // If one of task has error then summary task will fail and Rows will be empty
                // Inform user about that and write some info to log
                // One from possible scenarios: lack of disk space to write log
                if (tasks.Where(w => w.IsCanceled).Count()>0)
                    throw new Exception("Parsing canceled!");

                foreach (var err in tasks.Where(w => w.IsFaulted))
                {
                    Logger.Log(err.Exception.InnerException.Message);
                }
                throw new Exception("Parsing undone! \nOne of pasring tasks contain error! \nSee main.log for detail.");
            }
            Logger.Log("Parsing is done. Writing parsed data to database");
            await Keeper.InsertFileAsync(_AnketaFile);
            Logger.Log("Writing done.");
        }

        public bool FileAlreadyParsed(string FileName)
        {
            if (Keeper.GetFile(System.IO.Path.GetFileName(FileName))?.ID > 0)
                return true;
            else
                return false;
        }

    }

}