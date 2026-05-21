using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DAL;
using QuanLyGym.DTO;

namespace QuanLyGym.BLL
{
    public class HoiVienBLL
    {
        HoiVienDAL dal = new HoiVienDAL();

        // Lấy toàn bộ danh sách hội viên
        public List<HoiVienDTO> GetAll()
        {
            return dal.GetAllHoiVien();
        }

        // Thêm mới hội viên
        public string Insert(HoiVienDTO hv)
        {
            if (string.IsNullOrWhiteSpace(hv.MaHV) || string.IsNullOrWhiteSpace(hv.TenHV))
                return "Vui lòng nhập đầy đủ Mã và Tên Hội Viên!";

            if (string.IsNullOrWhiteSpace(hv.Sdt) || hv.Sdt.Length < 10)
                return "Số điện thoại không hợp lệ!";

            if (dal.InsertHoiVien(hv))
                return "Success";
            else
                return "Lỗi khi thêm vào cơ sở dữ liệu!";
        }

        // Cập nhật hội viên
        public string Update(HoiVienDTO hv)
        {
            if (string.IsNullOrWhiteSpace(hv.MaHV) || string.IsNullOrWhiteSpace(hv.TenHV))
                return "Vui lòng chọn hội viên và nhập đầy đủ tên!";

            if (dal.UpdateHoiVien(hv))
                return "Success";
            else
                return "Lỗi khi cập nhật cơ sở dữ liệu!";
        }

        // Xóa hội viên
        public string Delete(string maHV)
        {
            if (string.IsNullOrWhiteSpace(maHV))
                return "Vui lòng chọn hội viên cần xóa!";

            try
            {
                if (dal.DeleteHoiVien(maHV))
                    return "Success";
                return "Xóa thất bại!";
            }
            catch (Exception ex)
            {
                return "Không thể xóa hội viên này vì dữ liệu đang liên kết với Hợp đồng/Hóa đơn!";
            }
        }
    }
}
