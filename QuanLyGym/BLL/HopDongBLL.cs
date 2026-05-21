using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyGym.DAL;
using QuanLyGym.DTO;

namespace QuanLyGym.BLL
{
    public class HopDongBLL
    {
        HopDongDAL dal = new HopDongDAL();

        public DataTable GetAll()
        {
            return dal.GetAllHopDong();
        }

        public string Insert(HopDongDTO hd)
        {
            // Kiểm tra các trường bắt buộc không được để trống
            if (string.IsNullOrWhiteSpace(hd.MaHopDong) ||
                string.IsNullOrWhiteSpace(hd.MaHV) ||
                string.IsNullOrWhiteSpace(hd.MaGoi) ||
                string.IsNullOrWhiteSpace(hd.MaNV))
            {
                return "Vui lòng nhập Mã Hợp Đồng và chọn đầy đủ Hội Viên, Gói Tập, Nhân Viên!";
            }

            // Gán ngày lập mặc định là thời điểm hiện tại nếu chưa có
            if (hd.NgayLap == DateTime.MinValue)
            {
                hd.NgayLap = DateTime.Now;
            }

            try
            {
                if (dal.InsertHopDong(hd)) return "Success";
                return "Lỗi khi lưu Hợp Đồng vào Cơ sở dữ liệu!";
            }
            catch (Exception ex)
            {
                // Bắt lỗi vi phạm khóa ngoại (Ví dụ: Nhập sai Mã HV không tồn tại)
                return "Lỗi dữ liệu liên kết: Vui lòng kiểm tra lại Mã Hội Viên hoặc Mã Gói Tập có tồn tại không! \nChi tiết: " + ex.Message;
            }
        }

        public string Update(HopDongDTO hd)
        {
            if (string.IsNullOrWhiteSpace(hd.MaHopDong))
                return "Vui lòng chọn Hợp Đồng cần sửa!";

            if (dal.UpdateHopDong(hd)) return "Success";
            return "Cập nhật Hợp Đồng thất bại!";
        }

        public string Delete(string maHD)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                return "Chưa chọn Hợp Đồng cần xóa!";

            try
            {
                if (dal.DeleteHopDong(maHD)) return "Success";
                return "Xóa thất bại!";
            }
            catch (Exception)
            {
                // Ràng buộc thực tế: Hợp đồng đã có Hóa Đơn hoặc Phiếu Bảo Lưu thì không được xóa
                return "Không thể xóa Hợp Đồng này vì đã phát sinh Hóa Đơn hoặc dữ liệu liên quan!";
            }
        }
    }
}
