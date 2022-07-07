<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswd.aspx.cs" Inherits="ElectronicsProject.ChangePasswd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 5px;
        }
        .auto-style2 {
            width: 696px;
            height: 346px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <center>
            <table  class="auto-style2">
        <tr>
            <td class="auto-style1" style="text-align:left">
                &nbsp;</td>
            <td colspan="2" style="text-align:left">
                <asp:Label ID="Label1" runat="server" ></asp:Label>
                Hello <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Click Here To Login</asp:HyperLink>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td colspan="2">
                <span class="style18">&nbsp;Change Password</span></td>
        </tr>
        <tr>
            <td style="color: #000000" rowspan="4" class="auto-style1">
                &nbsp;</td>
            <td style="color: #000000">
                Enter Old Password:</td>
            <td>
                <asp:TextBox ID="txtOldPasswd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtOldPasswd" Display="Dynamic" 
                    ErrorMessage="Enter your old password" SetFocusOnError="True" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Enter New Password:</td>
            <td>
                <asp:TextBox ID="txtNewPasswd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNewPasswd" Display="Dynamic" 
                    ErrorMessage="Enter your old password" SetFocusOnError="True" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password:</td>
            <td>
                <asp:TextBox ID="txtConfrmPasswd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtNewPasswd" ControlToValidate="txtConfrmPasswd" 
                    ErrorMessage="Invalid Password" ForeColor="Red">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnChangePasswd" runat="server" Text="Change Password" 
                    onclick="Button1_Click" style="text-align: center" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td colspan="2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
    </table>
             </center>
        </div>
            
    </form>
</body>
</html>
