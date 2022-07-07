using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ElectronicsProject
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic;Integrated Security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CardDetails (FName, LName, CardNo, ExpiryDate, CVV, BillingAddr) values(@FName,@LName,@CardNo,@ExpiryDate, @CVV, @BillingAddr)", con);
            cmd.Parameters.AddWithValue("@FName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@CardNo", TextBox3.Text);
            cmd.Parameters.AddWithValue("@ExpiryDate", TextBox4.Text);
            cmd.Parameters.AddWithValue("@CVV", TextBox5.Text);
            cmd.Parameters.AddWithValue("@BillingAddr", TextBox6.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Payment Made Successful..!')</script>");
            Session["address"] = TextBox6.Text;
            Response.Redirect("Pdf_generate.aspx");
        }
    }
}