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

        public Guid AEUid { get; set; }

        public Guid StdDocUid { get; set; }

        public Guid CompositionUid { get; set; }

		public srting Name { get; set; }
        
        public int Flags { get; set; }
    }
}
