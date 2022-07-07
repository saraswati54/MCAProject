<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProductStatus.aspx.cs" Inherits="ElectronicsProject.UserProductStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" />        
    <style>
        .progress{
            /*width:300px;*/            
        }
        ul{
            text-align:center;
        }
        ul li{
            display:inline-block;
            width:200px;
            position:relative;
        }
        ul li .fa{
            background:#ccc;
            width:16px;
            height:16px;
            color:white;
            border-radius:50%;
            padding:5px;
        }
        ul li .fa::after{
            content:'';
            background:#ccc;
            height:5px;
            width:105px;
            display:block;
            position:absolute;
            left:0;
            top:10px;
            z-index:-1;
        }
        ul li:nth-child(1) .fa{
            background:#148e14;
        }
        ul li:nth-child(1) .fa::after{
            background:#148e14;
        }
        ul li:first-child .fa::after{
            width:105px;
            left:100px;
        }
        ul li:first-child .fa::after{
            width:105px;
        }
    </style>
</head>
<body style="background-repeat:no-repeat; background-position:right bottom ; background-image:url(images/home/bg_transport-van1.png);
       background-position-x:1000px; background-position-y:450px;">
    <form id="form1" runat="server">

        <div align="center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <marquee direction="left" scrollamount='<%# val %>' runat="server">
                <center>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/delivery-truck11.png"></asp:Image>
                </center>
            </marquee>
            <hr style="color:red; border:solid;" />
            &nbsp;&nbsp;
            <h1 style="color:#ff0000;">Recent Delivery Status</h1>
            <b>Order Id:</b> <asp:Label ID="lblOrderId" runat="server" ForeColor="#9933FF" Font-Bold="True" />
        </div>

        <br />
 
        <div class="progress">
            <ul >
                <li>
                    <i class="fa fa-check" aria-hidden="true"></i>
                    <p><b>Dispatched</b></p>
                </li>
                <li>
                    <i class="fa fa-check" aria-hidden="true"></i>
                    <p><b>Delivered</b></p>
                </li>
            </ul>
        </div>

        <br /><br />
        
        <div align="center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UserProductList.aspx" BackColor="#009900" Font-Bold="True" 
                Font-Size="Large" BorderColor="White" ForeColor="WhiteSmoke">Want to check all ordered products?</asp:HyperLink>
        </div>
        
        <br />
        
        <div align="center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/HomePage.aspx" BackColor="DarkOrchid" Font-Bold="True" 
                Font-Size="Large" BorderColor="White" ForeColor="WhiteSmoke">Back to Home Page</asp:HyperLink>
        </div>
    </form>
</body>
</html>