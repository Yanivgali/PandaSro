<%@ Page Title="UpdateStore" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateStore.aspx.cs" Inherits="YanivProject_UpdateStore" %>

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
    background-color:#222222;
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

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">     
    <asp:RadioButtonList ID="rblupdate" runat="server" style="margin-left:100px;" ForeColor="Silver" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">       
          <asp:ListItem>Update 1 Item</asp:ListItem>
        <asp:ListItem>Update All Items</asp:ListItem>
    </asp:RadioButtonList>
 <asp:Panel ID="Panel1" runat="server" style="position:center; text-align:center;">
             <asp:RadioButtonList ID="rblRace" runat="server" style="color:white; position:absolute; top:15%; left: 40%;" AutoPostBack="True" OnSelectedIndexChanged="rblRace_SelectedIndexChanged">
            <asp:ListItem>Ch</asp:ListItem>
            <asp:ListItem>Eu</asp:ListItem>
    </asp:RadioButtonList>
        <asp:DropDownList ID="ddlname" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlname_SelectedIndexChanged">
        <asp:ListItem>Choose weapon</asp:ListItem>
    </asp:DropDownList><center>
    <asp:GridView ID="grdStore" Visible="false" style="width:100px; height:100px; margin-top:200px; border: solid 2px black;" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" BackColor="Black" ForeColor="Red" >
         <Columns>
          <asp:TemplateField HeaderText="Weapon img">
            <ItemTemplate>      
           &nbsp;<asp:Image ID="img" runat="server" Height="67px" ImageUrl='<%# "Pictures/zWeapons/"+Eval("WeaponImg")%>' Style="position: static" Width="80px" />
            </ItemTemplate>          
            </asp:TemplateField>
        </Columns>                                                     
        </asp:GridView></center>
   <center><asp:Label ID="Label1" runat="server" ForeColor="White" Text="Change price:"></asp:Label> <asp:TextBox ID="txtupdateprice" runat="server" type="number" requried=""></asp:TextBox> <asp:Label ID="lbl" Visible="false" runat="server" BackColor="White" Text="Price before update:"></asp:Label> <asp:Label ID="lblBPrice" Visible="false" runat="server" BackColor="White" Text="Label"></asp:Label>
<asp:Button ID="Button1" runat="server" Text="Button" ForeColor="red" BackColor="Black" OnClick="Button1_Click"/>     <asp:Label ID="lblsucc" runat="server" ForeColor="Green" Text="Price update succsfuly."></asp:Label></center>
</asp:Panel>
    <asp:Panel ID="pnlupdateall" runat="server"><center>
    <asp:GridView ID="grdupdateall" style="width:100px; height:100px; margin-top:70px; border: solid 2px black;" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" BackColor="Black" ForeColor="Red" OnPageIndexChanging="grdStore_PageIndexChanging">
         <Columns>
          <asp:TemplateField HeaderText="Weapon img">
            <ItemTemplate>      
           &nbsp;<asp:Image ID="Image1" runat="server" Height="67px" ImageUrl='<%# "Pictures/zWeapons/"+Eval("WeaponImg")%>' Style="position: static" Width="80px" />
            </ItemTemplate>          
            </asp:TemplateField>
        </Columns>                                                     
        </asp:GridView></center>
         <center><asp:Label ID="Label2" runat="server" ForeColor="White" Text="Enter percent:"></asp:Label> <asp:TextBox ID="txtupdateall" runat="server" placeholder="Example:0<x<100" type="number" requried=""></asp:TextBox> 
             <asp:RadioButtonList ID="rblPrecent" runat="server" AutoPostBack="True" style="color:white;" OnSelectedIndexChanged="rblPrecent_SelectedIndexChanged"><asp:ListItem selected >Price increase</asp:ListItem> <asp:ListItem>Discount</asp:ListItem>
             </asp:RadioButtonList><asp:Button ID="Button2" runat="server" BackColor="Black" ForeColor="white" OnClick="Button2_Click" style="height: 27px" Text="Button" />
             <asp:Label ID="lblsuucall" runat="server" ForeColor="Green" Text="Price update succsfuly."></asp:Label></center></asp:Panel>
</asp:Content>

