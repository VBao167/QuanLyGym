using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyGym.Models;

public partial class GymManagementSystemContext : DbContext
{
    public GymManagementSystemContext()
    {
    }

    public GymManagementSystemContext(DbContextOptions<GymManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoCaoHongHoc> BaoCaoHongHocs { get; set; }

    public virtual DbSet<CaLamViec> CaLamViecs { get; set; }

    public virtual DbSet<ChamSocHoiVien> ChamSocHoiViens { get; set; }

    public virtual DbSet<ChiSoInbody> ChiSoInbodies { get; set; }

    public virtual DbSet<DoanhThu> DoanhThus { get; set; }

    public virtual DbSet<GoiTapGym> GoiTapGyms { get; set; }

    public virtual DbSet<HoSoNhanSu> HoSoNhanSus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoiVien> HoiViens { get; set; }

    public virtual DbSet<HopDong> HopDongs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<Lam> Lams { get; set; }

    public virtual DbSet<LichBaoTri> LichBaoTris { get; set; }

    public virtual DbSet<LichTapLuyen> LichTapLuyens { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuBaoLuu> PhieuBaoLuus { get; set; }

    public virtual DbSet<PhieuChuyenNhuong> PhieuChuyenNhuongs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThietBiGym> ThietBiGyms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GymManagementSystem;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaoCaoHongHoc>(entity =>
        {
            entity.HasKey(e => new { e.MaTb, e.MaNv, e.NgayBao }).HasName("PK__BaoCaoHo__3207CA78F19845FB");

            entity.ToTable("BaoCaoHongHoc");

            entity.Property(e => e.MaTb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaTB");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayBao).HasColumnType("datetime");
            entity.Property(e => e.DonViThucHien).HasMaxLength(100);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.BaoCaoHongHocs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaoCaoHong__MaNV__09A971A2");

            entity.HasOne(d => d.MaTbNavigation).WithMany(p => p.BaoCaoHongHocs)
                .HasForeignKey(d => d.MaTb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaoCaoHong__MaTB__08B54D69");
        });

        modelBuilder.Entity<CaLamViec>(entity =>
        {
            entity.HasKey(e => e.MaCa).HasName("PK__CaLamVie__27258E7B34E41097");

            entity.ToTable("CaLamViec");

            entity.Property(e => e.MaCa)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.TenCa).HasMaxLength(50);
        });

        modelBuilder.Entity<ChamSocHoiVien>(entity =>
        {
            entity.HasKey(e => new { e.MaHv, e.MaNv, e.NgayCs }).HasName("PK__ChamSocH__0BEA5A9E10EEBC44");

            entity.ToTable("ChamSocHoiVien");

            entity.Property(e => e.MaHv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayCs)
                .HasColumnType("datetime")
                .HasColumnName("NgayCS");
            entity.Property(e => e.KetQua).HasMaxLength(255);

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.ChamSocHoiViens)
                .HasForeignKey(d => d.MaHv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChamSocHoi__MaHV__04E4BC85");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.ChamSocHoiViens)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChamSocHoi__MaNV__05D8E0BE");
        });

        modelBuilder.Entity<ChiSoInbody>(entity =>
        {
            entity.HasKey(e => e.MaInbody).HasName("PK__ChiSoInb__E816E4A55A83E3A3");

            entity.ToTable("ChiSoInbody");

            entity.Property(e => e.MaInbody)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaHv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV");

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.ChiSoInbodies)
                .HasForeignKey(d => d.MaHv)
                .HasConstraintName("FK__ChiSoInbod__MaHV__5EBF139D");
        });

        modelBuilder.Entity<DoanhThu>(entity =>
        {
            entity.HasKey(e => e.MaDt).HasName("PK__DoanhThu__27258655ECC34EBA");

            entity.ToTable("DoanhThu");

            entity.Property(e => e.MaDt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaDT");
            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.ThoiGian).HasColumnType("datetime");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.DoanhThus)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK__DoanhThu__MaHD__72C60C4A");
        });

