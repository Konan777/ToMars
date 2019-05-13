using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Multik
{
    public class MTWriter<T>
    {
        private List<List<T>> _colls;
        private CancellationTokenSource _Cancel;
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
            if (_colls.Count() > threads) {
                _colls[_colls.Count - 2].AddRange(_colls[_colls.Count - 1]);
                _colls.Remove(_colls[_colls.Count - 1]);
            }
        }
        public async void Write(string tableName, string cleanUpField, DateTime startDate, DateTime endDate, string profileTable = null)
        {
            _Cancel = new CancellationTokenSource();
            InProgress = true;
            var cleanup = true;
            List<Task> Writers = new List<Task>();
            foreach (var coll in _colls)
            {
                if (_Cancel.IsCancellationRequested) break;
                Writers.Add(Task.Run(() => { WriteRows(coll, cleanup); } ));
                cleanup = false; // Только один поток выполняет очистку данных
            }
            await Task.WhenAll(Writers);
            InProgress = false;
        }
        public void Cancel()
        {
            _Cancel.Cancel(true);
        }
        private void WriteRows(List<T> rows, bool cleanup)
        {
            if (_Cancel.IsCancellationRequested) return;
            CoreHelper.InsertDailyData<T>(rows, false, cleanup, _startDate, _endDate, _tableName, _cleanUpField, _profileTable);
        }
        private IEnumerable<List<T>> splitList<T>(List<T> locations, int nSize)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }
    }


}
