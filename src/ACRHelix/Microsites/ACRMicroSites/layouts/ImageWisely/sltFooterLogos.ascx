<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltFooterLogos.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltFooterLogos" %>

<asp:Placeholder ID="phFooterLogos" runat="server" Visible="false">
	<asp:Repeater ID="rptFooterLogos" runat="server" OnItemDataBound="rptFooterLogos_ItemDataBound">
		<HeaderTemplate>
			<div class="logos">
				<h2>This content was developed jointly with:</h2>
				<div class="borderdiv"></div>
				<ul class="cf">
		</HeaderTemplate>
		<ItemTemplate>
			<li class="odd">
				<asp:ImageButton ID="imgBtn" runat="server" />
			</li>
		</ItemTemplate>
		<AlternatingItemTemplate>
			<li>
				<asp:ImageButton ID="imgBtn" runat="server" />
			</li>
		</AlternatingItemTemplate>
		<FooterTemplate>
				</ul>
			</div>
			<p>&nbsp;&nbsp;</p>
		</FooterTemplate>
	</asp:Repeater>
</asp:Placeholder>