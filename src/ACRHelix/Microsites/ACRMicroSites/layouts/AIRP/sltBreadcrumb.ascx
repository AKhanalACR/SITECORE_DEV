<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltBreadcrumb.ascx.cs" Inherits="ACR.layouts.AIRP.sltBreadcrumb" %>

<ul class=" breadcrumb cf">
	<asp:Repeater runat="server" ID="rptBreadcrumb" OnItemDataBound="rptBreadcrumb_OnItemDataBound">
		<ItemTemplate>
			<li>
				<asp:HyperLink runat="server" ID="hypBreadcrumbItem"/>
				<asp:Literal runat="server" ID="litSeparator"/>
			</li>
			
		</ItemTemplate>
	</asp:Repeater>
</ul>