<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltHomeFeaturedContent.ascx.cs" Inherits="ACR.layouts.AIRP.sltHomeFeaturedContent" %>
<article>
	<asp:Repeater runat="server" ID="rptHomeFeatures" OnItemDataBound="rptHomeFeatures_OnItemDataBound">
		<ItemTemplate>
			<section>
				<h1><asp:Hyperlink runat="server" ID="hypContentTitle"></asp:Hyperlink></h1>
				<asp:Literal runat="server" ID="litContent"></asp:Literal>
			</section>
		</ItemTemplate>
	</asp:Repeater>
			</article>