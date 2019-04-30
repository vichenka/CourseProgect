using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;
using Test.Models;

namespace Test.Models
{
    [Table("TEST")]
    public partial class TEST
    {
        public TEST()
        {
            QUESTION = new HashSet<QUESTION>();
            RESULT = new HashSet<RESULT>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string NAME_TEST { get; set; }       

        public int? ID_TYPE { get; set; }

        public virtual string ID_USER { get; set; }

         public virtual ICollection<QUESTION> QUESTION { get; set; }

         public virtual ICollection<RESULT> RESULT { get; set; }

        public virtual ApplicationUser USER { get; set; }

        public virtual TYPE TYPE { get; set; }
    }
}
