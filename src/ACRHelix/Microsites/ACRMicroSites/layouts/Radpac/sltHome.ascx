<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.layouts.Radpac.sltHome" Codebehind="sltHome.ascx.cs" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

<div id="home_banner">
<acr:image runat="server" id="imgSpotlight" visible="false" xmlns:acr="http://www.sitecore.net/xhtml"></acr:image>
</div>

<div id="about_image_wisely">
    <asp:literal runat="server" id="ltlIntro"></asp:literal>
</div>


<asp:placeholder runat="server" id="phVideo" visible="false">
<div id="home_video">
    <asp:hyperlink style="display:block;width:677px;height:300px;" id="hlFlowPlayer" runat="server">
    </asp:hyperlink>
    <script type="text/javascript" language="JavaScript">
        flowplayer(&lt;% Response.Write("'" + hlFlowPlayer.ClientID + "'"); %&gt;, '/flowplayer/flowplayer-3.2.5.swf',
        {
            clip:{
                autoPlay:false,
                autoBuffering:true
            }
        });
    </script>
</div>
</asp:placeholder>

<%--<div class="home_seperator">&nbsp;</div>--%>
<%--<div class="bluebox">
    <h2><asp:literal runat="server" id="ltlImgProf"></asp:literal></h2>

    <ul>
        <asp:repeater runat="server" id="rptImagingProf" onitemdatabound="rptImagingProf_ItemDataBound">
            <itemtemplate>
                <li><asp:hyperlink id="hlImagingProf" runat="server"></asp:hyperlink>
                <asp:literal id="ltlImagingProfText" runat="server"></asp:literal></li>
            </itemtemplate>
        </asp:repeater>
    </ul>
</div>

<div class="divider_30"></div>
<div class="bluebox">
    <acr:image runat="server" id="imgJournal" xmlns:acr="http://www.sitecore.net/xhtml"></acr:image>
    <div class="article_box">
        <asp:hyperlink runat="server" cssclass="link" id="lnkJournalLink"></asp:hyperlink>
        <asp:literal runat="server" id="ltlJournalText"></asp:literal>
    </div>
</div>--%>