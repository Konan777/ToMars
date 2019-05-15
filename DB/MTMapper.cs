    public class MTMapper
    {
        private DateTime _fromDate;
        private DateTime _toDate;
        private int _stepDays;
        private int _threads;
        private LogClient _logger;
        private string _storedProcName;

        public bool InProgress;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate">� ����</param>
        /// <param name="toDate">�� ����</param>
        /// <param name="stepDays">��� � ����</param>
        /// <param name="threads">�������</param>
        /// <param name="logger">������</param>
        public MTMapper(DateTime fromDate, DateTime toDate, int stepDays, int threads, LogClient logger = null)
        {
            _fromDate = fromDate.Date;
            _toDate = toDate.Date;
            _stepDays = stepDays-1;
            _threads = threads;
            _logger = logger;
        }
        public async Task MapAtomsAsync(string storedProcName)
        {
            InProgress = true;
            _storedProcName = storedProcName;
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            _logger?.Log(LogLevel.Message, $"�������� {storedProcName} c {_fromDate.ToShortDateString()} �� {_toDate.ToShortDateString()} ������� {_threads} ��� {_stepDays+1}");
            DateTime startDate = _fromDate;
            DateTime endDate = _fromDate;
            
            // ������� ��� ������ � ������
            List<Action> mappers = new List<Action>();
            int num=1;
            while (endDate < _toDate)
            {
                CancellationContext.ThrowIfCancellationRequested();
                endDate = startDate.AddDays(_stepDays) >= _toDate ? _toDate : startDate.AddDays(_stepDays);
                var tuple = Tuple.Create(startDate, endDate, num);
                // startDate, endDate, num ������������ ������, �.�. ��� ����� ����������� ��� ���� Action
                mappers.Add( () => { Map(tuple.Item1, tuple.Item2, tuple.Item3); } );
                if (endDate >= _toDate) break;
                startDate = startDate.AddDays(_stepDays + 1);
                num++;
            }
            
            // ��������� ����� � n ������� (loops)
            int loops = mappers.Count < _threads ? mappers.Count : _threads;
            List<Task> mappingTasks = new List<Task>();
            
            // ������ n ������ �������
            for (int i = 0; i < loops; i++)
                mappingTasks.Add(Task.Run(mappers[i]));
            int lastIndex = loops;

            // ���� ���� ��� ������ �� ����� ����������
            while (mappingTasks.Count>0)
            {
                var completed = await Task.WhenAny(mappingTasks);
                mappingTasks.Remove(completed);
                if (lastIndex < mappers.Count)
                {
                    mappingTasks.Add(Task.Run(mappers[lastIndex]));
                    lastIndex++;
                }
            }

            InProgress = false;
            sw.Stop();
            _logger?.Log(LogLevel.Message, $"�������� � ������ ��� {storedProcName} ���������. ����� {sw.Elapsed.ToString(@"m\:ss\.ff")}");
        }

        public void MapAtoms(string storedProcName)
        {
            MapAtomsAsync(storedProcName).Wait();
        }

        private async Task Map(DateTime fromDate, DateTime toDate, int thread)
        {
            try
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                var startDateParameter = new ObjectParameter("startDate", fromDate);
                var endDateParameter = new ObjectParameter("endDate", toDate);
                using (var ctx = new EleanorCoreEntities())
                {
                    ((IObjectContextAdapter)ctx).ObjectContext.CommandTimeout = Int32.MaxValue;
                    ((IObjectContextAdapter)ctx).ObjectContext.ExecuteFunction(_storedProcName, startDateParameter, endDateParameter);
                }

                sw.Stop();
                _logger?.Log(LogLevel.Message,
                    $"����� {thread} � {fromDate.ToShortDateString()} �� {toDate.ToShortDateString()} ����� {sw.Elapsed.ToString(@"m\:ss\.ff")}"
                 );
            }
            catch (Exception ex)
            {
                _logger?.Log(LogLevel.Message,
                    $"����� {thread} ������:{ex.Message}"
                 );
            }
        }
    }
