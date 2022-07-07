<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ElectronicsProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">        
        .auto-style1 {
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table align="center" >
                <tr>
                    <td colspan="2" align="center">
                        <asp:Image ID="Image1" runat="server" Height="73px" Width="95px" ImageUrl="~/images/Login Icon.png" />
                    </td>                       
                </tr>
                <tr>
                    <td colspan="2" align="center"><h2>Login</h2></td>                       
                </tr>
                <tr>
                    <td><b>Email Id: </b></td>
                    <td> <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><b>Password:</b></td>
                    <td>
                        <asp:TextBox ID="txtPasswd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" class="auto-style1">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="41px" OnClick="ImageButton1_Click" Width="131px" ImageUrl="~/images/download (1).jpg" />
                       <%-- <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click1" />--%>                        
                    </td>                  
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" Text="New User?" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style1" >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddProducts.aspx">Add Product</asp:HyperLink>--%>
                        <asp:LinkButton align="right" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Register Here..</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
