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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if(!IsPostBack)
            {
                if(Session["username"] != null && Convert.ToInt16(Session["usertype"]) == 1)
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else if (Session["username"] != null && Convert.ToInt16(Session["usertype"]) == 2)
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else if (Session["username"] != null && Convert.ToInt16(Session["usertype"]) == 3)
                {
                    Response.Redirect("HomePage.aspx");
                }
            }            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic; Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from RegDetails where Email='" + txtEmail.Text + "' and Passwd='" + txtPasswd.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (txtEmail.Text == "Admin@gmail.com" && txtPasswd.Text == "123")
            {
                Session["admin"] = txtEmail.Text;
                Session["role"]=1;
                Response.Redirect("AdminPage.aspx");                
            }
            else if (dt.Rows.Count == 1)
            {
                if (Convert.ToInt16(dt.Rows[0]["RoleId"]) == 2)
                {
                    Session["username"] = txtEmail.Text;
                    Session["role"] = dt.Rows[0]["RoleId"];
                    Response.Redirect("AdminPage.aspx");
                }
                else
                {
                    Session["username"] = txtEmail.Text;
                    Session["role"] = dt.Rows[0]["RoleId"];
                    Session["buyitem"] = null;
                    Session["wishListItems"] = null;
                    fillSavedCart();
                    fillWishList();
                    Response.Redirect("Homepage.aspx");
                    //LinkButton1.Visible = true;
                    //HyperLink1.Visible = false;
                }
            }
            else
            {
               Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Login Failed..";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        private void fillSavedCart()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("pid");
            dt.Columns.Add("pname");
            dt.Columns.Add("pimage");
            dt.Columns.Add("pdesc");
            dt.Columns.Add("pprice");
            dt.Columns.Add("pquantity");
            dt.Columns.Add("pcategory");
            dt.Columns.Add("ptotalprice");

            string conStr = "Data Source=.; Initial Catalog=Electronic; Integrated Security=true";
            SqlConnection con = new SqlConnection(conStr);
            string query = "select * from CartDetails where Email='" + Session["username"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if(ds.Tables[0].Rows.Count >0)
            {
                int i = 0;
                int counter = ds.Tables[0].Rows.Count;
                while(i < counter)
                {
                    dr = dt.NewRow();
                    dr["sno"] = i + 1;
                    dr["pid"] = ds.Tables[0].Rows[i]["ProductId"].ToString();
                    dr["pname"] = ds.Tables[0].Rows[i]["Pname"].ToString();
                    dr["pimage"] = ds.Tables[0].Rows[i]["Pimage"].ToString();
                    dr["pdesc"] = ds.Tables[0].Rows[0]["Pdesc"].ToString();
                    dr["pprice"] = ds.Tables[0].Rows[i]["Pprice"].ToString();
                    dr["pquantity"] = ds.Tables[0].Rows[i]["Pquantity"].ToString();
                    dr["pcategory"] = ds.Tables[0].Rows[0]["Pcategory"].ToString();
                    int price = Convert.ToInt32(ds.Tables[0].Rows[i]["pprice"].ToString());
                    int quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["pquantity"].ToString());
                    int totalPrice = price * quantity;
                    dr["ptotalprice"] = totalPrice;
                    dt.Rows.Add(dr);
                    i = i + 1;
                }
            }
            else
            {
                Session["buyitems"] = null;
            }
            Session["buyitems"] = dt;
        }

        //after logged in it will fetch all wishlist items which were added by that user previously & storing it in session
        private void fillWishList()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("pid");
            dt.Columns.Add("pname");
            dt.Columns.Add("pimage");
            dt.Columns.Add("pdesc");
            dt.Columns.Add("pprice");
            dt.Columns.Add("pcategory");

            string mycon = "Data Source=.; Initial Catalog=Electronic; Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            string myquery = "select * from WishListDetails where Email='" + Session["username"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(myquery, con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int i = 0;
                int counter = ds.Tables[0].Rows.Count;
                while (i < counter)
                {
                    dr = dt.NewRow();
                    dr["sno"] = i + 1;
                    dr["pid"] = ds.Tables[0].Rows[i]["ProductId"].ToString();
                    dr["pname"] = ds.Tables[0].Rows[i]["Pname"].ToString();
                    dr["pimage"] = ds.Tables[0].Rows[i]["Pimage"].ToString();
                    dr["pdesc"] = ds.Tables[0].Rows[0]["Pdesc"].ToString();
                    dr["pprice"] = ds.Tables[0].Rows[i]["Pprice"].ToString();
                    dr["pcategory"] = ds.Tables[0].Rows[0]["Pcategory"].ToString();
                   
                    dt.Rows.Add(dr);
                    i = i + 1;
                }
            }
            else
            {
                Session["wishListItems"] = null;
            }
            Session["wishListItems"] = dt;
        }
    }
}