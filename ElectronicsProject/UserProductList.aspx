<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProductList.aspx.cs" Inherits="ElectronicsProject.UserProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div align="center" style="height:auto">
                <div align="right">
                    <asp:LinkButton ID="AllOrder"  runat="server" OnClick="AllOrder_Click" BackColor="DarkOrchid" 
                        ForeColor="WhiteSmoke">Show all order list</asp:LinkButton>
                    &nbsp;
                </div>

                <asp:Label ID="Label1" runat="server" Text="Enter Order Id:" Height="24px" />
                &nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="true" width="168px" Height="29px" />
                &nbsp;
                <asp:Button ID="Button1" runat="server" Text="Click" Font-Bold="true" Height="39px" Width="72px" CssClass="button" 
                    OnClick="Button1_Click" BackColor="DarkOrchid" ForeColor="white"/>

                <br /><br />

                <asp:GridView ID="GridView1" runat="server" BackColor="#FF6699" BorderColor="#333333" OnRowDataBound="GridView1_RowDataBound" 
                    BorderWidth="5px" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="PrdtImage">
                            <ItemTemplate >
                                <%--<asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image") %>' Height="105px" Width="105px" />--%>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#Eval("Image") %>' Height="105px" Width="105px"
                                    CommandName="ViewPDF" CommandArgument='<%#Eval("Orderid") %>'/>
                            </ItemTemplate>                            
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <br/><br/>                
            </div>

            <div align="center">                
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HomePage.aspx" BackColor="DarkOrchid" Font-Bold="True" 
                    Font-Size="Large" BorderColor="White" ForeColor="WhiteSmoke">Back to Home Page</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UserProductStatus.aspx" BackColor="DarkOrchid" Font-Bold="True" 
                    Font-Size="Large" BorderColor="White" ForeColor="WhiteSmoke">Back to Previous Page</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>