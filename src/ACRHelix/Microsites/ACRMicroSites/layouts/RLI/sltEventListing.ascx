<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltEventListing.ascx.cs"	Inherits="ACR.layouts.RLI.sltEventListing" %>

<div class="list meetings">
	<asp:Repeater runat="server" ID="rptTags" OnItemDataBound="rptTags_OnItemDataBound">
		<ItemTemplate>
			<section>
			<label><asp:Literal runat="server" ID="litTag"/></label>
				<ul>
					<asp:Repeater runat="server" ID="rptEvents" OnItemDataBound="rptEvents_OnItemDataBound">
						<ItemTemplate>
							<li>
								<div class="title"><asp:Hyperlink runat="server" ID="hlTitle"></asp:Hyperlink></div>
								<div class="date"><asp:Literal runat="server" ID="litDate"></asp:Literal></div>
								<div class="location"><asp:Literal runat="server" ID="litLocation"></asp:Literal></div>
								<div class="location"><asp:Literal runat="server" ID="litTeaser"></asp:Literal></div>
								<asp:HyperLink runat="server" ID="hlRegistration">Details and Registration &raquo;</asp:HyperLink>
							</li>
						</ItemTemplate>
					</asp:Repeater>
				</ul>
			</section>
		</ItemTemplate>
	</asp:Repeater>
	<section id="noTags" runat="server" visible="False">
		<ul>
			<asp:Repeater runat="server" ID="rptEventsNoTag" OnItemDataBound="rptEvents_OnItemDataBound">
				<ItemTemplate>
					<li>
						<div class="title"><asp:Hyperlink runat="server" ID="hlTitle"></asp:Hyperlink></div>
						<div class="date"><asp:Literal runat="server" ID="litDate"></asp:Literal></div>
						<div class="location"><asp:Literal runat="server" ID="litLocation"></asp:Literal></div>
						<div class="location"><asp:Literal runat="server" ID="litTeaser"></asp:Literal></div>
						<asp:HyperLink runat="server" ID="hlRegistration">Details and Registration &raquo;</asp:HyperLink>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</section>
</div>