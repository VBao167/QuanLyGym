using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGym.DTO;
using System.Data;

namespace QuanLyGym.DAL
{
    public class GoiTapGymDAL
    {
        DatabaseConnection db = new DatabaseConnection();

        public DataTable GetAllGoiTap()
        {
            string query = "SELECT MaGoi, TenGoi, DonGia, ThoiHan, MaKM FROM GoiTapGym";
            return db.ExecuteQuery(query);
        }

        public bool InsertGoiTap(GoiTapGymDTO gt)
        {
            string query = string.Format(
                "INSERT INTO GoiTapGym (MaGoi, TenGoi, DonGia, ThoiHan, MaKM) VALUES ('{0}', N'{1}', {2}, {3}, {4})",
                gt.MaGoi, gt.TenGoi, gt.DonGia, gt.ThoiHan,
                string.IsNullOrEmpty(gt.MaKM) ? "NULL" : $"'{gt.MaKM}'");
            return db.ExecuteNonQuery(query) > 0;
        }

        public bool UpdateGoiTap(GoiTapGymDTO gt)
        {
            string query = string.Format(
                "UPDATE GoiTapGym SET TenGoi = N'{1}', DonGia = {2}, ThoiHan = {3}, MaKM = {4} WHERE MaGoi = '{0}'",
                gt.MaGoi, gt.TenGoi, gt.DonGia, gt.ThoiHan,
                string.IsNullOrEmpty(gt.MaKM) ? "NULL" : $"'{gt.MaKM}'");
            return db.ExecuteNonQuery(query) > 0;
        }

        public bool DeleteGoiTap(string maGoi)
        {
            string query = string.Format("DELETE FROM GoiTapGym WHERE MaGoi = '{0}'", maGoi);
            return db.ExecuteNonQuery(query) > 0;
        }
    }
}
