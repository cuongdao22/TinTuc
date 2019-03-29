using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class Login:Dbconnect
    {
        public static int login(string id, string pass)
        {
            int kq = 1;
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand cmd = new SqlCommand("sp_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", id);
            cmd.Parameters.AddWithValue("@MatKhau", pass);
            kq = (int)cmd.ExecuteScalar();
            con.Close();
            return kq;
        }
        public static Areas.Models.NhanVien getauthority(string email)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand cmd = new SqlCommand("sp_getIDNV", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);
            openConnect();
            Areas.Models.NhanVien nv = new Areas.Models.NhanVien();

            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                nv.Id = rd["Id"] is DBNull ? 0 : rd.GetInt32(0);
                nv.Ten = rd["Id"] is DBNull ? "" : rd.GetString(1).Trim();
                nv.Admin = rd["Id"] is DBNull ? false : rd.GetBoolean(2);

            }
            rd.Close();
            con.Close();
            return nv;
        }
    }
}