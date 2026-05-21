using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class TaiKhoan
{
    public string TenDangNhap { get; set; }

    public string MatKhau { get; set; }

    public bool? TrangThai { get; set; }

    public string QuyenHan { get; set; }

    public string MaNv { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }
}
