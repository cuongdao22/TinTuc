using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class PhongBan : Dbconnect
    {
        public static List<Areas.Models.PhongBan> select()
        {
            openConnect();
            List<Areas.Models.PhongBan> list = new List<Areas.Models.PhongBan>();
            SqlCommand cmd = new SqlCommand("select PhongBan.id,PhongBan.IdDanhMuc,DanhMuc.Ten,PhongBan.QuanLi,NhanVien.Ten as 'tenql',PhongBan.Email from PhongBan,DanhMuc,NhanVien where PhongBan.IdDanhMuc = DanhMuc.Id  and PhongBan.QuanLi = NhanVien.id", con);

            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.PhongBan tt = new Areas.Models.PhongBan();
                tt.Id = rd["id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.IdDM = rd["IdDanhMuc"] is DBNull ? 1 : rd.GetInt32(1);
                tt.TenDM = rd["Ten"] is DBNull ? "" : rd.GetString(2).Trim();
                tt.IdQL = rd["QuanLi"] is DBNull ? 0 : rd.GetInt32(3);
                tt.TenQL = rd["tenql"] is DBNull ? "" : rd.GetString(4).Trim();
                tt.Email = rd["Email"] is DBNull ? "" : rd.GetString(5).Trim();
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }
        public static List<Areas.Models.NhanVien> selectDSMod(string idPB)
        {
            openConnect();
            List<Areas.Models.NhanVien> list = new List<Areas.Models.NhanVien>();
            SqlCommand cmd = new SqlCommand("select NhanVien as mnv,NhanVien.Ten,NhanVien.Email,NgayThem from Mod,PhongBan,NhanVien where NhanVien.Id = mod.NhanVien and PhongBan.Id = @idPB", con);
            cmd.Parameters.AddWithValue("@idPB", idPB);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.NhanVien tt = new Areas.Models.NhanVien();
                tt.Id = rd["mnv"] is DBNull ? 0 : rd.GetInt32(0);
                tt.Ten = rd["Ten"] is DBNull ? "" : rd.GetString(1);
                tt.Email = rd["Email"] is DBNull ? "" : rd.GetString(2).Trim();
                tt.NgayThem =  rd.GetDateTime(3);
                
                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }
        public static List<Areas.Models.NhanVien> selectDSNV()
        {
            openConnect();
            List<Areas.Models.NhanVien> list = new List<Areas.Models.NhanVien>();
            SqlCommand cmd = new SqlCommand("select id,ten,email from nhanvien", con);

            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.NhanVien tt = new Areas.Models.NhanVien();
                tt.Id = rd["id"] is DBNull ? 0 : rd.GetInt32(0);
                tt.Ten = rd["ten"] is DBNull ? "" : rd.GetString(1);
                tt.Email = rd["email"] is DBNull ? "" : rd.GetString(2).Trim();

                list.Add(tt);
            }
            rd.Close();
            closeConnect();
            return list;
        }
        public static void insert(Areas.Models.PhongBan tin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_PhongBan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ten", tin.IdDM);
            cmd.Parameters.AddWithValue("@DanhMucCha", tin.IdQL);
            cmd.Parameters.AddWithValue("@MetaTitle", XuLiChuoi.xoaKhoangTrang(tin.Email.Trim()));

            cmd.ExecuteNonQuery();
            closeConnect();
        }
        
        public static void insertMod(string mnv,string qldm)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_mod", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nhanvien", mnv);
            cmd.Parameters.AddWithValue("@qldm", qldm);
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void update(Areas.Models.PhongBan tin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_DanhMuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ten", tin.TenDM);
            cmd.Parameters.AddWithValue("@DanhMucCha", tin.Dsnv);
            cmd.Parameters.AddWithValue("@MetaTitle", XuLiChuoi.xoaKhoangTrang(tin.Email.Trim()));
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void deteleDSMod(string mnv)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("delete from mod where nhanvien = @nhanvien", con);
            cmd.Parameters.AddWithValue("@nhanvien", mnv);

            cmd.ExecuteNonQuery();
            closeConnect();
        }
    }
}