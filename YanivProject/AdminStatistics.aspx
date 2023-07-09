<%@ Page Title="AdminStatistics" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="AdminStatistics.aspx.cs" Inherits="YanivProject_AdminStatistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <asp:GridView ID="grdstatistics" runat="server" style=" margin-left:26%; height:250px; width:300px; color:bisque; border: solid 2px black; min-width: 50%;"></asp:GridView>
</asp:Content>

