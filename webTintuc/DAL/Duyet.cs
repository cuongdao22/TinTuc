﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class Duyet:Dbconnect
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
        public static void duyet(string id)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_update_TinTuc_duyet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            closeConnect();
        }
        public static void Kduyet(string id)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_update_TinTuc_Dduyet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            closeConnect();
        }

    }
}