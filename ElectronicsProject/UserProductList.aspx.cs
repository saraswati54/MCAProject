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
    public partial class UserProductList : System.Web.UI.Page
    {
        string emailId;
        SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic; Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                emailId = Session["username"].ToString();
                //SqlDataAdapter sda = new SqlDataAdapter("select OrderId as oderid, productname as Productname, price as Price, quantity as Quantity, orderdate as Orderdate, status as Status from OrderDetails where Orderdate='" + TextBox1.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter("select odr.orderid as OrderId, odr.productname as Productname,pdt.Pimage as Image, odr.price as Price, odr.quantity as Quantity, odr.orderdate as Orderdate, odr.status as Status from OrderDetails odr inner join Product pdt on pdt.ProductId = odr.productid where odr.email='" + emailId + "' and odr.orderid like '" + TextBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string status = dt.Rows[0][6].ToString();
                    if (status == "Pending" || status == "pending")
                    {
                        dt.Rows[0][6] = "Dispached";
                    }
                    else
                    {
                        dt.Rows[0][6] = "Delivered";
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                    Response.Write("<script>alert('please enter valid order id..');</script>");
            }
        }

        protected void AllOrder_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                emailId = Session["username"].ToString();
                SqlDataAdapter sda = new SqlDataAdapter("select odr.orderid as OrderId, odr.productname as Productname,pdt.Pimage as Image, odr.price as Price, odr.quantity as Quantity, odr.orderdate as Orderdate, odr.status as Status from OrderDetails odr inner join Product pdt on pdt.ProductId = odr.productid where Email='" + emailId + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string status;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    status = dt.Rows[i][6].ToString();
                    if (status == "Pending" || status == "pending")

                    {
                        dt.Rows[i][6] = "Dispached";
                    }
                    else
                    {
                        dt.Rows[i][6] = "Delivered";
                    }
                    status = "";
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();
                TextBox1.Text = string.Empty;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text == "Delivered")
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                }
            }
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[3].Visible = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewPDF")
            {
                Session["Orderid"] = e.CommandArgument.ToString();
                Response.Redirect("Invoice.aspx");
            }
        }
    }
}