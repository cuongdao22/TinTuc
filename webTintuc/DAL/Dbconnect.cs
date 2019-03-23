using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class Dbconnect
    {
        protected static SqlConnection con = new SqlConnection(@"Data Source = (local) ; Initial Catalog = WebTinTuc ;Integrated Security = True ");
        public void openConnect()
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closeConnect()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Open();
            }
        }
    }
}