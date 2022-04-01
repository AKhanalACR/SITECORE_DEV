<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="ACR.controls.RLI.Header" %>
<header class="header">
	<div class="wrapper cf">
		<asp:HyperLink runat="server" ID="hlLogo" CssClass="logo"><asp:Image runat="server" ID="imgLogo"/></asp:HyperLink>
		<div class="topNav">
			<asp:Repeater runat="server" ID="rptTopLinks" OnItemDataBound="rptTopLinks_OnItemDataBound">
				<ItemTemplate>
					<asp:HyperLink runat="server" ID="hlTopLink"/>
				</ItemTemplate>
			</asp:Repeater>
			<asp:HyperLink runat="server" ID="hlFacebook" CssClass="facebook" Target="_blank"></asp:HyperLink>
			<asp:HyperLink runat="server" ID="hlTwitter" CssClass="twitter" Target="_blank"></asp:HyperLink>
		</div>

		<div class="search">
			<input type="text/css" placeholder="Search" id="searchbox" /><a href="" id="searchlink"></a>
		</div>
	</div>
</header>
<nav class="mainNav">
	<div class="wrapper cf">
			<ul>
		<asp:Repeater runat="server" ID="rptMainNav" OnItemDataBound="rptMainNav_OnItemDataBound">
			<ItemTemplate>
				<li>
					<asp:HyperLink runat="server" ID="hypMainNavItem"></asp:HyperLink>
					<asp:placeholder ID="plcSubNav" runat="server">
						<ul>
							<asp:Repeater runat="server" ID="rptSubnav" OnItemDataBound="rptSubNav_OnItemDataBound">
								<ItemTemplate>
									<li>
										<asp:HyperLink runat="server" ID="hypSubNavItem"></asp:HyperLink>
									</li>
								</ItemTemplate>
							</asp:Repeater>
						</ul></asp:placeholder>
				</li>
			</ItemTemplate>
		</asp:Repeater></ul></div>
</nav>