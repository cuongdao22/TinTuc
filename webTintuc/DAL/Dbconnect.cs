﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webTintuc.DAL
{
    public class Dbconnect
    {
        protected static SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS ; Initial Catalog = WebTinTuc ;Integrated Security = True ");

        public static void openConnect()
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public static void closeConnect()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}