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
    public partial class UCHopDong : UserControl
    {
        HopDongBLL hdBLL = new HopDongBLL();
        HoiVienBLL hvBLL = new HoiVienBLL();
        GoiTapGymBLL gtBLL = new GoiTapGymBLL();

        public UCHopDong()
        {
            InitializeComponent();
        }

        private void UCHopDong_Load(object sender, EventArgs e)
        {
            LoadDanhSachHopDong();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            // Đổ dữ liệu Hội Viên
            cbHoiVien.DataSource = hvBLL.GetAll();
            cbHoiVien.DisplayMember = "TenHV";
            cbHoiVien.ValueMember = "MaHV";

            // Đổ dữ liệu Gói Tập
            cbGoiTap.DataSource = gtBLL.GetAll();
            cbGoiTap.DisplayMember = "TenGoi";
            cbGoiTap.ValueMember = "MaGoi";
        }

        private void LoadDanhSachHopDong()
        {
            // Đổ dữ liệu Hợp Đồng
            dgvHopDong.DataSource = hdBLL.GetAll();
        }
        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvHopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Gom thông tin từ giao diện vào DTO
            HopDongDTO hd = new HopDongDTO();
            hd.MaHopDong = txtMaHD.Text;
            hd.NoiDung = txtNoiDung.Text;
            hd.MaKM = txtMaKM.Text;

            // Gọi tầng BLL để xử lý cập nhật
            string ketQua = hdBLL.Update(hd);
            if (ketQua == "Success")
            {
                MessageBox.Show("Cập nhật hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHopDong(); // Tải lại lưới dữ liệu
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            txtNoiDung.Clear();
            txtMaKM.Clear();
            cbHoiVien.SelectedIndex = -1;
            cbGoiTap.SelectedIndex = -1;
            // cbNhanVien.SelectedIndex = -1;

            txtMaHD.ReadOnly = false; // Mở khóa cho phép nhập mã mới khi thêm mới
            txtMaHD.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa từ danh sách!", "Thông báo");
                return;
            }

            // Hiện bảng hỏi xác nhận trước khi xóa dữ liệu quan trọng
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string ketQua = hdBLL.Delete(txtMaHD.Text);
                if (ketQua == "Success")
                {
                    MessageBox.Show("Xóa hợp đồng thành công!", "Thông báo");
                    LoadDanhSachHopDong();
                    btnLamMoi_Click(sender, e); // Xóa trắng form sau khi xóa dữ liệu thành công
                }
                else
                {
                    MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HopDongDTO hd = new HopDongDTO();
            hd.MaHopDong = txtMaHD.Text;
            hd.MaHV = cbHoiVien.SelectedValue?.ToString();
            hd.MaGoi = cbGoiTap.SelectedValue?.ToString();

            // Mở ra khi có ComboBox Nhân Viên
            hd.MaNV = "NV01"; // Tạm thời gán cứng để test nếu chưa làm xong ComboBox NV

            hd.NoiDung = txtNoiDung.Text;
            hd.MaKM = txtMaKM.Text;
            hd.NgayLap = DateTime.Now;

            string ketQua = hdBLL.Insert(hd);
            if (ketQua == "Success")
            {
                MessageBox.Show("Lập hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachHopDong();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbGoiTap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbHoiVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMaKM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra người dùng click đúng dòng có dữ liệu, không click vào tiêu đề cột
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];

                // Đẩy dữ liệu vào TextBox
                txtMaHD.Text = row.Cells["MaHopDong"].Value?.ToString();
                txtNoiDung.Text = row.Cells["NoiDung"].Value?.ToString();
                txtMaKM.Text = row.Cells["MaKM"].Value?.ToString();

                // Đẩy dữ liệu vào ComboBox dựa theo Tên hiển thị (Text)
                cbHoiVien.Text = row.Cells["TenHV"].Value?.ToString();
                cbGoiTap.Text = row.Cells["TenGoi"].Value?.ToString();

                // Tháo comment dòng dưới nếu bạn đã đổ dữ liệu cho Nhân Viên
                // cbNhanVien.Text = row.Cells["TenNV"].Value?.ToString();

                // Khóa không cho sửa Mã Hợp Đồng (vì mã là khóa chính, không được thay đổi)
                txtMaHD.ReadOnly = true;
            }
        }
    }
}
