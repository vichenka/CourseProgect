namespace BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POINT")]
    public partial class POINT
    {
        [Key]
        public int ID_ANSWER { get; set; }

        public int? ID_Quest { get; set; }

        [StringLength(50)]
        public string ANSWER { get; set; }

        [Column("POINT")]
        public int? POINT1 { get; set; }

        public virtual QUESTION QUESTION { get; set; }
    }
}
