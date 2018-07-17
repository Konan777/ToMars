using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indusoft.LDS.Common.Services;
using Indusoft.LDS.Services.Contracts.Calibration.Entity;
using Indusoft.LDS.Services.Contracts.Calibration.Model;

namespace Indusoft.LDS.Services.Contracts.Calibration
{
    public interface ICalibrationDataService : IDataService
    {
        ClbrGraphSeries[] GetClbrGraphSeriesByGraph(Guid clbrGraphUid);
        void ClbrGraphSeriesInsert(ref ClbrTask clbrTask);
        void ClbrGraphSeriesUpdate(ref ClbrTask clbrTask);
        void ClbrGraphSeriesDelete(ClbrTask clbrTask);

        ClbGraphSeriesTest[] GetClbGraphSeriesTestByGraphSeries(Guid clbrGraphSeriesUid);
		ClbGraphSeriesTest[] GetClbGraphSeriesTestByTechTest(Guid techTestUid);
        void ClbrGraphSeriesInsert(ref ClbrTask clbrTask);
        void ClbrGraphSeriesUpdate(ref ClbrTask clbrTask);
        void ClbrGraphSeriesDelete(ClbrTask clbrTask);

        ClbrTaskSeries[] GetClbrTaskSeries ByGraphSeries(Guid clbrGraphSeriesUid);
        void ClbrTaskSeriesInsert(ref ClbrTask clbrTask);
        void ClbrTaskSeriesUpdate(ref ClbrTask clbrTask);
        void ClbrTaskSeriesDelete(ClbrTask clbrTask);

        ClbrTaskSeriesTest[] GetClbrTaskSeriesTestByGraphSeries(Guid clbrGraphSeriesUid);
		ClbrTaskSeriesTest[] GetClbrTaskSeriesTestByTaskSeries(Guid clbrTaskSeriesUid);
        void ClbrTaskSeriesTestInsert(ref ClbrTask clbrTask);
        void ClbrTaskSeriesTestUpdate(ref ClbrTask clbrTask);
        void ClbrTaskSeriesTestDelete(ClbrTask clbrTask);


    }
}
