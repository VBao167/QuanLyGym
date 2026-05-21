using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGym.DTO
{
    public class NhanVienDTO
    {
        
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string Sdt { get; set; }
        public string ChucVu { get; set; }
        public NhanVienDTO() { }
    }

    // 2. DTO Gói Tập Gym
    public class GoiTapGymDTO
    {
        public string MaGoi { get; set; }
        public string TenGoi { get; set; }
        public decimal DonGia { get; set; }
        public int ThoiHan { get; set; }
        public string MaKM { get; set; } // Khóa ngoại
        public GoiTapGymDTO() { }
    }

    // 3. DTO Khuyến Mãi
    public class KhuyenMaiDTO
    {
        public string MaKM { get; set; }
        public float PhanTramGiam { get; set; }
        public KhuyenMaiDTO() { }
    }

    // 4. DTO Thiết Bị Gym
    public class ThietBiGymDTO
    {
        public string MaTB { get; set; }
        public string TenTB { get; set; }
        public string LoaiTB { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgayMua { get; set; }
        public ThietBiGymDTO() { }
    }
}
