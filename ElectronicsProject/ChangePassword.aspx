<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ElectronicsProject.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 507px;
            height: 147px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <center> <b> Change Password </b></center>

            <center>
            <table style="align-items:center" class="auto-style1">
                <tr>
                    <td>
                        Old Password:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        New Password:
                    </td>
                    <td>
                        
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm Password:
                    </td>
                    <td>
                        
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr colspan="2">
                    <td>
                        
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>
                
            </table>
          </center>
        </div>
    </form>
</body>
</html>
