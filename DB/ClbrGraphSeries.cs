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

        public Guid ClbrGraphWSUid { get; set; }

		public srting Name { get; set; }
        
        public int SeriesType { get; set; }
    }
}
