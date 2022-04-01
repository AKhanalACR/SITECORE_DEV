<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltListWithLogos.ascx.cs" Inherits="ACR.layouts.Radpac.sltListWithLogos" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %><asp:repeater runat="server" id="rptTopics" onitemdatabound="RptTopicsItemDataBound">
    <itemtemplate>
        <h2 class="clearboth"><asp:literal id="ltlHeadingTitle" runat="server"></asp:literal></h2>
        <div class="borderdiv">&nbsp;</div>
        <ul class="block">
            <asp:repeater id="rptList" runat="server" onitemdatabound="RptListItemDataBound">
                <itemtemplate>
                    <li>
                    <div class="img"><acr:image id="imgListItem" runat="server" cssclass="titleimg" xmlns:acr="http://www.sitecore.net/xhtml"></acr:image>
                    </div>
                    <div class="col">
                        <p><asp:hyperlink id="hlListItem" runat="server" cssclass="simple" target="_blank"></asp:hyperlink></p>
                        <asp:literal id="ltlDescription" runat="server"></asp:literal>
                    </div></li>
                </itemtemplate>
            </asp:repeater>
        </ul>
    </itemtemplate>
</asp:repeater>