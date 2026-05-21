using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class LichBaoTri
{
    public string MaBt { get; set; }

    public DateOnly? NgayBt { get; set; }

    public string MaTb { get; set; }

    public string MaNv { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }

    public virtual ThietBiGym MaTbNavigation { get; set; }
}
