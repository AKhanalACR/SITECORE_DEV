<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltListWithLogosHoriz.ascx.cs" Inherits="ACR.layouts.Radpac.sltListWithLogosHoriz" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %><script type="text/javascript">
	    // Create the tooltips only on document load
	    $(document).ready(function() {
	        // By suppling no content attribute, the library uses each elements title attribute by default
	        $('ul.horizblock li a[href][title]').qtip({
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
<asp:repeater runat="server" id="rptTopics" onitemdatabound="RptTopicsItemDataBound">
    <itemtemplate>
        <asp:placeholder id="phTopic" runat="server">
        <h2 class="clearboth"><asp:literal id="ltlHeadingTitle" runat="server"></asp:literal></h2>
        <div class="borderdiv">&nbsp;</div>
        <div class="Vendors"></div>
        
            <asp:repeater id="rptLogos" runat="server" onitemdatabound="RptLogosDataBound">
                <headertemplate><ul class="horizblock">
                <itemtemplate>
                    <li>
                        <asp:hyperlink id="hlListItem" runat="server" target="_blank"><acr:image id="imgListItem" runat="server" cssclass="titleimg" xmlns:acr="http://www.sitecore.net/xhtml"></acr:image>
                        </asp:hyperlink>
                    </li>
                </itemtemplate>
                <footertemplate></footertemplate></ul></headertemplate>
            </asp:repeater>
            <asp:repeater id="rptList" runat="server" onitemdatabound="RptListItemDataBound">
                <headertemplate><ul class="horizblock">
                <itemtemplate>
									<li>
                        <asp:hyperlink id="hltxtListItem" runat="server" target="_blank"></asp:hyperlink>
                  </li>
                </itemtemplate>
                <footertemplate></footertemplate></ul></headertemplate>
            </asp:repeater>
        
        <asp:literal id="ltlDisclaimer" runat="server"></asp:literal>
        <div class="clearboth"></div>
        </asp:placeholder>
    </itemtemplate>
</asp:repeater>