using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class TongBienTap : Dbconnect
    {
        public static List<Areas.Models.NhanVien> selectDSTongBT()
        {
            openConnect();
            List<Areas.Models.NhanVien> list = new List<Areas.Models.NhanVien>();
            SqlCommand cmd = new SqlCommand("select NhanVien as mnv,NhanVien.Ten,NhanVien.Email,NgayThem from TongBienTap,NhanVien where NhanVien.Id = TongBienTap.NhanVien ", con);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.NhanVien tt = new Areas.Models.NhanVien();
                tt.Id = rd["mnv"] is DBNull ? 0 : rd.GetInt32(0);
                tt.Ten = rd["Ten"] is DBNull ? "" : rd.GetString(1);
                tt.Email = rd["Email"] is DBNull ? "" : rd.GetString(2).Trim();
                tt.NgayThem = rd.GetDateTime(3);
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }
        public static void insert(string mnv)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_TongBienTap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nhanvien", mnv);
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void detele(string mnv)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("delete from TongBienTap where nhanvien = @nhanvien", con);
            cmd.Parameters.AddWithValue("@nhanvien", mnv);

            cmd.ExecuteNonQuery();
            closeConnect();
        }
    }
}