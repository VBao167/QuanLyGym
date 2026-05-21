using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DAL;
using QuanLyGym.DTO;

namespace QuanLyGym.BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVienDTO> GetAllNhanVien()
        {
            return dal.GetAllNhanVien();
        }

        public bool InsertNhanVien(NhanVienDTO NV)
        {
            // Kiểm tra dữ liệu cơ bản không được để trống
            if (string.IsNullOrEmpty(NV.MaNV) || string.IsNullOrEmpty(NV.TenNV))
            {
                return false;
            }
            return dal.InsertNhanVien(NV);
        }

        public bool UpdateNhanVien(NhanVienDTO NV)
        {
            if (string.IsNullOrEmpty(NV.MaNV))
            {
                return false;
            }
            return dal.UpdateNhanVien(NV);
        }

        public bool DeleteNhanVien(string MaNV)
        {
            if (string.IsNullOrEmpty(MaNV))
            {
                return false;
            }
            return dal.DeleteNhanVien(MaNV);
        }
    }
}