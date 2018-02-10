using System;
using System.IO;

namespace ToMars.Model.Settings
{
    // We can use database instead of file
    public interface ISettingKeeper
    {
        void Save(string xml);
        string Load();
    }
    public class SettingsToFile : ISettingKeeper
    {
        private static string FileName = AppDomain.CurrentDomain.BaseDirectory + @"\ToMars.ini";

        public void Save(string xml)
        {
            File.WriteAllText(FileName, xml);
        }

        public string Load()
        {
            if (File.Exists(FileName))
                return File.ReadAllText(FileName);
            else
                return "";
        }
    }
}
