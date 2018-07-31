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
    [TableName(Name = "ClbrGraphWS")]
    public class ClbrGraphWS: EditableDataEntity<ClbrGraphWS>
    {
        [PrimaryKey(1)]
        public Guid ClbrGraphWSUid { get; set; }
        
        public Guid ClbrGraphUid { get; set; }

		[Nullable]
        public Guid? StdDocUid { get; set; }

		[Nullable]
        public Guid? CompositionUid { get; set; }

		[Required, MaxLength(150)]
		public srting Name { get; set; }
        
		[Required]
        public int Flags { get; set; }

		public EditableList<ClbrGraphWSCompBatch> ClbrGraphWSCompBatchs { get; set; }
    }
}
