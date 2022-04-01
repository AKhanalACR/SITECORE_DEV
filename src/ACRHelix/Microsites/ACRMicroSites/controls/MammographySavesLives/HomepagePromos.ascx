<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomepagePromos.ascx.cs" Inherits="ACR.controls.MammographySavesLives.HomepagePromos" %>

<div class="home-section-row-4-secondary">
	<a href="tools.aspx"><span class="promo-banner"><sc:fieldrenderer FieldName="Promotional Banner" id="fldPromoImage" runat="server" /></span></a>
	<asp:Repeater ID="rptPromos" runat="server">
		<HeaderTemplate>
			<ul class="home-section home-callouts">	
		</HeaderTemplate>
		<ItemTemplate>
			<li class="home-callout-item">
				<span class="callout-image"><sc:fieldrenderer id="calloutImage" runat="server" FieldName="Promo Image" /></span>
				<h3 class="callout-title"><sc:fieldrenderer id="calloutTitle" runat="server" FieldName="Promo Title" /></h3>
				<p class="callout-description"><sc:fieldrenderer id="calloutDesc" runat="server" FieldName="Promo Teaser" /></p>
				<a class="callout-action" id="calloutAction" runat="server"></a>
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
</div>				