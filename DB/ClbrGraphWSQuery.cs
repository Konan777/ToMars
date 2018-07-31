using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.Data.Linq;
using Indusoft.LDS.Services.Contracts.Calibration.Entity;

namespace Indusoft.LDS.Server.Services.Calibration.Queries
{
    internal class ClbrGraphWSQuery : BaseQuery
    {
        private Table<ClbrGraphWS> ClbrGraphWSTable => Get<ClbrGraphWS>();

        public ClbrGraphWSQuery(BLToolkit.Data.DbManager db)
            : base(db)
        {
        }

		public IEnumerable<ClbrGraphWS> GetClbrGraphWS() => ClbrGraphWSTable;

        public IEnumerable<ClbrGraphWS> GetClbrGraphWSByGraph(Guid clbrGraphUid)
        {
            return ClbrGraphWSTable.Where(x => x.ClbrGraphUid == clbrGraphUid);
        }

        public IEnumerable<ClbrGraphWS> GetClbrGraphWSByGraph(Guid[] clbrGraphUids)
        {
            return ClbrGraphWSTable.Where(x => clbrGraphUids.Contains(x.ClbrGraphUid));
        }
    }
}
