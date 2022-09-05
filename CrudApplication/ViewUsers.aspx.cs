using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CrudApplication
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConntectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string User = "Welcome '" + Session["UserName"].ToString() + "'";
                lblUname.Text = User.ToString();
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SPUserList_View", con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    GridView_UserList.DataSource = dt;
                    GridView_UserList.DataBind();
                }
            }
        }
        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void lnkDetails_Command(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("RegForm.aspx?ID=" + e.CommandArgument.ToString());
            }
        }
    }
}