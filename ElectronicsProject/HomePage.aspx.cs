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
    public partial class Homepage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic; Integrated Security=True;");

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addprodwish"] = "false";
            Session["addproduct"] = "false";

            if (Session["username"] != null)
            {
                Label4.Text = "Logged in as " + Session["username"].ToString();
                HyperLink1.Visible = false;
                Button1.Visible = true;
            }
            else
            {
                Label4.Text = "Hello you can Login here...";
                HyperLink1.Visible = true;
                Button1.Visible = false;
            }

            if(!IsPostBack)
            {
                Drp_ProductCategory();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Homepage.aspx");
            Label4.Text = "You have logged out successfully...";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {                                 
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product where (Pname like '%" + TextBox1.Text + "%') or (Productid like '%" + TextBox1.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSourceID = null;
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewPrdtDetail")
            {
                Response.Redirect("ProductDetails.aspx?id=" + e.CommandArgument.ToString());
            }

            Session["addprodwish"] = "true";
            if (e.CommandName == "AddToWishlist")
            {
                DropDownList list = (DropDownList)(e.Item.FindControl("DropDownList1"));
                Response.Redirect("AddToWishlist.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + list.SelectedItem.ToString());
            }

            Session["addproduct"] = "true";
            if (e.CommandName == "AddToCart")
            {
                DropDownList list = (DropDownList)(e.Item.FindControl("DropDownList1"));                
                Response.Redirect("AddTocart.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + list.SelectedItem.ToString());
            }
        }

        public void Drp_ProductCategory()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Category", con);
            ProductCategories.DataSource = cmd.ExecuteReader();
            ProductCategories.DataTextField = "CategoryName";
            ProductCategories.DataValueField = "CategoryId";
            ProductCategories.DataBind();
            ProductCategories.Items.Insert(0, "Product Category");
            con.Close();
        }
        protected void ProductCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strQuery = "";
            string selectedProduct = ProductCategories.SelectedItem.Text;
            if (selectedProduct == "Product Category")
            {
                strQuery = "";
            }
            else
            {
                strQuery = "where Pcategory = '" + selectedProduct + "'";
            }
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product " + strQuery+"" , con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                if (selectedProduct == dt.Rows[0][6].ToString())
                {

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('No product found');</script>");
            }
            DataList1.DataSourceID = null;            
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label productID = e.Item.FindControl("Label6") as Label;
            Label stock = e.Item.FindControl("Label5") as Label;
            ImageButton btn = e.Item.FindControl("ImageButton1") as ImageButton;
            ImageButton btnWishList = e.Item.FindControl("ImageButton3") as ImageButton;
            DropDownList selectQuantity = (DropDownList)(e.Item.FindControl("DropDownList1"));
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product where ProductId= '" + productID.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            String stockdata = "";

            if (dt.Rows.Count > 0)
            {
                stockdata = dt.Rows[0]["Pquantity"].ToString();

            }
            con.Close();

            if (stockdata == "0")
            {
                stock.Text = "Out of Stock";
                btn.Enabled = false;
                btn.CssClass = "opacity: 30%;";
                selectQuantity.Enabled = false;
               // btn.ImageUrl = "Images/1.jpg";

            }
            else 
            {
                stock.Text = stockdata;
            }

            if(Session["username"] != null)
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("Select ProductId from WishListDetails where ProductId = '"+ productID.Text+"' and Email='"+Session["username"].ToString()+"'",con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                if (dt.Rows.Count == 1)
                {
                    btnWishList.ImageUrl = "images/Products/blue-heart.png";
                }
                else 
                {
                    btnWishList.ImageUrl = "images/Products/heart-outline.jpg";
                }
            }
        }
    }
}
