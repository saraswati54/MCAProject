﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="ElectronicsProject.Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="DOWNLOAD INVOICE"
                Font-Bold="True" Height="62px" Width="298px"
                OnClick="Button1_Click" ForeColor="Silver" />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Homepage.aspx"
                Width="227px" Font-Bold="True" Font-Size="Large"
                Height="39px">Go TO HOME PAGE</asp:HyperLink>
            
            
            
            <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderWidth="2px">
                <table border="1">
                    <tr>
                        <td style="text-align:center">                         
                                  <h2 style="text-align:center">Retail Invoice</h2>    
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Order No:
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            <br/><br/>
                            Order Date:
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        Buyer Address:<br/>
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        Seller Address:<br/><br/>
                                        Vamsh Electronics,Pune, Maharashtra..
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="1000px">
                                <Columns>
                                    <asp:BoundField DataField="sno" HeaderText="SNo">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="productid" HeaderText="Product Id">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="productname" HeaderText="Product Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="quantity" HeaderText="Quantity">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="price" HeaderText="Price">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="totalprice" HeaderText="Total Price">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>                                                      
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Grand Total:
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                           <b> This is computere generated invoice and does not required signature.</b>
                        </td>
                    </tr>
                     
                </table>

            </asp:Panel>
        </div>
    </form>
</body>
</html>
