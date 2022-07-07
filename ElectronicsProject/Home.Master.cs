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
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //counting no. of products present in shopping cart
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt = (DataTable)Session["buyitems"];
            dt = (DataTable)Session["wishListItems"];
            if (dt != null)
            {
                Label2.Text = dt.Rows.Count.ToString();
            }
            else
            {
                Label2.Text = "0";
            }


            if(dt2 != null)
            {
                Label2.Text = dt2.Rows.Count.ToString();
            }
            else
            {
                Label2.Text = "0";
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int i = ran.Next(1, 8);     //should have to create images as 1.jpg , 2.jpg , 3.jpg , 4.jpg , 3.jpg
            {
                Image2.ImageUrl = "~/images/" + i.ToString() + ".jpg";
                Image2.Width = 1150;
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddToCart.aspx");
        }
       
        protected void iBtnDeliveryStatus_Click(object sender, ImageClickEventArgs e)
        {
            if(Session["username"] != null)
            {
                string userId = Session["username"].ToString();
                SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic; Integrated Security=true;");
                SqlDataAdapter sda = new SqlDataAdapter("Select * from OrderDetails where Email='" + userId + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count >0)
                {
                    Response.Redirect("UserProductStatus.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void iBtnWishlist_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("AddToWishlist.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            

        }
    }
}