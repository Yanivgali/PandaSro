<%@ Page Title="Final payment" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="YanivProject_Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="stylePage/css/Test.css" rel="stylesheet" />
      <script>
function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById("<%=txt.ClientID%>").innerHTML =
    h + ":" + m + ":" + s;
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
}
    </script> 
      <style>
        image
        {
            height:170px;
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <center><h1 style="color:yellow;">Checkout</h1><hr class="style-two" /></center>
                <div id="f1_container">
                <div id="f1_card" class="shadow">
                <div class="front face">    
                    <asp:Label ID="Lblitemname1" runat="server" Text="Label" ForeColor="White" style="margin-left:35%; color:black;"></asp:Label>
                    <hr class="style-two"/><br />
                    <asp:Label ID="lbldiscription" runat="server" Text="Label" ForeColor="White"></asp:Label>
                    <asp:Label ID="lblRace" runat="server" Text="Label" ForeColor="Red" style="margin-left:90%;" ></asp:Label>
                    <asp:Image ID="itemimage1" runat="server" style="height:205px;width:100%;border-width:0px; margin-left:5px; margin-top:23px;"/>
                </div>
                </div>
                </div>
                <div runat="server" style="margin-left:48%; border:groove; width:500px; margin-top:10px; margin-bottom:100px;">
                <li style="color:lightblue;"><span class="glyphicon glyphicon-time"></span>Current Time:&nbsp<asp:label id="txt" runat="server"></asp:label></li><br />
                <asp:Label ID="lblcoupon" runat="server" Text="Label" ForeColor="White">Enter coupon code(if you have):</asp:Label><asp:TextBox ID="txtcoupon" runat="server"></asp:TextBox><asp:Label ID="lblcosucc" runat="server" forecolor="green" Text="Coupon have been used succsfuly."></asp:Label><asp:Label ID="lblnotexist" ForeColor="Red" runat="server" Text="This coupon dosent exist!"></asp:Label><asp:Button ID="btncheek" runat="server" Text="Cheek coupon" formnovalidate="" OnClick="btncheek_Click" /><br />
                <asp:Label ID="Label3" runat="server" Text="Enter Visa: " ForeColor="white"></asp:Label><asp:TextBox ID="txtvisa" type="number" runat="server"  required=""></asp:TextBox><br />
                <asp:Label ID="Label4" runat="server" Text="Visa Holder: " ForeColor="white"></asp:Label><asp:TextBox ID="txtvisaholder" type="text" runat="server"  required=""></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="Expired Date: " ForeColor="white"></asp:Label><asp:TextBox ID="txtexpiredate" type="text" runat="server"  required=""></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="CVC: " ForeColor="white"></asp:Label><asp:TextBox ID="txtCVC" type="number" runat="server"  required=""></asp:TextBox>
                <br />
             <asp:Label ID="Label2" runat="server" Text="Choose Weapon Amount: " ForeColor="white"></asp:Label>
        <asp:DropDownList ID="ddlamount" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>100</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="Label1" runat="server" Text="Weapon Price: " ForeColor="white"></asp:Label>
        <asp:Label ID="lblitemprice1" runat="server" Text="Label" ForeColor="White"></asp:Label><br />
        <asp:Button ID="btnOrder" runat="server" Text="End Order" BackColor="Black" BorderColor="Yellow" ForeColor="Red" OnClick="btnOrder_Click"  />
                    <asp:Label ID="lblerr" runat="server" ForeColor="Red" Text="Informtion is incorrect, Try agian."></asp:Label>
                <asp:Label ID="lblsucc" runat="server" Text="The order was successful" style="color:lime;"></asp:Label>
                <br />
    </div>
</asp:Content>
