<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ElectronicsProject.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <style type="text/css">
        /*.auto-style3 {
            width: 1106px;
        }*/
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="auto-style1" >
        <tr style="background-color:#5f98f3; width:1000px;" >
            <td colspan="2" style="text-align:right" >
                <asp:Label ID="Label4" runat="server" style="text-align:left" Font-Bold="True" Font-Italic="True"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/Login.aspx">Click Here To Login</asp:HyperLink>
                <asp:Button ID="Button1" runat="server" Text="Logout" BorderColor="White" Font-Bold="True" Height="22px" Width="105px" 
                    OnClick="Button1_Click" BackColor="#ff5050"  />
            </td>
            <td style="text-align:right">
                <asp:DropDownList ID="ProductCategories" AutoPostBack="true" BackColor="#5f98f3" Font-Bold="true" ForeColor="White" 
                    Font-Size="Medium" runat="server" OnSelectedIndexChanged="ProductCategories_SelectedIndexChanged" />&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2" Height="25px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton2" runat="server" Height="22px"  OnClick="ImageButton2_Click" Width="36px"
                    ImageUrl="~/images/Searchbar.jpeg" /> 

            </td>
        </tr>
    </table>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" DataKeyField="ProductId" Height="293px" Width="310px" 
        RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand" align="center" OnItemDataBound="DataList1_ItemDataBound">
        <ItemTemplate> 
            <table>
                <tr>
                    <td style="text-align:center; background-color:#5f98f3">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Pname") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="ImageButton4" runat="server" Height="240px" Width="306px" 
                            BorderColor="#5F98F3"  ImageUrl='<%# Eval("Pimage") %>' CommandName="ViewPrdtDetail" CommandArgument='<%# Eval("ProductId") %>' />

                        <%--<asp:Image ID="Image1" runat="server" Height="240px" Width="306px" 
                            BorderColor="#5F98F3" ImageUrl='<%# Eval("Pimage") %>'/>--%>
                        <div class="stock">
                            &nbsp;Stock:&nbsp;
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Pquantity") %>' 
                                BackColor='<%# (int)Eval("Pquantity") <= 10 ? System.Drawing.Color.Red : System.Drawing.Color.Green %>'/>
                        </div>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("ProductId") %>' Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center; background-color:#5f98f3">
                        <asp:Label ID="Label2" runat="server" Text="Price: Rs" Style="text-align:center"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Pprice") %>' Style="text-align:center"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>

                <tr align="center">
                    <td style="text-align:center; border-block-color:black">
                        <asp:ImageButton CssClass="btnWishlist" ID="ImageButton3"  runat="server" Height="42px" width="67px" 
                            CommandName="AddToWishlist"  CommandArgument='<%# Eval("ProductId") %>'  ImageUrl="~/images/Products/wishlist4.jpeg" />
                        &nbsp;&nbsp;
                        <span style="width:90px">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                         </span>
                        &nbsp;&nbsp;
                   <span>
                        <asp:ImageButton CssClass="btnCart" ID="ImageButton1" runat="server" CommandArgument='<%# Eval("ProductId") %>' 
                            Height="37px"  Width="150px" CommandName="AddToCart" ImageUrl="~/images/green-add-to-cart-button.png" />
                   </span>
                 </td>
                </tr>


            </table>
            <br/>
           
        </ItemTemplate>
    </asp:DataList>
   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Electronic %>" 
        SelectCommand="SELECT [ProductId], [Pname], [Pimage], [Pprice], [Pquantity], [Pcategory] FROM [Product]">

    </asp:SqlDataSource>
</asp:Content>
