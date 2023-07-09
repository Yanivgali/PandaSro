<%@ Page Title="Register" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="YanivProject_Register1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">  <style> 
        .form{
            position:relative;
        }
        .textbox{
            position:center;
            border:2px solid white;
            border-radius:5px;
            outline:none;
            padding: 4px;
            margin-top:10px;
        }
        .form-label{
            position:absolute;
            top:0;
            left:0;
            padding:10px;
            cursor:text;
            pointer-events:none;
            transition:top 200ms ease-in, left 200ms,font-size 200ms;
        }
        .textbox:focus{
            border:1px;
        }
        .textbox:focus~ .form-label,
        .textbox:not(:placeholder-shown).textbox:not(:focus)~.form-label{
            top:-0.5rem;
            height:0.1rem;
            left:0.5rem;
            font-size:0.65em;
            border:0.2rem;
            border-radius:0.2rem;
            background:#212121;
            color:white;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <h1><center>Register Page</center></h1>
    <hr class="style-one" />
    <asp:Panel ID="Panel1" runat="server" style="width:800px; position: absolute; margin:0 auto; margin-left:43%; margin-top:5%;">  
                <div class="form" >
                <input type="text" id="txtun" name="" placeholder=" " class="textbox" runat="server" required="required"/>
          <label class="form-label" id="lblun" runat="server">Username</label><br /></div>
              <div class="form" style="margin-top:1%;">
         <input type="password"  id="txtps" name="" placeholder=" " class="textbox" runat="server" required="required" />
          <label class="form-label" id="lblps" runat="server">Password</label><br />
            </div>
            <div class="form" style="margin-top:1%;">
          <input type="password" id="txtcon" name="" placeholder=" " class="textbox" runat="server" required="required"/> 
         <label class="form-label" id="lblpscon" runat="server">Confirm password</label><br />         
            </div>
          <div class="form" style="margin-top:1%;">
         <input type="text" id="txtem" name="" placeholder=" " class="textbox" runat="server" required="required"/> 
         <label class="form-label" id="lblem" runat="server">Email</label><br />
                       </div>
    <asp:Button ID="Button1" runat="server" BackColor="black" CssClass="auto-style9" ForeColor="White" Text="Create Account" OnClick="Button1_Click" style="margin-top:3%; margin-left:13%;" />
    </asp:Panel>
</asp:Content>

