<%@ Page Title="Delete Item from store" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="DeletefromStore.aspx.cs" Inherits="YanivProject_DeletefromStore" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <div id="asd">
       <center><asp:GridView ID="grdWeapons" FooterStyle-BackColor="YellowGreen" runat="server" style="width:100px; height:100px; border: solid 2px black;" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" BackColor="Black" ForeColor="Red" OnRowDeleting="grdWeapons_RowDeleting" OnPageIndexChanging="grdWeapons_PageIndexChanging">
           
            <Columns> 
                <asp:ButtonField ButtonType="Button" Text="X" CommandName="Delete" />
            </Columns>
          <Columns>
          <asp:TemplateField HeaderText="Weapon img">
            <ItemTemplate>      
           &nbsp;<asp:Image ID="Image1" runat="server" Height="67px" ImageUrl='<%# "Pictures/zWeapons/"+Eval("WeaponImg")%>' Style="position: static" Width="80px" />
            </ItemTemplate>          
            </asp:TemplateField>
        </Columns>
        </asp:GridView></center>
    </div>
</asp:Content>

