<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Header" %>

<div class="header-content">
	<a class="site-logo" href="/"><sc:fieldrenderer runat="server" id="scCHeaderLogo" FieldName="Logo" /></a>
	
	<div class="header-utility">
		
	<asp:Repeater ID="HeaderLinksRepeater" runat="server">
		<HeaderTemplate>
			<ul class="header-links">
		</HeaderTemplate>
		<ItemTemplate>
			<li class="header-link-item" id="headerLinkItem" runat="server"><a class="header-link" id="headerLink" runat="server"></a></li>
		</ItemTemplate>
		<FooterTemplate></ul></FooterTemplate>
	</asp:Repeater>
	
	<asp:Repeater ID="SocialLinksRepeater" runat="server">
		<HeaderTemplate>
			<ul class="social-icons">
		</HeaderTemplate>
		<ItemTemplate>
			<li class="social-icon-item" id="socialIconItem" runat="server">
				<a target="_blank" class="social-icon" id="socialLink" runat="server">
					<img id="socialImage" runat="server" />
				</a>
			</li>
		</ItemTemplate>
		<FooterTemplate></ul></FooterTemplate>
	</asp:Repeater>
	</div>
</div>
