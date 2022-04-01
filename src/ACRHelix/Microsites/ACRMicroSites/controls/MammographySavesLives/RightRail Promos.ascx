<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RightRail Promos.ascx.cs" Inherits="ACR.controls.MammographySavesLives.RightRail_Promos" %>

<asp:Repeater ID="rptRightRailPromos" runat="server">
	<HeaderTemplate>
	</HeaderTemplate>
	<ItemTemplate>
	<div class="sidebar-callout">
			<h5><img class="callout-image" id="calloutImage" runat="server" />
			<a class="callout-header-sm" id="calloutTitle" runat="server"></a></h5>
			<%--<h5 class="callout-header-sm" id="calloutTitle" runat="server"></h5>--%>
			<p id="calloutDesc" runat="server" visible="false"></p>
			<a class="callout-action" id="calloutAction" runat="server" visible="false"></a>
		</div>
	</ItemTemplate>
	<FooterTemplate>
	</FooterTemplate>
</asp:Repeater>
<div class="clear"></div>
