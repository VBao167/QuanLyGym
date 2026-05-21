using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGym.DTO
{
    public class PhieuBaoLuuDTO
    {
        public string MaPBL { get; set; }
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayBaoLuu { get; set; }
        public string NoiDung { get; set; }
        public PhieuBaoLuuDTO() { }
    }

    // 11. DTO Phiếu Chuyển Nhượng
    public class PhieuChuyenNhuongDTO
    {
        public string MaPCN { get; set; }
        public string MaHD { get; set; }
        public string MaHV_Cu { get; set; }
        public string MaHV_Moi { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayThucHien { get; set; }
        public decimal PhiDichVu { get; set; }
        public PhieuChuyenNhuongDTO() { }
    }

    // 12. DTO Lên Lịch Bảo Trì Thiết Bị
    public class LenLichBaoTriDTO
    {
        public string MaBT { get; set; }
        public string MaTB { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayBT { get; set; }
        public decimal ChiPhi { get; set; }
        public LenLichBaoTriDTO() { }
    }
}
