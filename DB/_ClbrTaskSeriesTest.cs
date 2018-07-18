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
    [TableName(Name = "ClbrTaskSeriesTest")]
    public class ClbrTaskSeriesTest: EditableDataEntity<ClbrTaskSeriesTest>
    {
        [PrimaryKey(1)]
        public Guid ClbrTaskSeriesTestUid { get; set; }
        
        public Guid ClbrTaskSeriesUid { get; set; }

        public Guid ClbrGraphSeriesTestUid { get; set; }

		[Required]
		public float Value { get; set; }

		[Nullable]        
        public float? AbsErr { get; set; }
    }
}
