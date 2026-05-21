using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyGym.DAL
{
    public class TaiKhoanDAL
    {
        DatabaseConnection db = new DatabaseConnection();

        // Hàm kiểm tra đăng nhập và trả về Quyền Hạn (Admin, Sale, PT...)
        public string CheckLogin(string username, string password)
        {
            string quyenHan = "";
            string query = string.Format("SELECT QuyenHan FROM TaiKhoan WHERE TenDangNhap = '{0}' AND MatKhau = '{1}' AND TrangThai = N'1'", username, password);

            DataTable dt = db.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                quyenHan = dt.Rows[0]["QuyenHan"].ToString();
            }
            return quyenHan; // Nếu sai tài khoản/mật khẩu, chuỗi này sẽ rỗng
        }
    }
}
