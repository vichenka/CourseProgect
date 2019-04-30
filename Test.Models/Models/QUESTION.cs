using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace Test.Models
{ 

    [Table("QUESTION")]
    public partial class QUESTION
    {
         public QUESTION()
        {
            POINT = new HashSet<POINT>();
        }

        [Key]
        public int ID_QUESTION { get; set; }

        public int? ID_TEST { get; set; }

        [Column("QUESTION")]
        [StringLength(50)]
        public string QUESTION1 { get; set; }

         public virtual ICollection<POINT> POINT { get; set; }

        public virtual TEST TEST { get; set; }
    }
}
