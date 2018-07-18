using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using BLToolkit.EditableObjects;
using Indusoft.LDS.Common.Services;
using Indusoft.LDS.Server.Services.Calibration.Queries;
using Indusoft.LDS.Services.Contracts.Calibration;
using TechTest = Indusoft.LDS.Services.Contracts.Calibration.TechTest;
using Indusoft.LDS.Services.Contracts.Calibration.Entity;
using Indusoft.LDS.Services.Contracts.Calibration.Model;
using Indusoft.LDS.Services.Contracts.Repository;
using Indusoft.LDS.Services.Contracts.Tasks;

namespace Indusoft.LDS.Server.Services.Calibration
{
    public class CalibrationDataService : DataService<DataEntityBase, CalibrationDataAccessor>, ICalibrationDataService
    {
		#region ClbrGraphSeries
        public ClbrGraphSeries[] GetClbrGraphSeriesByGraph(Guid clbrGraphUid)
        {
            var graphSeries = new ClbrGraphSeriesQuery(DbManager).GetClbrGraphSeriesByGraph(clbrGraphUid).ToList();
            FillGraphSeries(graphSeries);
            return graphSeries.ToArray();
        }

        public void ClbrGraphSeriesInsert(ref ClbrGraphSeries graphSeries)
        {
            Accessor.ClbrGraphSeriesInsert(ref graphSeries);
			GraphSeriesSaveChilds(clbrGraph);
        }

        public void ClbrGraphSeriesUpdate(ref ClbrGraphSeries graphSeries)
        {
			GraphSeriesSaveChilds(clbrGraph);
            Accessor.ClbrGraphSeriesUpdate(ref graphSeries);
        }

        public void ClbrGraphSeriesDelete(ref ClbrGraphSeries graphSeries)
        {
            Accessor.ClbrGraphSeriesDelete(ref graphSeries);
        }

        public void GraphSeriesSaveChilds(ClbrGraphSeries graphSeries)
        {
            if (graphSeries.GraphSeriesTests != null)
            {
                foreach (ClbGraphSeriesTest seriesTest in graphSeries.GraphSeriesTests)
                {
                    ClbGraphSeriesTest test = seriesTest;
                    if (test.IsInserted)
                    {
                        Accessor.ClbGraphSeriesTestInsert(ref test);
                    }
                    else
                        if (test.IsDeleted)
                    {
                        Accessor.ClbGraphSeriesTestDelete(test);
                    }

                }
            }
        }

        private void FillGraphSeries(List<ClbrGraphSeries> graphSeries)
        {
            var srUids = graphSeries.Select(s => s.ClbrGraphSeriesUid).ToArray();

            var tstQuery = new ClbGraphSeriesTestQuery(DbManager);

    		var tests = tstQuery.GetClbrGraphSeriesByGraph(srUids);

			foreach (var seria in graphSeries)
			{
				seria.GraphSeriesTests = new EditableList<ClbGraphSeriesTest>(
					tests.FindAll(a => a.ClbrGraphSeriesUid == seria.ClbrGraphSeriesUid)
				);
			}
        }
		#endregion

		#region ClbrGraphSeriesTest
        public ClbrGraphSeriesTest[] GetClbrGraphSeriesTestBySeries(Guid clbrGraphSeriesUid)
        {
            var seriesTests = new ClbrGraphSeriesTestQuery(DbManager).GetClbrGraphSeriesBySeries(clbrGraphSeriesUid).ToList();
            return seriesTests.ToArray();
        }

        public void ClbrGraphSeriesTestInsert(ref ClbrGraphSeriesTest seriesTest)
        {
            Accessor.ClbrGraphSeriesTestInsert(ref seriesTest);
        }

        public void ClbrGraphSeriesUpdate(ref ClbrGraphSeriesTest seriesTest)
        {
            Accessor.ClbrGraphSeriesUpdate(ref seriesTest);
        }

        public void ClbrGraphSeriesDelete(ref ClbrGraphSeriesTest seriesTest)
        {
            Accessor.ClbrGraphSeriesDelete(ref seriesTest);
        }

		#endregion


    }
}
