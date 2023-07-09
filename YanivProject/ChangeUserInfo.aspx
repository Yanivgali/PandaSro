<%@ Page Title="Change user info" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeUserInfo.aspx.cs" Inherits="YanivProject_ChangeUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <center>
    <asp:DropDownList runat="server" AutoPostBack="True" ID="ddlt">
        <asp:ListItem>Choose Info to change</asp:ListItem>
        <asp:ListItem>ChangeUserName</asp:ListItem>
        <asp:ListItem>ChangePassword</asp:ListItem>
        <asp:ListItem>ChangeEmail</asp:ListItem>
    </asp:DropDownList>   
    <asp:Panel runat="server" ID="pnlEmail" >
    <asp:Label ID="Label1" style="background-color:red; color:white;" runat="server" Text="Up date your Email:"></asp:Label><asp:TextBox ID="txtupEmail" runat="server"></asp:TextBox></asp:Panel>
    <asp:Panel runat="server" ID="pnlUsername">
    <asp:Label ID="Label2" style="background-color:red; color:white;" runat="server" Text="Up date your UserName:"></asp:Label><asp:TextBox ID="txtupdateUserName" runat="server"></asp:TextBox></asp:Panel>
        <asp:Panel runat="server" ID="pnlPassword">
    <asp:Label ID="Label3" style="background-color:red; color:white;" runat="server" Text="Up date your Password:"></asp:Label><asp:TextBox ID="txtupdatepassword" runat="server"></asp:TextBox></asp:Panel>
    <asp:Label style="background-color:red; color:white;" runat="server" Text="You need to change at least one thing pls try agian." ID="lblerr"></asp:Label>
    <asp:Label style="background-color:red; color:white;" runat="server" Text="This UserName alredy in use/or not valid." ID="lblusernamet"></asp:Label>
    <asp:Label style="background-color:red; color:white;" runat="server" Text="This Email alredy in use/or not valid." ID="lblemailt"></asp:Label>
    <asp:Label style="color:green;" runat="server" Text="Your Id have been change successfully." ID="lblsucc"></asp:Label>
         <asp:Button runat="server" style="background-color:red; color:white;" ID="btnacc" OnClick="btnacc_Click" Text="Change Settings" />
    </Center>
</asp:Content>

