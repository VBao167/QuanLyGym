using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGym.DTO
{
    public class HoiVienDTO
    {
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        public string GioiTinh { get; set; }
        public string Sdt { get; set; }

        public HoiVienDTO() { }

        public HoiVienDTO(string maHV, string tenHV, string gioiTinh, string sdt)
        {
            MaHV = maHV;
            TenHV = tenHV;
            GioiTinh = gioiTinh;
            Sdt = sdt;
        }
    }
}
