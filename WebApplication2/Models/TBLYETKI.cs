namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLYETKI")]
    public partial class TBLYETKI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLYETKI()
        {
            TBLUYE = new HashSet<TBLUYE>();
        }

        [Key]
        public int YETKIID { get; set; }

        [Required]
        [StringLength(50)]
        public string YETKIAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLUYE> TBLUYE { get; set; }
    }
}
