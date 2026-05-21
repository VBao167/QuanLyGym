using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class NhanVien
{
    public string MaNv { get; set; }

    public string TenNv { get; set; }

    public string Sdt { get; set; }

    public string ChucVu { get; set; }

    public virtual ICollection<BaoCaoHongHoc> BaoCaoHongHocs { get; set; } = new List<BaoCaoHongHoc>();

    public virtual ICollection<ChamSocHoiVien> ChamSocHoiViens { get; set; } = new List<ChamSocHoiVien>();

    public virtual ICollection<HoSoNhanSu> HoSoNhanSus { get; set; } = new List<HoSoNhanSu>();

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual ICollection<Lam> Lams { get; set; } = new List<Lam>();

    public virtual ICollection<LichBaoTri> LichBaoTris { get; set; } = new List<LichBaoTri>();

    public virtual ICollection<LichTapLuyen> LichTapLuyens { get; set; } = new List<LichTapLuyen>();

    public virtual ICollection<PhieuBaoLuu> PhieuBaoLuus { get; set; } = new List<PhieuBaoLuu>();

    public virtual ICollection<PhieuChuyenNhuong> PhieuChuyenNhuongs { get; set; } = new List<PhieuChuyenNhuong>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
