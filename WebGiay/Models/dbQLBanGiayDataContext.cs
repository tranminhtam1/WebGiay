using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebGiay.Models
{
    public partial class dbQLBanGiayDataContext : DbContext
    {
        public dbQLBanGiayDataContext()
            : base("name=dbQLBanGiayDataContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CHITIETDONTHANG> CHITIETDONTHANGs { get; set; }
        public virtual DbSet<CONGTY> CONGTies { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<GIAY> GIAYs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIGIAY> LOAIGIAYs { get; set; }
        public virtual DbSet<NHATHIETKE> NHATHIETKEs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THIETKEGIAY> THIETKEGIAYs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.PassAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONTHANG>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CONGTY>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDONTHANGs)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAY>()
                .Property(e => e.Giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GIAY>()
                .Property(e => e.Anhbia)
                .IsUnicode(false);

            modelBuilder.Entity<GIAY>()
                .HasMany(e => e.CHITIETDONTHANGs)
                .WithRequired(e => e.GIAY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAY>()
                .HasMany(e => e.THIETKEGIAYs)
                .WithRequired(e => e.GIAY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienthoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<NHATHIETKE>()
                .Property(e => e.Dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<NHATHIETKE>()
                .HasMany(e => e.THIETKEGIAYs)
                .WithRequired(e => e.NHATHIETKE)
                .HasForeignKey(e => e.MaTKG)
                .WillCascadeOnDelete(false);
        }
    }
}
