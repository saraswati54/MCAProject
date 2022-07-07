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
    public partial class UserProductStatus : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=Electronic; integrated Security=true;");
        public int val;


        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Status();
                DataBind();
            }
        }

        public void Status()
        {
            if(Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string status = "";
                string orderId = "";
                string userid = Session["username"].ToString();

                SqlDataAdapter sda = new SqlDataAdapter("select * from OrderDetails inner join (select max(orderdate) as LatestDate, Email as UserId from OrderDetails Group by Email) SubMax on OrderDetails.orderdate = LatestDate and OrderDetails.Email = SubMax.userid where Email='"+ userid +"'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count == 1)
                {
                    orderId = dt.Rows[0][0].ToString();
                    status = dt.Rows[0][7].ToString();
                    lblOrderId.Text = orderId;
                    val = 25;

                    SqlDataAdapter sda1 = new SqlDataAdapter("select * from OrderDetails where Email='" + userid + "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    if(dt1.Rows.Count > 1)
                    {
                        HyperLink1.Visible = true;
                    }
                    else
                    {
                        HyperLink1.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                if(status == "Completed")
                {
                    val = 0;
                    Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\"type=\"text/css\" href=\"" + ResolveUrl("~/css/Statusstyle.css") + "\"/>"));
                }
            }
        }
    }
}