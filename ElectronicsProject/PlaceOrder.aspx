﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="ElectronicsProject.PlaceOrder1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" style="margin-top:50px; width:530px; height:563px; background-color:darkcyan" >
                <tr>
                    <td colspan="2" align="center" vertical-align:"top">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large"  Text="Card Details"></asp:Label>
                    </td>
                </tr>  
                
                <tr>
                    <td align="center" vertical-align:"top">
                        <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" Font-Bold="True"
                            Font-Size="Medium" Height="38px" Width="191px" placeholder="First Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is Empty" 
                            ControlToValidate="TextBox1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    .    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="First Name must be in Character." ControlToValidate="TextBox1"
                            ValidationExpression="^[A-Za-z]*$">*</asp:RegularExpressionValidator>
                    </td>                
                    <td align="center" vertical-align:"top">
                        <asp:TextBox ID="TextBox2" runat="server" BorderColor="Black" Font-Bold="True"
                            Font-Size="Medium" Height="38px" Width="191px" placeholder="Last Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is Empty" 
                            ControlToValidate="TextBox2" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ErrorMessage="Last Name must be in Character." ControlToValidate="TextBox2"
                            ValidationExpression="^[A-Za-z]*$">*</asp:RegularExpressionValidator>                    
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Image ID="Image1" runat="server" BorderColor="Black" BorderWidth="2px" Height="132px" ImageUrl="~/images/home/paypal-payment.png" Width="570px" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="center">                         
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Card Number"></asp:Label>                         
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="center" style="vertical-align:top">
                        <asp:TextBox ID="TextBox3" runat="server" BorderColor="Black" Font-Bold="True" TextMode="Password"
                            Font-Size="Medium" Height="38px" Width="563px" placeholder="16 Digits"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="Card No. is Empty" ForeColor="Red"
                            ControlToValidate="TextBox3" >*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ErrorMessage="Card No must of 16 Digits" ForeColor="Red" 
                            ControlToValidate="TextBox3" ValidationExpression="[0-9]{16}">*</asp:RegularExpressionValidator>
                    </td>                    
                </tr>

                <tr>
                    <td align="center">
                        
                        <asp:Label ID="Label3" runat="server" Text="Expiry Date" Font-Bold="True" Font-Size="Large" ></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="Label4" runat="server" Text="CVV"  Font-Bold="True" Font-Size="Large" ></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td  align="center" style="vertical-align:top" >
                        <asp:TextBox ID="TextBox4" runat="server" BorderColor="Black" Font-Bold="True" 
                            Font-Size="Medium" Height="38px" Width="188px" placeholder="MM/YY(06/1991)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ErrorMessage="Expiry Date is Empty" ForeColor="Red"
                            ControlToValidate="TextBox4" >*</asp:RequiredFieldValidator>
                    </td>
                    <td align="center" style="vertical-align:top" >
                        <asp:TextBox ID="TextBox5" runat="server" BorderColor="Black" Font-Bold="True" TextMode="Password"
                            Font-Size="Medium" Height="38px" Width="188px" placeholder="3 Digits"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ErrorMessage="CVV is Empty" ForeColor="Red"
                            ControlToValidate="TextBox5" >*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ErrorMessage="CVV must be of 3 digits" ForeColor="Red" 
                            ControlToValidate="TextBox5" ValidationExpression="[0-9]{3}">*</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="center" style="vertical-align:top"  >
                        <asp:TextBox ID="TextBox6" runat="server" BorderColor="Black" Font-Bold="True"
                            Font-Size="X-Large" Height="49px" Width="444px" placeholder="Billing Address" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ErrorMessage="Address is Empty" ForeColor="Red"
                            ControlToValidate="TextBox6" >*</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="center" >
                        <asp:Button ID="Button1" runat="server" BackColor="Black" 
                            BorderWidth="2px" Font-Size="Large" ForeColor="White"
                            Height="55px" Text="Submit" Width="188px" OnClick="Button1_Click" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" HeaderText="Fix the following errors" />

                    </td>
                </tr>
                <tr>                    
                    <td colspan="2">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AddToCart.aspx" Font-Bold="True" >Previous Page</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="True" NavigateUrl="~/Homepage.aspx" >Home Page</asp:HyperLink>
                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
