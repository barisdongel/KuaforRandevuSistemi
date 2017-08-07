namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TBLRANDEVU")]
    public partial class TBLRANDEVU
    {
        [Key]
        public int RANDEVUID { get; set; }

        public int ALANUYEID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RANDEVUTARIH { get; set; }

        public int RANDEVUSAATID { get; set; }

        public int KUAFORID { get; set; }

        public virtual TBLKUAFOR TBLKUAFOR { get; set; }

        public virtual TBLRANDEVUSAAT TBLRANDEVUSAAT { get; set; }

        public virtual TBLUYE TBLUYE { get; set; }
    }
}
