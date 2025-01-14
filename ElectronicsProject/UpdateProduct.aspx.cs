﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace ElectronicsProject
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        string str = "Data Source=.; Initial Catalog=Electronic; Integrated Security=true ";
        int Productid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null && Session["role"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Convert.ToInt16(Session["role"]) == 3)
                {
                    Response.Redirect("HomePage.aspx");
                }
                ShowProduct();
            }
        }

        public void ShowProduct()
        {
            string condition;
            if(Convert.ToInt16(Session["role"]) == 2)
            {
                condition =@"where Email = '"+ Session["username"] + @"' and RoleId = "+ Session["role"];
            }
            else
            {
                condition = string.Empty;
            }
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Product "+ condition +" ",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowProduct();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DropDownList1.SelectedValue = "Select Category";
            ShowProduct();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label productID = (Label)row.FindControl("Label1");
            Productid = int.Parse(productID.Text.ToString());
            SqlConnection scon = new SqlConnection(str);
            SqlDataAdapter sd = new SqlDataAdapter("select * from Product where ProductId='" + Productid + "'", scon);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = Productid;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];

            FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
            if (fileUpload.HasFile)
            {
                Label productID = (Label)row.FindControl("Label1");
                TextBox pName = (TextBox)row.FindControl("TextBox1");
                TextBox pDesc = (TextBox)row.FindControl("TextBox2");
                TextBox pPrice = (TextBox)row.FindControl("TextBox3");
                TextBox pQuantity = (TextBox)row.FindControl("TextBox4");
                string pCategory = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[6].FindControl("DropDownList2")).Text;

                fileUpload.SaveAs(Server.MapPath("~/images/Products/") + Path.GetFileName(fileUpload.FileName));
                string pImage = "~/images/Products/" + Path.GetFileName(fileUpload.FileName);

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand scmd = new SqlCommand("update Product set Pname=@1, Pdesc=@2,Pimage=@3, Pprice=@4, Pquantity=@5, Pcategory=@6 where ProductId=@7", con);
                scmd.Parameters.AddWithValue("@1", pName.Text);
                scmd.Parameters.AddWithValue("@2", pDesc.Text);
                scmd.Parameters.AddWithValue("@3", pImage);
                scmd.Parameters.AddWithValue("@4", pPrice.Text);
                scmd.Parameters.AddWithValue("@5", pQuantity.Text);
                scmd.Parameters.AddWithValue("@6", pCategory);
                scmd.Parameters.AddWithValue("@7", productID.Text);
                scmd.ExecuteNonQuery();
                con.Close();
                GridView1.EditIndex = -1;
                Response.Write("<script>alert('Product Updated Successfully');</script>");
                ShowProduct();
              //  DropDownList1.SelectedValue = "Select Category";
            }
            else
            {
                Response.Write("<script>alert('Please select product image');</script>");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Cname = DropDownList1.SelectedValue.ToString();
            if (Cname == "Select Category")
            {
                ShowProduct();
            }
            else
            {
                string condition;
                if(Convert.ToInt16(Session["role"]) == 2)
                {
                    condition = @"and Email = '" + Session["username"] + @"' and RoleId = " + Session["role"];
                }
                else
                {
                    condition = string.Empty;
                }
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter sd = new SqlDataAdapter("select * from Product where Pcategory='" + Cname + "' "+ condition +" ", con);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}
