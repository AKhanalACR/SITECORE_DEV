<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.layouts.ImageWisely.sltHome" Codebehind="sltHome.ascx.cs" %>
<%@ Import Namespace="ACR.controls.ImageWisely" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>
<%@ Register TagPrefix="iw" TagName="callout" Src="~/controls/ImageWisely/Callout.ascx" %>

<!-- Removed 10/24/2012 by C.Castle -- Some of this, particuarly the banner, may need to stay --
<div id="home_banner">
<acr:image ID="imgSpotlight" runat="server" Visible="false" />
</div>

<asp:PlaceHolder ID="phVideo" runat="server" Visible="false">
	<div id="home_video">
			<asp:HyperLink  style="display:block;width:677px;height:300px;" 
				id="hlFlowPlayer" runat="server">
			</asp:HyperLink>
			<script type="text/javascript" language="JavaScript">
					flowplayer(<% Response.Write("'" + hlFlowPlayer.ClientID + "'"); %>, '/flowplayer/flowplayer-3.2.5.swf',
					{
							clip:{
									autoPlay:false,
									autoBuffering:true
							}
					});
			</script>
	</div>
</asp:PlaceHolder>
-->

<!-- New Format for each section/item -->
<!-- about: note the missing <h2> from the "item" section -->
<asp:PlaceHolder ID="phIntroduction" runat="server" Visible="false">
	<div class="homeSection cf">
		<h1><asp:Literal ID="litIntroTitle" runat="server" /></h1>
		<asp:Literal ID="litIntroText" runat="server" />
	</div>
</asp:PlaceHolder>

<!-- Callout -->
	<iw:callout ID="iwCallout" runat="server" Visible="False"></iw:callout>

<!-- News -->
<asp:PlaceHolder ID="phNews" runat="server" Visible="false">
	<asp:Repeater ID="rptNews" runat="server" OnItemDataBound="rptNews_ItemDataBound">
		<HeaderTemplate>
			<div class="homeSection cf">
				<div class="left"><h1><asp:Literal ID="litNewsTitle" runat="server" /></h1></div>
				<div class="subscribe" style="display:none">
					<a href="/IW-News-RSS-Feed">
						<span class="link-rss">&nbsp;</span>
						<span class="subscribeText">Subscribe</span>
					</a>
				</div>
		</HeaderTemplate>
		<ItemTemplate>
			<div class="item cf">
				<h2><asp:Literal ID="litNewsItemTitle" runat="server" /></h2>
				<div class="content cf">
					<asp:Literal ID="litNewsItemContent" runat="server" />
				</div>
				<asp:Hyperlink ID="hlNewsRead" runat="server" CssClass="more" />
			</div>
		</ItemTemplate>
		<FooterTemplate>
				<a href="/Media-Room" class="more moreNews">&raquo; See Additional News</a>
			</div>
		</FooterTemplate>
	</asp:Repeater>	
</asp:PlaceHolder>

<!-- Top Reads -->
<asp:PlaceHolder ID="phTopReads" runat="server" Visible="false">
	<div class="homeSection cf">
		<h1><asp:Literal ID="litTopReadsTitle" runat="server" /></h1>
		<asp:Literal ID="litTopReadsText" runat="server" />
	</div>
</asp:PlaceHolder>

<!-- Commitment -->
<asp:PlaceHolder ID="phCommitment" runat="server" Visible="false">
	<div class="homeSection cf">
		<h1><asp:Literal ID="litCommitmentTitle" runat="server" /></h1>
		<asp:Literal ID="litCommitmentText" runat="server" />
	</div>
</asp:PlaceHolder>

<!-- Additional -->
<asp:PlaceHolder ID="phAdditional" runat="server" Visible="false">
	<div class="homeSection cf">
		<h1><asp:Literal ID="litAdditionalTitle" runat="server" /></h1>
		<asp:Literal ID="litAdditionalText" runat="server" />
	</div>
</asp:PlaceHolder>
<!-- End: New Generic html code for repeatable items-->

<!-- Removed 10/24/2012 by C.Castle --
<div class="home_seperator">&nbsp;</div>
<div class="bluebox">
	<h2><asp:Literal ID="ltlImgProf" runat="server" /></h2>

	<ul>
		<asp:Repeater ID="rptImagingProf" runat="server" OnItemDataBound="rptImagingProf_ItemDataBound">
			<ItemTemplate>
				<li><asp:Hyperlink ID="hlImagingProf" runat="server" />
				<asp:Literal ID="ltlImagingProfText" runat="server" /></li>
			</ItemTemplate>
		</asp:Repeater>
	</ul>
</div>

<div class="divider_30"></div>
<div class="bluebox">
	<acr:image ID="imgJournal" runat="server" />
	<div class="article_box">
		<asp:HyperLink CssClass="link" ID="lnkJournalLink" runat="server" />
		<asp:Literal ID="ltlJournalText" runat="server" />
	</div>
</div>
-->