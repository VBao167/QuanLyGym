using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class HoiVien
{
    public string MaHv { get; set; }

    public string TenHv { get; set; }

    public string GioiTinh { get; set; }

    public string Sdt { get; set; }

    public virtual ICollection<ChamSocHoiVien> ChamSocHoiViens { get; set; } = new List<ChamSocHoiVien>();

    public virtual ICollection<ChiSoInbody> ChiSoInbodies { get; set; } = new List<ChiSoInbody>();

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual ICollection<LichTapLuyen> LichTapLuyens { get; set; } = new List<LichTapLuyen>();

    public virtual ICollection<PhieuChuyenNhuong> PhieuChuyenNhuongMaHv1Navigations { get; set; } = new List<PhieuChuyenNhuong>();

    public virtual ICollection<PhieuChuyenNhuong> PhieuChuyenNhuongMaHv2Navigations { get; set; } = new List<PhieuChuyenNhuong>();
}
