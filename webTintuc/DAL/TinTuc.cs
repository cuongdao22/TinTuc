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
        public static void insert(Areas.Front.Models.TinTuc tin)
        {
            SqlCommand cmd = new SqlCommand("sp_insert_TinTuc", con);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("Ten", tin.id);
            cmd.ExecuteNonQuery();
        }

    }
}