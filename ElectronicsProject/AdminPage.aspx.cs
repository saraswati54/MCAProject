using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectronicsProject
{
    public partial class Adminpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null && Session["role"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Label1.Text = "Welcome";
                    if (Convert.ToInt16(Session["role"]) == 1)
                    {
                        Label1.Text += " Admin"; //admin image
                    }
                    else if (Convert.ToInt16(Session["role"]) == 2)
                    {
                        Label1.Text += " Vendor";    //multi vendor image
                    }
                    else
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                }
            }
        }
    }
}