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
    public partial class ManageRoles : System.Web.UI.Page
    {
        string str = "Data Source=.; Initial Catalog=Electronic; Integrated Security=true ";
        int AccountId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null && Session["role"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Convert.ToInt16(Session["role"]) == 2)
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else if (Convert.ToInt16(Session["role"]) == 3)
                {
                    Response.Redirect("HomePage.aspx");
                }
                ShowAccUsers();

            }
        }

            public void ShowAccUsers()
            {
                string condition;
                SqlConnection con = new SqlConnection(str);
                if (Convert.ToInt16(Session["role"]) == 2)
                {
                    condition = @"where Email = '" + Session["username"] + @"' and RoleId = " + Session["role"];
                }
                else
                {
                    condition = string.Empty;
                }
                
                SqlDataAdapter sda = new SqlDataAdapter("select u.Id concat(Fname ,' ', Lname) Name, u.Email, u.RoleId, r.RoleName from RegDetails u inner join Role r on u.RoleId = r.RoleId ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = AccountId;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];

            
                Label accountId = (Label)row.FindControl("Label1");
                string roleId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[3].FindControl("ddlRoles")).Text;

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand scmd = new SqlCommand("update RegDetails set RoleId=@1 where Id=@2", con);
                
                scmd.Parameters.AddWithValue("@1", roleId);
                scmd.Parameters.AddWithValue("@2", accountId.Text);
                scmd.ExecuteNonQuery();
                con.Close();
                GridView1.EditIndex = -1;
                Response.Write("<script>alert('Role Updated Successfully');</script>");
                ShowAccUsers();
                //  ddlRoles.SelectedValue = "Select Users";
            
                
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label accountID = (Label)row.FindControl("Label1");
            AccountId = int.Parse(accountID.Text.ToString());
            SqlConnection scon = new SqlConnection(str);
            SqlDataAdapter sd = new SqlDataAdapter("select u.Id concat(Fname,' ', Lname) Name, u.Email, u.RoleId, r.RoleName from RegDetails u inner join Role r on u.RoleId = r.RoleId where u.Id='"+ AccountId+"' ", scon);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowAccUsers();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            //ddlRoles.SelectedValue = "Select Users";
            ShowAccUsers();
        }

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int roleId = Convert.ToInt16(ddlRoles.SelectedValue.ToString()); 
        //    if (roleId == 0)
        //    {
        //        ShowAccUsers();
        //    }
        //    else
        //    {
                
        //        SqlConnection con = new SqlConnection(str);
        //        SqlDataAdapter sd = new SqlDataAdapter("select u.Id, concat(Fname,' ', Lname) Name, u.Email, u.RoleId, r.RoleName from RegDetails u inner join Role r on u.RoleId = r.RoleId ", con);
        //        DataTable dt = new DataTable();
        //        sd.Fill(dt);
        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();
        //    }
        //}

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int roleId = Convert.ToInt16(ddlRoles.SelectedValue.ToString());
            if (roleId == 0)
            {
                ShowAccUsers();
            }
            else
            {
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter sd = new SqlDataAdapter("select u.Id, concat(Fname,' ', Lname) Name, u.Email, u.RoleId, r.RoleName from RegDetails u inner join Role r on u.RoleId = r.RoleId ", con);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
    
}