        modelBuilder.Entity<GoiTapGym>(entity =>
        {
            entity.HasKey(e => e.MaGoi).HasName("PK__GoiTapGy__3CD30F691750B5C0");

            entity.ToTable("GoiTapGym");

            entity.Property(e => e.MaGoi)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaKm)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKM");
            entity.Property(e => e.TenGoi).HasMaxLength(100);

            entity.HasOne(d => d.MaKmNavigation).WithMany(p => p.GoiTapGyms)
                .HasForeignKey(d => d.MaKm)
                .HasConstraintName("FK__GoiTapGym__MaKM__5BE2A6F2");
        });

        modelBuilder.Entity<HoSoNhanSu>(entity =>
        {
            entity.HasKey(e => e.MaHs).HasName("PK__HoSoNhan__2725A6EF10240D09");

            entity.ToTable("HoSoNhanSu");

            entity.Property(e => e.MaHs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHS");
            entity.Property(e => e.ChungChi).HasMaxLength(255);
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.TenNv)
                .HasMaxLength(100)
                .HasColumnName("TenNV");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoSoNhanSus)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__HoSoNhanSu__MaNV__619B8048");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13BFAFFE7D9");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HinhThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.NgayThu)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoTienThu).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<HoiVien>(entity =>
        {
            entity.HasKey(e => e.MaHv).HasName("PK__HoiVien__2725A6D23E731A36");

            entity.ToTable("HoiVien");

            entity.Property(e => e.MaHv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV");
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenHv)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("TenHV");
        });

        modelBuilder.Entity<HopDong>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HopDong__2725A6E0D0DCD8F6");

            entity.ToTable("HopDong");

            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaGoi)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaHv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaGoiNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.MaGoi)
                .HasConstraintName("FK__HopDong__MaGoi__6EF57B66");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK__HopDong__MaHoaDo__6FE99F9F");

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.MaHv)
                .HasConstraintName("FK__HopDong__MaHV__6D0D32F4");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__HopDong__MaNV__6E01572D");
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKm).HasName("PK__KhuyenMa__2725CF1555C33A60");

            entity.ToTable("KhuyenMai");

            entity.Property(e => e.MaKm)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKM");
            entity.Property(e => e.PhanTramGiam).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Lam>(entity =>
        {
            entity.HasKey(e => new { e.MaNv, e.MaCa, e.NgayLam }).HasName("PK__Lam__303260358B7C6ABF");

            entity.ToTable("Lam");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MaCa)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaCaNavigation).WithMany(p => p.Lams)
                .HasForeignKey(d => d.MaCa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lam__MaCa__693CA210");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Lams)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lam__MaNV__68487DD7");
        });

        modelBuilder.Entity<LichBaoTri>(entity =>
        {
            entity.HasKey(e => e.MaBt).HasName("PK__LichBaoT__27247597840DB96D");

            entity.ToTable("LichBaoTri");

            entity.Property(e => e.MaBt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaBT");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MaTb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaTB");
            entity.Property(e => e.NgayBt).HasColumnName("NgayBT");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.LichBaoTris)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__LichBaoTri__MaNV__0D7A0286");

            entity.HasOne(d => d.MaTbNavigation).WithMany(p => p.LichBaoTris)
                .HasForeignKey(d => d.MaTb)
                .HasConstraintName("FK__LichBaoTri__MaTB__0C85DE4D");
        });

        modelBuilder.Entity<LichTapLuyen>(entity =>
        {
            entity.HasKey(e => e.MaLt).HasName("PK__LichTapL__2725C773548DBE4C");

            entity.ToTable("LichTapLuyen");

            entity.Property(e => e.MaLt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaLT");
            entity.Property(e => e.MaHv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.LichTapLuyens)
                .HasForeignKey(d => d.MaHv)
                .HasConstraintName("FK__LichTapLuy__MaHV__01142BA1");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.LichTapLuyens)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__LichTapLuy__MaNV__02084FDA");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70AAB689E66");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNv)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("TenNV");
        });

        modelBuilder.Entity<PhieuBaoLuu>(entity =>
        {
            entity.HasKey(e => e.MaPbl).HasName("PK__PhieuBao__3AE0790197BCEC63");

            entity.ToTable("PhieuBaoLuu");

            entity.Property(e => e.MaPbl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaPBL");
            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayBaoLuu)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasMaxLength(255);

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.PhieuBaoLuus)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK__PhieuBaoLu__MaHD__7D439ABD");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuBaoLuus)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PhieuBaoLu__MaNV__7E37BEF6");
        });

        modelBuilder.Entity<PhieuChuyenNhuong>(entity =>
        {
            entity.HasKey(e => e.MaPcn).HasName("PK__PhieuChu__3AE071223990B602");

            entity.ToTable("PhieuChuyenNhuong");

            entity.Property(e => e.MaPcn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaPCN");
            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaHv1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV1");
            entity.Property(e => e.MaHv2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV2");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayThucHien)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhiDichVu).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.PhieuChuyenNhuongs)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK__PhieuChuye__MaHD__797309D9");

            entity.HasOne(d => d.MaHv1Navigation).WithMany(p => p.PhieuChuyenNhuongMaHv1Navigations)
                .HasForeignKey(d => d.MaHv1)
                .HasConstraintName("FK__PhieuChuy__MaHV1__76969D2E");

            entity.HasOne(d => d.MaHv2Navigation).WithMany(p => p.PhieuChuyenNhuongMaHv2Navigations)
                .HasForeignKey(d => d.MaHv2)
                .HasConstraintName("FK__PhieuChuy__MaHV2__778AC167");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuChuyenNhuongs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PhieuChuye__MaNV__787EE5A0");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TenDangNhap).HasName("PK__TaiKhoan__55F68FC1CE4171A4");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MatKhau)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuyenHan).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__TaiKhoan__MaNV__656C112C");
        });

        modelBuilder.Entity<ThietBiGym>(entity =>
        {
            entity.HasKey(e => e.MaTb).HasName("PK__ThietBiG__2725006F93031EC5");

            entity.ToTable("ThietBiGym");

            entity.Property(e => e.MaTb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaTB");
            entity.Property(e => e.LoaiThietBi).HasMaxLength(50);
            entity.Property(e => e.MaLoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenTb)
                .HasMaxLength(100)
                .HasColumnName("TenTB");
            entity.Property(e => e.TinhTrang).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
