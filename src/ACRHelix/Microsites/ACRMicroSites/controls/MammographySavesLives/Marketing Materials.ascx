<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Marketing Materials.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Marketing_Materials" %>

<div class="tools-marketing-materials">
	<h2>Marketing Materials</h2>
	<div class="body-content single-column print-media">
		<sc:FieldRenderer id="marketingMaterialsImage" runat="server" FieldName="Marketing Materials Image" />
		<div class="print-media-list">
		<ul>
		<asp:Repeater id="marketingMaterialsRepeater" runat="server">
			<ItemTemplate>
				<li>
				<p><sc:FieldRenderer id="marketingMaterialsTitle" runat="server" FieldName="Print Media Title"/><br />
				<a class="print-media-link" id="mediaLink1" runat="server"><sc:FieldRenderer id="lowresTitle" runat="server" FieldName="Low Res Title"/></a><a class="print-media-link" id="mediaLink2" runat="server"><sc:FieldRenderer id="highresTitle" runat="server" FieldName="Hi Res Title"/></a>
				</p>
				</li>
			</ItemTemplate>
		</asp:Repeater>	
		</ul>
		</div>
	</div>
</div>