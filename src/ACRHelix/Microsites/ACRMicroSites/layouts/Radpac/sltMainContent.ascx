<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.layouts.Radpac.sltMainContent" Codebehind="sltMainContent.ascx.cs" %>
<%@ Register TagPrefix="acr" TagName="Breadcrumb" Src="~/controls/Radpac/BreadcrumbUtilityLinks.ascx" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %><div id="inside_wisely">
    <!--googleoff: all-->
    <acr:breadcrumb runat="server" id="acrBreadcrumb" xmlns:acr="http://www.sitecore.net/xhtml"></acr:breadcrumb>
    <div class="borderdiv">&nbsp;</div>
    <div class="borderdiv">&nbsp;</div>
    <!--googleon: all-->
    <h1 class="heading1"><asp:literal runat="server" id="ltlPageTitle"></asp:literal></h1>
    <div>
        <acr:image runat="server" id="imgGeneral" cssclass="titleimg" xmlns:acr="http://www.sitecore.net/xhtml"></acr:image>
        <asp:literal runat="server" id="ltlGeneral"></asp:literal>
    </div>
    <sc:placeholder runat="server" id="phLeftContent" key="leftContent"></sc:placeholder>
    <div class="clearboth"></div>
    <asp:panel runat="server" id="pnlImgCard" cssclass="fullbluebox pmnone" visible="false">
        <ul class="block">
            <li>
                <asp:hyperlink id="hlCard1" runat="server" target="_blank"><acr:image id="imgCard" runat="server" xmlns:acr="http://www.sitecore.net/xhtml"></acr:image></asp:hyperlink>
                <p><asp:hyperlink id="hlCard2" runat="server" target="_blank" cssclass="simple floatleft">&raquo; <asp:literal id="ltlCardTitle" runat="server"></asp:literal></asp:hyperlink>
                <asp:hyperlink id="hlCard3" runat="server" target="_blank" cssclass="simple floatleft"><span class="pdfimg">&nbsp;</span></asp:hyperlink>
                </p>
                <p><asp:hyperlink id="hlWalletCard1" target="_blank" runat="server" cssclass="simple floatleft">&raquo; <asp:literal id="ltlWalletTitle" runat="server"></asp:literal></asp:hyperlink>
                <asp:hyperlink id="hlWalletCard2" target="_blank" runat="server" cssclass="simple floatleft"><span class="pdfimg">&nbsp;</span></asp:hyperlink>
                </p>
                <asp:literal id="ltlCardText" runat="server"></asp:literal>
             </li>
         </ul>
    </asp:panel>
    <p>&nbsp;&nbsp;</p>
</div>