using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace Test.Models
{  

    [Table("TYPE")]
    public partial class TYPE
    {
        public TYPE()
        {
            HISTORY = new HashSet<HISTORY>();
            TEST = new HashSet<TEST>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string NAME_TYPE { get; set; }

         public virtual ICollection<HISTORY> HISTORY { get; set; }

         public virtual ICollection<TEST> TEST { get; set; }
    }
}
