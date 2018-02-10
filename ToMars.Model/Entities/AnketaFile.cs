using System.Collections.Generic;

namespace ToMars.Model.Entities
{
    public enum AketaType
    {
        Basic = 1,
        Extended = 1
    }

    public class AnketaFile
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public virtual ICollection<Anketa> Rows { get; set; }
    }
}