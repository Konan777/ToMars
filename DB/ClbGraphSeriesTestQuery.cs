using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.Data.Linq;
using Indusoft.LDS.Services.Contracts.Calibration.Entity;

namespace Indusoft.LDS.Server.Services.Calibration.Queries
{
    internal class ClbGraphSeriesTestQuery : BaseQuery
    {
        private Table<ClbGraphSeriesTest> ClbrGraphSeriesTable => Get<ClbGraphSeriesTest>();

        public ClbGraphSeriesTestQuery(BLToolkit.Data.DbManager db)
            : base(db)
        {
        }

		public IEnumerable<ClbGraphSeriesTest> GetClbGraphSeriesTest() => ClbrGraphSeriesTable;

        public IEnumerable<ClbGraphSeriesTest> GetClbGraphSeriesTestBySeries(Guid clbrGraphSeriesUid)
        {
            return ClbGraphSeriesTestTable.Where(x => x.ClbrGraphSeriesUid == clbrGraphSeriesUid);
        }
    }
}
