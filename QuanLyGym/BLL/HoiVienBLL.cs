using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DAL;
using QuanLyGym.DTO;
using System.Data;
namespace QuanLyGym.BLL
{
    public class HoiVienBLL
    {
        HoiVienDAL dal = new HoiVienDAL();

        public DataTable GetAll()
        {
            return dal.GetAllHoiVien();
        }

        public string Insert(HoiVienDTO hv)
        {
            if (string.IsNullOrWhiteSpace(hv.MaHV) || string.IsNullOrWhiteSpace(hv.TenHV))
                return "Vui lòng nhập đầy đủ Mã và Tên Hội Viên!";

            if (hv.Sdt.Length < 10)
                return "Số điện thoại không hợp lệ!";

            if (dal.InsertHoiVien(hv))
                return "Success";
            else
                return "Lỗi khi thêm vào cơ sở dữ liệu!";
        }

        public string Update(HoiVienDTO hv)
        {
            if (string.IsNullOrWhiteSpace(hv.MaHV) || string.IsNullOrWhiteSpace(hv.TenHV))
                return "Vui lòng chọn hội viên và nhập đầy đủ tên!";

            if (dal.UpdateHoiVien(hv))
                return "Success";
            else
                return "Lỗi khi cập nhật cơ sở dữ liệu!";
        }

        public string Delete(string maHV)
        {
            if (string.IsNullOrWhiteSpace(maHV))
                return "Vui lòng chọn hội viên cần xóa!";

            // Lưu ý: Thực tế nếu HV có hợp đồng thì không được xóa (vướng khóa ngoại)
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
