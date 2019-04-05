using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class DanhMuc:Dbconnect
    {
        public static List<Areas.Models.DanhMuc>  select(string id)
        {
            openConnect();
            List<Areas.Models.DanhMuc> list = new List<Areas.Models.DanhMuc>();
            SqlCommand cmd = new SqlCommand("sp_select_dm", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nhanvien", id);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.DanhMuc tt = new Areas.Models.DanhMuc();
                tt.Id = rd["Id"] is DBNull ? 0 : rd.GetInt32(1);
                tt.Ten = rd["Ten"] is DBNull ? "" : rd.GetString(0).Trim();
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }
        public static List<Areas.Models.DanhMuc> selectDSNV(string id)
        {
            openConnect();      
            List<Areas.Models.DanhMuc> list = new List<Areas.Models.DanhMuc>();
            SqlCommand cmd = new SqlCommand("sp_select_dm", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nhanvien", id);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.DanhMuc tt = new Areas.Models.DanhMuc();
                tt.Id = rd["Id"] is DBNull ? 0 : rd.GetInt32(1);
                tt.Ten = rd["Ten"] is DBNull ? "" : rd.GetString(0).Trim();
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }
        public static Areas.Models.DanhMuc selectDM(string idDM)
        {
            openConnect();
            Areas.Models.DanhMuc tt = new Areas.Models.DanhMuc();
            SqlCommand cmd = new SqlCommand("sp_select_dm_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", idDM);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                
                tt.Id = rd["id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.Ten = rd["Ten"] is DBNull ? "" : rd.GetString(1).Trim();
                tt.DanhMucCha = rd["DanhMucCha"] is DBNull ? 0 : rd.GetInt32(2);
                tt.TenDanhMucCha = rd["TenDanhMucCha"] is DBNull ? "Không có" : rd.GetString(3).Trim();
                tt.MetaTitle = rd["MetaTitle"] is DBNull ? "" : rd.GetString(4).Trim();
                tt.HienThi = rd["HienThi"] is DBNull ? false : rd.GetBoolean(5);

            }
            rd.Close();
            closeConnect();
            return tt;
        }
        public static List<Areas.Models.DanhMuc> selectALLDM()
        {
            openConnect();
            List<Areas.Models.DanhMuc> list = new List<Areas.Models.DanhMuc>();
            
            SqlCommand cmd = new SqlCommand("select a.id,a.Ten,a.DanhMucCha,b.Ten as 'TenDanhMucCha',a.MetaTitle,a.HienThi from DanhMuc a LEFT JOIN DanhMuc b on b.Id = a.DanhMucCha", con);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.DanhMuc tt = new Areas.Models.DanhMuc();
                tt.Id = rd["id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.Ten = rd["Ten"] is DBNull ? "" : rd.GetString(1).Trim();
                tt.DanhMucCha = rd["DanhMucCha"] is DBNull ? 0 : rd.GetInt32(2);
                tt.TenDanhMucCha = rd["TenDanhMucCha"] is DBNull ? "Không có" : rd.GetString(3).Trim();
                tt.MetaTitle = rd["MetaTitle"] is DBNull ? "" : rd.GetString(4).Trim();
                tt.HienThi = rd["HienThi"] is DBNull ? false : rd.GetBoolean(5);
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }

        public static List<Areas.Models.DanhMuc> select()
        {
            openConnect();
            List<Areas.Models.DanhMuc> list = new List<Areas.Models.DanhMuc>();
            SqlCommand cmd = new SqlCommand("select * from DanhMuc where DanhMucCha is null", con);
            
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.DanhMuc tt = new Areas.Models.DanhMuc();
                tt.Id = rd["Id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.Ten = rd["Ten"] is DBNull ? "" : rd.GetString(1).Trim();
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }

        public static List<Areas.Models.DanhMuc> selectAll()
        {
            openConnect();
            List<Areas.Models.DanhMuc> list = new List<Areas.Models.DanhMuc>();
            SqlCommand cmd = new SqlCommand("select a.id,a.Ten,a.DanhMucCha,b.Ten as 'TenDanhMucCha',a.MetaTitle,a.HienThi from DanhMuc a LEFT JOIN DanhMuc b on b.Id = a.DanhMucCha ", con);

            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.DanhMuc tt = new Areas.Models.DanhMuc();
                tt.Id = rd["id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.Ten = rd["Ten"] is DBNull ? "" : rd.GetString(1).Trim();
                tt.DanhMucCha = rd["DanhMucCha"] is DBNull ? 0 : rd.GetInt32(2);
                tt.TenDanhMucCha = rd["TenDanhMucCha"] is DBNull ? "Không có" : rd.GetString(3).Trim();
                tt.MetaTitle = rd["MetaTitle"] is DBNull ? "" : rd.GetString(4).Trim();
                tt.HienThi = rd["HienThi"] is DBNull ? false : rd.GetBoolean(5);
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }
        public static void insert(Areas.Models.DanhMuc tin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_DanhMuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ten", tin.Ten.Trim());
            cmd.Parameters.AddWithValue("@DanhMucCha", tin.DanhMucCha);
            cmd.Parameters.AddWithValue("@MetaTitle",XuLiChuoi.xoaKhoangTrang(tin.MetaTitle.Trim()));
            cmd.Parameters.AddWithValue("@HienThi", tin.HienThi);
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void update(Areas.Models.DanhMuc tin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_update_DanhMuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", tin.Id);
            cmd.Parameters.AddWithValue("@Ten", tin.Ten.Trim());
            cmd.Parameters.AddWithValue("@DanhMucCha", tin.DanhMucCha);
           
            cmd.Parameters.AddWithValue("@MetaTitle", XuLiChuoi.xoaKhoangTrang(tin.MetaTitle.Trim()));
            cmd.Parameters.AddWithValue("@HienThi", tin.HienThi);
            cmd.ExecuteNonQuery();
            closeConnect();
        }
    }
}