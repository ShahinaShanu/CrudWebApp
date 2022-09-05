using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CrudApplication
{
   public partial class RegForm : System.Web.UI.Page
    {
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConntectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clearForm();
                GetCountry();
                int intID = 0;
                if (Request.QueryString["ID"] == null)
                {
                }
                else
                {
                    intID = Convert.ToInt32(Request.QueryString["ID"]);
                }
                Con.Open();
                SqlCommand cmd = new SqlCommand("SPGetUserDetails", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", intID);
                cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
               
                if (dt.Rows.Count >= 1)
                {
                  string[] items = dt.Rows[0]["Interest"].ToString().Split(',');
                    foreach (string word in items)
                    {
                        try
                        {
                            int index = Array.IndexOf(items, word);
                            if (index>-1) {
                                cblInterest.Items.FindByText(word).Selected = true;
                            }
                            else
                            {
                                cblInterest.Items.FindByText(word).Selected = false;
                            }
                            
                        }
                        catch (Exception exp)
                        {
                            lblErrorMsg.Text = exp.ToString();
                        }
                    }
                        hdnid.Value = intID.ToString();
                    txtFname.Text = dt.Rows[0]["FirstName"].ToString();
                    txtLname.Text = dt.Rows[0]["LastName"].ToString();
                    txtEmail.Text = dt.Rows[0]["Emailid"].ToString();
                    RdBtnListGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                    DdlCountry.SelectedValue = dt.Rows[0]["Countryid"].ToString();
                    Con.Close();
                    GetState();
                    DdlState.SelectedValue = dt.Rows[0]["Stateid"].ToString();
                    GetCity();
                    Con.Open();
                    DdlCity.SelectedValue = dt.Rows[0]["Cityid"].ToString();
                    txtPwd.Text = dt.Rows[0]["Pasword"].ToString();
                    txtConfirmPwd.Text = dt.Rows[0]["Pasword"].ToString();
                    txtZip.Text = dt.Rows[0]["ZipCode"].ToString();
                    lblFileUpload.Text = dt.Rows[0]["ProfilePicName"].ToString();
                    PictureUpload();
                    navbar.Visible = false;
                    BtnRegister.Text = "Update";
                    BtnBack.Visible = true;
                    BtnDel.Visible = true;
                    headingReg.InnerText = "Edit your Details";
                    txtEmail.ReadOnly = true;
                    Con.Close();
                }
            }
            else
            {
                txtPwd.Attributes["value"] = txtPwd.Text;
                txtPwd.Attributes["value"] = txtConfirmPwd.Text;
            }
        }
        protected void BtnRegister_Click(object sender, EventArgs e)
        {
           
            string Userid = hdnid.Value.ToString();
            if (txtEmail.ReadOnly == true){}
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SPGetUserEmail", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", txtEmail.Text.Trim());
                cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                Con.Close();
                if (dt.Rows.Count >= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Entered Email already Registered');", true);
                    goto Exit;
                }
            }
            if (Userid == null || Userid != null)
            {
                string status = string.Empty;
                foreach (ListItem item in this.cblInterest.Items)
                {
                    if (item.Selected)
                        status += item + ",";
                }
                string InputString = "";
                InputString = status.ToString().Substring(0, status.ToString().Length - 1);
                
                PictureUpload();
                var imagename = DateTime.Now.ToString("yyyyMMddHHmmss");
                var filename = "Pic" + imagename + FileUploadPic.FileName;
                SqlCommand cmd = new SqlCommand("SPReg_InsertUpdateUser", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", hdnid.Value);
                cmd.Parameters.AddWithValue("@Emailid", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@FirstName ", txtFname.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLname.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", RdBtnListGender.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Password", txtPwd.Text.Trim());
                cmd.Parameters.AddWithValue("@Cityid ", DdlCity.SelectedValue);
                cmd.Parameters.AddWithValue("@Stateid", DdlState.SelectedValue);
                cmd.Parameters.AddWithValue("@ZipCode", txtZip.Text);
                cmd.Parameters.AddWithValue("@Countryid", DdlCountry.SelectedValue);
                cmd.Parameters.AddWithValue("@Interest", InputString.Trim());
                cmd.Parameters.AddWithValue("@FileName", filename);
                Con.Open();
                cmd.ExecuteNonQuery();

                if (Session["UserName"] != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Successfully Updated');", true);
                    clearForm();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Successfully Registered');", true);
                    clearForm();
                }

            }
        Exit:;
        }

        void clearForm()
        {
            txtFname.Text = txtLname.Text = txtEmail.Text = txtPwd.Text = txtConfirmPwd.Text = txtZip.Text  = "";
            DdlCity.Items.Clear();
            DdlCountry.Items.Clear();
            DdlState.Items.Clear();
            RdBtnListGender.ClearSelection();
            cblInterest.ClearSelection();
        }
        void GetCountry()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("SPGetCountry", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                DdlCountry.Items.Clear();
                DdlCountry.DataTextField = "CountryName";
                DdlCountry.DataValueField = "CountryId";
                DdlCountry.DataSource = dt;
                DdlCountry.DataBind();
                DdlCountry.Items.Insert(0, "Select Country--");
                Con.Close();
            }

        }
        void GetState()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("SPGetState", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryID", DdlCountry.SelectedValue);
            cmd.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            DdlState.DataSource = dt;
            DdlState.Items.Clear();
            DdlState.DataTextField = "StateName";
            DdlState.DataValueField = "StateId";
            DdlState.DataBind();
            DdlState.Items.Insert(0, "Select State--");
            Con.Close();


        }
        void GetCity()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("SPGetCity", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateID", DdlState.SelectedValue);
            cmd.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                DdlCity.Items.Clear();
                DdlCity.DataTextField = "CityName";
                DdlCity.DataValueField = "CityId";
                DdlCity.DataSource = dt;
                DdlCity.DataBind();
                DdlCity.Items.Insert(0, "Select City--");
                Con.Close();
            }

        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetState();

        }

        protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCity();

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("ViewUsers.aspx");
            }
        }
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            string Userid = hdnid.Value.ToString();
            Con.Open();
            SqlCommand cmd = new SqlCommand("SPDelUser", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", Userid);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Successfully Deleted');", true);
            clearForm();

        }
        void PictureUpload()
        {
            var imagePath = ConfigurationManager.AppSettings["ImagePath"];
            var imagename = DateTime.Now.ToString("yyyyMMddHHmmss");
            var filename = "Pic" + imagename + FileUploadPic.FileName;
            try
            {
                if (FileUploadPic.HasFile)
                {
                    string folderPath = Server.MapPath(imagePath);
                    //Check whether Directory (Folder) exists, although we have created, if it si not created this code will check
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        //If folder does not exists. Create it.
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    //save file in the specified folder and path
                    FileUploadPic.SaveAs(folderPath+filename.Trim());

                    //once file is uploaded show message to user in label control
                    lblSuccessMsg.Text = System.IO.Path.GetFileName(filename) + " has been uploaded.";
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "There was an error" + ex.Message;
            }
        }
    }
}