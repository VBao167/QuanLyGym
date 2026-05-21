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
    public class GoiTapGymBLL
    {
        GoiTapGymDAL dal = new GoiTapGymDAL();

        public List<GoiTapGymDTO> GetAll()
        {
            return dal.GetAllGoiTap();
        }

        public string Insert(GoiTapGymDTO gt)
        {
            if (string.IsNullOrWhiteSpace(gt.MaGoi) || string.IsNullOrWhiteSpace(gt.TenGoi))
                return "Mã và Tên gói tập không được để trống!";

            if (gt.DonGia <= 0 || gt.ThoiHan <= 0)
                return "Đơn giá và thời hạn phải lớn hơn 0!";

            if (dal.InsertGoiTap(gt)) return "Success";
            return "Lỗi khi thêm gói tập vào CSDL!";
        }

        public string Update(GoiTapGymDTO gt)
        {
            if (string.IsNullOrWhiteSpace(gt.MaGoi))
                return "Vui lòng chọn gói tập cần sửa!";

            if (dal.UpdateGoiTap(gt)) return "Success";
            return "Lỗi khi cập nhật gói tập!";
        }

        public string Delete(string maGoi)
        {
            if (string.IsNullOrWhiteSpace(maGoi)) return "Chưa chọn gói tập cần xóa!";
            try
            {
                if (dal.DeleteGoiTap(maGoi)) return "Success";
                return "Xóa thất bại!";
            }
            catch (Exception)
            {
                return "Không thể xóa vì Gói tập này đang được sử dụng trong Hợp Đồng!";
            }
        }
    }
}
