<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomepageVideoFeatures.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Homepage.HomepageVideoFeatures" %>
<%@ Register TagPrefix="acr" TagName="YouTubeVideo" src="~/controls/MammographySavesLives/YouTubeVideo.ascx" %>

	<p class="text-box-title"><asp:Literal ID="litComponentTitle" runat="server" /></p>
	<div class="intro-text-module" id="divIntroText" runat="server"><p><asp:Literal ID="litPodcastVideosIntro" runat="server" /></p></div>
	<asp:Repeater ID="rptVideos" runat="server">
		<ItemTemplate>
			<div class="video-downloads" id="vidPromoContainer" runat="server">
				<acr:YouTubeVideo id="acrVideo" runat="server" NormalNoControls="true" CssClass="video" ShowDescriptionBox="false" EnableJSAPI="true" />
				<a class="arrow-link" id="videoArrowLink" runat="server"></a>
				<div class="video-downloads-info">
					<p><asp:HyperLink CssClass="video-downloads-title" Target="_blank" ID="hlVideoTitle" runat="server"></asp:HyperLink></p>
					<p class="video-downloads-details"><asp:Literal runat="server" ID="litVideoDetail" /></p>
				</div>
				<asp:Panel ID="pnlShareThis" runat="server" CssClass="addthis_toolbox addthis_default_style video-share-link">
						<a class="addthis_button_compact">
							<img src="/images/MammographySavesLives/share_btn.png" /></a>
				</asp:Panel>
			</div>
		</ItemTemplate>
	</asp:Repeater>
	<script type="text/javascript">
		var addthis_config = {
			ui_delay: 200,
			data_track_clickback: true
		};
</script>
<script type="text/plain" data-cookieconsent="marketing" src="https://s7.addthis.com/js/250/addthis_widget.js#username=noelleneu"></script>