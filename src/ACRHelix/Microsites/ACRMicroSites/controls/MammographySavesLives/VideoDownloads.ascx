<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoDownloads.ascx.cs" Inherits="ACR.controls.MammographySavesLives.VideoDownloads" %>
<%@ Register TagPrefix="acr" TagName="YouTubeVideo" src="~/controls/MammographySavesLives/YouTubeVideo.ascx" %>

<h2><asp:Literal ID="litComponentTitle" runat="server" /></h2>
<div class="intro-text video-downloads-intro" id="divIntroText" runat="server"><sc:FieldRenderer id="scPageDescription" runat="server" FieldName="Video Downloads Intro" /></div>
<asp:Repeater ID="rptVideosDiv" runat="server" OnItemDataBound="rptVideosDiv_ItemDataBound">
	<ItemTemplate>
		<div class="video-downloads-container">
			<asp:Repeater ID="rptVideos" runat="server" OnItemDataBound="rptVideos_ItemDataBound">
				<ItemTemplate>
					<div class="video-downloads" id="videoDownloadsContainer" runat="server">
						<acr:YouTubeVideo id="acrVideo" runat="server" NormalNoControls="true" CssClass="video" ShowDescriptionBox="false" EnableJSAPI="true" />
						<a class="arrow-link" id="videoArrowLink" runat="server"></a>
						<div class="video-downloads-info">
							<p><asp:HyperLink CssClass="video-downloads-title" Target="_blank" ID="hlVideoTitle" runat="server"></asp:HyperLink></p>
							<p class="video-downloads-details"><asp:Literal runat="server" ID="litVideoDetail" /></p>
						</div>
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</ItemTemplate>
</asp:Repeater>