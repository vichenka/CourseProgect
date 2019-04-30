using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace Test.Models
{
    [Table("RESULT")]
    public partial class RESULT
    {
        [Key]
        public int ID_Result { get; set; }

        public int? ID_Test { get; set; }

        public int? RESULT1 { get; set; }

        public int? RESULT2 { get; set; }

        [StringLength(50)]
        public string TEXT_RESULT { get; set; }

        public virtual TEST TEST { get; set; }
    }
}
