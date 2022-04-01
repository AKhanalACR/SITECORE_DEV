<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Footer" %>

<p><strong><sc:fieldrenderer runat="server" id="scCopyrightIntro" FieldName="Copyright Intro" /></strong></p>
<asp:Repeater ID="footerLogos" runat="server">
	<HeaderTemplate>
		<ul class="footer-logos">
	</HeaderTemplate>
	<ItemTemplate>
		<li class="footer-logo-item">
			<a target="_blank" class="footer-logo-link" id="logoLink" runat="server">
				<sc:fieldrenderer id="logoImage" runat="server" FieldName="Footer Logo" />
			</a>
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:Repeater>
<p class="disclaimer">
	<sc:fieldrenderer runat="server" id="scCopyrightNotice" FieldName="Copyright Notice" />
</p>

 