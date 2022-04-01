<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnlineProviderResources.ascx.cs" Inherits="ACR.controls.MammographySavesLives.OnlineProviderResources" %>

<h2 class="resource-title"><asp:Literal ID="litComponentTitle" runat="server" /></h2>
<div class="body-content single-column print-media">
	<ul class="resource-list">
		<asp:Repeater id="onlineProviderResourcesRepeater" runat="server">
			<ItemTemplate>
				<li>
					<asp:HyperLink runat="server" ID="hlOnlineProviderResourcesLink" CssClass="resource-link" />
				</li>
			</ItemTemplate>
		</asp:Repeater>	
	</ul>
</div>