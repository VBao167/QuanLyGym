using QuanLyGym.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyGym.BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanDAL dal = new TaiKhoanDAL();

        public string Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return "Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!";

            string quyen = dal.CheckLogin(username, password);

            if (string.IsNullOrEmpty(quyen))
                return "Sai tài khoản, mật khẩu hoặc tài khoản đã bị khóa!";

            return quyen; // Trả về quyền hạn để Form biết đường xử lý
        }
    }
}