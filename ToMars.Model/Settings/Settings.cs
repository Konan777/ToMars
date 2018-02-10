using System;
using System.Collections.Generic;
using System.Linq;
using ToMars.Model.Context;

namespace ToMars.Model.Settings
{
    public interface ISettings
    {
        Database SelectedDatabase { get; set; }
        List<Database> Databases { get; set; }
        void Restore();
        void Save();
        TMContext GetNewContext();
    }

    public class BaseSettings
    {
        public List<Database> Databases { get; set; }

        // Used in MainViewModel to display same control
        public Database SelectedDatabase { get; set; }
    }

    public class Setting : BaseSettings, ISettings
    {
        private readonly ILogger _Logger;

        // Split settings to three part by functionnality
        private readonly ISettingKeeper Keeper;

        private readonly ISettingsSerializer Serializer;

        public Setting()
        {
        } // Parameterless constructor is needed for Deserialisation

        public Setting(ISettingsSerializer _serializer, ISettingKeeper _keeper, ILogger _logger)
        {
            Keeper = _keeper;
            Serializer = _serializer;
            _Logger = _logger;
        }

        public void Save()
        {
            try
            {
                var xml = Serializer.Serialize(this);
                Keeper.Save(xml);
            }
            catch (Exception ex)
            {
                _Logger.Log(ex.Message, ex);
            }
        }

        public void Restore()
        {
            Databases = new List<Database>();
            var data = Keeper.Load();
            if (data.Length > 0){
                try {
                    var st = Serializer.Deserialize(data);
                    Databases = st.Databases;
                    // st.SelectedDatabase is not the one of st.Databases
                    SelectedDatabase = Databases.FirstOrDefault(w => w.Name == st.SelectedDatabase.Name);
                } catch (Exception ex) {
                    _Logger.Log(ex.Message, ex);
                }
            }
        }

        public TMContext GetNewContext()
        {
            return SelectedDatabase.GetNewContext();
        }
    }
}