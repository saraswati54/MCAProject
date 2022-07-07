<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ElectronicsProject.ProductDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Product Detail</title>
   <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" />
    <style>
        .card:hover{
            -webkit-box-shadow: -1px 9px 40px -12px rgba(0,0,0,0.75);
            -moz-box-shadow: -1px 9px 40px -12px rgba(0,0,0,0.75);
            box-shadow: -1px 9px 40px -12px rgba(0,0,0,0.75);
        }
    </style>
</head> 

<body>
    <form id="form1" runat="server">
        <div align="center">
            <center>
                <h2> Product Detail </h2>
            </center>
            <asp:DataList ID="DataList1" runat="server"  DataKeyField="ProductId" DataSourceID="SqlDataSource2" OnItemCommand="DataList1_ItemCommand"  >   
                <ItemTemplate>
                    <div class="container" >
                        <div class="row">
                            <div class="col-12-lg mt-2">
                                <div class="card" style="width:28rem;">
                                    <asp:Image ID="Image2" runat="server" CssClass="card-img-top" ImageUrl='<%# Eval("Pimage")%>'
                                        AlternateText="Product Image"  />         
                                <div class="card-body bg-dark">
                                    <h4 class="card-title text-white"><%# Eval("Pname")%> </h4>
                                    <h5 class="card-title text-white">Price: Rs<%# Eval("Pprice")%></h5>
                                    <p class="card-text text-white">Description: <br/><%# Eval("Pdesc")%></p>
                                    <%--<p class="card-text text-white">Category: <br/><%# Eval("Pcategory")%></p>--%>
                                    <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server"  
                                        Text="Add to Cart" CommandArgument='<%# Eval("ProductId")%>' Commandname="AddToCart"/>
                                </div>
                              </div>
                            </div>
                        </div>
                    </div>
                    
<%--                    <div>
                        <table style="border-color:black"
                        <tr>
                        </tr>
                        <tr>
                            <td style="text-align:center; ">
                                <asp:Image ID="Image1" runat="server" BorderColor="#5F98F3" Height="240px" ImageUrl='<%# Eval("Pimage") %>' Width="306px" />
                            </td>
                            <tr>
                                <td style="text-align:center; background-color:#5f98f3">
                                    <asp:Label ID="Label6" runat="server" Style="text-align:center" Text='<%# Eval("Pcategory") %>'></asp:Label>
                                    <br/>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:center; background-color:black">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="White" Text='<%# Eval("Pname") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:center; background-color:#5f98f3">
                                    <asp:Label ID="Label3" runat="server" Style="text-align:center" Text="Price: Rs"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Style="text-align:center" Text='<%# Eval("Pprice") %>'></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            </tr>
                            <tr>
                                <td style="text-align:center; background-color:#5f98f3">
                                    <asp:Label ID="Label2" runat="server" Style="text-align:center" Text='<%# Eval("Pdesc") %>'></asp:Label>
                                    <br/>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:center">
                                    <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("ProductId")%>' CommandName="AddToCart" Height="33px" Text="Add Cart" Width="125px" />
                                </td>
                            </tr>
                        </tr>
                       
                    </table>
                        
                        
                  </div>
                --%>
                  <%--  
                    <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                    <br />
                    Pname:
                    <asp:Label ID="PnameLabel" runat="server" Text='<%# Eval("Pname") %>' />
                    <br />
                    Pdesc:
                    <asp:Label ID="PdescLabel" runat="server" Text='<%# Eval("Pdesc") %>' />
                    <br />
                    Pimage:
                    <asp:Label ID="PimageLabel" runat="server" Text='<%# Eval("Pimage") %>' />
                    <br />
                    Pprice:
                    <asp:Label ID="PpriceLabel" runat="server" Text='<%# Eval("Pprice") %>' />
                    <br />
                    Pcategory:
                    <asp:Label ID="PcategoryLabel" runat="server" Text='<%# Eval("Pcategory") %>' />
                    <br />
                    <br />--%>
                    
                </ItemTemplate>
            </asp:DataList>
            
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Electronic %>"
                SelectCommand="SELECT [ProductId], [Pname], [Pdesc], [Pimage], [Pprice], [Pcategory] FROM [Product] WHERE ([ProductId] = @ProductId)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ProductId" QueryStringField="id" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            
        </div>
    </form>
</body>
</html>
