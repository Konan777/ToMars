сдалеть из CoreHelper'a singleton
многопоточная вставка в элли
пофразовый анализатор для яндекса
дробить на периоды в днях


    public class MTWriter<T> where T : class
    {
        private List<List<T>> _colls;
        private string _tableName;
        private string _cleanUpField;
        private string _profileTable;
        private DateTime _startDate;
        private DateTime _endDate;

        public bool InProgress;
        public MTWriter(List<T> data, int threads = 1)
        {
            if (!data.Any()) return;
            int chunkSize = data.Count / threads;
            _colls = splitList<T>(data, chunkSize).ToList();
            // Фикс для случая когда data.Count не поделилась ровно на число потоков (10/3 дают 4 _colls)
            if (_colls.Count() > threads)
            {
                _colls[_colls.Count - 2].AddRange(_colls[_colls.Count - 1]);
                _colls.Remove(_colls[_colls.Count - 1]);
            }
        }
        public async void Write(string tableName, string cleanUpField, DateTime startDate, DateTime endDate, string profileTable = null)
        {
            _tableName = tableName;
            _cleanUpField = cleanUpField;
            _profileTable = profileTable;
            _startDate = startDate;
            _endDate = endDate;

            InProgress = true;
            var cleanup = true;
            List<Task> Writers = new List<Task>();
            var q = CoreHelper.DbConnectionString;
            foreach (var coll in _colls)
            {
                CancellationContext.ThrowIfCancellationRequested();
                Writers.Add(Task.Run(() => { WriteRows(coll, cleanup); }));
                cleanup = false; // Только один поток выполняет очистку данных
            }
            await Task.WhenAll(Writers);
            InProgress = false;
        }
        private void WriteRows(List<T> rows, bool cleanup)
        {
            try
            {
                CoreHelper.InserdData<T>(rows, false, cleanup, _startDate, _endDate, _tableName, _cleanUpField);
                //CoreHelper.InsertDailyData<T>(rows, false, cleanup, _startDate, _endDate, _tableName, _cleanUpField, _profileTable);
            }
            catch (Exception ex)
            {
                throw new EleanorException($"Ошибка при записи данных ", ex);
            }
        }
        private IEnumerable<List<T>> splitList<T>(List<T> locations, int nSize)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }
    }

C:\Work\Seolution\Programs\Eleanor\ITA.Eleanor.Core\Infrastructure\EntityToXml.cs
	using (var connection = new SqlConnection(CoreHelper.DbConnectionString))
C:\Work\Seolution\Programs\Eleanor\ITA.Eleanor.Core\Db\EleanorCoreModel.Context.cs
        public EleanorCoreEntities(string dbConnectionString)
            : base(ObjectContextHelper.CreateConnectionString("EleanorCoreEntities", dbConnectionString))
        { }
C:\Work\Seolution\Programs\Eleanor\ITA.Eleanor.Core\Infrastructure\CoreHelper.cs
        public static string dbConnectionString;
        public static string DbConnectionString { get { return dbConnectionString; } }

        static CoreHelper()
        {
            ((IObjectContextAdapter) _entities).ObjectContext.CommandTimeout = Int32.MaxValue;
            dbConnectionString = ObjectContextHelper.DbConnectionString;
        }

        public static void InserdData<T>(List<T> data, bool mapOnly, bool cleanup, DateTime? startDate, DateTime? endDate, string tableAndSchema, string cleanupFilterColumn)
            where T : class
        {
            var serializer = new EntityToXml<T>(tableAndSchema);
            var xmlString = serializer.GetXmlString(data, mapOnly);
            using (var ctx = new EleanorCoreEntities(dbConnectionString))
            {
                ctx.UniversalBulkInsert(xmlString, cleanup, startDate, endDate, mapOnly, tableAndSchema, cleanupFilterColumn);
            }
        }
