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

        // 1. Lấy toàn bộ danh sách hội viên
        public DataTable GetAllNhanVien()
        {
            string query = "SELECT MaNV, TenNV, GioiTinh, Sdt FROM NhanVien";
            return db.ExecuteQuery(query);
        }

        // 2. Thêm mới hội viên
        public bool InsertNhanVien(NhanVienDTO NV)
        {
            string query = string.Format(
                "INSERT INTO NhanVien (MaNV, TenNV, Sdt,ChucVu) VALUES ('{0}', N'{1}', {2}', N'{3}')",
                NV.MaNV, NV.TenNV, NV.Sdt, NV.ChucVu);
            return db.ExecuteNonQuery(query) > 0;
        }

        // 3. Cập nhật thông tin hội viên
        public bool UpdateNhanVien(NhanVienDTO NV)
        {
            string query = string.Format(
                "UPDATE NhanVien SET TenNV = N'{1}', ChucVu = N'{2}', Sdt = '{3}' WHERE MaNV = '{0}'",
                NV.MaNV, NV.TenNV, NV.ChucVu, NV.Sdt);
            return db.ExecuteNonQuery(query) > 0;
        }

        // 4. Xóa hội viên
        public bool DeleteNhanVien(string MaNV)
        {
            string query = string.Format("DELETE FROM NhanVien WHERE MaNV = '{0}'", MaNV);
            return db.ExecuteNonQuery(query) > 0;
        }
    }
}
