<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="ACR.controls.RLI.Footer" %>
			
			<footer class="page">
	<div class="wrapper cf">
		<div class="sitemap">
			<asp:Repeater runat="server" ID="rptFooterLinkColumns" OnItemDataBound="rptFooterLinkColumns_OnItemDataBound">
				<ItemTemplate>
					<ul>
								<li><strong><asp:HyperLink runat="server" ID="hypHeaderLink"></asp:HyperLink></strong></li>
						<asp:Repeater runat="server" ID="rptFooterLinks" OnItemDataBound="rptFooterLink_OnItemDataBound">
							<ItemTemplate>
								<li><asp:HyperLink runat="server" ID="hypLink"/></li>
							</ItemTemplate>
						</asp:Repeater>
					</ul>
				</ItemTemplate>
			</asp:Repeater>
		</div>

		<div class="socialMedia">
			<asp:HyperLink runat="server" ID="hlFacebook" Target="_blank" CssClass="facebook"></asp:HyperLink>
			<asp:HyperLink runat="server" ID="hlTwitter" Target="_blank" CssClass="twitter"></asp:HyperLink>
		</div>

		<div class="buttons">
			<asp:Repeater runat="server" ID="rptButtons" OnItemDataBound="rptButtons_OnItemDataBound">
				<ItemTemplate>
					<asp:HyperLink runat="server" ID="hlButton" CssClass="button grey"><asp:Image runat="server" ID="imgButtonIcon" CssClass="icon"/><asp:Literal runat="server" ID="litButtonTitle"></asp:Literal></asp:HyperLink>
				</ItemTemplate>
			</asp:Repeater>
		</div>

		<div class="info">
			<asp:Literal runat="server" ID="litCopyright"></asp:Literal>
		</div>
	</div>
</footer>