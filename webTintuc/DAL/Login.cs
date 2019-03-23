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
            SqlCommand cmd = new SqlCommand("select count(id) from [user] where id = '" + id + "' and password = '" + pass + "'", con);
            kq = (int)cmd.ExecuteScalar();
            con.Close();
            return kq;
        }
        public static Boolean getauthority(string id)
        {
            int kq = 1;
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand cmd = new SqlCommand("select count()", con);
            con.Close();
            return false;
        }
    }
}