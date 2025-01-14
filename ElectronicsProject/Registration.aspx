﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ElectronicsProject.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">  
        .auto-style1 {            
            height: 697px;
            width: 625px;
        }
        .auto-style2{
            width:50%;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" height="744px" width="700">
        <div>
            <table class="auto-style1" align="center" style="background-color: #5f98f3;">
                <tr>
                    <td colspan="2" align="center">
                        <h2 style="font-size: x-large">Registration</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <b>First Name:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFname" runat="server" Height="30px" Width="178px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFname"
                            ErrorMessage="First Name is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFname"
                            ErrorMessage="Only Characters." ForeColor="Red" ValidationExpression="^[A-Za-z]*$" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <b>Last Name:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLname" runat="server" Height="30px" Width="178px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLname"
                            ErrorMessage="Last Name is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
                        &nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLname"
                            ErrorMessage="Only Characters." ForeColor="Red" ValidationExpression="^[A-Za-z]*$" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <b>Email ID:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Height="30px" Width="178px" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email ID is empty." ForeColor="Red">*</asp:RequiredFieldValidator>  
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display = "Dynamic"
                        ValidationExpression= "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            ErrorMessage = "Invalid email address" ControlToValidate="txtEmail" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <b>Gender:</b>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropGender" runat="server" Height="30px" Width="182px">
                            <asp:ListItem>Select gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dropGender"
                            ErrorMessage="Gender is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <b>Address:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Height="30px" Width="178px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress"
                            ErrorMessage="Address is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <b>Phone No:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" Height="30px" Width="178px" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhone"
                            ErrorMessage="Phone No. is empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                        &nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPhone"
                            ErrorMessage="Invalid Phone No." ForeColor="Red" ValidationExpression="[0-9]{10}" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <b>Password:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPasswd" runat="server" Height="30px" Width="178px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPasswd"
                            ErrorMessage="Password is empty." ForeColor="Red" >*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <b>Confirm Password:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfmPasswd" runat="server" Height="30px" Width="178px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConfmPasswd"
                            ErrorMessage="Confirm Password is empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPasswd"
                            ControlToValidate="txtConfmPasswd" ErrorMessage="Password should be matched." ForeColor="Red" />                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" Height="35px" Width="150px"
                            OnClick="btnRegister_Click" Font-Bold="True" Font-Size="Large" />
                        <br />
                        <asp:Label ID="lblMsg" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" >
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Height="70px" />
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>--%>
            </table>
        </div>
    </form>
</body>
</html>
