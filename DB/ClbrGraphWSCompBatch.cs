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
    [TableName(Name = "ClbrGraphWSCompBatch")]
    public class ClbrGraphWSCompBatch: EditableDataEntity<ClbrGraphWSCompBatch>
    {
        [PrimaryKey(1)]
        public Guid ClbrGraphWSCompBatchUid { get; set; }
        
        public Guid ClbrGraphWSUid { get; set; }

        public Guid AEBatchUid { get; set; }

		[Nullable]
        public int DimsId { get; set; }

    }
}
