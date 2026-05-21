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
using QuanLyGym.DTO;

namespace QuanLyGym.UserControls
{
    public partial class UCHoiVien : UserControl
    {
        HoiVienBLL bll = new HoiVienBLL();

        public UCHoiVien()
        {
            InitializeComponent();
        }

        private void UCHoiVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm LoadData: Gán danh sách hội viên từ BLL vào DataGridView
        private void LoadData()
        {
            dgvHoiVien.DataSource = bll.GetAll();
        }

        // Sự kiện click vào 1 dòng trong DataGridView sẽ hiển thị thông tin lên TextBox
        private void dgvHoiVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoiVien.Rows[e.RowIndex];
                txtMaHV.Text = row.Cells["MaHV"].Value.ToString();
                txtTenHV.Text = row.Cells["TenHV"].Value.ToString();
                txtGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString() ?? "";
                txtSdt.Text = row.Cells["Sdt"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HoiVienDTO hv = new HoiVienDTO()
            {
                MaHV = txtMaHV.Text,
                TenHV = txtTenHV.Text,
                GioiTinh = txtGioiTinh.Text,
                Sdt = txtSdt.Text
            };

            string ketQua = bll.Insert(hv);
            if (ketQua == "Success")
            {
                MessageBox.Show("Thêm hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnLamMoi_Click(sender, e);
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HoiVienDTO hv = new HoiVienDTO()
            {
                MaHV = txtMaHV.Text,
                TenHV = txtTenHV.Text,
                GioiTinh = txtGioiTinh.Text,
                Sdt = txtSdt.Text
            };

            string ketQua = bll.Update(hv);
            if (ketQua == "Success")
            {
                MessageBox.Show("Cập nhật hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnLamMoi_Click(sender, e);
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có chắc chắn muốn xóa hội viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dt == DialogResult.Yes)
            {
                string ketQua = bll.Delete(txtMaHV.Text);
                if (ketQua == "Success")
                {
                    MessageBox.Show("Xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHV.Clear();
            txtTenHV.Clear();
            txtGioiTinh.Clear();
            txtSdt.Clear();
            LoadData();
        }
    }
}
