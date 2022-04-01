<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="For Physicians.ascx.cs" Inherits="ACR.controls.MammographySavesLives.For_Physicians" %>

<div class="tools-for-physicians">
	<h2><asp:Literal ID="litComponentTitle" runat="server" /></h2>
	<div class="body-content single-column print-media">
		<sc:FieldRenderer id="physicianImage" runat="server" FieldName="Physician Image" />
		<div class="print-media-list">
		<ul>
		<asp:Repeater id="physRepeater" runat="server">
			<ItemTemplate>
				<li>
				<p><sc:FieldRenderer id="physTitle" runat="server" FieldName="Print Media Title"/><br />
				<a class="print-media-link" id="mediaLink1" runat="server"><sc:FieldRenderer id="lowresTitle" runat="server" FieldName="Low Res Title"/></a><a class="print-media-link" id="mediaLink2" runat="server"><sc:FieldRenderer id="highresTitle" runat="server" FieldName="Hi Res Title"/></a>
				</p>
				</li>
			</ItemTemplate>
		</asp:Repeater>	
		</ul>
		</div>
	</div>
</div>