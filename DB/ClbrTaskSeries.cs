using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.DataAccess;
using BLToolkit.EditableObjects;
using BLToolkit.Mapping;
using Indusoft.LDS.Common.Services;

namespace Indusoft.LDS.Services.Contracts.Calibration.Entity
{
    [Serializable]
    [TableName(Name = "ClbrTaskSeries")]
    public class ClbrTaskSeries: EditableDataEntity<ClbrTaskSeries>
    {
        [PrimaryKey(1)]
        public Guid ClbrTaskSeriesUid { get; set; }
        
        public Guid ClbrGraphSeriesUid { get; set; }
    }
}
