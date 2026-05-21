using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class HoaDon
{
    public string MaHoaDon { get; set; }

    public DateTime? NgayThu { get; set; }

    public decimal? SoTienThu { get; set; }

    public string HinhThucThanhToan { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();
}
