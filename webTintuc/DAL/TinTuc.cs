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
            openConnect();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.TinTuc tt = new Areas.Models.TinTuc();
                tt.Id1 = rd["Id"] is DBNull ? 0 : rd.GetInt32(0) ;
                tt.TieuDe1 = rd["TieuDe"] is DBNull ? "" : rd.GetString(1).Trim() ;
                tt.Tag1 = rd["Tag"] is DBNull ? "" : rd.GetString(2) ;
                tt.NoiDung1 = rd["NoiDung"] is DBNull ? "" : rd.GetString(3).Trim() ;
                tt.NgayDang1 = rd["NgayDang"] is DBNull ? d : rd.GetDateTime(4) ;
                tt.NgayTao1 = rd["NgayTao"] is DBNull ? d : rd.GetDateTime(5) ;
                tt.HienThi1 = rd["HienThi"] is DBNull ? false : rd.GetBoolean(6) ;
                tt.TuKhoa1 = rd["TuKhoa"] is DBNull ? "" : rd.GetString(7).Trim() ;
                tt.DanhMuc1 = rd["DanhMuc"] is DBNull ? 0 : rd.GetInt32(8) ;
                tt.TenDM1 = rd["Ten"] is DBNull ? "" : rd.GetString(9).Trim();
                tt.Anh1 = rd["Anh"] is DBNull ? "" : rd.GetString(10).Trim() ;
                tt.MetaTitle1 = rd["MetaTitle"] is DBNull  ? "" : rd.GetString(11).Trim() ;
                tt.TacGia1 = rd["tentg"] is DBNull ? "" : rd.GetString(12).Trim() ;
                tt.Hot1 = rd["Hot"] is DBNull ? false : rd.GetBoolean(13) ;
                list.Add(tt);
            }
            rd.Close();
            return list;
        }
        public static List<Areas.Models.TinTuc> selectList_Duyet(string stt)
        {
            List<Areas.Models.TinTuc> list = new List<Areas.Models.TinTuc>();
            SqlCommand cmd = new SqlCommand("Admin_sp_select_TinTuc_ALL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@trangThaiDuyet", stt);
            openConnect();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.TinTuc tt = new Areas.Models.TinTuc();
                tt.Id1 = rd["Id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.TieuDe1 = rd["TieuDe"] is DBNull ? "" : rd.GetString(1).Trim();
                tt.Tag1 = rd["Tag"] is DBNull ? "" : rd.GetString(2);
                tt.NoiDung1 = rd["NoiDung"] is DBNull ? "" : rd.GetString(3).Trim();
                tt.NgayDang1 = rd["NgayDang"] is DBNull ? d : rd.GetDateTime(4);
                tt.NgayTao1 = rd["NgayTao"] is DBNull ? d : rd.GetDateTime(5);
                tt.HienThi1 = rd["HienThi"] is DBNull ? false : rd.GetBoolean(6);
                tt.TuKhoa1 = rd["TuKhoa"] is DBNull ? "" : rd.GetString(7).Trim();
                tt.DanhMuc1 = rd["DanhMuc"] is DBNull ? 0 : rd.GetInt32(8);
                tt.TenDM1 = rd["Ten"] is DBNull ? "" : rd.GetString(9).Trim();
                tt.Anh1 = rd["Anh"] is DBNull ? "" : rd.GetString(10).Trim();
                tt.MetaTitle1 = rd["MetaTitle"] is DBNull ? "" : rd.GetString(11).Trim();
                tt.TacGia1 = rd["tentg"] is DBNull ? "" : rd.GetString(12).Trim();
                tt.Hot1 = rd["Hot"] is DBNull ? false : rd.GetBoolean(13);
                tt.Trangthaiduyet = rd["trangThaiDuyet"] is DBNull ? 0 : rd.GetInt32(14);
                list.Add(tt);
            }
            rd.Close();
            return list;
        }
        public static Areas.Models.TinTuc selectTT(string matin)
        {
            Areas.Models.TinTuc tt = new Areas.Models.TinTuc();
            SqlCommand cmd = new SqlCommand("sp_select_TinTuc_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", matin);
            openConnect();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                
                tt.Id1 = rd["Id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.TieuDe1 = rd["TieuDe"] is DBNull ? "" : rd.GetString(1).Trim();
                tt.Tag1 = rd["Tag"] is DBNull ? "" : rd.GetString(2);
                tt.NoiDung1 = rd["NoiDung"] is DBNull ? "" : rd.GetString(3).Trim();
                tt.NgayDang1 = rd["NgayDang"] is DBNull ? d : rd.GetDateTime(4);
                tt.NgayTao1 = rd["NgayTao"] is DBNull ? d : rd.GetDateTime(5);
                tt.HienThi1 = rd["HienThi"] is DBNull ? false : rd.GetBoolean(6);
                tt.TuKhoa1 = rd["TuKhoa"] is DBNull ? "" : rd.GetString(7).Trim();
                tt.DanhMuc1 = rd["DanhMuc"] is DBNull ? 0 : rd.GetInt32(8);
                tt.TenDM1 = rd["Ten"] is DBNull ? "" : rd.GetString(9).Trim();
                tt.Anh1 = rd["Anh"] is DBNull ? "" : rd.GetString(10).Trim();
                tt.MetaTitle1 = rd["MetaTitle"] is DBNull ? "" : rd.GetString(11).Trim();
                tt.TacGia1 = rd["tentg"] is DBNull ? "" : rd.GetString(12).Trim();
                tt.Hot1 = rd["Hot"] is DBNull ? false : rd.GetBoolean(13);
               
            }
            rd.Close();
            return tt;
        }
        public static List<Areas.Models.TinTuc> selectTT4()
        {
            List<Areas.Models.TinTuc> list = new List<Areas.Models.TinTuc>();
            
            SqlCommand cmd = new SqlCommand(" select top 4 Id,TieuDe,Tag,NoiDung,NgayDang,TuKhoa,DanhMuc,Anh,MetaTitle from tintuc where HienThi = 1 order by NgayTao", con);
            openConnect();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.TinTuc tt = new Areas.Models.TinTuc();
                tt.Id1 = rd["Id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.TieuDe1 = rd["TieuDe"] is DBNull ? "" : rd.GetString(1).Trim();
                tt.Tag1 = rd["Tag"] is DBNull ? "" : rd.GetString(2);
                tt.NoiDung1 = rd["NoiDung"] is DBNull ? "" : rd.GetString(3).Trim();
                tt.NgayDang1 = rd["NgayDang"] is DBNull ? d : rd.GetDateTime(4);
                tt.TuKhoa1 = rd["TuKhoa"] is DBNull ? "" : rd.GetString(5).Trim();
                tt.DanhMuc1 = rd["DanhMuc"] is DBNull ? 0 : rd.GetInt32(6);
                tt.Anh1 = rd["Anh"] is DBNull ? "" : rd.GetString(7).Trim();
                tt.MetaTitle1 = rd["MetaTitle"] is DBNull ? "" : rd.GetString(8).Trim();
                list.Add(tt);
            }
            rd.Close();
            return list;
        }


        public static void insert(Areas.Models.TinTuc tin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TieuDe", tin.TieuDe1.Trim());
            cmd.Parameters.AddWithValue("@Tag", tin.Tag1.Trim());
            cmd.Parameters.AddWithValue("@NoiDung", tin.NoiDung1.Trim());
            cmd.Parameters.AddWithValue("@TuKhoa", tin.TuKhoa1.Trim());
            cmd.Parameters.AddWithValue("@Anh", tin.Anh1.Trim());
            cmd.Parameters.AddWithValue("@MetaTitle", tin.MetaTitle1.Trim());
            cmd.Parameters.AddWithValue("@TacGia", tin.TacGia1.Trim());
            cmd.Parameters.AddWithValue("@DanhMuc", tin.DanhMuc1);
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void update(Areas.Models.TinTuc tin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_update_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TieuDe", tin.TieuDe1.Trim());
            cmd.Parameters.AddWithValue("@Tag", XuLiChuoi.xoaKhoangTrang(tin.Tag1.Trim()));
            cmd.Parameters.AddWithValue("@NoiDung", tin.NoiDung1.Trim());
            cmd.Parameters.AddWithValue("@TuKhoa", XuLiChuoi.xoaKhoangTrang(tin.TuKhoa1.Trim()));
            cmd.Parameters.AddWithValue("@Anh", tin.Anh1.Trim());
            cmd.Parameters.AddWithValue("@MetaTitle", XuLiChuoi.xoaKhoangTrang(tin.TieuDe1.Trim()) );
            cmd.Parameters.AddWithValue("@Id", tin.Id1);
            cmd.Parameters.AddWithValue("@DanhMuc", tin.DanhMuc1);
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void Admin_update(Areas.Models.TinTuc tin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("Admin_sp_update_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", tin.Id1);
            cmd.Parameters.AddWithValue("@TieuDe", tin.TieuDe1.Trim());
            cmd.Parameters.AddWithValue("@Tag", tin.Tag1.Trim());
            cmd.Parameters.AddWithValue("@NoiDung", tin.NoiDung1.Trim());
            cmd.Parameters.AddWithValue("@HienThi", tin.HienThi1);
            if(tin.HienThi1 ) cmd.Parameters.AddWithValue("@NgayDang", DateTime.Now.ToString());
            else cmd.Parameters.AddWithValue("@NgayDang", "");
            cmd.Parameters.AddWithValue("@TuKhoa", tin.TuKhoa1.Trim());
            cmd.Parameters.AddWithValue("@Anh", tin.Anh1.Trim());
            cmd.Parameters.AddWithValue("@MetaTitle", tin.MetaTitle1.Trim());
            cmd.Parameters.AddWithValue("@Hot", tin.Hot1);   
            cmd.Parameters.AddWithValue("@DanhMuc", tin.DanhMuc1);
            cmd.ExecuteNonQuery();
            closeConnect();
        }

        public List<Areas.Models.DanhMuc> chuyenMuc()
        {
            openConnect();
            List<Areas.Models.DanhMuc> list = new List<Areas.Models.DanhMuc>();
            SqlCommand cmd = new SqlCommand("sp_select_danhMuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.DanhMuc tt = new Areas.Models.DanhMuc();
                tt.Id = rd["Id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.DanhMucCha = rd["TieuDe"] is DBNull ? 0 : rd.GetInt32(1);
                tt.MetaTitle = rd["Tag"] is DBNull ? "" : rd.GetString(2).Trim();
                tt.Ten = rd["NoiDung"] is DBNull ? "" : rd.GetString(3).Trim();
                tt.TenDanhMucCha = rd["NgayDang"] is DBNull ? "" : rd.GetString(4).Trim();
                tt.HienThi = rd["NgayDang"] is DBNull ? false : rd.GetBoolean(4);         
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }
        public  static void xoa(string id)
        {

        }
        public static Boolean checkAdmin(string id)
        {
            Boolean check = false;
            int kq = 1;
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand cmd = new SqlCommand("select count(Nhanvien) from TongBienTap where nhanvien = @nhanvien", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nhanvien", id);

            kq = (int)cmd.ExecuteScalar();


            con.Close();

            return check;
        }
        public static string getIDTT()
        {
            
            string kq = "";
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand cmd = new SqlCommand("select max(id) from tintuc", con);
            kq = cmd.ExecuteScalar().ToString();
            con.Close();

            return kq;
        }
    }
}