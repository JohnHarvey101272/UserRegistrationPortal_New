using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistrationPortal
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //Server side validation if Javascript is disabled on browser
            if (Page.IsValid)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("spAddUser", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@UserNo", txtUserNo.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        lblStatus.Text = "User created successully";
                        txtUserName.Text = String.Empty;
                        txtUserNo.Text = String.Empty;
                        Response.Redirect("~/UserInformationPage.aspx");
                    }
                    catch (Exception ex)
                    {
                        MsgBox("Error = " + ex.Message.ToString(), this.Page, this);
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        lblStatus.Text = "Validation Failed! User not created";
                    }
                    finally
                    {
                        con.Close();
                        con.Dispose();
                    }
                }
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Validation Failed! User not created";
            }
        }
    }
}
