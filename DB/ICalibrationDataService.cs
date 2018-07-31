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

        ClbrGraphWS[] GetClbrGraphWSByGraph(Guid clbrGraphWS);
        void ClbrClbrGraphWSInsert(ref ClbrGraphWS clbrGraphWS);
        void ClbrClbrGraphWSUpdate(ref ClbrGraphWS clbrGraphWS);
        void ClbrClbrGraphWSDelete(ClbrGraphWS clbrGraphWS);

        ClbrGraphWSCompBatch[] GetClbrGraphWSCompBatchByGraphWS(Guid clbrGraphWS);
		ClbrGraphWSCompBatch[] GetClbrGraphWSCompBatchByGraphWS(Guid[] clbrGraphWS);
        void ClbrTaskSeriesTestInsert(ref ClbrGraphWS clbrGraphWS);
        void ClbrTaskSeriesTestUpdate(ref ClbrGraphWS clbrGraphWS);
        void ClbrTaskSeriesTestDelete(ClbrGraphWS clbrGraphWS);

    }
}
