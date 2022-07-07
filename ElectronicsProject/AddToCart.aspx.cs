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
    public partial class AddToCart : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Electronic; Integrated Security = true"); 
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["addproduct"] = "false";

            //Login Session
            if (!IsPostBack)
            {
                if (Session["buyitems"] == null)
                {
                    Response.Redirect("Login.aspx");
                }       

                //Adding product to GridView()
                Session["addproduct"] = "false";
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

                if (Request.QueryString["id"] != null)
                {
                    if (Session["buyitems"] == null)
                    {
                        dr = dt.NewRow();                        
                        SqlDataAdapter da = new SqlDataAdapter("Select * from Product where ProductId=" + Request.QueryString["id"], con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                        dr["pdesc"] = ds.Tables[0].Rows[0]["Pdesc"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
                        dr["pquantity"] = Request.QueryString["Pquantity"];
                        dr["pcategory"] = ds.Tables[0].Rows[0]["Pcategory"].ToString();

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["pprice"].ToString());
                        int Quantity = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * Quantity;
                        dr["ptotalprice"] = TotalPrice;

                        dt.Rows.Add(dr);

                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into CartDetails values ('"+dr["sno"] + "','" + dr["pid"] +"','"+dr["pname"] + "','"+dr["pdesc"] +"','"+dr["pimage"] + "','"+dr["pprice"]+"','"+dr["pquantity"]+"','"+dr["pcategory"]+"','"+Session["username"].ToString()+"')",con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        btnPlaceOrder.Enabled = true;

                        GridView1.FooterRow.Cells[5].Text = "Total Amount";
                        GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                        Response.Redirect("AddToCart.aspx");

                    }
                    else
                    {
                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        
                        SqlDataAdapter da = new SqlDataAdapter("select * from Product where ProductId=" + Request.QueryString["id"], con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = sr + 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                        dr["pdesc"] = ds.Tables[0].Rows[0]["Pdesc"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
                        dr["pquantity"] = Request.QueryString["quantity"];
                        dr["pcategory"] = ds.Tables[0].Rows[0]["Pcategory"].ToString();

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["pprice"].ToString());
                        int Quantity = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * Quantity;
                        dr["ptotalprice"] = TotalPrice;

                        dt.Rows.Add(dr);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into CartDetails values ('" + dr["sno"] + "','" + dr["pid"] + "','" + dr["pname"] + "','" + dr["pdesc"] + "','" + dr["pimage"] + "','" + dr["pprice"] + "','" + dr["pquantity"] + "','" + dr["pcategory"] + "','" + Session["username"].ToString() + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        btnPlaceOrder.Enabled = true;

                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                        Response.Redirect("AddToCart.aspx");
                    }                    
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count > 0)
                    {
                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                    }
                }
            }
            //string OrderDate = DateTime.Now.ToShortDateString();
            //Session["Orderdate"] = OrderDate;
            if(GridView1.Rows.Count.ToString() == "0")
            {
                LinkButton1.Enabled = false;
                LinkButton1.ForeColor = System.Drawing.Color.White;
                btnPlaceOrder.Enabled = false;
                btnPlaceOrder.Text = "Oops";
            }
            else
            {
                LinkButton1.Enabled = true;
                btnPlaceOrder.Enabled = true;
            }
            orderid();
        }

        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int totalprice=0;
            //nprice = Convert.ToIntss32(dt.Rows[i]["pprice"].ToString());
            while (i < nrow)
            {
                totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["ptotalprice"].ToString());
                i++;
                //Convert.ToInt32(dt.Rows[i]["pprice"].ToString())
            }

            return totalprice;
        }

        public void orderid()
        {
            String alpha = "abcdefghijKlmnopqrstuvwxyz0123456789";
            Random r = new Random();
            char[] myArray = new char[5];
            for (int i = 0; i < 5; i++)
            {
                myArray[i] = alpha[(int)(35 * r.NextDouble())];
            }
            String
            Orderid = "Order_Id: " + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString()
                + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + new string(myArray) + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            Session["Orderid"] = Orderid;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
                qdata = cell.Text;
                dtdata = sr.ToString();
                sr1 = Convert.ToInt32(qdata);
                TableCell prID = GridView1.Rows[e.RowIndex].Cells[1];                

                if (sr == sr1)
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();

                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete top(1) from CartDetails where ProductId='" + prID.Text + "' and Email='" + Session["username"] + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //Item has been deleted from Shopping Cart
                    break;
                }
            }
            // 5.Setting SNo.after deleting Row item from cart                       
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                 dt.Rows[i - 1]["sno"] = i;
                 dt.AcceptChanges();
            }

            Session["buyitems"] = dt;
            Response.Redirect("AddToCart.aspx");
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            bool isTrue = true;
            DataTable dt;
            dt = (DataTable)Session["buyitems"];
            if(dt.Rows.Count <= 0)
            {
                Response.Write("<script>alert('hii');</script>");
            }
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int pId = Convert.ToInt16(dt.Rows[i]["pid"]);
                int pQuantity = Convert.ToInt16(dt.Rows[i]["pquantity"]);
                SqlDataAdapter sda = new SqlDataAdapter("select Pquantity, Pname from Product where ProductId='" + pId + "'", con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                int quantity = Convert.ToInt16(dtbl.Rows[0][0]);
                if (quantity == 0)
                {
                    string pName = dtbl.Rows[0][1].ToString();
                    string msg = "" + pName + " is not in Stock.";
                    Response.Write("<script>alert('" + msg + "');</script>");
                    isTrue = false;
                }
            }
            if (GridView1.Rows.Count.ToString() == "0")
            {
                Response.Write("<script>alert('Your cart is empty, you cannot place an order.');</script>");
            }
            else
            {
                if (isTrue == true)
                {
                    Response.Redirect("PlaceOrder.aspx");
                }
            }
        
            //DataTable dt;
            //dt = (DataTable)Session["buyitems"];
            //for (int i = 0; i <= dt.Rows.Count - 1; i++)
            //{                
            //    con.Open();                

            //    string query = "INSERT INTO OrderDetails (Orderid, sno, Productid, Productname, Price, quantity, Orderdate, Status)"+ 
            //        "values ('" + Session["Orderid"] + "'," + dt.Rows[i]["sno"] + "," + dt.Rows[i]["pid"] + ",'" + 
            //        dt.Rows[i]["pname"].ToString() + "'," + dt.Rows[i]["pprice"] + "," + dt.Rows[i]["pquantity"] + ",'" + 
            //        Session["Orderdate"].ToString() + "','Pending')";

            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}            

            //if(dt.Rows.Count == -1)
            //{
            //    Response.Write("<script>alert('No products are there in the cart to place order');</script>");
            //}

            //if (Session["username"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            //else
            //{
            //    if (GridView1.Rows.Count.ToString() == "0")
            //    {
            //        Response.Write("<script>alert('Your Cart is Empty, You cannot place order');</script>");
            //    }
            //    else
            //    {
            //        Response.Redirect("PlaceOrder.aspx");
            //    }
            //}
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["buyitems"] = null;
            ClearWishList();
        }

        public void ClearWishList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from CartDetails where Email='" + Session["username"] + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AddToCart.aspx");
        }

    }
}