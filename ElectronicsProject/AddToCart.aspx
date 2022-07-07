<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="ElectronicsProject.AddToCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" style="margin:0 auto;">
            <h2 style="text-decoration:underline overline; color:darkcyan;" >You have following Products in your carts</h2>

            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" 
                NavigateUrl="~/HomePage.aspx">Continue Shopping</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;            
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" OnClick="LinkButton1_Click">Clear Cart</asp:LinkButton>

        <br/><br/>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                BorderStyle="None" BorderWidth="1px"  EmptyDataText="No Product Available in Shopping Cart" BorderColor="#3366CC"
                Font-Bold="True" Height="60px" ShowFooter="True" Width="1100px" BackColor="White" OnRowDeleting="GridView1_RowDeleting" >                
                <Columns>
                <asp:BoundField DataField="sno" HeaderText="Sr No.">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pid" HeaderText="Product ID">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="pimage" HeaderText="Product Image">
                    <ControlStyle Height="300px" Width="350px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:BoundField DataField="pname" HeaderText="Product Name">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                    <asp:BoundField DataField="pdesc" HeaderText="Description">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="pprice" HeaderText="Price">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pquantity" HeaderText="Quantity">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ptotalprice" HeaderText="Total Price">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ShowDeleteButton="True" DeleteText="Remove" />
            </Columns>
                <FooterStyle BackColor="#99CCCC" Font-Bold="True" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                
            </asp:GridView>
            <br/><br/>

            <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" Font-Bold="True" Font-Size="Large" Height="38px" Width="123px" OnClick="btnPlaceOrder_Click" BackColor="#66FF66" BorderStyle="Ridge" ForeColor="Blue" />
        </div>
    </form>
</body>
</html>
