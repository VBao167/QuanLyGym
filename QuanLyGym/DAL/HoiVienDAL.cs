using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DTO;
using QuanLyGym.Models;

namespace QuanLyGym.DAL
{
    public class HoiVienDAL
    {
        private GymManagementSystemContext _context;

        public HoiVienDAL()
        {
            _context = new GymManagementSystemContext();
        }

        // 1. Lấy toàn bộ danh sách hội viên
        public List<HoiVienDTO> GetAllHoiVien()
        {
            try
            {
                var list = _context.HoiViens
                    .Select(hv => new HoiVienDTO
                    {
                        MaHV = hv.MaHv,
                        TenHV = hv.TenHv,
                        GioiTinh = hv.GioiTinh,
                        Sdt = hv.Sdt
                    })
                    .ToList();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllHoiVien: {ex.Message}");
                return new List<HoiVienDTO>();
            }
        }

        // 2. Thêm mới hội viên
        public bool InsertHoiVien(HoiVienDTO hv)
        {
            try
            {
                var hoiVien = new HoiVien
                {
                    MaHv = hv.MaHV,
                    TenHv = hv.TenHV,
                    GioiTinh = hv.GioiTinh,
                    Sdt = hv.Sdt
                };
                _context.HoiViens.Add(hoiVien);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi InsertHoiVien: {ex.Message}");
                return false;
            }
        }

        // 3. Cập nhật thông tin hội viên
        public bool UpdateHoiVien(HoiVienDTO hv)
        {
            try
            {
                var hoiVien = _context.HoiViens.FirstOrDefault(h => h.MaHv == hv.MaHV);
                if (hoiVien == null)
                    return false;

                hoiVien.TenHv = hv.TenHV;
                hoiVien.GioiTinh = hv.GioiTinh;
                hoiVien.Sdt = hv.Sdt;

                _context.HoiViens.Update(hoiVien);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateHoiVien: {ex.Message}");
                return false;
            }
        }

        // 4. Xóa hội viên
        public bool DeleteHoiVien(string maHV)
        {
            try
            {
                var hoiVien = _context.HoiViens.FirstOrDefault(h => h.MaHv == maHV);
                if (hoiVien == null)
                    return false;

                _context.HoiViens.Remove(hoiVien);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteHoiVien: {ex.Message}");
                return false;
            }
        }
    }
}
