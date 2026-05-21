using System;
using System.Collections.Generic;

namespace QuanLyGym.Models;

public partial class ThietBiGym
{
    public string MaTb { get; set; }

    public string TenTb { get; set; }

    public string LoaiThietBi { get; set; }

    public DateOnly? NgayMua { get; set; }

    public string TinhTrang { get; set; }

    public string MaLoai { get; set; }

    public virtual ICollection<BaoCaoHongHoc> BaoCaoHongHocs { get; set; } = new List<BaoCaoHongHoc>();

    public virtual ICollection<LichBaoTri> LichBaoTris { get; set; } = new List<LichBaoTri>();
}
