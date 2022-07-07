using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectronicsProject
{
    public partial class PlaceOrder1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.; Initial Catalog=Electronic; Integrated Security=true");
        bool isTrue = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {                       
            if(Session["buyitems"] != null && Session["orderid"] !=null)
            {
                DataTable dt = (DataTable)Session["buyitems"];
                for(int i = 0; i <= dt.Rows.Count-1; i++)
                {
                    string pId = dt.Rows[i]["pid"].ToString();
                    int pQuantity = Convert.ToInt16(dt.Rows[i]["pquantity"]);
                    SqlDataAdapter sda = new SqlDataAdapter("select Pquantity from Product where ProductId='" + pId + "'", con);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    int quantity = Convert.ToInt16(dtbl.Rows[0][0]);
                    if(quantity > 0)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into OrderDetails(OrderId,sno,ProductId,Productname,Price,Quantity,Orderdate,Status, Email)" +
                        "values('" + Session["orderid"] + "'," + dt.Rows[i]["sno"] + "," + dt.Rows[i]["pid"] + ",'" + dt.Rows[i]["pname"] + "'," +
                        dt.Rows[i]["pprice"] + "," + dt.Rows[i]["pquantity"] + ",'" + DateTime.Now.ToString() + "','Pending','"+Session["username"].ToString()+"')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                decreaseQuantity();
                Payment();
                clearCart();
                Session["buyitems"] = null;
                Response.Redirect("Invoice.aspx");
            }
            else
            {
                Response.Redirect("AddToCart.aspx");
            }
        }

        public void decreaseQuantity()
        {
            DataTable dt = (DataTable)Session["buyitems"];
            for(int i = 0; i <= dt.Rows.Count-1;i++ )
            {
                int pId = Convert.ToInt16(dt.Rows[i]["pid"]);
                int pQuantity = Convert.ToInt16(dt.Rows[i]["pquantity"]);
                SqlDataAdapter sda = new SqlDataAdapter("select Pquantity from Product where ProductId='" + pId + "'", con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                int quantity = Convert.ToInt16(dtbl.Rows[0][0]);
                if(quantity > 0)
                {
                    int reduceQuantity = quantity - pQuantity;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Product set Pquantity ='" + reduceQuantity + "' where ProductId ='" + pId + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }
            }
        }
        public void clearCart()
        {
            if(Session["username"] != null)
            {
                DataTable dt = (DataTable)Session["buyitems"];
                for(int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    int pId = Convert.ToInt32(dt.Rows[i]["pid"]);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CartDetails where Email='" + Session["username"] + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }            
        }

        public void Payment()
        {
            if (isTrue == true)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CardDetails " + "(Fname, Lname, CardNo, ExpiryDate, CVV, BillingAddr) values (@Fname, @Lname, @CardNo, @ExpiryDate, @CVV, @BillingAddr)", con);
                cmd.Parameters.AddWithValue("@Fname", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Lname", TextBox2.Text);
                cmd.Parameters.AddWithValue("@CardNo", TextBox3.Text);
                cmd.Parameters.AddWithValue("@ExpiryDate", TextBox4.Text);
                cmd.Parameters.AddWithValue("@CVV", TextBox5.Text);
                cmd.Parameters.AddWithValue("@BillingAddr", TextBox6.Text);

                cmd.ExecuteNonQuery();
                con.Close(); 
            }
            Session["address"] = TextBox6.Text;
        }
    }
}