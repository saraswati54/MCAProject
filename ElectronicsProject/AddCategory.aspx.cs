﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace ElectronicsProject
{
    public partial class AddCategory : System.Web.UI.Page
    {
        string str = "Data Source =.; Initial Catalog=Electronic; Integrated Security=true;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["admin"] == null) 
                {
                    Response.Redirect("Login.aspx");
                }
                else if(Convert.ToInt16(Session["role"]) == 2)
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else if (Convert.ToInt16(Session["role"]) == 3)
                {
                    Response.Redirect("HomePage.aspx");
                }

                ShowGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Category where CategoryName= '" + TextBox1.Text.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                Response.Write("<script>alert('This category already present');</script>");
            }
            else
            {
                SqlConnection scon = new SqlConnection(str);
                scon.Open();
                SqlCommand cmd = new SqlCommand("insert into Category values(@Cname)", scon);
                cmd.Parameters.AddWithValue("@Cname", TextBox1.Text);
                cmd.ExecuteNonQuery();
                scon.Close();
                Response.Write("<script>alert('One record added.');</script>");
                TextBox1.Text = "";
                ShowGrid();
            }
        }

        public void ShowGrid()
        {
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Category", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ShowGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int cId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("Delete from Category where CategoryId =@1", con1);
            cmd1.Parameters.AddWithValue("@1", cId);
            cmd1.ExecuteNonQuery();
            con1.Close();
            Response.Write("<script>alert('Category deletion successful');</script>");
            ShowGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int cId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string categoryName = (row.FindControl("TextBox2") as TextBox).Text;
            SqlConnection con2 = new SqlConnection(str);
            con2.Open();
            SqlCommand cmd1 = new SqlCommand("update category set CategoryName=@1 where CategoryId=@2", con2);
            cmd1.Parameters.AddWithValue("@1", categoryName);
            cmd1.Parameters.AddWithValue("@2", cId);
            cmd1.ExecuteNonQuery();
            con2.Close();
            Response.Write("<script>alert('Category updation successful');</script>");
            GridView1.EditIndex = -1;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowGrid();
        }
    }
}