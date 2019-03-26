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
            SqlCommand cmd = new SqlCommand("sp_insert_tag", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Tag", tag);
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
                string ttag = rd["Tag"] is DBNull ? "" : rd.GetString(0);

                l.Add(ttag);
            }
            rd.Close();
            closeConnect();
            return l;
        }
    }
}