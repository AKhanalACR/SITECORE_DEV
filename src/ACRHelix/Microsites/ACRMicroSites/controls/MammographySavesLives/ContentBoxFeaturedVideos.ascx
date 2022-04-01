<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentBoxFeaturedVideos.ascx.cs" Inherits="ACR.controls.MammographySavesLives.ContentBoxFeaturedVideos" %>
<%@ Register TagPrefix="acr" TagName="YouTubeVideo" src="~/controls/MammographySavesLives/YouTubeVideo.ascx" %>

<div class="content-box">
	<div class="content-box-header">
		<div class="content-box-title">
			<sc:fieldrenderer id="cbTitleImage" runat="server" FieldName="Featured Videos Title Image" />
		</div>
	</div>
        
	<div class="content-box-details">
		<h3><sc:fieldrenderer id="leadVidTitle" runat="server" FieldName="Promo Title" /></h3>
		<acr:YouTubeVideo id="StraightTalkVideo" runat="server" Width="256" Height="192" Chromeless="false" ShowDescriptionBox="false" />
		<p><sc:fieldrenderer id="leadVidTeaser" runat="server" FieldName="Promo Teaser" /></p>
		
		<asp:Repeater ID="rptCBVideos" runat="server">
			<ItemTemplate>
				<div class="video-thumb">
					<a id="vidImgLink" runat="server" target="_blank"><sc:fieldrenderer id="vidImg" runat="server" FieldName="Promo Image" /></a>
                
					<div class="video-thumb-details">
						<h4 class="video-thumb-title">
							<a id="vidTextLink" runat="server" target="_blank"><sc:fieldrenderer id="vidTitle" runat="server" FieldName="Promo Link Title" /></a>
						</h4>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>
