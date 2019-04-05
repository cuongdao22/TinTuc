using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class NhanVien : Dbconnect
    {


        static DateTime d = new DateTime(1990, 1, 1);
        
        public static List<Areas.Models.NhanVien> selectList()
        {
            List<Areas.Models.NhanVien> l = new List<Areas.Models.NhanVien>();
            SqlCommand cmd = new SqlCommand("select * from NhanVien", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Areas.Models.NhanVien nv = new Areas.Models.NhanVien();
                nv.Id = dr["Id"] is DBNull ? 0 : dr.GetInt32(0);
                nv.Ten = dr["Ten"] is DBNull ? "" : dr.GetString(1);
                nv.NgaySinh = dr["NgaySinh"] is DBNull ? d : dr.GetDateTime(2);
                nv.Email = dr["Email"] is DBNull ? "" : dr.GetString(3);
                nv.Admin = dr["Admin"] is DBNull ? false : dr.GetBoolean(5); 
                
                l.Add(nv);
            }
            dr.Close();

            con.Close();
            return l;
        }
        public static void insert(Areas.Models.NhanVien nv)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_insert_NhanVien", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ten", nv.Ten);
            cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
            cmd.Parameters.AddWithValue("@Email", nv.Email);
            cmd.Parameters.AddWithValue("@Admin", nv.Admin);
            cmd.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
            if(nv.IdDM != 0)
            cmd.Parameters.AddWithValue("@DanhMuc", nv.IdDM);
            else cmd.Parameters.AddWithValue("@DanhMuc", DBNull.Value);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void update(Areas.Models.NhanVien nv)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_update_NhanVien", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", nv.Id);
            cmd.Parameters.AddWithValue("@Ten", nv.Ten);
            cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
            cmd.Parameters.AddWithValue("@Email", nv.Email);
            cmd.Parameters.AddWithValue("@Admin", nv.Admin);
            if (nv.IdDM != 0)
                cmd.Parameters.AddWithValue("@DanhMuc", nv.IdDM);
            else cmd.Parameters.AddWithValue("@DanhMuc", DBNull.Value);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static Areas.Models.NhanVien selectNV(int id)
        {
            Areas.Models.NhanVien nv = new Areas.Models.NhanVien();
            SqlCommand cmd = new SqlCommand(" select nhanvien.ID,nhanvien.Ten,NgaySinh,email,admin,DanhMuc,DanhMuc.Ten as TenDM from NhanVien LEFT JOIN DanhMuc on NhanVien.DanhMuc = DanhMuc.Id where nhanvien.id = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                nv.Id = dr["Id"] is DBNull ? 0 : dr.GetInt32(0);
                nv.Ten = dr["Ten"] is DBNull ? "" : dr.GetString(1);
                nv.NgaySinh = dr["NgaySinh"] is DBNull ? d : dr.GetDateTime(2).Date;
                nv.Email = dr["Email"] is DBNull ? "" : dr.GetString(3);
                nv.Admin = dr["Admin"] is DBNull ? false : dr.GetBoolean(4);
                nv.IdDM = dr["DanhMuc"] is DBNull ? 0 : dr.GetInt32(5);
                nv.TenDM = dr["TenDM"] is DBNull ? "Không" : dr.GetString(6);
                
            }
            dr.Close();

            con.Close();
            return nv;
        }
    }
  
}


