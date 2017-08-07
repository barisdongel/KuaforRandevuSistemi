namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLUYE")]
    public partial class TBLUYE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLUYE()
        {
            TBLRANDEVU = new HashSet<TBLRANDEVU>();
        }

        [Key]
        public int UYEID { get; set; }

        [Required]
        [StringLength(50)]
        public string AD { get; set; }

        [Required]
        [StringLength(50)]
        public string SOYAD { get; set; }

        [Required]
        [StringLength(50)]
        public string NUMARA { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string SIFRE { get; set; }

        public int YETKIID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLRANDEVU> TBLRANDEVU { get; set; }

        public virtual TBLYETKI TBLYETKI { get; set; }
    }
}
