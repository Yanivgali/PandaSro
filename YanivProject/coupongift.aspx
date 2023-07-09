<%@ Page Title="" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="coupongift.aspx.cs" Inherits="YanivProject_coupongift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <center><asp:DropDownList ID="ddlus" runat="server" AutoPostBack="True" DataTextField="UserName" DataValueField="UserName" AppendDataBoundItems="True" DataSourceID="AccessDataSource1">
        <asp:ListItem>Select User to gift</asp:ListItem>
    </asp:DropDownList>        
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/YanivGali_DB.mdb" SelectCommand="SELECT [UserName] FROM [TblUser]"></asp:AccessDataSource>
   <asp:Label runat="server" Text="You must choose user name to gift!" ForeColor="Red" ID="lblchoose"></asp:Label>
        <asp:Label ID="lblsend" runat="server" Text="Label" ForeColor="Green">Gift send succsfuly to user gmail.</asp:Label>
   <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></center>
</asp:Content>

