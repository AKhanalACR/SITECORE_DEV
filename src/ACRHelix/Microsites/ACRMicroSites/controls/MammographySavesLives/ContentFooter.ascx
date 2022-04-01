<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentFooter.ascx.cs" Inherits="ACR.controls.MammographySavesLives.ContentFooter" %>

<div class="content-footer">
	<div class="content-footer-links-container">
		<asp:Repeater ID="rptSocialLinks" runat="server">
			<HeaderTemplate>
				<ul class="content-footer-links social-icons">
			</HeaderTemplate>
			<ItemTemplate>
				<li class="social-icon-item" id="socialListItem" runat="server">
					<a target="_blank" class="social-icon" id="socialLink" runat="server">
						<sc:fieldrenderer id="socialImage" runat="server" FieldName="Logo" />
					</a>
				</li>
			</ItemTemplate>
			<FooterTemplate></ul></FooterTemplate>
		</asp:Repeater>
	
		<asp:Repeater ID="rptFooterLinks" runat="server">
			<HeaderTemplate>
				<ul class="content-footer-links">
			</HeaderTemplate>
			<ItemTemplate>
				<li class="content-footer-item" id="footerNavListItem" runat="server"><a class="content-footer-link" id="footerLink" runat="server"></a></li>
			</ItemTemplate>
			<FooterTemplate></ul></FooterTemplate>
		</asp:Repeater>
	</div>
</div>