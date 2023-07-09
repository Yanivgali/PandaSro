<%@ Page Title="Add item to store" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="AddToStore.aspx.cs" Inherits="YanivProject_AddToStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <center><asp:Panel ID="Panel1" runat="server">      
         <asp:Label ID="Label3" runat="server" Text="Choose Race:" style="Color:white;"></asp:Label><asp:DropDownList runat="server" ID="ddlrace" required="" AutoPostBack="True">
             <asp:ListItem>Choose Race</asp:ListItem>
             <asp:ListItem>Ch</asp:ListItem>
             <asp:ListItem>Eu</asp:ListItem>
         </asp:DropDownList><asp:Label ID="lblrace" runat="server" Text="Choose Race!" style="Color:red;"></asp:Label><br />
        <asp:Label ID="Label1" runat="server" Text="Weapon Name:" style="Color:white;"></asp:Label>
    <asp:TextBox ID="txtname" runat="server" required="" placeholder="Enter Weapon name:"></asp:TextBox><br />
                <asp:Label ID="Label4" runat="server" Text="Weapon Price:" style="Color:white;"></asp:Label>
    <asp:TextBox ID="txtprice" runat="server"  type="number" required="" placeholder="Enter Price:"></asp:TextBox><br />       
                <asp:Label ID="Label5" runat="server" Text="Weapon url:" style="Color:white;"></asp:Label>
    <asp:TextBox ID="txtweaponurl" runat="server"  type="text" required="" placeholder="Enter Picture url:"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Weapon Id:" style="Color:white;"></asp:Label>
        <textarea runat="server" id="txtdescription" cols="20" rows="2" required="" placeholder="Descrip The Weapon:"></textarea><br />
        <asp:FileUpload ID="f1" runat="server" required="" style="color:red; background:black;"/>
         &nbsp;<img id="img" runat="server" src="#" />
        <br /><asp:Button ID="btnupload" runat="server" Text="Upload" ForeColor="white" type="submit" value="upload" BackColor="Black" OnClick="btnupload_Click"/>
        <asp:Label ID="lblSucc" runat="server" Text="Upload Succed." style="Color:green;"></asp:Label>
    </asp:Panel></center>

</asp:Content>

