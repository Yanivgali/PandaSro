<%@ Page Title="Store2" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Store2.aspx.cs" Inherits="YanivProject_Store2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"><script>
function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = checkTime(m);
    s = checkTime(s);

    var sss =  h + ":" + m + ":" + s;

    document.getElementById("<%=txttime.ClientID%>").innerHTML =
    h + ":" + m + ":" + s;
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
}
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" style="position:center; text-align:center;">
        <asp:RadioButtonList ID="rblRace" runat="server" style="color:white; position:relative; top:0%; left: 45%;" AutoPostBack="True" OnSelectedIndexChanged="rblRace_SelectedIndexChanged">
            <asp:ListItem>Ch</asp:ListItem>
            <asp:ListItem>Eu</asp:ListItem>
    </asp:RadioButtonList>
    <asp:DropDownList ID="ddlname" runat="server" style="position:absolute;" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlname_SelectedIndexChanged">
        <asp:ListItem>Choose weapon</asp:ListItem>
    </asp:DropDownList>
</asp:Panel>
    <asp:Panel ID="pnlCheckout" runat="server" align="center" style="position:center;"><div align="right"><li style="color:lightblue;"><span class="glyphicon glyphicon-time"></span>Current Time:&nbsp<label id="txttime" runat="server" ></label></li></div>
         <br />
               <asp:Image ID="imgweapon" runat="server" Style="border:groove; height:200px; width:150px; position:absolute; top:22%; left:25%;"/>
  <asp:Label ID="lblcoupon" runat="server" Text="Label" ForeColor="White">Enter coupon code(if you have):</asp:Label><asp:TextBox ID="txtcoupon" runat="server"></asp:TextBox><asp:Label ID="lblcosucc" runat="server" forecolor="green" Text="Coupon have been used succsfuly."></asp:Label><asp:Label ID="lblnotexist" ForeColor="Red" runat="server" Text="This coupon dosent exist!"></asp:Label><asp:Button ID="btncheek" runat="server" Text="Cheek coupon" OnClick="btncheek_Click" /><br />
        <asp:Label ID="Label3" runat="server" Text="Enter Visa: " ForeColor="white"></asp:Label><asp:TextBox ID="txtvisa" type="number" runat="server"  required=""></asp:TextBox>
        <br />
                <asp:Label ID="Label4" runat="server" Text="Visa Holder: " ForeColor="white"></asp:Label><asp:TextBox ID="txtVisaholder" type="text" runat="server"  required=""></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="Expired Date: " ForeColor="white"></asp:Label><asp:TextBox ID="txtexpiredate" type="text" runat="server"  required=""></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="CVC: " ForeColor="white"></asp:Label><asp:TextBox ID="txtCVC" type="number" runat="server"  required=""></asp:TextBox>
                <br />        <asp:Label ID="Label7" runat="server" Text="Price: " ForeColor="white"></asp:Label>
        <asp:Label ID="lbltotalprice" runat="server" Text="" ForeColor="White"></asp:Label>
        <asp:Button ID="btnOrder" runat="server" Text="End Order" BackColor="Black" BorderColor="Yellow" ForeColor="Red" OnClick="btnOrder_Click"  />
                <asp:Label ID="lblerr" runat="server" ForeColor="Red" Text="Informtion is incorrect, Try agian."></asp:Label>
                <asp:Label ID="lblsucc" runat="server" Text="The order was successful" style="color:lime;"></asp:Label>

    </asp:Panel>
</asp:Content>

