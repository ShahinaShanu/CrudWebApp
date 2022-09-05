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
    public partial class ResetPwdWindow : System.Web.UI.Page
    {
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConntectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Con.Open();
            string UEmail = Session["UEmail"].ToString();
            SqlCommand cmd = new SqlCommand("SPResetPwd", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailID", UEmail);
            cmd.Parameters.AddWithValue("@Password", txtCnfmpwd.Text);
            cmd.ExecuteNonQuery();
            Con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Successfully Reset password');", true);
            clearForm();
        }
        void clearForm()
        {
            txtNewPwd.Text = txtCnfmpwd.Text = "";
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}