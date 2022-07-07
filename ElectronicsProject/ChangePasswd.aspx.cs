using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectronicsProject
{
    public partial class ChangePasswd : System.Web.UI.Page
    {
        string str = "Data Source =.; Initial Catalog=Electronic; Integrated Security=true;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Label1.Text = "Logged in as " + Session["username"].ToString();
                HyperLink1.Visible = false;
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ChangesPassword();
            try
            {
                string OldPasswd = txtOldPasswd.Text;
                string NewPasswd = txtNewPasswd.Text;
                string ConfrmPasswd = txtConfrmPasswd.Text;
                //string cs = ConfigurationManager.ConnectionStrings["Electronic"].ConnectionString;
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * RegDetails where Passwd = '" + OldPasswd + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dr.Read();
                    con.Close();
                    if (NewPasswd == ConfrmPasswd)
                    {
                        con.Open(); ;
                        //cmd = new SqlCommand("update RegDetails set Passwd ='" + txtNewPasswd.Text + "'
                        //where Passwd ='" + txtOldPasswd.Text + "' ", con);
                        cmd = new SqlCommand("update RegDetails set Passwd ='" + txtNewPasswd.Text + "'where username = @username ", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblMsg.Text = "Password has been changed successfully!";
                    }
                }
                else
                {
                    lblMsg.Text = "Invalid Password, Please enter correct Password";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error:" +ex.Message.ToString();
            }
        }
        
    }
}