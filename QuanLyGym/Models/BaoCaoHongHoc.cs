using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class BaoCaoHongHoc
{
    public string MaTb { get; set; }

    public string MaNv { get; set; }

    public DateTime NgayBao { get; set; }

    public string MoTaSuCo { get; set; }

    public string DonViThucHien { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; }

    public virtual ThietBiGym MaTbNavigation { get; set; }
}
