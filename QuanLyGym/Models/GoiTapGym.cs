using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class GoiTapGym
{
    public string MaGoi { get; set; }

    public string TenGoi { get; set; }

    public decimal? DonGia { get; set; }

    public int? ThoiHan { get; set; }

    public string MaKm { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual KhuyenMai MaKmNavigation { get; set; }
}
