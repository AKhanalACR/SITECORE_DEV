<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltList.ascx.cs" Inherits="ACR.layouts.Radpac.sltList" %><asp:panel runat="server" id="pnlTopicBookmarks" cssclass="fullbluebox" visible="false">
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>
    <asp:literal id="ltlBookmarks" runat="server"></asp:literal>
</asp:panel>
<div class="clearboth">&nbsp;</div>


<asp:repeater runat="server" id="rptHeadings" onitemdatabound="RptHeadingsItemDataBound">
    <itemtemplate>
        <h2 class="clearboth"><asp:literal id="ltlHeadingTitle" runat="server"></asp:literal></h2>
        <div class="borderdiv">&nbsp;</div>
        <ul class="simple_list">
            <asp:repeater id="rptList" runat="server" onitemdatabound="RptListItemDataBound">
                <itemtemplate>
                    <li>
                        <h4 class="blt"><asp:literal id="ltlBullet" runat="server"></asp:literal></h4>
                        <div>
                        <h4><asp:hyperlink id="hlListItem" runat="server"></asp:hyperlink></h4>
                        <div style="display:block;">
                        <asp:literal id="ltlIcon" runat="server"  ></asp:literal>
                        <acr:image runat="server" id="lstImage" xmlns:acr="http://www.sitecore.net/xhtml" style="display:block"></acr:image>
                        <asp:literal id="ltlDescription" runat="server" ></asp:literal>
                        <br />
                        </div>
                        </div>
                    </li>
                </itemtemplate>
            </asp:repeater>
        </ul>
       <p style="text-align:right;"><a href="#" class="backToTop">Back to Top</a></p>
    </itemtemplate>
</asp:repeater>