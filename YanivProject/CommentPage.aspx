<%@ Page Title="Comment" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="CommentPage.aspx.cs" Inherits="YanivProject_CommentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">   
     <div>
    <div align="center"> <font  face="Algerian" color="white" size="10"><u>תגובות של משתמשים</font> </u> <hr />  </div>
    </div>
        <asp:TextBox ID="txtDate" runat="server" style="z-index: 1; left: 119px; top: 124px;"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 302px; top: 127px; min-width:40%; color:white;" Text=":תאריך"></asp:Label><br />
        <asp:DropDownList ID="ddlCommentsType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCommentsType_SelectedIndexChanged" style="margin-left: 40%;">
            <asp:ListItem>בחר סוג תגובה</asp:ListItem>
            <asp:ListItem>תלונה</asp:ListItem>
            <asp:ListItem>דיווח</asp:ListItem>
            <asp:ListItem>שאלה</asp:ListItem>
            <asp:ListItem>בקשה</asp:ListItem>
        </asp:DropDownList>
        <asp:GridView ID="grdComments" runat="server" OnRowDeleting="grdComments_RowDeleting1" style="z-index: 1; margin-left:40%; margin-top:5%; height: 115px; width: 196px" ForeColor="White">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="מחיקה" ShowHeader="True" Text="מחק" >
                <ItemStyle ForeColor="Red" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
</asp:Content>

