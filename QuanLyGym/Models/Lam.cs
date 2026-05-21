using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class Lam
{
    public string MaNv { get; set; }

    public string MaCa { get; set; }

    public DateOnly NgayLam { get; set; }

    public double? GioLam { get; set; }

    public virtual CaLamViec MaCaNavigation { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }
}
