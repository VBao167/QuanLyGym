using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGym.DTO
{
    public class HopDongDTO
    {
        public string MaHopDong { get; set; }
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        public string MaGoi { get; set; }
        public string TenGoi { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NoiDung { get; set; }
        public string MaKM { get; set; }
        public HopDongDTO() { }
    }

    // 6. DTO Hóa Đơn
    public class HoaDonDTO
    {
        public string MaHoaDon { get; set; }
        public string MaHopDong { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayThu { get; set; }
        public decimal SoTienThu { get; set; }
        public string HinhThuc { get; set; } // Tiền mặt, Chuyển khoản...
        public HoaDonDTO() { }
    }

    // 7. DTO Tài Khoản (Phục vụ đăng nhập, phân quyền)
    public class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; }
        public string QuyenHan { get; set; }
        public string MaNV { get; set; }
        public string MaHV { get; set; }
        public TaiKhoanDTO() { }
    }

    // 8. DTO Chỉ Số Inbody
    public class ChiSoInbodyDTO
    {
        public string MaInbody { get; set; }
        public string MaHV { get; set; }
        public DateTime NgayDo { get; set; }
        public float CanNang { get; set; }
        public float ChieuCao { get; set; }
        public float TyLeMo { get; set; }
        public float TyLeCo { get; set; }
        public float BMI { get; set; }
        public ChiSoInbodyDTO() { }
    }

    // 9. DTO Lịch Tập Luyện (Booking PT)
    public class LichTapLuyenDTO
    {
        public string MaLT { get; set; }
        public string MaHV { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayTap { get; set; }
        public TimeSpan GioTap { get; set; }
        public string TrangThai { get; set; }
        public LichTapLuyenDTO() { }
    }
}
