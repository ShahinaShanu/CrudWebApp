using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CrudApplication
{
    public class LoginCls
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConntectionString"].ToString());
        public int Login(String UN, String PW)
        {
            int i = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("SPGetLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetLogin");
            cmd.Parameters.AddWithValue("@UserID", UN);
            cmd.Parameters.AddWithValue("@Password",PW);
            cmd.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            int count= dt.Rows.Count;
            if (count == 1)
            {
                i = 1;
            }
            con.Close();

            return i;
        }
        public int RegisteredEmail(String email)
        {
            int i = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("SPGetLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetEmail");
            cmd.Parameters.AddWithValue("@UserID", email);
            cmd.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            int count = dt.Rows.Count;
            if (count == 1)
            {
                i = 1;
            }
            con.Close();

            return i;
        }

    }

}