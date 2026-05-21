using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyGym.DTO;
using System.Data.SqlClient; 

namespace QuanLyGym.DAL
{
    public class HopDongDAL
    {
        DatabaseConnection db = new DatabaseConnection();

        // 1. Lấy danh sách Hợp Đồng (Kèm theo Tên thay vì chỉ hiển thị Mã)
        public DataTable GetAllHopDong()
        {
            string query = @"
                SELECT 
                    HD.MaHopDong, 
                    HV.TenHV, 
                    GT.TenGoi, 
                    NV.TenNV, 
                    HD.NgayLap, 
                    HD.NoiDung, 
                    HD.MaKM
                FROM HopDong HD
                JOIN HoiVien HV ON HD.MaHV = HV.MaHV
                JOIN GoiTapGym GT ON HD.MaGoi = GT.MaGoi
                JOIN NhanVien NV ON HD.MaNV = NV.MaNV";
            return db.ExecuteQuery(query);
        }

        // 2. Thêm Hợp Đồng mới
        public bool InsertHopDong(HopDongDTO hd)
        {
            // Xử lý trường hợp MaKM hoặc NoiDung có thể rỗng
            string maKM = string.IsNullOrEmpty(hd.MaKM) ? "NULL" : $"'{hd.MaKM}'";
            string noiDung = string.IsNullOrEmpty(hd.NoiDung) ? "NULL" : $"N'{hd.NoiDung}'";

            string query = string.Format(
                "INSERT INTO HopDong (MaHopDong, MaHV, MaGoi, MaNV, NgayLap, NoiDung, MaKM) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4:yyyy-MM-dd HH:mm:ss}', {5}, {6})",
                hd.MaHopDong, hd.MaHV, hd.MaGoi, hd.MaNV, hd.NgayLap, noiDung, maKM);

            return db.ExecuteNonQuery(query) > 0;
        }

        // 3. Cập nhật Hợp Đồng (Thường chỉ cho phép sửa nội dung hoặc mã khuyến mãi)
        public bool UpdateHopDong(HopDongDTO hd)
        {
            string maKM = string.IsNullOrEmpty(hd.MaKM) ? "NULL" : $"'{hd.MaKM}'";
            string noiDung = string.IsNullOrEmpty(hd.NoiDung) ? "NULL" : $"N'{hd.NoiDung}'";

            string query = string.Format(
                "UPDATE HopDong SET NoiDung = {1}, MaKM = {2} WHERE MaHopDong = '{0}'",
                hd.MaHopDong, noiDung, maKM);

            return db.ExecuteNonQuery(query) > 0;
        }

        // 4. Xóa Hợp Đồng
        public bool DeleteHopDong(string maHD)
        {
            string query = string.Format("DELETE FROM HopDong WHERE MaHopDong = '{0}'", maHD);
            return db.ExecuteNonQuery(query) > 0;
        }
    }
}
