<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ChangesPassword.aspx.cs" Inherits="ElectronicsProject.ChangesPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       
        .auto-style3 {
            width: 202px;
        }
        .auto-style4 {
            width: 202px;
            height: 30px;
        }
       
        .auto-style5 {
            width: 937px;
            height: 253px;
            margin-left: 317px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
     <div>
          <table align="center" class="auto-style1" >
        <tr style="background-color:#5f98f3; width:1100px;" >
            <td colspan="2" style="text-align:right" class="auto-style3">
                <asp:Label ID="Label4" runat="server" style="text-align:left" Font-Bold="True" Font-Italic="True"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/Login.aspx">Click Here To Login</asp:HyperLink>
                <asp:Button ID="Button1" runat="server" Text="Logout" BorderColor="White" Font-Bold="True" Height="27px" Width="105px" 
                    OnClick="Button1_Click" BackColor="#ff5050"  />
            </td>
            <td style="text-align:right">
                <asp:DropDownList ID="ProductCategories" AutoPostBack="true" BackColor="#5f98f3" Font-Bold="true" ForeColor="White" 
                    Font-Size="Medium" runat="server"  />&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2" Height="25px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton2" runat="server" Height="29px"   Width="36px"
                    ImageUrl="~/images/home/search-icon.png" /> 

            </td>
        </tr>
    </table>
     </div>
    
       <table class="auto-style5" >
        <tr>
            <td class="auto-style4" style="text-align:left">
                <asp:Label ID="Label1" runat="server" ></asp:Label>
                Hello <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Login.aspx">Click Here To Login</asp:HyperLink>
                </td>
            <td colspan="2" style="text-align:left" >
                &nbsp;</td>
        </tr>
        <tr>
            
            <td colspan="2">
                <span class="style18">&nbsp;Change Password</span></td>
        </tr>
        <tr>
            <td class="auto-style3">
                Enter Old Password:</td>
            <td>
                <asp:TextBox ID="txtOldPasswd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtOldPasswd" Display="Dynamic" 
                    ErrorMessage="Enter your old password" SetFocusOnError="True" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            </td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                Enter New Password:</td>
            <td>
                <asp:TextBox ID="txtNewPasswd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNewPasswd" Display="Dynamic" 
                    ErrorMessage="Enter your old password" SetFocusOnError="True" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
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
                     style="text-align: center" />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" >
                &nbsp;</td>
            <td colspan="2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
    </table>
         
</asp:Content>
