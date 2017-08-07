namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelKuafor : DbContext
    {
        public ModelKuafor()
            : base("name=ModelKuaforDB")
        {
        }

        public virtual DbSet<TBLKUAFOR> TBLKUAFOR { get; set; }
        public virtual DbSet<TBLRANDEVU> TBLRANDEVU { get; set; }
        public virtual DbSet<TBLRANDEVUSAAT> TBLRANDEVUSAAT { get; set; }
        public virtual DbSet<TBLUYE> TBLUYE { get; set; }
        public virtual DbSet<TBLYETKI> TBLYETKI { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBLUYE>()
                .HasMany(e => e.TBLRANDEVU)
                .WithRequired(e => e.TBLUYE)
                .HasForeignKey(e => e.ALANUYEID);
        }
    }
}
