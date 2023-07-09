 <%@ Page Title="Store" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Store.aspx.cs" Inherits="YanivProject_StoreTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="stylePage/css/Test.css" rel="stylesheet" />
    <script type="text/javascript">
        function reply_click(clicked_id)
        {
                         if ( '<%= Session["User"] %>' == null) {
                alert("Log in first!");
            }
            if ( '<%= Session["User"] %>' != null) {
                alert(clicked_id);
            }

   
        }
</script>
    <style>
 .button:hover
 {
  opacity: 0.2;
 }
 .AddToStore
 {
    display: block;
    width: 100%;
    height: 40px;
    background: #4E9CAF;
    padding: 10px;
    text-align: center;
    border-radius: 5px;
    color: white;
    font-weight: bold;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
     <div  runat="server" id="f1_container"></div>
</asp:Content>
