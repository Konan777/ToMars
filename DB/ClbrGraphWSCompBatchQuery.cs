using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.Data.Linq;
using Indusoft.LDS.Services.Contracts.Calibration.Entity;

namespace Indusoft.LDS.Server.Services.Calibration.Queries
{
    internal class ClbrGraphWSCompBatchQuery : BaseQuery
    {
        private Table<ClbrGraphWSCompBatch> ClbrGraphWSCompBatchTable => Get<ClbrGraphWSCompBatch>();

        public ClbrGraphWSCompBatchQuery(BLToolkit.Data.DbManager db)
            : base(db)
        {
        }

		public IEnumerable<ClbrGraphWSCompBatch> GetClbrGraphWSCompBatch() => ClbrGraphWSCompBatchTable;

        public IEnumerable<ClbrGraphWSCompBatch> GetClbrGraphWSCompBatchByGraphWS(Guid clbrGraphWSUid)
        {
            return ClbrGraphWSCompBatchTable.Where(x => x.ClbrGraphWSUid == clbrGraphWSUid);
        }

        public IEnumerable<ClbrGraphWSCompBatch> GetClbrGraphWSCompBatchByGraphWS(Guid[] clbrGraphWSUid)
        {
            return ClbrGraphWSCompBatchTable.Where(x => clbrGraphWSUid.Contains(x.ClbrGraphWSUid));
        }
    }
}
