using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class HoSoNhanSu
{
    public string MaHs { get; set; }

    public string TenNv { get; set; }

    public string ChungChi { get; set; }

    public DateOnly? NgayVaoLam { get; set; }

    public string KhenThuong { get; set; }

    public string MaNv { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }
}
