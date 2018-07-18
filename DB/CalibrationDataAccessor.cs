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

        #region ClbrGraphSeries

        public void ClbrGraphSeriesInsert(ref ClbrGraphSeries graphSeries)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(graphSeries);
            DbManager.SetSpCommand("[dbo].[ClbrGraphSeries_Insert]", parameters)
                     .ExecuteNonQuery(graphSeries);
        }


        public void ClbrGraphSeriesUpdate(ref ClbrGraphSeries graphSeries)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(graphSeries);
            DbManager.SetSpCommand("[dbo].[ClbrGraphSeries_Update]", parameters)
                     .ExecuteNonQuery();
        }


        public void ClbrGraphSeriesDelete(ref ClbrGraphSeries graphSeries)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(graphSeries);
            DbManager.SetSpCommand("[dbo].[ClbrGraphSeries_Delete]", parameters).ExecuteNonQuery();
        }

        #endregion

        #region ClbGraphSeriesTest

        public void ClbGraphSeriesTestInsert(ref ClbGraphSeriesTest graphSeriesTest)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(graphSeriesTest);
            DbManager.SetSpCommand("[dbo].[ClbGraphSeriesTest_Insert]", parameters)
                     .ExecuteNonQuery(graphSeriesTest);
        }


        public void ClbGraphSeriesTestUpdate(ref ClbGraphSeriesTest graphSeriesTest)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(graphSeriesTest);
            DbManager.SetSpCommand("[dbo].[ClbGraphSeriesTest_Update]", parameters)
                     .ExecuteNonQuery(graphSeriesTest);
        }


        public void ClbGraphSeriesTestDelete(ref ClbGraphSeriesTest graphSeriesTest)
        {
            IDbDataParameter[] parameters = DbManager.CreateParameters(graphSeriesTest);
            DbManager.SetSpCommand("[dbo].[ClbGraphSeriesTest_Delete]", parameters).ExecuteNonQuery();
        }

        #endregion
    }
}
