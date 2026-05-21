using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class DoanhThu
{
    public string MaDt { get; set; }

    public DateTime? ThoiGian { get; set; }

    public string MaHd { get; set; }

    public virtual HopDong MaHdNavigation { get; set; }
}
