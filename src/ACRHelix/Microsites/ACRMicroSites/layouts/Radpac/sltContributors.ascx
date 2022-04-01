<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltContributors.ascx.cs" Inherits="ACR.layouts.Radpac.sltContributors" %><div id="fullbluebox" class="fullbluebox">
    <ul class="alphasort">
        <asp:literal runat="server" id="ltlAlphaNav"></asp:literal>
      <!-- <li><a href="#"  title="A" class="alphabets">A</a></li> -->
    </ul>
</div>
<ul class="jenerallist">
    <asp:repeater runat="server" id="rptAlpha" onitemdatabound="rptAlpha_OnItemDataBound">
        <itemtemplate>
        <li id="liAlphaBlock" runat="server" visible="false">
          <h2 class="clearboth"><asp:literal id="ltlAlpha" runat="server"></asp:literal></h2>
          <div class="borderdiv">&nbsp;</div>
          <ul>
            <asp:repeater id="rptContributors" runat="server" onitemdatabound="rptContributors_OnItemDataBound">
                <itemtemplate>
                <li><asp:literal id="ltlContr" runat="server"></asp:literal></li>
                </itemtemplate>
            </asp:repeater>
          </ul>
        </li>
        <li id="liAlphaBlockTop" runat="server" visible="false"><a href="#" title="backToTop" class="backToTop"><span>&nbsp;</span>Back to Top</a></li>
        </itemtemplate>
    </asp:repeater>
</ul>