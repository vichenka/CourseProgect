namespace BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TEST")]
    public partial class TEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEST()
        {
            QUESTION = new HashSet<QUESTION>();
            RESULT = new HashSet<RESULT>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string NAME_TEST { get; set; }

        [StringLength(50)]
        public string AUTHOR { get; set; }

        public int? ID_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESULT> RESULT { get; set; }

        public virtual USER USER { get; set; }

        public virtual TYPE TYPE { get; set; }
    }
}
