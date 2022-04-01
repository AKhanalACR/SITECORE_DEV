<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltList.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltList" %>

<asp:Panel id="pnlTopicBookmarks" CssClass="fullbluebox" runat="server" Visible="false">
    <asp:Literal ID="ltlBookmarks" runat="server" />
</asp:Panel>
<div class="clearboth">&nbsp;</div>


<asp:Repeater ID="rptHeadings" runat="server" OnItemDataBound="RptHeadingsItemDataBound">
    <ItemTemplate>
        <h2 class="clearboth"><asp:Literal ID="ltlHeadingTitle" runat="server" /></h2>
        <div class="borderdiv">&nbsp;</div>
        <ul class="simple_list">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="RptListItemDataBound">
                <ItemTemplate>
                    <li>
                        <h4 class="blt"><asp:Literal ID="ltlBullet" runat="server"/></h4>
                        <div>
                        <h4><asp:Hyperlink ID="hlListItem" runat="server" /></h4>
                        <asp:Literal ID="ltlIcon" runat="server"/>
                        <asp:Literal ID="ltlDescription" runat="server" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
       <p style="text-align:right;"><a href="#" class="backToTop">Back to Top</a></p>
    </ItemTemplate>
</asp:Repeater>