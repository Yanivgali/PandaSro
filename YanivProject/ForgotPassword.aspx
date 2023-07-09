 <%@ Page Title="Recover Password" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="YanivProject_ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
        <h1><center>Verfication Page:</center></h1><hr />
                    <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Enter your UserName:"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter your UserName"></asp:TextBox>
                <asp:Label ID="lblun" runat="server" CssClass="auto-style2" ForeColor="Red" Text="This User name isn't Exists!"></asp:Label><br />
       <asp:Panel ID="Panel1" runat="server">
                <asp:Panel ID="Panel2" runat="server">
                <asp:Label ID="Label8" runat="server" ForeColor="White" Text="Enter your email:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your Email"></asp:TextBox><asp:Label ID="lblsucc" runat="server" ForeColor="Red" Text="We Send you the password to your email:"></asp:Label>
         <asp:Label ID="lblEmailname" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblerr1" runat="server" ForeColor="Red" Text="You enterd wrong email please try again."></asp:Label>

                </asp:Panel>
        <asp:Button ID="btnSend" runat="server" Text="Verfy Now"  OnClick="btnSend_Click" ForeColor="Black" BackColor="Red" />
        <p>
            &nbsp;</p>
        </asp:Panel>
</asp:Content>

