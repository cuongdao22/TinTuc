using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class Tag:Dbconnect
    {
        //sp_insert_tag
        public static void insert(string tag)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_Tag", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tag", XuLiChuoi.xoaKhoangTrang(tag.Trim()));
            
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void insert(string tag,string url)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_Tag2 ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tag", XuLiChuoi.xoaKhoangTrang(tag.Trim()));
            if (url!=null)
            {
                cmd.Parameters.AddWithValue("@url", XuLiChuoi.xoaKhoangTrang(url.Trim()));
            } else cmd.Parameters.AddWithValue("@url", " ");

            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void update(string tag, string url)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_update_Tag ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tag", XuLiChuoi.xoaKhoangTrang(tag.Trim()));
            if (url != null)
            {
                cmd.Parameters.AddWithValue("@url", XuLiChuoi.xoaKhoangTrang(url.Trim()));
            }
            else cmd.Parameters.AddWithValue("@url", " ");

            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static int checkTag(string tag)
        {
            int kq = 1;
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand cmd = new SqlCommand("select count(tag) from tag where tag = @tag", con);
            cmd.Parameters.AddWithValue("@tag", XuLiChuoi.xoaKhoangTrang(tag.Trim()));
            kq = (int)cmd.ExecuteScalar();
            con.Close();
            return kq;
        }
        public static void insertTagtt(string tag,string maTin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_TagTT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tag", XuLiChuoi.xoaKhoangTrang( tag.Trim()));
            cmd.Parameters.AddWithValue("@tintuc", maTin.Trim());
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void deteleTagtt( string maTin)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("delete from TagTT where TinTuc = @matin", con);
            cmd.Parameters.AddWithValue("@matin", maTin.Trim());
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static List<string> getTag()
        {
            List<string> l = new List<string>();
            openConnect();
            SqlCommand cmd = new SqlCommand("select tag from tag", con);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.TinTuc tt = new Areas.Models.TinTuc();
                string ttag = rd["Tag"] is DBNull ? "" : rd.GetString(0).Trim();

                l.Add(ttag);
            }
            rd.Close();
            closeConnect();
            return l;
        }

        public static Areas.Models.Tag getTag(string id)
        {
            Areas.Models.Tag tt = new Areas.Models.Tag();
            openConnect();
            SqlCommand cmd = new SqlCommand("select * from tag where tag = @tag", con);
            cmd.Parameters.AddWithValue("@tag", id);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {            
                tt.TenTag = rd["Tag"] is DBNull ? "" : rd.GetString(0).Trim();
                tt.Url = rd["Url"] is DBNull ? "" : rd.GetString(1).Trim();
            }
            rd.Close();
            closeConnect();
            return tt;
        }

        public static List<Areas.Models.Tag> getALLTag()
        {
            List<Areas.Models.Tag> l = new List<Areas.Models.Tag>();
            openConnect();
            SqlCommand cmd = new SqlCommand("select * from tag", con);
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rd.Read())
            {
                Areas.Models.Tag tt = new Areas.Models.Tag();
                tt.TenTag = rd["Tag"] is DBNull ? "" : rd.GetString(0).Trim();
                tt.Url = rd["Url"] is DBNull ? "" : rd.GetString(1).Trim();
                l.Add(tt);
            }
            rd.Close();
            closeConnect();
            return l;
        }
    }
}