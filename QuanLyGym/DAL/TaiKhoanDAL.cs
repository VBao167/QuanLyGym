using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.Models;

namespace QuanLyGym.DAL
{
    public class TaiKhoanDAL
    {
        private GymManagementSystemContext _context;

        public TaiKhoanDAL()
        {
            _context = new GymManagementSystemContext();
        }

        // Hàm kiểm tra đăng nhập và trả về Quyền Hạn (Admin, Sale, PT...)
        public string CheckLogin(string username, string password)
        {
            try
            {
                var taiKhoan = _context.TaiKhoans
                    .FirstOrDefault(tk => tk.TenDangNhap == username && 
                                          tk.MatKhau == password && 
                                          tk.TrangThai == true);

                if (taiKhoan != null)
                {
                    return taiKhoan.QuyenHan;
                }
                return ""; // Nếu sai tài khoản/mật khẩu hoặc trạng thái không hoạt động, trả về chuỗi rỗng
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CheckLogin: {ex.Message}");
                return "";
            }
        }
    }
}
