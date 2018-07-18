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
    [TableName(Name = "ClbrGraphSeries")]
    public class ClbrGraphSeries: EditableDataEntity<ClbrGraphSeries>
    {
        [PrimaryKey(1)]
        public Guid ClbrGraphSeriesUid { get; set; }
        
        public Guid ClbrGraphUid { get; set; }

		[Nullable]
        public Guid? ClbrGraphWSUid { get; set; }

		[Required, MaxLength(150)]
		public srting Name { get; set; }
        
		[Required]
        public int SeriesType { get; set; }

		public EditableList<ClbGraphSeriesTest> GraphSeriesTests { get; set; }
    }
}
