<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Emailverification.aspx.cs" Inherits="YanivProject_email_verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email verification</title>
    <style>
        html {
  height: 100%;
  width:100%;
}
        body {
            background-image: url(Pictures/SilkroadHomepage.jpg);
            position: relative;
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;

        }
        h1{
            color:red;
            font-style: italic;
        }
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
</head>
<body bgcolor="#222222">
    <form id="form1" runat="server" class="auto-style2">
       <center><h1>We send you the code to your email</h1>
           </center>
        <asp:Panel ID="Panel1" runat="server" style="width:800px; position: absolute; margin:0 auto; margin-left:43%;">  
      <div class="form" style="margin-top:1%;">
                  <asp:Label ID="Label3" runat="server" CssClass="auto-style4" ForeColor="White" Text="Enter Here the Code:" style="position:absolute; margin-left:-17%; margin-top:0.9rem;"></asp:Label> <input type="text"  id="txtemvr" name="" placeholder=" " class="textbox" runat="server" required="required"/> 
         <label class="form-label" id="lblcode" runat="server">Code</label><br />
          <asp:Button ID="btnsend" runat="server" Text="Verfiy" style="margin-top:3%; background-color:red; margin-left:13%;" OnClick="Button1_Click"/>
          </asp:Panel> 
    </form>

</body>
</html>
