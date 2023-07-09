<%@ Page Title="DownloadsPage" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Downloads.aspx.cs" Inherits="YanivProject_Downloads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <h1><center>Downloads Page</center></h1><hr class="style-one"/>
    <div class="div" style="margin-left:14%; width: 242px; height: 295px;"><img src="Pictures/MegaLogo.jpg" style="width: 235px; height: 230px;"/><br /><p>Panda's Mbot.<br /><asp:LinkButton ID="linkButton2" CSSClass="btn" runat="server" postbackurl="https://mega.nz/#!lwAhwDZD!lc2wboBcotjOZRDsws2Pnm0_emoZKehg7feQy-kCcos">Download Here.</asp:LinkButton></p><br /></div>
    <div class="div" style="margin-left:13%; width: 241px; height: 295px; "><img src="Pictures/images.jpg" style="width: 235px; height: 230px;"/><br /><p>Panda Sro Client.<br /><asp:LinkButton ID="linkButton1" CSSClass="btn" runat="server" postbackurl="https://www.mediafire.com/file/ln9y26j509szh6a/Electus_110_255.zip/file">Download Here.</asp:LinkButton></p><br /></div>
    <div class="div" style="margin-left:14%; width: 242px; height: 295px;"><img src="Pictures/images.jpg" style="width: 235px; height: 230px;"/><br /><p>Panda Sro Client.<br /><asp:LinkButton ID="linkButton" CSSClass="btn" runat="server" postbackurl="https://mega.nz/#!yGYDXSSZ!ksFDJlkurrcHP7q2tsoQmNxZXTW7H6lNrgQebuK63Hk">Download Here.</asp:LinkButton></p><br /></div>
    <br /><hr class="style-one" style="margin-top:310px"/>
    <div class="divc">
        <h4 style="margin: 50px 0px 0px 0px;">Other downloads:</h4>
        <table class="table text-center">
            <tbody>
            <tr class="tr">
                <td> <a  target="_blank" href="https://www.microsoft.com/en-us/download/details.aspx?id=35&amp;44F86079-8679-400C-BFF2-9CA5F2BCBDFC">
                    <img src="Pictures/directx.png" style="width:75px;" alt="DirectX"/>
                </a></td>
                <td> <a target="_blank" href="https://www.microsoft.com/en-us/download/details.aspx?id=35&amp;44F86079-8679-400C-BFF2-9CA5F2BCBDFC">
                    <strong>DirectX</strong>
                </a></td>
            </tr>
            <tr class="tr">
                <td> <a target="_blank" href="https://aka.ms/vs/15/release/vc_redist.x86.exe">
                    <img src="Pictures/vcredist.png" style="width:75px;" alt="Microsoft Visual C++ 2017 Redistributable"/>
                </a></td>
                <td> <a target="_blank" href="https://aka.ms/vs/15/release/vc_redist.x86.exe">
                    <strong>Microsoft Visual</strong>
               </a> </td>
            </tr>
            <tr class="tr">
                <td> <a target="_blank" href="https://www.microsoft.com/en-us/download/details.aspx?id=49982">
                    <img src="Pictures/dotnet.png" style="width:75px;" alt="Microsoft .NET Framework 4.6.1"/>
                </a></td>
                <td> <a target="_blank" href="https://www.microsoft.com/en-us/download/details.aspx?id=49982">
                    <strong>Microsoft.NET</strong>
               </a> </td>
            </tr>
            <tr class="tr">
                <td> <a target="_blank" href="https://www.geforce.com/drivers">
                    <img src="Pictures/nvidia.png" style="width:75px;" alt="nVidia"/>
                </a></td>
                <td> <a target="_blank" href="https://www.geforce.com/drivers">
                    <strong>nVidia Drivers</strong>
                </a></td>

            </tr>
            <tr class="tr">
                <td><a target="_blank" href="http://support.amd.com/en-us/download">
                    <img src="Pictures/amd.jpg" style="width:75px;" alt="AMD"/>
                </a></td>
                <td>
                    <a target="_blank" href="http://support.amd.com/en-us/download">
                    <strong>AMD Drivers</strong>
                </a></td>
            </tr>
            <tr class="tr">
                <td> <a target="_blank" href="https://downloadcenter.intel.com">
                    <img src="Pictures/intel.png" style="width:75px;" alt="Intel"/>
                </a></td>
                <td> <a target="_blank" href="https://downloadcenter.intel.com">
                    <strong>Intel Drivers</strong>
                </a></td>   
            </tr>
            </tbody>
        </table>
    </div><br />    
     <hr class="style-one" style="margin-top:230px"/>
     <div class="divc" style=" border-style: groove; border-color: inherit; border-width: medium; margin-top:90px; margin-bottom:50px; color:white; font-family:'Simplified Arabic'; width: 500px;">
        <table style="width:100%; height:100%;">
            <thead>
            <tr class="tr">
                <th style="width: 51px"></th>
                <th>Minimum Specifications</th>
                <th style="width: 231px">Recommended Specifications</th>
            </tr>
            </thead>
            <tbody>
            <tr class="tr">
                <th style="width: 51px">CPU</th>
                <td>Pentium 3 800MHz or higher</td>
                <td style="width: 231px">Pentium 4 2.4GHz or higher</td>
            </tr>
            <tr class="tr">
                <th style="width: 51px">RAM</th>
                <td>768MB</td>
                <td style="width: 231px">2GB</td>
            </tr>
            <tr class="tr">
                <th style="width: 51px">VGA</th>
                <td>3D speed over GeForce2 or ATI 9000</td>
                <td style="width: 231px">3D speed over GeForce FX 5600 or ATI9500</td>
            </tr>
            <tr class="tr">
                <th style="width: 51px">SOUND</th>
                <td>DirectX 9.0c Compatibility card</td>
                <td style="width: 231px">DirectX 9.0c Compatibility card</td>
            </tr>
            <tr class="tr">
                <th style="width: 51px">HDD</th>
                <td>5GB or higher(including swap and temporary file)</td>
                <td style="width: 231px">7GB or higher(including swap and temporary file)</td>
            </tr>
            <tr class="tr">
                <th style="width: 51px">OS</th>
                <td>Windows Vista SP2</td>
                <td style="width: 231px">Windows 7, 8, 8.1, 10</td>
            </tr>
            </tbody>
        </table>
    </div>
</asp:Content>