<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="ElectronicsProject.PlaceOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" style="margin-top:50px; width:531px; height:563px; background-color:darkcyan;">
                <tr>
                    <td colspan="2" align="center" style="vertical-align:top">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Font-Size="XX-Large" Text="Card Details">
                        </asp:Label> 
                    </td>
                </tr>
                <tr>
                    <td align="center" style="vertical-align:top">
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="First Name" BackColor="White" BorderColor="Black" 
                            BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is Empty" 
                            ControlToValidate="TextBox1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[A-Za-z]*$"
                            ErrorMessage="First Name must be in character" ControlToValidate="TextBox1" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                    <td align="center" style="vertical-align:top">
                        <asp:TextBox ID="TextBox2" runat="server" placeholder="First Name" BackColor="White" BorderColor="Black" 
                            BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is Empty" 
                            ControlToValidate="TextBox2" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[A-Za-z]*$"
                            ErrorMessage="Last Name must be in character" ControlToValidate="TextBox2" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Image ID="Image1" runat="server" BorderColor="Black" BorderWidth="2px" ImageUrl="~/images/paypal-payment.png" 
                            Width="438px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label2" runat="server" Text="Card Number" Font-Bold="True" ForeColor="White" 
                            Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="vertical-align:top">
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="16 Digits" BackColor="White" BorderColor="Black" 
                            BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="442px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Card Number is Empty" 
                            ControlToValidate="TextBox3" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="[0-9]{16}"
                            ErrorMessage="Card Number must be of 16 Digit" ControlToValidate="TextBox3" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>                    
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label3" runat="server" Text="Expiry Date" ForeColor="White" Font-Bold="true" 
                            Font-Size="Large"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="Label4" runat="server" Text="CVV" ForeColor="White" Font-Bold="true" 
                            Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="vertical-align:top">
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="MM/YY(Eg.061996)" BackColor="White" BorderColor="Black" 
                            BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Expiry Date is Empty" 
                            ControlToValidate="TextBox4" ForeColor="Red">*</asp:RequiredFieldValidator>                        
                    </td>
                    <td align="center" style="vertical-align:top">
                        <asp:TextBox ID="TextBox5" runat="server" placeholder="3 Digits" BackColor="White" BorderColor="Black" 
                            BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="CVV is Empty" 
                            ControlToValidate="TextBox5" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="[0-9]{3}"
                            ErrorMessage="CVV must be of 3 Digit" ControlToValidate="TextBox5" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="vertical-align:top">
                        <asp:TextBox ID="TextBox6" runat="server" placeholder="Billing Address" BackColor="White" Height="50px" Width="188px"
                            BorderWidth="2px" BorderColor="Black" Font-Bold="True" Font-Size="X-Large"  TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Billing address is Empty" 
                            ControlToValidate="TextBox6" ForeColor="Red">*</asp:RequiredFieldValidator>                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="Black" BorderColor="White" BorderWidth="2px" 
                            Font-Bold="True" Font-Size="Large" ForeColor="White" Width="188px" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" HeaderText="Fix the following errors" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/AddToCart.aspx">Previous Page</asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" NavigateUrl="~/Homepage.aspx">Home Page</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
