using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class LichTapLuyen
{
    public string MaLt { get; set; }

    public DateOnly? NgayTap { get; set; }

    public TimeOnly? GioTap { get; set; }

    public string TrangThai { get; set; }

    public string MaHv { get; set; }

    public string MaNv { get; set; }

    public virtual HoiVien MaHvNavigation { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }
}
