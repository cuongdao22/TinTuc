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


    }
}