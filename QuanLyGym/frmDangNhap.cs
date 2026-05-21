using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyGym.BLL;

namespace QuanLyGym
{
    public partial class frmDangNhap : Form
    {
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string ketQua = tkBLL.Login(txtTaiKhoan.Text, txtMatKhau.Text);

            if (ketQua == "Admin" || ketQua == "Sale" || ketQua == "PT")
            {
                // Đăng nhập thành công, mở FormMain và truyền Quyền hạn sang
                MessageBox.Show("Đăng nhập thành công với quyền: " + ketQua, "Thông báo");

                Formmain frm = new Formmain(ketQua); // Lát nữa ta sẽ sửa FormMain để nhận biến này
                this.Hide(); // Ẩn form đăng nhập
                frm.ShowDialog(); // Hiển thị form chính
                this.Close(); // Đóng form đăng nhập khi form chính bị tắt
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoa_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
