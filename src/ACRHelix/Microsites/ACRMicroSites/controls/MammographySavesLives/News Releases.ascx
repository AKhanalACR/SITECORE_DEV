<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News Releases.ascx.cs" Inherits="ACR.controls.MammographySavesLives.News_Releases" %>

<h2><asp:Literal ID="litComponentTitle" runat="server" /></h2>
<div runat="server" id="divBody" class="body-content research-content single-column">
	<asp:Repeater ID="NewsReleaseRepeater" runat="server">
	<ItemTemplate>
		<div class="body-content-callout" id="releaseDiv" runat="server">
		<p>
		<a target="_blank" id="releaseLink" runat="server">
		<sc:fieldrenderer id="newsTitle" runat="server" FieldName="News Release Title" /></a></p>
		</div>
		<div class="clear" id="itemClear" runat="server" Visible="false"></div>
	</ItemTemplate>
	</asp:Repeater>
</div>