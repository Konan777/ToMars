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
		#region ClbrGraphWS
        public ClbrGraphWS[] GetClbrGraphWSByGraph(Guid clbrGraphUid)
        {
            var clbrGraphWS = new ClbrGraphWSQuery(DbManager).GetClbrGraphWSByGraph(clbrGraphUid).ToList();
            FillCompBatchs(clbrGraphWS);
            return clbrGraphWS.ToArray();
        }

        public void ClbrGraphWSInsert(ref ClbrGraphWS clbrGraphWS)
        {
            Accessor.ClbrGraphWSInsert(ref clbrGraphWS);
			GraphSeriesSaveChilds(clbrGraphWS);
        }

        public void ClbrGraphWSUpdate(ref ClbrGraphWS clbrGraphWS)
        {
			ClbrGraphWSChilds(clbrGraphWS);
            Accessor.ClbrGraphWSUpdate(ref clbrGraphWS);
        }

        public void ClbrGraphWSDelete(ref ClbrGraphWS clbrGraphWS)
        {
            Accessor.ClbrGraphWSDelete(ref clbrGraphWS);
        }

        public void GraphSeriesSaveChilds(ClbrGraphWS clbrGraphWS)
        {
            if (ClbrGraphWS.ClbrGraphWSCompBatchs != null)
            {
                foreach (ClbrGraphWSCompBatch compBatch in ClbrGraphWS.ClbrGraphWSCompBatchs)
                {
                    ClbrGraphWSCompBatch test = compBatch;
                    if (test.IsInserted)
                    {
                        Accessor.ClbrGraphWSCompBatchInsert(ref test);
                    }
                    else
                        if (test.IsDeleted)
                    {
                        Accessor.ClbrGraphWSCompBatchDelete(test);
                    }
					else
                        if ((test.IsChenged) || (test.IsDirty))
                    {
                        Accessor.ClbrGraphWSCompBatchUpdate(test);
                    }

                }
            }
        }

        private void FillCompBatchs(List<ClbrGraphWS> clbrGraphWS)
        {
            var cbUids = clbrGraphWS.Select(s => s.ClbrGraphUid).ToArray();

            var tstQuery = new ClbrGraphWSCompBatchQuery(DbManager);

    		var tests = tstQuery.GetClbrGraphWSCompBatchByGraphWS(srUids);

			foreach (var graphWS in clbrGraphWS)
			{
				graphWS.ClbrGraphWSCompBatchs = new EditableList<ClbrGraphWSCompBatch>(
					tests.FindAll(a => a.ClbrGraphWSUid == batch.ClbrGraphWSUid)
				);
			}
        }
		#endregion

		#region ClbrGraphWSCompBatch

        public ClbrGraphWSCompBatch[] GetClbrGraphWSCompBatchByGraphWS(Guid clbrGraphWS)
        {
            var compBatchs = new ClbrGraphWSCompBatchQuery(DbManager).GetClbrGraphWSCompBatchByGraphWS(clbrGraphWS).ToList();
            return compBatchs.ToArray();
        }

        public void ClbrGraphWSCompBatchInsert(ref ClbrGraphWSCompBatch clbrGraphWSCompBatch)
        {
            Accessor.ClbrGraphWSCompBatchInsert(ref clbrGraphWSCompBatch);
        }

        public void ClbrGraphWSCompBatchUpdate(ref ClbrGraphWSCompBatch clbrGraphWSCompBatch)
        {
            Accessor.ClbrGraphWSCompBatchUpdate(ref clbrGraphWSCompBatch);
        }

        public void ClbrGraphWSCompBatchDelete(ref ClbrGraphWSCompBatch clbrGraphWSCompBatch)
        {
            Accessor.ClbrGraphWSCompBatchDelete(ref clbrGraphWSCompBatch);
        }

		#endregion


    }
}
