using System;
using System.Collections.Generic;

namespace FrontGraph.Db
{
    public enum ModeImport
    {
        ModeImportAndMap // Импортировать и привязать к атомам
        , ModeImport     // Только импортировать (без привязки)
        , ModeMap        // Перепривязать существующие данные
    }
    // реализуем интерфейс в каждом импортере. минимум переделок
    public interface IImporter
    {
        void DoImport(DateTime? fromDate, DateTime? toDate, bool cleanUp);
        void DoMapAtoms();
    }

    // Класс пускающий N обработчиков в соответствии с настройкой
    public class Plugin
    {
        // Period & CleanUp
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private bool _isCleanUp;
        private ModeImport _importMode;
    
        public Plugin(DateTime? fromDate, DateTime? toDate, bool isCleanUp, ModeImport importMode)
        {
            _fromDate = fromDate;
            _toDate = toDate;
            _isCleanUp = isCleanUp;
            _importMode = importMode;
        }

        private List<IImporter> _importers;
        public void Init(List<IImporter> importers)
        {
            _importers = importers;
        }
        public void Import()
        {
            foreach (var importer in _importers)
            {
                if (_importMode == ModeImport.ModeImportAndMap || _importMode == ModeImport.ModeImport)
                    importer.DoImport(_fromDate, _toDate, _isCleanUp);
                else
                    importer.DoMapAtoms();
            }
        }
    }

    // Конкретная реализация
    public class ScbApiImporter : IImporter
    {
        private bool _mapAtoms;  // Перепривязать существующие данные
        private string _filePath;

        public ScbApiImporter(bool mapAtoms)
        {
            _mapAtoms = mapAtoms;
        }

        public void DoImport(DateTime? fromDate, DateTime? toDate, bool cleanUp)
        {
            var rows = Read(fromDate, toDate);
            Write(rows, cleanUp, _mapAtoms);
        }
        public void DoMapAtoms()
        {
        }
        private List<ScbItem> Read(DateTime? fromDate, DateTime? toDate)
        {
            var result = new List<ScbItem>();
            return result;
        }
        private void Write(List<ScbItem> data, bool cleanUp, bool mapOnly)
        {
        }
    }
    public partial class ScbItem
    {
        public int Id { get; set; }
    }

    public class MainPlugin
    {
        public MainPlugin()
        {
            var importer = new ScbApiImporter(true);
            var plugin = new Plugin(DateTime.Now, DateTime.Now, true, ModeImport.ModeImportAndMap);
            plugin.Init(new List<IImporter>() { importer });
            plugin.Import();
        }
    }

}
