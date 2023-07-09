<%@ Page Title="Add Comment" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="YanivProject_Comment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <meta charset="UTF-8">
  <link href="stylePage/css/StarRating.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server"> 
       <div>
    <div align="center"> 
        <asp:Label ID="lblerr" runat="server" ForeColor="Red" style="z-index: 1; position: absolute; top: 350px; left: 611px" Text="You must choose Comment"></asp:Label>
        <u> <font  face="Algerian"  size="10" style="color:white;">יצירת קשר</font> </u>  </div>
    </div>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 1062px; top: 187px; position: absolute" Text="מייל" ForeColor="White"></asp:Label>
        <asp:label ID="txtMail" runat="server" style="color:white; z-index: 1; left: 810px; top: 184px; position: absolute" required=""></asp:label>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 1059px; top: 272px;  position: absolute" Text="תאריך" ForeColor="White"></asp:Label>
        <asp:label ID="txtDate" runat="server" style=" color:white; z-index: 1; left: 810px; top: 268px;  position: absolute"></asp:label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 1057px; top: 346px; position: absolute"  ForeColor="White" Text="נושא"></asp:Label>
        <asp:DropDownList ID="ddlCommentType" runat="server" style="z-index: 1; left: 810px; top: 343px; position: absolute" AutoPostBack="True">
            <asp:ListItem>בחר סוג תגובה</asp:ListItem>
            <asp:ListItem>תלונה</asp:ListItem>
            <asp:ListItem>דיווח</asp:ListItem>
            <asp:ListItem>שאלה</asp:ListItem>
            <asp:ListItem>בקשה</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtComment" runat="server" required="" style="z-index: 1; left: 810px; top: 427px; position: absolute; height: 113px; width: 187px" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 1052px; top: 432px; position: absolute" Text="תגובה" ForeColor="White"></asp:Label>
    <asp:Button ID="Button2" runat="server" style="left: 810px; top: 587px; position: absolute;" Text="Send" BackColor="White" OnClick="Button2_Click" />
    <asp:Label ID="lblSucc" runat="server" style="z-index: 1; left: 926px; top: 623px; position: absolute" Text="התגובה נקלטה בהצלחה" ForeColor="White"></asp:Label>
</asp:Content>

