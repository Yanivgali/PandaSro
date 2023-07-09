<%@ Page Title="Login" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="YanivProject_Pictures_Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> 
        <style>
 
    </style> 
    <script type="text/javascript">
        function btnlogin() {
            jQuery(window).load(function () {
                sessionStorage.setItem('status', 'loggedIn')
            });
        }
        </script>
     <style> 
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
            background:#000000;
            color:white;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
      <div class="box">
                          <h2 style="margin-top:-5%;">Login</h2> 
            <hr style="margin-top:-8%;" class="style-one"/>
 <asp:Panel ID="Panel1" runat="server" style="position:static; margin:0 auto; margin-left:15%; margin-top:-5%;"> 
                <div class="form" style="margin-top:10%; margin-left:5%;" >
                <input type="text" id="txtUserName" name="" placeholder=" " class="textbox" runat="server" required="required"/>
          <label class="form-label" id="lblun" runat="server">Username</label><br /></div>
              <div class="form" style="margin-top:3%; margin-left:5%;">
         <input type="password"  id="txtPassword" name="" placeholder=" " class="textbox" runat="server" required="required" />
          <label class="form-label" id="lblps" runat="server">Password</label><br />
            </div>
             <asp:Button runat="server" Text="Login" onClick="btnlogin" id="btnlogin1"  style="margin-left:5%; background:black; color:white;" />
             <a href="ForgotPassword.aspx" class="button" style="margin-left:10%;">Forgot Password</a>

    </asp:Panel>
    </div>
</asp:Content>