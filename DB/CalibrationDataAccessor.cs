using System;
using System.Data;
using System.Data.SqlClient;
using Indusoft.LDS.Common.Services;
using Indusoft.LDS.Services.Contracts.Calibration;
using Indusoft.LDS.Services.Contracts.Calibration.Model;
using Indusoft.LDS.Services.Contracts.Calibration.Entity;
using System.Collections.Generic;

namespace Indusoft.LDS.Server.Services.Calibration
{
    public abstract class CalibrationDataAccessor : DataAccessorEx<DataEntityBase, CalibrationDataAccessor>
    {
		// ClbrGraphError

        #region ClbrGraphWS

        public void ClbrGraphWSInsert(ref ClbrGraphWS clbrGraphWS)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(clbrGraphWS, null, new[] { "RV" }, null, null);
            DbManager.SetSpCommand("[dbo].[ClbrGraphWS_Insert]", parameters).ExecuteNonQuery(clbrGraphWS);
		}


        public void ClbrGraphWSUpdate(ref ClbrGraphWS clbrGraphWS)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(clbrGraphWS, null, new[] { "RV" }, null, null);
            DbManager.SetSpCommand("[dbo].[ClbrGraphWS_Update]", parameters).ExecuteNonQuery(clbrGraphWS);
        }


        public void ClbrGraphWSDelete(ref ClbrGraphSeries graphSeries)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(clbrGraphWS, null, new[] { "RV" }, null, null);
            DbManager.SetSpCommand("[dbo].[ClbrGraphWS_Delete]", parameters).ExecuteNonQuery();
        }

        #endregion

        #region ClbrGraphWSCompBatch

        public void ClbrGraphWSCompBatchInsert(ref ClbrGraphWSCompBatch clbrGraphWSCompBatch)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(clbrGraphWSCompBatch, null, new[] { "RV" }, null, null);
            DbManager.SetSpCommand("[dbo].[ClbrGraphWSCompBatch_Insert]", parameters).ExecuteNonQuery(clbrGraphWSCompBatch);
		}


        public void ClbrGraphWSCompBatchUpdate(ref ClbrGraphWSCompBatch clbrGraphWSCompBatch)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(clbrGraphWSCompBatch, null, new[] { "RV" }, null, null);
            DbManager.SetSpCommand("[dbo].[ClbrGraphWSCompBatch_Update]", parameters).ExecuteNonQuery(clbrGraphWSCompBatch);
        }


        public void ClbrGraphWSCompBatchDelete(ref ClbrGraphWSCompBatch clbrGraphWSCompBatch)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(clbrGraphWSCompBatch, null, new[] { "RV" }, null, null);
            DbManager.SetSpCommand("[dbo].[ClbrGraphWSCompBatch_Delete]", parameters).ExecuteNonQuery();
        }

        #endregion
    }
}
