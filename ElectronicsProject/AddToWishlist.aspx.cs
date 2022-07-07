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
    public partial class AddToWishlist : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic; Integrated Security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //check login or not
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                //Adding product to gridview
                //Adding product to GridView()

                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("pid");
                dt.Columns.Add("pname");
                dt.Columns.Add("pimage");
                dt.Columns.Add("pdesc");
                dt.Columns.Add("pprice");
                dt.Columns.Add("pcategory");

                if (Request.QueryString["id"] != null)
                {
                    if (Session["wishListItems"] == null)
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
                        dr["pcategory"] = ds.Tables[0].Rows[0]["Pcategory"].ToString();

                        dt.Rows.Add(dr);

                        con.Open();
                        SqlCommand cmd = new SqlCommand("Insert into WishListDetails values ('" + dr["sno"] + "','" + dr["pid"] + "','" + dr["pname"] + "','" + dr["pdesc"] + "','" + dr["pimage"] + "','" + dr["pprice"] + "','" + dr["pcategory"] + "','" + Session["username"].ToString() + "')", con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["wishListItems"] = dt;
                        Response.Redirect("HomePage.aspx");

                    }
                    else
                    {
                        dt = (DataTable)Session["wishListItems"];
                        bool isTrue = false;
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();

                        SqlDataAdapter da = new SqlDataAdapter("select * from Product where ProductId=" + Request.QueryString["id"], con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        int esist = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductId"].ToString());

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            int pid = Convert.ToInt32(dt.Rows[i]["pid"].ToString());
                            if (esist == pid)
                            {
                                isTrue = true;
                                break;
                            }
                        }

                        if (!isTrue)
                        {
                            dr["sno"] = sr + 1;
                            dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                            dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                            dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                            dr["pdesc"] = ds.Tables[0].Rows[0]["Pdesc"].ToString();
                            dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();

                            dt.Rows.Add(dr);
                            con.Open();
                            SqlCommand cmd = new SqlCommand("Insert into WishListDetails values ('" + dr["sno"] + "','" + dr["pid"] + "','" + dr["pname"] + "','" + dr["pdesc"] + "','" + dr["pimage"] + "','" + dr["pprice"] + "','" + dr["pcategory"] + "','" + Session["username"].ToString() + "')", con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Session["wishListItems"] = dt;
                            Response.Redirect("HomePage.aspx");
                        }
                        else
                        {

                            DataTable dt2 = new DataTable();
                            dt2 = (DataTable)Session["wishListItems"];
                            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                            {
                                int id;
                                int prdID;
                                string prdata = Request.QueryString["id"].ToString();

                                prdID = Convert.ToInt32(prdata);
                                id = Convert.ToInt32(dt2.Rows[i]["pid"].ToString());
                                if (id == prdID)
                                {
                                    dt2.Rows[i].Delete();
                                    dt2.AcceptChanges();
                                    con.Open();
                                    SqlCommand cmd = new SqlCommand("Delete from WishListDetails where ProductId='" + prdID + "' and Email='" + Session["username"] + "' ", con);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    break;
                                }
                            }
                            Session["wishListItems"] = dt2;
                            Response.Redirect("HomePage.aspx");
                        }
                    }
                }
                else
                {
                    dt = (DataTable)Session["wishListItems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

            if (GridView1.Rows.Count.ToString() == "0")
            {
                LinkButton1.Enabled = false;
                LinkButton1.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                LinkButton1.Enabled = true;
            }
        
        }
            
            

            

    
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();           
            dt = (DataTable)Session["wishListItems"];
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
                    SqlCommand cmd = new SqlCommand("delete top(1) from WishListDetails where ProductId='" + prID.Text + "' and Email='" + Session["username"] + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //Item has been deleted from Shopping Cart
                    break;
                }
            }
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["sno"] = 1;
                dt.AcceptChanges();
            }
            Session["wishListItems"] = dt;
            Response.Redirect("AddToWishlist.aspx");

        }
        public void ClearWishList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from WishListDetails where Email='" + Session["username"] + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AddToWishlist.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}