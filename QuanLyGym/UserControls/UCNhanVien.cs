using System;
using System.Windows.Forms;
using QuanLyGym.BLL;
using QuanLyGym.DTO;

namespace QuanLyGym.UserControls
{
    public partial class UCNhanVien : UserControl
    {
        NhanVienBLL bll = new NhanVienBLL();

        public UCNhanVien()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)

        {



        }

        private void UCNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvNhanVien.DataSource = bll.GetAllNhanVien();
        }

        // Sự kiện click vào 1 dòng trong DataGridView sẽ hiển thị thông tin lên TextBox
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                txtSdt.Text = row.Cells["Sdt"].Value.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO()
            {
                MaNV = txtMaNV.Text,
                TenNV = txtTenNV.Text,
                Sdt = txtSdt.Text,
                ChucVu = txtChucVu.Text
            };

            if (bll.InsertNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại thông tin (Mã NV có thể bị trùng)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO()
            {
                MaNV = txtMaNV.Text,
                TenNV = txtTenNV.Text,
                Sdt = txtSdt.Text,
                ChucVu = txtChucVu.Text
            };

            if (bll.UpdateNhanVien(nv))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dt == DialogResult.Yes)
            {
                if (bll.DeleteNhanVien(txtMaNV.Text))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e); // Xóa trắng các ô nhập
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSdt.Clear();
            txtChucVu.Clear();
            LoadData();
        }
    }
}