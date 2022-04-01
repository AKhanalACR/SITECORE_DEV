<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltFooter.ascx.cs" Inherits="ACR.layouts.AIRP.sltFooter" %>
<asp:PlaceHolder ID="phAdScript" runat="server" Visible="false">
	<div class="footer-advertisement">
				<asp:Literal runat="server" ID="litAdScript" />
	</div>
</asp:PlaceHolder>
<div class="newsletter cf">
	<div class="wrapper cf">
		<asp:Image runat="server" ID="imgNewsletter"/>
		<section>
			<asp:Literal runat="server" ID="litNewsletter"></asp:Literal>		</section>
		<asp:HyperLink runat="server" CssClass="button" ID="hypNewsletter"></asp:HyperLink>
	</div>
</div>
<footer class="cf">
	<div class="wrapper">
		<div class="linkedLists">
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
			<ul>
			<asp:Repeater runat="server" ID="rptFooterSideLinks" OnItemDataBound="rptFooterSideLinks_OnItemDataBound">
				<ItemTemplate>
					<li>
						<strong><asp:HyperLink runat="server" ID="hypSideLink"/></strong>
					</li>
				</ItemTemplate>
			</asp:Repeater>
				<li class="social">
					<ul>
		<li><asp:HyperLink runat="server" CssClass="facebook"  ID="hypFacebook" Target="_blank"><strong>Facebook</strong></asp:HyperLink></li>
		<li><asp:HyperLink runat="server" CssClass="twitter"  ID="hypTwitter" Target="_blank"><strong>Twitter</strong></asp:HyperLink></li>
		<li><asp:HyperLink runat="server" CssClass="youTube"  ID="hypYouTube" Target="_blank"><strong>YouTube</strong></asp:HyperLink></li>
					</ul>
				</li>			
			</ul>
		</div>
		<%--<div class="advertisement">
			<asp:Literal runat="server" ID="litAdScript" Visible="false" />
		</div>--%>
		<div class="copyright">
			<p>&copy; <asp:Literal runat="server" ID="litDate"/> American Institute for Radiologic Pathology.</p>
			<ul class="cf">
				<li><asp:HyperLink runat="server" ID="hypCopyright"></asp:HyperLink></li>
				<li><asp:HyperLink runat="server" ID="hypPrivacy"></asp:HyperLink></li>
			</ul>
		</div>
	</div>
		
</footer>