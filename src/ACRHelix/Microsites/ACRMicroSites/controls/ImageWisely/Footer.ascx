<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="ACR.controls.ImageWisely.Footer" %>

<asp:Panel id="pnlShareThis" runat="server" cssclass="sharethis cf" Visible="false">
    <div>
        <a href="http://www.addthis.com/bookmark.php?v=250&amp;username=noelleneu" onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')" onmouseout="addthis_close()" onclick="return addthis_sendto()"><img src="/images/ImageWisely/share.jpg" align="absmiddle" alt=""/>Share this site</a>
    </div>
<!-- AddThis Button END -->
    <script type="text/javascript">
        var addthis_config = {
            ui_delay: 200,
            data_track_clickback: true,
            services_compact: 'email, facebook, twitter, linkedin',
            services_expanded: 'email, facebook, twitter, linkedin'
        };
    </script>
    <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#username=noelleneu"></script>
 </asp:Panel>

<div class="sitemapFooter cf">
	<ul>
		<li>
			<a href="/Imaging-Modalities.aspx">Imaging Modalities</a>
			<ul>
				<li><a href="/Imaging-Modalities/General-Radiation-Safety">General Radiation Safety</a></li>
				<li><a href="/Imaging-Modalities/Computed-Tomography">Computed Tomography</a></li>
				<li><a href="/Imaging-Modalities/Nuclear-Medicine">Nuclear Medicine</a></li>
				<li><a href="/Imaging-Modalities/Fluoroscopy">Fluoroscopy</a></li>
			</ul>
		</li>
	</ul>

	<ul>
		<li><a href="/Referring-Practitioners">Referring Practitioners</a></li>
		<li><a href="/Patients">Patients</a></li>
		<li><a href="/My-Equipment">My Equipment</a></li>
	</ul>
	
	<ul>
		<li>
			<a href="/Pledge">Pledge</a>
			<ul>
				<li><a href="/Pledge">Take the Pledge</a></li>
				<li><a href="/Pledge/Honor-Roll">Honor Roll</a></li>
			</ul>
		</li>
	</ul>
	
	<ul>
		<li><a href="/About-Us">About Us</a></li>
		<li><a href="/Contact-Us">Contact Us</a></li>
		<li><a href="/Media-Room">News</a></li>
	</ul>
	
	<ul class="social">
		<li><asp:Hyperlink ID="hlFaceBook" title="facebook" CssClass="facebook" Target="_blank" runat="server">Like Us on</asp:Hyperlink></li>
    <li><asp:Hyperlink ID="hlTwitter" title="twitter" CssClass="twitter" Target="_blank" runat="server">Follow Us on</asp:Hyperlink></li>
	</ul>
</div>

<div id="footer">
    <ul id="footer_nav">
      <asp:Repeater ID="RptNavLinks" runat="server" OnItemDataBound="RptNavLinks_ItemDataBound" >
        <ItemTemplate>
            <li id="liNav" runat="server"><asp:HyperLink id="hlNav" runat="server"/></li>
        </ItemTemplate> 
        </asp:Repeater>
    </ul>
    <div class="borderdiv">&nbsp;</div>
    <div class="borderdiv">&nbsp;</div>
    <asp:Literal ID="ltlFooter" runat="server"/>
</div>
