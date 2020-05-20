using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PatientServices.Models
{
    public partial class DBConnect : DbContext
    {
        public DBConnect()
        {
        }

        public DBConnect(DbContextOptions<DBConnect> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> TblCountry { get; set; }
        public virtual DbSet<Patient> TblPatient { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=AVIJIT-PC02;Initial Catalog=PatientDB;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasOne(d => d.PatientCountryNavigation)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(x => x.PatientCountry)
                    .HasConstraintName("FK_tblPatient_tblCountry");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
