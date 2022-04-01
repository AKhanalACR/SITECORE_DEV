<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomepageSmallPromo.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Homepage.HomepageSmallPromo" %>

<div class="home-section-row-3-secondary">
	<asp:PlaceHolder runat="server" ID="phPromoTitle" Visible="false">
		<p class="text-box-title">
			<asp:Literal ID="litPromoTitle" runat="server" />
		</p>
	</asp:PlaceHolder>
	<div class="text-box">
		<asp:PlaceHolder runat="server" ID="phPromoTeaser" Visible="false">
			<p class="intro-text-module no-left-margin"><asp:Literal runat="server" ID="litPromoTeaser" /></p>
		</asp:PlaceHolder>
		<div class="homepage-small-promo-links">
			<asp:PlaceHolder runat="server" ID="phPromoLink" Visible="false">
				<asp:HyperLink ID="hlPromoLink" CssClass="callout-action" runat="server" Target="_blank" />
			</asp:PlaceHolder>
			<asp:PlaceHolder ID="phPromoLinkLinkBreak" runat="server" Visible="false">
				<br />
			</asp:PlaceHolder>
			<asp:PlaceHolder runat="server" ID="phPromoLink2" Visible="false">
				<asp:HyperLink ID="hlPromoLink2" CssClass="callout-action" runat="server" Target="_blank" />
			</asp:PlaceHolder>
		</div>
	</div>
	<asp:PlaceHolder ID="phPromoImage" runat="server" Visible="false">
		<div class="promo-image">
			<sc:fieldrenderer FieldName="Promo Image" id="fldPromoImage" runat="server" />
		</div>
	</asp:PlaceHolder>
</div>
