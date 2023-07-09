<%@ Page Title="HomePage" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="YanivProject_HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link href="stylePage/css/Test.css" rel="stylesheet" />
<!-- jQuery -->
  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
  <script>window.jQuery || document.write('<script src="js/libs/jquery-1.7.min.js">\x3C/script>')</script>

  <!-- FlexSlider -->
  <script src="stylePage/js/jquery.flexslider.js"></script>

 <!-- Syntax Highlighter -->
    <script src="stylePage/js/shCore.js"></script>
    <script src="stylePage/js/shBrushXml.js"></script>
    <script src="stylePage/js/shBrushJScript.js"></script>
  <!-- Optional FlexSlider Additions -->
    <script src="stylePage/js/jquery.easing.js"></script>
    <script src="stylePage/js/jquery.mousewheel.js"></script>
    <script src="stylePage/js/demo.js"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>   
     <script src="stylePage/js/modernizr.js"></script>
    <link href="stylePage/css/flexslider.css" rel="stylesheet" />
    <link href="stylePage/css/demo.css" rel="stylesheet" />
    <link href="stylePage/css/Test.css" rel="stylesheet" />
    <style>
    hr.style-six {    
    background:url('Pictures/pandafighter.jpg') center no-repeat;
    background-size:70px;
    height: 50px;
    width:500px;
    }
hr.style-six:before {
    left: -20px;
    right: 30%;
    margin-right: 0px;
}
hr.style-six:after {
    right: 25px;
    left: 50%;
    margin-left: 100px;
}
#toHide {
  position:fixed;
  z-index: 10;
  right: 0;
  bottom: 0;
  min-width: 100%;
  min-height: 100%;
}
    </style>    
    <script>
        setTimeout(hideDiv, 6999); //Instead of 10000 put your video's length, in milliseconds  
        function hideDiv() {
            document.getElementById("toHide").style.display = "none";
        }
    $(function(){
      SyntaxHighlighter.all();
    });
    $(window).load(function () {
      $('.flexslider').flexslider({
        animation: "slide",
        start: function(slider){
          $('body').removeClass('loading');
        }
      });
    });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server" >
