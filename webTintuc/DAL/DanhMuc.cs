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
        public static void select(string id)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand("sp_insert_tag", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.ExecuteNonQuery();
            closeConnect();
        }
    }
}