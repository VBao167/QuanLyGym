using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class ChiSoInbody
{
    public string MaInbody { get; set; }

    public double? CanNang { get; set; }

    public double? ChieuCao { get; set; }

    public double? TyLeCo { get; set; }

    public double? TyLeMo { get; set; }

    public string MaHv { get; set; }

    public virtual HoiVien MaHvNavigation { get; set; }
}
