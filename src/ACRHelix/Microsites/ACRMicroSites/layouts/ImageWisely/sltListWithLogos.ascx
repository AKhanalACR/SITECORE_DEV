<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltListWithLogos.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltListWithLogos" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

<asp:Repeater ID="rptTopics" runat="server" OnItemDataBound="RptTopicsItemDataBound">
    <ItemTemplate>
        <h2 class="clearboth"><asp:Literal ID="ltlHeadingTitle" runat="server" /></h2>
        <div class="borderdiv">&nbsp;</div>
        <ul class="block">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="RptListItemDataBound">
                <ItemTemplate>
                    <li>
                    <div class="img"><acr:image ID="imgListItem" runat="server" CssClass="titleimg"/>
                    </div>
                    <div class="col">
                        <p><asp:HyperLink ID="hlListItem" runat="server" CssClass="simple" Target="_blank" /></p>
                        <asp:Literal ID="ltlDescription" runat="server" />
                    </div></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </ItemTemplate>
</asp:Repeater>
                    