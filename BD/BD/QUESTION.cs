namespace BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUESTION")]
    public partial class QUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POINT> POINT { get; set; }

        public virtual TEST TEST { get; set; }
    }
}
