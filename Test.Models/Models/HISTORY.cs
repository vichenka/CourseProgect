
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;
using Test.Models;

namespace Test.Models
{
   
    [Table("HISTORY")]
    public partial class HISTORY
    {
        public int ID { get; set; }

        //[Required]
        //[StringLength(50)]
     //   public string ID_USER { get; set; }

        public int? ID_RESULTH { get; set; }

        public int? ID_TYPE { get; set; }

        public virtual TYPE TYPE { get; set; }

        public virtual ApplicationUser USER { get; set; }
    }
}
