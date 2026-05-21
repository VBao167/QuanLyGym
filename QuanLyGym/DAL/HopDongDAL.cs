using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyGym.DTO;
using QuanLyGym.Models;
using Microsoft.EntityFrameworkCore;

namespace QuanLyGym.DAL
{
    public class HopDongDAL
    {
        private GymManagementSystemContext _context;

        public HopDongDAL()
        {
            _context = new GymManagementSystemContext();
        }

        // 1. Lấy danh sách Hợp Đồng (Kèm theo Tên thay vì chỉ hiển thị Mã)
        public List<HopDongDTO> GetAllHopDong()
        {
            try
            {
                var list = _context.HopDongs
                    .Include("MaHvNavigation")
                    .Include("MaGoiNavigation")
                    .Include("MaNvNavigation")
                    .Select(hd => new HopDongDTO
                    {
                        MaHopDong = hd.MaHd,
                        MaHV = hd.MaHv,
                        TenHV = hd.MaHvNavigation.TenHv,
                        MaGoi = hd.MaGoi,
                        TenGoi = hd.MaGoiNavigation.TenGoi,
                        MaNV = hd.MaNv,
                        TenNV = hd.MaNvNavigation.TenNv,
                        NgayLap = hd.NgayLap,
                        NoiDung = hd.NoiDung,
                        MaKM = hd.MaHoaDon
                    })
                    .ToList();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllHopDong: {ex.Message}");
                return new List<HopDongDTO>();
            }
        }

        // 2. Thêm Hợp Đồng mới
        public bool InsertHopDong(HopDongDTO hd)
        {
            try
            {
                var hopDong = new HopDong
                {
                    MaHd = hd.MaHopDong,
                    MaHv = hd.MaHV,
                    MaGoi = hd.MaGoi,
                    MaNv = hd.MaNV,
                    NgayLap = hd.NgayLap,
                    NoiDung = hd.NoiDung,
                    MaHoaDon = string.IsNullOrEmpty(hd.MaKM) ? null : hd.MaKM
                };
                _context.HopDongs.Add(hopDong);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi InsertHopDong: {ex.Message}");
                return false;
            }
        }

        // 3. Cập nhật Hợp Đồng (Thường chỉ cho phép sửa nội dung hoặc mã khuyến mãi)
        public bool UpdateHopDong(HopDongDTO hd)
        {
            try
            {
                var hopDong = _context.HopDongs.FirstOrDefault(h => h.MaHd == hd.MaHopDong);
                if (hopDong == null)
                    return false;

                hopDong.NoiDung = hd.NoiDung;
                hopDong.MaHoaDon = string.IsNullOrEmpty(hd.MaKM) ? null : hd.MaKM;

                _context.HopDongs.Update(hopDong);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateHopDong: {ex.Message}");
                return false;
            }
        }

        // 4. Xóa Hợp Đồng
        public bool DeleteHopDong(string maHD)
        {
            try
            {
                var hopDong = _context.HopDongs.FirstOrDefault(h => h.MaHd == maHD);
                if (hopDong == null)
                    return false;

                _context.HopDongs.Remove(hopDong);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteHopDong: {ex.Message}");
                return false;
            }
        }
    }
}
