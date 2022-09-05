using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudApplication
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        LoginCls obj = new LoginCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSendMail_Click(object sender, EventArgs e)
        {
            int i = obj.RegisteredEmail(txtresetEmail.Text);
            if (i == 1)
            {
                Session["UEmail"] = txtresetEmail.Text;
                Response.Redirect("ResetPwdWindow.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Invalid Email ID');", true);
            }
        }
    }
}