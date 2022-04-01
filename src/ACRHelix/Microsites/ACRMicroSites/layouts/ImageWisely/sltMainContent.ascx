<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltMainContent.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltMainContent" %>
<%@ Register TagPrefix="acr" TagName="Breadcrumb" Src="~/controls/ImageWisely/BreadcrumbUtilityLinks.ascx" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>
<div id="inside_wisely">
    <!--googleoff: all-->
    <acr:Breadcrumb ID="acrBreadcrumb" runat="server" />
    <div class="borderdiv">&nbsp;</div>
    <div class="borderdiv">&nbsp;</div>
    <!--googleon: all-->
    <h1 class="heading1"><asp:Literal ID="ltlPageTitle" runat="server" /></h1>
    <div>
        <acr:image ID="imgGeneral" runat="server" CssClass="titleimg"/>
        <asp:Literal ID="ltlGeneral" runat="server" />
    </div>
    <sc:Placeholder ID="phLeftContent" runat="server" Key="leftContent" />
    <div class="clearboth"></div>
    <asp:Panel id="pnlImgCard" CssClass="fullbluebox pmnone" runat="server" Visible="false">
        <ul class="block">
            <li>
                <asp:HyperLink id="hlCard1" runat="server" Target="_blank"><acr:image ID="imgCard" runat="server" /></asp:HyperLink>
                <p><asp:HyperLink id="hlCard2" runat="server" Target="_blank" CssClass="simple floatleft">&raquo; <asp:Literal ID="ltlCardTitle" runat="server" /></asp:HyperLink>
                <asp:HyperLink id="hlCard3" runat="server" Target="_blank" CssClass="simple floatleft"><span class="pdfimg">&nbsp;</span></asp:HyperLink>
                </p>
                <p><asp:HyperLink id="hlWalletCard1" Target="_blank" runat="server" CssClass="simple floatleft">&raquo; <asp:Literal ID="ltlWalletTitle" runat="server" /></asp:HyperLink>
                <asp:HyperLink id="hlWalletCard2" Target="_blank" runat="server" CssClass="simple floatleft"><span class="pdfimg">&nbsp;</span></asp:HyperLink>
                </p>
                <asp:Literal ID="ltlCardText" runat="server" />
             </li>
         </ul>
    </asp:Panel>
		<sc:Placeholder ID="phLeftBottomContent" runat="server" Key="leftBottomContent" />
</div>