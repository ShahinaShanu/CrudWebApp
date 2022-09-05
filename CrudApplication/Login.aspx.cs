using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudApplication
{
    public partial class Login : System.Web.UI.Page
    {
        LoginCls obj = new LoginCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            int i = obj.Login(txtUsername.Text, txtUserpwd.Text);
            if (i == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Loggedin Successfully');", true);
                Session["UserName"] = txtUsername.Text.ToString();
                Response.Redirect("ViewUsers.aspx");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Login Failed..Kindly Enter correct Username & Password');", true);
            }
        }
    }
}