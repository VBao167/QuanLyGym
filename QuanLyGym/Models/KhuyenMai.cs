using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class KhuyenMai
{
    public string MaKm { get; set; }

    public decimal? PhanTramGiam { get; set; }

    public virtual ICollection<GoiTapGym> GoiTapGyms { get; set; } = new List<GoiTapGym>();
}
