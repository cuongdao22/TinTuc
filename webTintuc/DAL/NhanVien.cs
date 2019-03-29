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
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Areas.Models.NhanVien nv = new Areas.Models.NhanVien();
                nv.Id = dr["Id"] is DBNull ? 0 : dr.GetInt32(0);
                nv.Ten = dr["Ten"] is DBNull ? "" : dr.GetString(1);
                nv.NgaySinh = dr["NgaySinh"] is DBNull ? d : dr.GetDateTime(2);
                nv.Email = dr["Email"] is DBNull ? "" : dr.GetString(3);
                nv.Admin = dr["Admin"] is DBNull ? false : dr.GetBoolean(4);
                
                nv.Mod = dr["Mod"] is DBNull ? false : dr.GetBoolean(5);
                l.Add(nv);
            }
            dr.Close();

            con.Close();
            return l;
        }
        public static void insert(Areas.Models.NhanVien nv)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from NhanVien", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ten", nv.Ten);
            cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
            cmd.Parameters.AddWithValue("@Email", nv.Email);
            cmd.Parameters.AddWithValue("@Admin", nv.Admin);
            cmd.Parameters.AddWithValue("@Mod", nv.Mod);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void update(Areas.Models.NhanVien nv)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from NhanVien ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ten", nv.Ten);
            cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
            cmd.Parameters.AddWithValue("@Email", nv.Email);
            cmd.Parameters.AddWithValue("@Admin", nv.Admin);
            cmd.Parameters.AddWithValue("@Mod", nv.Mod);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
  
}


