using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class HopDong
{
    public string MaHd { get; set; }

    public DateTime? NgayLap { get; set; }

    public string NoiDung { get; set; }

    public string MaHv { get; set; }

    public string MaNv { get; set; }

    public string MaGoi { get; set; }

    public string MaHoaDon { get; set; }

    public virtual ICollection<DoanhThu> DoanhThus { get; set; } = new List<DoanhThu>();

    public virtual GoiTapGym MaGoiNavigation { get; set; }

    public virtual HoaDon MaHoaDonNavigation { get; set; }

    public virtual HoiVien MaHvNavigation { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }

    public virtual ICollection<PhieuBaoLuu> PhieuBaoLuus { get; set; } = new List<PhieuBaoLuu>();

    public virtual ICollection<PhieuChuyenNhuong> PhieuChuyenNhuongs { get; set; } = new List<PhieuChuyenNhuong>();
}