<video src="video.mp4" id="toHide" playsinline autoplay muted loop></video>
 <h3 style="margin-left:45%; margin-top:40px;">PandaSro Home Page:</h3><hr class="style-one"/>
    <div id="container" class="cf" style="width:100%;">
        <div id="main" role="main" style="width:100%; height:450px; margin-left:0%; margin-top:-3%;">
            <section class="slider" style="width:100%;">
                <div class="flexslider" style="width:100%;">
                    <ul class="slides">
                        <li>
                            <img src="Pictures/Silder/constantinople.jpg"  style="width:100%; height:180px;"/>
                        </li>
                        <li>
                            <img src="Pictures/Silder/samarkand.jpg"  style="width:100%; height:180px;"/>
                        </li>
                        <li>
                            <img src="Pictures/Silder/hotan.jpg"  style="width:100%; height:180px;" />
                        </li>
                        <li>
                            <img src="Pictures/Silder/donwhang.jpg" style="width:100%; height:180px;"/>
                        </li>
                        <li>
                            <img src="Pictures/Silder/jangan.jpg" style="width:100%; height:180px;"  />
                        </li>
                    </ul>
                </div>
            </section><hr class="style-one"/>
        </div>
    </div>
    <h3 style="margin-left:37%; margin-top:-7%;">PandaSro Trailer:</h3><br />
    <hr class="style-five" style="width:42%; margin-left:25%; margin-top:0%;"></hr>
        &nbsp;<div class="pandaTrailer" style=" border:groove; margin: 25px 0px 0px 26%; float:left;"><iframe width="646" height="314" src="https://www.youtube.com/embed/TCyfvcweYEk" frameborder="15" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" ></iframe></div>
         <div class="divh1"><h4 style="color:blue;">Battle Royale - Event Times & <strong style="color:darkgreen;">Rewards</strong></h4></div>
        <div class="divh" style="margin: -50px 0px 0px 26%;"><img class="img-responsive" style="display: block; margin-left: auto; margin-right: auto;" src="http://i.epvpimg.com/O636cab.jpg" alt="" width="626" height="335"><font color="white"><center> We are finally announcing two Battle Royale events every day! 
            <p>Battle Royale Event will start EVERY DAY at 17:30 and 23:30 Panda Time</p>
            <p>Reward is 750 silks in Panda EU server </p>
            <p>Login for Battle Royale server will be online ''ONLY!'' for 5 minutes once the event starts.</p><p>You will see the server under CHECK status at other times </p> 
            <p>Battle Royale Champion will receive free Panda T-Shirt and Discord Nitro Subscription from Panda Team.</p>
            <strong>HOW TO BECOME AN Panda BATTLE ROYALE CHAMPION</strong>
            <p>Follow the ranking in #battle-royale (and soon on our website).</p><p> The player with the most Battle Royale wins will become the Battle Royale Champion of the month!</p></center>
        </font></div>
        <div class="divh1"><h4 style="color:red;">Buying/Selling Silks For Real Money (Blackmarket)</h4></div>
        <div class="divh" style="margin: -50px 0px 0px 26%;"><font color="white"><p>The silk transactions are being investigated on daily basis and the players involved with blackmarket transactions</p><p>are being punished.</p>
        <p>Kindly be informed that any player associated with blackmarket including;</p>
        <font color="red"><p>- Buying silks from players for cash</p>
        <p>- Selling silks to players for cash</p>
        <p>- Being a middle for transactions stated above</p>
        <p>Will get a permanent BAN without Any Warning.</p></font>
        <p>Our daily checks include silk transactions via drop item, exchange, stall, <br />guild storage, account storage, pick-pet and every possible way of transfering items.</p></font>
        </div>
        <div class="divh1"><h4 style="color:red;">[Server Maintenance] Server Maintenance Notice</h4></div>
        <div class="divh" style="margin: -50px 0px 0px 26%;"><font color="white">
          <p>Hello, this is Silkroad Panda Team,</p>
            <p>All Servers will be undergoing Server maintenance.</p>
            <p>Maintenance Period : Oct. 22th, 2019 10:00~15:00 server Time</p>
            <font color="red">
            <p>[Patch List]</p></font>
            <p>1. Bug fix</p>
            <p>2. Improve Server Stability.</p>
            <p>3. Balloon Carnival Event Close</p>
            <p>4. Halloween event Start (~11/19)</p>
            <p>5. Halloween avatar sales</p>
            <br />
            <br />
            <p>Please wait patiently Thanks.</p>
            <br />
        </div>
    <div class="ServerInfo" style="margin-top:-3%;"><h3 style="margin-left:0%; color:red; ">Server info</h3>
     <div><ul class="list-unstyled">
     <li style="color:green;"><span class="glyphicon glyphicon-user"></span>Players online: <strong id="test"></strong>67/350</li>
     <li style="color:blue;"><span class="glyphicon glyphicon-time"></span>Server Time:&nbsp<strong id="txt"></strong></li>
     <li><span class="glyphicon glyphicon-alert"></span> CAP: 120</li>
     <li><span class="glyphicon glyphicon-globe"></span> Race: Chinese/European</li>
     <li><span class="glyphicon glyphicon-asterisk"></span> XP Solo: 65x</li>
     <li><span class="glyphicon glyphicon-asterisk"></span> XP PT: 50x</li>
     <li><span class="glyphicon glyphicon-play"></span> Guild Limit: 24</li>
     <li><span class="glyphicon glyphicon-play"></span> Union Limit: 3</li>
     <li><span class="glyphicon glyphicon-asterisk"></span> Special Trade: Every day: 20:30-22:00</li>
     <li><span class="glyphicon glyphicon-plus-sign"></span> Max Plus: 10</li>
     <li><span class="glyphicon glyphicon-screenshot"></span> Play2Win: YES</li>
     </ul></div>
     <hr />
    <h3 style="margin-left:0%;">Fortress war</h3>
    <ul class="list-unstyled">
    <li><span class="glyphicon glyphicon-time"></span> Fortress War: Sunday 19:30</li>
    <li><span class="glyphicon glyphicon-check"></span> Registration: Everyday.</li>
    <li><span class="glyphicon glyphicon-tower"></span> Hotan: No One</li>
    </ul>
    <hr />
    </div><br />&nbsp
    <div class="box type2" style="width:200px; margin-left:40%; margin-top:35%;">
                    <div class="ctt" >
                        <div class="ranks-title" style="width:200px; height:20px;"><i class="fa fa-discord"></i> Discord channel <a href="https://discord.gg/5aZHQET">Join</a></div>
                        <div class="box" style="width:250px; height:550px; margin-top:90%;">
                            <br>
                            <iframe src="https://discordapp.com/widget?id=643895607529832458&theme=dark" width="200" height="500" allowtransparency="true" frameborder="0" style="margin-top:-15%; margin-left:-10%;"></iframe>
                        </div>
                    </div>
                </div>
</asp:Content>