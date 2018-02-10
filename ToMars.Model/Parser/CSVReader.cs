using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToMars.Model.Entities;

namespace ToMars.Model.Parser
{
    // Posible XLSReader, ZIPReader, ETC
    public interface IReader
    {
        int CountLinesInFile(string FileName);
        void Open(string FileName, Encoding _encoding);
        string ReadLine();
        bool EndOfStream();
        void Close();
        Task Export(string FileName, List<Anketa> rows);
    }

    public class CSVReader : IReader
    {
        private StreamReader _StreamReader;

        public void Open(string FileName, Encoding _encoding)
        {
            _StreamReader = new StreamReader(FileName, _encoding);
        }

        public string ReadLine()
        {
            return _StreamReader.ReadLine();
        }

        public bool EndOfStream()
        {
            return _StreamReader.EndOfStream;
        }

        public void Close()
        {
            _StreamReader.Close();
        }

        public int CountLinesInFile(string FileName)
        {
            int lines = 0;
            using (var newReader = new StreamReader(FileName))
            {
                while (!newReader.EndOfStream)
                {
                    newReader.ReadLine();
                    lines++;
                }
            }
            return lines-1; // minus header
        }

        public Task Export(string FileName, List<Anketa> rows)
        {
            return Task.Run(() =>
            {
                string output = "ФИО	Дата рождения	EMail   Телефон\n";
                foreach (var ank in rows)
                {
                    output += ank.FIO + "\t" + 
                        ank.Birthday.ToString(CultureInfo.InvariantCulture) + "\t" + 
                        ank.Email + "\t" + 
                        ank.Phone + "\n";
                }
                Thread.Sleep(3000);
                File.WriteAllText(FileName, output, Encoding.GetEncoding(1251));
            });
        }
    }
}
