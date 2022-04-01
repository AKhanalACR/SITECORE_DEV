<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomepagePrimaryVideoFeature.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Homepage.HomepagePrimaryVideoFeature" %>
<%@ Register TagPrefix="acr" TagName="YouTubeVideo" src="~/controls/MammographySavesLives/YouTubeVideo.ascx" %>

<div class="home-section-secondary">
        <acr:YouTubeVideo id="SurvivorStoriesVideo" runat="server" NormalNoControls="true" CssClass="video" ShowDescriptionBox="false" EnableJSAPI="true" />
        
				<asp:PlaceHolder runat="server" ID="phTextBox" Visible="false">
					<div class="text-box">
						<asp:PlaceHolder runat="server" ID="phTextBoxTitle" Visible="false">
							<p class="text-box-title"><sc:fieldrenderer FieldName="Promo Title" id="fldTeaserTitle" runat="server" /></p>
						</asp:PlaceHolder>
						<p class="video-description"><asp:Literal runat="server" ID="litTeaser" /></p>
						<asp:PlaceHolder runat="server" ID="phLinkTitle" Visible="false">
							<a class="callout-action" id="ancAction" runat="server"><sc:fieldrenderer FieldName="Promo Link Title" id="fldLinkTitle" runat="server" /></a>
						</asp:PlaceHolder>
					</div>
				</asp:PlaceHolder>

        <div class="video-title-ribbon">
          <a class="video-title-link" id="videoTitleLink" runat="server"><sc:fieldrenderer FieldName="Promo Image" id="imgHomepageFeatureVideoTitle" runat="server" /></a>
          <a class="arrow-link" id="videoArrowLink" runat="server"></a>
        </div>
</div>
