<%@ Page Title="Your Cart" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="YanivProject_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
.mydatagrid
{
    width: 80%;
    border: solid 2px black;
    min-width: 80%;
}
.header
{
    background-color: #646464;
    font-family: Arial;
    color: White;
    border: none 0px transparent;
    height: 25px;
    text-align: center;
    font-size: 16px;
}
 
.rows
{
    background-color: #fff;
    font-family: Arial;
    font-size: 14px;
    color: #000;
    min-height: 25px;
    text-align: left;
    border: none 0px transparent;
}
.rows:hover
{
    background-color: #222222;
    font-family: Arial;
    color: #fff;
    text-align: left;
}
.selectedrow
{
    background-color: #ff8000;
    font-family: Arial;
    color: #fff;
    font-weight: bold;
    text-align: left;
}
.mydatagrid a /** FOR THE PAGING ICONS  **/
{
    background-color: Transparent;
    padding: 5px 5px 5px 5px;
    color: #fff;
    text-decoration: none;
    font-weight: bold;
}
 
.mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/
{
    background-color: #000;
    color: #fff;
}
.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
{
    background-color: #c9c9c9;
    color: #000;
    padding: 5px 5px 5px 5px;
}
.pager
{
    background-color: #646464;
    font-family: Arial;
    color: White;
    height: 30px;
    text-align: left;
}
 
.mydatagrid td
{
    padding: 5px;
}
.mydatagrid th
{
    padding: 5px;
}
 .button_cont{
    border-radius: 4px;
    background: linear-gradient(to right,#000000f2,#d60a0a3d) !important;
    border: none;
    text-align: center;
    padding: 20px;
    margin: auto;
    width: 14%;
    transition: all 0.4s;
 }  
 .button_cont span {
   cursor: pointer;
   display: inline-block;
   position: relative;
   transition: 0.4s;
            z-index: 1;
            left: 686px;
            top: 1029px;
        }
 .button_cont span:after {
   color:white;
   content: '\00bb';
   position: absolute;
   opacity: 0;
   top: -12px;
   right: -20px;
   transition: 0.5s;
 }
 .button_cont:hover span {
   padding-right: 25px;
 }
 .button_cont:hover span:after {
   opacity: 1;
   right: 0;
 }
 .test{
    background-color: transparent;
    border: none;
    color:white;
 }
        </style>     
<script>
function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = checkTime(m);
    s = checkTime(s);
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
    <center><asp:GridView ID="grdCart" style="width:100px; height:100px; border: solid 2px black;" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" BackColor="Black" ForeColor="Red" OnRowDeleting="grdCart_RowDeleting" OnPageIndexChanging="grdCart_PageIndexChanging">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete from your cart" ShowHeader="True" Text="X" />
        </Columns>  
        <Columns>  
          <asp:TemplateField HeaderText="Weapon img">
            <ItemTemplate>      
           &nbsp;<asp:Image ID="img" runat="server" Height="67px" ImageUrl='<%# Eval("Weaponimg","{0}")%>' Style="position: static" Width="80px" />
            </ItemTemplate>          
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount">
    <ItemTemplate>
               <asp:DropDownList runat="server" ID="ddlamount" AutoPostBack="True" ForeColor="#550A21" EnableViewState="true"  Text='<%# Bind("Amount") %>' OnSelectedIndexChanged="ddlamount_SelectedIndexChanged" >
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
               </asp:DropDownList>
        
</ItemTemplate>
</asp:TemplateField>
        </Columns>                                                     
        </asp:GridView></center>
    <div runat="server" class="button_cont" align="center"><asp:Button ID="btn" class="test" target="_blank" rel="nofollow" runat="server" Text="Check out" OnClick="btn_Click"/>
    </div><center><asp:Label ID="lblempty" runat="server" Text="Your cart is empty!" style="color:red;"></asp:Label></center>
    <asp:Panel ID="pnlCheckout" runat="server" align="center">
       <div align="right"><li style="color:lightblue;"><span class="glyphicon glyphicon-time"></span>Current Time:&nbsp<asp:label id="txttime" runat="server" ></asp:label></li></div>
         <br />
        <asp:Label ID="lblcoupon" runat="server" Text="Label" ForeColor="White">Enter coupon code(if you have):</asp:Label><asp:TextBox ID="txtcoupon" runat="server"></asp:TextBox><asp:Label ID="lblcosucc" runat="server" forecolor="green" Text="Coupon have been used succsfuly."></asp:Label><asp:Label ID="lblnotexist" ForeColor="Red" runat="server" Text="This coupon dosent exist!"></asp:Label><asp:Button ID="btncheek" runat="server" Text="Cheek coupon" OnClick="btncheek_Click" style="height: 27px" /><br />
        <asp:Label ID="Label3" runat="server" Text="Enter Visa: " ForeColor="white"></asp:Label><asp:TextBox ID="txtvisa" type="number" runat="server"  required=""></asp:TextBox><br />
                <asp:Label ID="Label4" runat="server" Text="Visa Holder: " ForeColor="white"></asp:Label><asp:TextBox ID="txtVisaholder" type="text" runat="server"  required=""></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="Expired Date: " ForeColor="white"></asp:Label><asp:TextBox ID="txtexpiredate" type="text" runat="server"  required=""></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="CVC: " ForeColor="white"></asp:Label><asp:TextBox ID="txtCVC" type="number" runat="server"  required=""></asp:TextBox>
                <br />        <asp:Label ID="Label7" runat="server" Text="Total Price: " ForeColor="white"></asp:Label>
        <asp:Label ID="lbltotalprice" runat="server" Text="Label" ForeColor="White"></asp:Label>
        <asp:Button ID="btnOrder" runat="server" Text="End Order" BackColor="Black" BorderColor="Yellow" ForeColor="Red" OnClick="btnOrder_Click"  />
                <asp:Label ID="lblerr" runat="server" ForeColor="Red" Text="Information is incorrect, Try agian."></asp:Label>
                <asp:Label ID="lblsucc" runat="server" Text="The order was successful" style="color:lime;"></asp:Label>
    </asp:Panel>
</asp:Content>
