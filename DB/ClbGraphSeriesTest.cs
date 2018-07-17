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
    [TableName(Name = "ClbGraphSeriesTest")]
    public class ClbGraphSeriesTest: EditableDataEntity<ClbGraphSeriesTest>
    {
        [PrimaryKey(1)]
        public Guid ClbrGraphSeriesTestUid { get; set; }
        
        public Guid ClbrGraphSeriesUid { get; set; }

        public Guid TechTestUid { get; set; }

	public float Value { get; set; }
        
        public float AbsErr { get; set; }
    }
}