using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
namespace webTintuc.DAL
{
    public class TinTuc:Dbconnect
    {
        static DateTime d = new DateTime(1990,1,1);
        
        public static List<Areas.Models.TinTuc> selectList()
        {
            List<Areas.Models.TinTuc> list = new List<Areas.Models.TinTuc>();
            SqlCommand cmd = new SqlCommand("Admin_sp_select_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.TinTuc tt = new Areas.Models.TinTuc();
                tt.Id1 = rd["Id"] is DBNull ? 0 : rd.GetInt32(0) ;
                tt.TieuDe1 = rd["TieuDe"] is DBNull ? "" : rd.GetString(1) ;
                tt.Tag1 = rd["Tag"] is DBNull ? "" : rd.GetString(2) ;
                tt.NoiDung1 = rd["NoiDung"] is DBNull ? "" : rd.GetString(3) ;
                tt.NgayDang1 = rd["NgayDang"] is DBNull ? d : rd.GetDateTime(4) ;
                tt.NgayTao1 = rd["NgayTao"] is DBNull ? d : rd.GetDateTime(5) ;
                tt.HienThi1 = rd["HienThi"] is DBNull ? false : rd.GetBoolean(6) ;
                tt.TuKhoa1 = rd["TuKhoa"] is DBNull ? "" : rd.GetString(7) ;
                tt.DanhMuc1 = rd["DanhMuc"] is DBNull ? 0 : rd.GetInt32(8) ;
                tt.Anh1 = rd["Anh"] is DBNull ? "" : rd.GetString(9) ;
                tt.MetaTitle1 = rd["MetaTitle"] is DBNull  ? "" : rd.GetString(10) ;
                tt.TacGia1 = rd["Ten"] is DBNull ? "" : rd.GetString(11) ;
                tt.Hot1 = rd["Hot"] is DBNull ? false : rd.GetBoolean(12) ;
                list.Add(tt);
            }
            rd.Close();
            return list;
        }


        public static void insert(Areas.Models.TinTuc tin)
        {
            SqlCommand cmd = new SqlCommand("sp_insert_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TieuDe", tin.TieuDe1);
            cmd.Parameters.AddWithValue("@Tag", tin.Tag1);
            cmd.Parameters.AddWithValue("@NoiDung", tin.NoiDung1);
            cmd.Parameters.AddWithValue("@TuKhoa", tin.TuKhoa1);
            cmd.Parameters.AddWithValue("@Anh", tin.Anh1);
            cmd.Parameters.AddWithValue("@MetaTitle", tin.MetaTitle1);
            cmd.Parameters.AddWithValue("@TacGia", tin.TacGia1);
            cmd.Parameters.AddWithValue("@DanhMuc", tin.DanhMuc1);
            cmd.ExecuteNonQuery();
        }

        public static void Admin_update(Areas.Models.TinTuc tin)
        {
            SqlCommand cmd = new SqlCommand("Admin_sp_update_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", tin.Id1);
            cmd.Parameters.AddWithValue("@TieuDe", tin.TieuDe1);
            cmd.Parameters.AddWithValue("@Tag", tin.Tag1);
            cmd.Parameters.AddWithValue("@NoiDung", tin.NoiDung1);
            cmd.Parameters.AddWithValue("@HienThi", tin.HienThi1);
            if(tin.HienThi1 ) cmd.Parameters.AddWithValue("@NgayDang", DateTime.Now.ToString());
            else cmd.Parameters.AddWithValue("@NgayDang", "");
            cmd.Parameters.AddWithValue("@TuKhoa", tin.TuKhoa1);
            cmd.Parameters.AddWithValue("@Anh", tin.Anh1);
            cmd.Parameters.AddWithValue("@MetaTitle", tin.MetaTitle1);
            cmd.Parameters.AddWithValue("@Hot", tin.Hot1);   
            cmd.Parameters.AddWithValue("@DanhMuc", tin.DanhMuc1);
            cmd.ExecuteNonQuery();
        }

        public static void chuyenMuc()
        {

        }
        public  static void xoa(string id)
        {

        }


    }
}