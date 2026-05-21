using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DTO;
using System.Data;

namespace QuanLyGym.DAL
{
    public class NhanVienDAL
    {
        DatabaseConnection db = new DatabaseConnection();

        // 1. Lấy toàn bộ danh sách nhân viên
        public DataTable GetAllNhanVien()
        {
            // Đã xóa cột GioiTinh vì NhanVien không có
            string query = "SELECT MaNV, TenNV, Sdt, ChucVu FROM NhanVien";
            return db.ExecuteQuery(query);
        }

        // 2. Thêm mới nhân viên
        public bool InsertNhanVien(NhanVienDTO NV)
        {
            // Đã fix lỗi thiếu dấu nháy đơn ở phần '{2}'
            string query = string.Format(
                "INSERT INTO NhanVien (MaNV, TenNV, Sdt, ChucVu) VALUES ('{0}', N'{1}', '{2}', N'{3}')",
                NV.MaNV, NV.TenNV, NV.Sdt, NV.ChucVu);
            return db.ExecuteNonQuery(query) > 0;
        }

        // 3. Cập nhật thông tin nhân viên
        public bool UpdateNhanVien(NhanVienDTO NV)
        {
            // Đã sắp xếp lại đúng thứ tự tham số {0}, {1}, {2}, {3}
            string query = string.Format(
                "UPDATE NhanVien SET TenNV = N'{1}', Sdt = '{2}', ChucVu = N'{3}' WHERE MaNV = '{0}'",
                NV.MaNV, NV.TenNV, NV.Sdt, NV.ChucVu);
            return db.ExecuteNonQuery(query) > 0;
        }

        // 4. Xóa nhân viên
        public bool DeleteNhanVien(string MaNV)
        {
            string query = string.Format("DELETE FROM NhanVien WHERE MaNV = '{0}'", MaNV);
            return db.ExecuteNonQuery(query) > 0;
        }
    }
}