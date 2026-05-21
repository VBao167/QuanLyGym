using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DTO;
using QuanLyGym.Models;

namespace QuanLyGym.DAL
{
    public class GoiTapGymDAL
    {
        private GymManagementSystemContext _context;

        public GoiTapGymDAL()
        {
            _context = new GymManagementSystemContext();
        }

        public List<GoiTapGymDTO> GetAllGoiTap()
        {
            try
            {
                var list = _context.GoiTapGyms
                    .Select(gt => new GoiTapGymDTO
                    {
                        MaGoi = gt.MaGoi,
                        TenGoi = gt.TenGoi,
                        DonGia = gt.DonGia.HasValue ? gt.DonGia.Value : 0,
                        ThoiHan = gt.ThoiHan.HasValue ? gt.ThoiHan.Value : 0,
                        MaKM = gt.MaKm
                    })
                    .ToList();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllGoiTap: {ex.Message}");
                return new List<GoiTapGymDTO>();
            }
        }

        public bool InsertGoiTap(GoiTapGymDTO gt)
        {
            try
            {
                var goiTap = new GoiTapGym
                {
                    MaGoi = gt.MaGoi,
                    TenGoi = gt.TenGoi,
                    DonGia = gt.DonGia,
                    ThoiHan = gt.ThoiHan,
                    MaKm = string.IsNullOrEmpty(gt.MaKM) ? null : gt.MaKM
                };
                _context.GoiTapGyms.Add(goiTap);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi InsertGoiTap: {ex.Message}");
                return false;
            }
        }

        public bool UpdateGoiTap(GoiTapGymDTO gt)
        {
            try
            {
                var goiTap = _context.GoiTapGyms.FirstOrDefault(g => g.MaGoi == gt.MaGoi);
                if (goiTap == null)
                    return false;

                goiTap.TenGoi = gt.TenGoi;
                goiTap.DonGia = gt.DonGia;
                goiTap.ThoiHan = gt.ThoiHan;
                goiTap.MaKm = string.IsNullOrEmpty(gt.MaKM) ? null : gt.MaKM;

                _context.GoiTapGyms.Update(goiTap);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateGoiTap: {ex.Message}");
                return false;
            }
        }

        public bool DeleteGoiTap(string maGoi)
        {
            try
            {
                var goiTap = _context.GoiTapGyms.FirstOrDefault(g => g.MaGoi == maGoi);
                if (goiTap == null)
                    return false;

                _context.GoiTapGyms.Remove(goiTap);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteGoiTap: {ex.Message}");
                return false;
            }
        }
    }
}
