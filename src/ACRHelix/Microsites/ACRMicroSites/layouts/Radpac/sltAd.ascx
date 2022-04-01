<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltAd.ascx.cs" Inherits="ACR.layouts.Radpac.sltAd" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %><p class="ad">
    <%--<asp:hyperlink runat="server" id="newsLink">
            <asp:image runat="server" id="newsImage" imageurl="/images/Radpac/InTheNewsButton.png" width="190" height="39"></asp:image>
    </asp:hyperlink>--%>
</p>
<%--<div class="borderdiv" id="ctl3">&nbsp;</div>
<div class="borderdiv" id="ctl4">&nbsp;</div>
 --%>
<asp:repeater runat="server" id="rptAdItem" onitemdatabound="rptAdItem_ItemDataBound">
    <itemtemplate>
        <p class="ad"><asp:literal id="ltlLink" runat="server"></asp:literal>
        <acr:image runat="server" id="adImage" xmlns:acr="http://www.sitecore.net/xhtml"></acr:image>
        <asp:literal id="ltlLinkEnd" runat="server"></asp:literal>
        </p>

    </itemtemplate>    
</asp:repeater>