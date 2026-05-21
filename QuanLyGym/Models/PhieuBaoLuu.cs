using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class PhieuBaoLuu
{
    public string MaPbl { get; set; }

    public DateTime? NgayBaoLuu { get; set; }

    public string NoiDung { get; set; }

    public string MaHd { get; set; }

    public string MaNv { get; set; }

    public virtual HopDong MaHdNavigation { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }
}
