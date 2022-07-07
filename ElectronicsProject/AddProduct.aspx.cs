using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ElectronicsProject
{
    public partial class addCategory1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null && Session["role"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Session["username"] != null && Convert.ToInt16(Session["usertype"]) == 2)
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else if (Convert.ToInt16(Session["role"]) == 3)
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(Session["username"] != null && Session["role"] != null)
            {
                SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic; Integrated Security=true");
                if (imageUpload.HasFile)
                {
                    string fileName = imageUpload.PostedFile.FileName;
                    string filePath = "images/Products/" + imageUpload.FileName;
                    imageUpload.PostedFile.SaveAs(Server.MapPath("~/images/Products/") + fileName);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Product values('" + txtName.Text + "','" + txtDesc.Text + "','" + filePath + "','" + txtPrice.Text + "','" + txtQuantity.Text + "','" + DropDownList1.SelectedItem.Text + "', '"+ Session["admin"] + "', '" + Session["role"] + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Product added successfully.');</script>");
                }
            }
            
        }
    }
}