namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLRANDEVUSAAT")]
    public partial class TBLRANDEVUSAAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLRANDEVUSAAT()
        {
            TBLRANDEVU = new HashSet<TBLRANDEVU>();
        }

        [Key]
        public int RANDEVUSAATID { get; set; }

        [Required]
        [StringLength(50)]
        public string RANDEVUSAATLERI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLRANDEVU> TBLRANDEVU { get; set; }
    }
}
