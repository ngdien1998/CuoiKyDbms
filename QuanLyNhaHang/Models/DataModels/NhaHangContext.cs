namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NhaHangContext : DbContext
    {
        public NhaHangContext()
            : base("name=NhaHangContext")
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<ChiTietSlideAnh> ChiTietSlideAnhs { get; set; }
        public virtual DbSet<DanhGiaMonAn> DanhGiaMonAns { get; set; }
        public virtual DbSet<DatHangOnline> DatHangOnlines { get; set; }
        public virtual DbSet<HinhMonAn> HinhMonAns { get; set; }
        public virtual DbSet<LoaiBaiViet> LoaiBaiViets { get; set; }
        public virtual DbSet<LoaiMonAn> LoaiMonAns { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SlideAnh> SlideAnhs { get; set; }
        public virtual DbSet<ThucDon> ThucDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>()
                .Property(e => e.IDNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<DanhGiaMonAn>()
                .Property(e => e.EmailNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<DatHangOnline>()
                .Property(e => e.IDNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<DatHangOnline>()
                .Property(e => e.EmailNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiBaiViet>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.LoaiBaiViet)
                .HasForeignKey(e => e.IDLoaiBaiViet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiMonAn>()
                .HasMany(e => e.MonAns)
                .WithOptional(e => e.LoaiMonAn)
                .HasForeignKey(e => e.IDLoaiMonAn);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.MoTaChiTiet)
                .IsUnicode(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.DanhGiaMonAns)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.HinhMonAns)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.EmailNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.DanhGiaMonAns)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.DatHangOnlines)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.IDNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.DatHangOnlines)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);
        }
    }
}
