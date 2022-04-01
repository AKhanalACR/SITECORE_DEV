<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltListWithLogosCollapsible.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltListWithLogosCollapsible" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

<script src="/js/ImageWisely/expand-collapse.js" type="text/javascript" ></script>
	<script type="text/javascript">
	    // Create the tooltips only on document load
	    $(document).ready(function() {
	        // By suppling no content attribute, the library uses each elements title attribute by default
	        $('ul.block li a[href][title]').qtip({
	            content: {
	                text: false // Use each elements title attribute
	            },
	            style: {
	                width: 350,
	                padding: 10,
	                background: '#EBEBEB',
	                color: 'black',
	                textAlign: 'left',
	                border: { width: 3, radius: 3, color: 'gainsboro' }
	            },
	            position: { corner: { target: 'bottomLeft', tooltip: 'topLeft'} },
	            show: { delay: 500, solo: true }
	        });

	        // NOTE: You can even omit all options and simply replace the regular title tooltips like so:
	        // $('#content a[href]').qtip();
	    });
	</script>
<asp:Repeater ID="rptTopics" runat="server" OnItemDataBound="RptTopicsItemDataBound">
    <ItemTemplate>
        <asp:PlaceHolder ID="phTopic" runat="server">
        <h2 class="clearboth"><asp:Literal ID="ltlHeadingTitle" runat="server" /></h2>
        <div class="borderdiv">&nbsp;</div>
        <div class="Vendors"></div>
        
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="RptListItemDataBound">
                <HeaderTemplate><ul class="block"></HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="hlListItem" runat="server" Target="_blank"><acr:image ID="imgListItem" runat="server" CssClass="titleimg"/>
                        </asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="hltxtListItem" runat="server" Target="_blank"></asp:HyperLink>
                    </li>
                </ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
        
        <asp:Literal ID="ltlDisclaimer" runat="server" />
        <div class="clearboth"></div>
        </asp:PlaceHolder>
    </ItemTemplate>
</asp:Repeater>