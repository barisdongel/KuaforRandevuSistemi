namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLKUAFOR")]
    public partial class TBLKUAFOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKUAFOR()
        {
            TBLRANDEVU = new HashSet<TBLRANDEVU>();
        }

        [Key]
        public int KUAFORID { get; set; }

        [Required]
        [StringLength(50)]
        public string KUAFORAD { get; set; }

        [Required]
        [StringLength(50)]
        public string KUAFORSOYAD { get; set; }

        [Required]
        [StringLength(50)]
        public string KUAFORYAS { get; set; }

        [Required]
        [StringLength(11)]
        public string KUAFORNUMARA { get; set; }

        [Required]
        [StringLength(50)]
        public string KUAFOREMAİL { get; set; }

        public bool KUAFORMEDENİDURUMID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLRANDEVU> TBLRANDEVU { get; set; }
    }
}
