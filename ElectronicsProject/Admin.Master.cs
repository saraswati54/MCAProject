using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectronicsProject
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["username"] == null && Session["role"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

            int usertype = Convert.ToInt16(Session["role"]);
                
            if(usertype == 1)
            {
                Image1.ImageUrl = "~/images/mipp-admin-banner.jpg";    //admin image
            }
            else if (usertype == 2)
            {
                Image1.ImageUrl = "~/images/venbanner.jpg";    //multi vendor image
            }
            if (usertype == 2)
            {
                btnCategory.Visible = false;
                btnOrderStatus.Visible = false;
                btnManageRole.Visible = false;
            }
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProduct.aspx");
        }

        protected void btnOrderStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderStatus.aspx");
        }

        protected void btnManageRole_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRoles.aspx");
        }
    }
}