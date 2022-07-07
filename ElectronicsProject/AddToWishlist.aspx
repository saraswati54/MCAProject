<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToWishlist.aspx.cs" Inherits="ElectronicsProject.AddToWishlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" style="margin:0 auto;">

            <h2 style="text-decoration:underline overline blink; color:#5f98f3"> You have following Products in your wishlist</h2>
            <br/>

            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" Font-Size="Large" NavigateUrl="~/HomePage.aspx">Continue Shopping</asp:HyperLink>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Clear Wishlist</asp:LinkButton>
            <br/><br/>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"  EmptyDataText="No Product Available in Wishlist"
                Font-Bold="True" Height="60px" ShowFooter="True" Width="1100px" OnRowDeleting="GridView1_RowDeleting" ForeColor="#333333" GridLines="None" >                
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:BoundField DataField="sno" HeaderText="Sr No.">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pid" HeaderText="Product ID">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="pimage" HeaderText="Product Image">
                    <ControlStyle Height="200px" Width="260px" />
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
                
                <asp:CommandField ShowDeleteButton="True" DeleteText="Remove" />
            </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                
            </asp:GridView>
            <br/><br/>

        </div>
    </form>
</body>
</html>
