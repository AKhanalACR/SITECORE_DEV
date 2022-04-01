<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Facts.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Facts" %>
<div class="main-highlight-panel">
	<div class="primary-highlight">
		<sc:fieldrenderer id="leadFactImage" runat="server" FieldName="Fact Image" />
		<p class="highlight-text"><sc:fieldrenderer id="leadFactText" runat="server" FieldName="Fact Description" /></p>
		<span class="highlight-panel-image-container">
			<span class="highlight-panel-image"><sc:fieldrenderer id="factsLeadImage" runat="server" FieldName="Facts Lead Image" /></span>
		</span>
	</div>
	
	<asp:Repeater ID="rptFacts" runat="server">
		<ItemTemplate>
			<div class="secondary-highlight">
				<sc:fieldrenderer id="factImage" runat="server" FieldName="Fact Image" />
				<p><sc:fieldrenderer id="factDescription" runat="server" FieldName="Fact Description" /></p>
			</div>
		</ItemTemplate>
	</asp:Repeater>
	<div class="clear"></div>
</div>
