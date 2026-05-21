using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class ChamSocHoiVien
{
    public string MaHv { get; set; }

    public string MaNv { get; set; }

    public DateTime NgayCs { get; set; }

    public string NoiDung { get; set; }

    public string KetQua { get; set; }

    public virtual HoiVien MaHvNavigation { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }
}
