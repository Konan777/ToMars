using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToMars.Model.Entities
{
    public class Anketa
    {
        public int ID { get; set; }
        public int FileId { get; set; }
        public string FIO { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [ForeignKey("FileId")]
        public virtual AnketaFile AnketaFile { get; set; }
    }
}
