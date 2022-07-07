using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ElectronicsProject
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic; Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into RegDetails" + "(Fname, Lname, Email, Gender, Address, Phone, Passwd) values (@Fname, @Lname, @Email, @Gender, @Address, @Phone, @Passwd)", con);
            
            cmd.Parameters.AddWithValue("@Fname", txtFname.Text);
            cmd.Parameters.AddWithValue("@Lname", txtLname.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Gender", dropGender.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Passwd", txtPasswd.Text);
            
            cmd.ExecuteNonQuery();
            con.Close();
            lblMsg.Text = "Welcome, Registration Successful!";
            Response.Write("<script>alert('Registered Successfully !!');</script>");
            Response.Redirect("Login.aspx");
        }
    }
}