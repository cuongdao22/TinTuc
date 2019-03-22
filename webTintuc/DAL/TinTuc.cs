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
        public static List<Areas.Front.Models.TinTuc> selectList()
        {
            List<Areas.Front.Models.TinTuc> list = new List<Areas.Front.Models.TinTuc>();
            SqlCommand cmd = new SqlCommand("select * from TinTuc", con);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                
            }
            rd.Close();
            return list;
        }
        public static void insert(Areas.Front.Models.TinTuc tin)
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

        public static void Admin_update(Areas.Front.Models.TinTuc tin)
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
        public  static void xoa(string id)
        {

        }


    }
}