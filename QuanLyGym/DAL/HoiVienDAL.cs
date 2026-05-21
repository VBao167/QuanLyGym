using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DTO;
using System.Data;
namespace QuanLyGym.DAL
{
    public class HoiVienDAL
    {
        DatabaseConnection db = new DatabaseConnection();

        // 1. Lấy toàn bộ danh sách hội viên
        public DataTable GetAllHoiVien()
        {
            string query = "SELECT MaHV, TenHV, GioiTinh, Sdt FROM HoiVien";
            return db.ExecuteQuery(query);
        }

        // 2. Thêm mới hội viên
        public bool InsertHoiVien(HoiVienDTO hv)
        {
            string query = string.Format(
                "INSERT INTO HoiVien (MaHV, TenHV, GioiTinh, Sdt) VALUES ('{0}', N'{1}', N'{2}', '{3}')",
                hv.MaHV, hv.TenHV, hv.GioiTinh, hv.Sdt);
            return db.ExecuteNonQuery(query) > 0;
        }

        // 3. Cập nhật thông tin hội viên
        public bool UpdateHoiVien(HoiVienDTO hv)
        {
            string query = string.Format(
                "UPDATE HoiVien SET TenHV = N'{1}', GioiTinh = N'{2}', Sdt = '{3}' WHERE MaHV = '{0}'",
                hv.MaHV, hv.TenHV, hv.GioiTinh, hv.Sdt);
            return db.ExecuteNonQuery(query) > 0;
        }

        // 4. Xóa hội viên
        public bool DeleteHoiVien(string maHV)
        {
            string query = string.Format("DELETE FROM HoiVien WHERE MaHV = '{0}'", maHV);
            return db.ExecuteNonQuery(query) > 0;
        }
    }
}
