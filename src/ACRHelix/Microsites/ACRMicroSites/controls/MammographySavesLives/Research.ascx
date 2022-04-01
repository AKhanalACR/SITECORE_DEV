<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Research.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Research" %>

<div class="body-content research-content">
<asp:Repeater ID="researchRepeater" runat="server">
<ItemTemplate>
	<div class="body-content-callout" id="itemDiv" runat="server">
		<p><a target="_blank" id="researchLink" runat="server">
		<sc:fieldrenderer id="researchTitle" runat="server" FieldName="Research Title" /></a><br /><sc:fieldrenderer id="researchAuthor" runat="server" FieldName="Research Author" /></p>
	</div>
	<div class="clear" id="itemClear" runat="server"></div>
	</ItemTemplate>
</asp:Repeater>
</div>
