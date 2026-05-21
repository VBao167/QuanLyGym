using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DTO;
using QuanLyGym.Models;

namespace QuanLyGym.DAL
{
    public class NhanVienDAL
    {
        private GymManagementSystemContext _context;

        public NhanVienDAL()
        {
            _context = new GymManagementSystemContext();
        }

        // 1. Lấy toàn bộ danh sách nhân viên
        public List<NhanVienDTO> GetAllNhanVien()
        {
            try
            {
                var list = _context.NhanViens
                    .Select(nv => new NhanVienDTO
                    {
                        MaNV = nv.MaNv,
                        TenNV = nv.TenNv,
                        Sdt = nv.Sdt,
                        ChucVu = nv.ChucVu
                    })
                    .ToList();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllNhanVien: {ex.Message}");
                return new List<NhanVienDTO>();
            }
        }

        // 2. Thêm mới nhân viên
        public bool InsertNhanVien(NhanVienDTO NV)
        {
            try
            {
                var nhanVien = new NhanVien
                {
                    MaNv = NV.MaNV,
                    TenNv = NV.TenNV,
                    Sdt = NV.Sdt,
                    ChucVu = NV.ChucVu
                };
                _context.NhanViens.Add(nhanVien);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi InsertNhanVien: {ex.Message}");
                return false;
            }
        }

        // 3. Cập nhật thông tin nhân viên
        public bool UpdateNhanVien(NhanVienDTO NV)
        {
            try
            {
                var nhanVien = _context.NhanViens.FirstOrDefault(n => n.MaNv == NV.MaNV);
                if (nhanVien == null)
                    return false;

                nhanVien.TenNv = NV.TenNV;
                nhanVien.Sdt = NV.Sdt;
                nhanVien.ChucVu = NV.ChucVu;

                _context.NhanViens.Update(nhanVien);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateNhanVien: {ex.Message}");
                return false;
            }
        }

        // 4. Xóa nhân viên
        public bool DeleteNhanVien(string MaNV)
        {
            try
            {
                var nhanVien = _context.NhanViens.FirstOrDefault(n => n.MaNv == MaNV);
                if (nhanVien == null)
                    return false;

                _context.NhanViens.Remove(nhanVien);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteNhanVien: {ex.Message}");
                return false;
            }
        }
    }
}