using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.Data.Linq;
using Indusoft.LDS.Services.Contracts.Calibration.Entity;

namespace Indusoft.LDS.Server.Services.Calibration.Queries
{
    internal class ClbrGraphSeriesQuery : BaseQuery
    {
        private Table<ClbrGraphSeries> ClbrGraphSeriesTable => Get<ClbrGraphSeries>();

        public ClbrGraphSeriesQuery(BLToolkit.Data.DbManager db)
            : base(db)
        {
        }

		public IEnumerable<ClbrGraphSeries> GetClbrGraphSeries() => ClbrGraphSeriesTable;

        public IEnumerable<ClbrGraphSeries> GetClbrGraphSeriesByGraph(Guid clbrGraphUid)
        {
            return ClbrGraphSeriesTable.Where(x => x.ClbrGraphUid == clbrGraphUid);
        }

        public IEnumerable<ClbrGraphSeries> GetClbrGraphSeriesByGraph(Guid[] clbrGraphUids)
        {
            return ClbrGraphSeriesTable.Where(x => clbrGraphUids.Contains(x.ClbrGraphUid));
        }
    }
}
