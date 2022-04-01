<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltSidebar.ascx.cs" Inherits="ACR.layouts.AIRP.sltSidebar" %>

			<aside>
				<section>
					<asp:Repeater runat="server" ID="rptSidebarButtons" OnItemDataBound="rptSidebarButtons_OnItemDatabound">
						<ItemTemplate>
							<asp:HyperLink runat="server" ID="hypSidebarLink" CssClass="button">
								<asp:Image runat="server" ID="imgSidebarImage"/>
								<span><asp:Literal runat="server" ID="litLinkText"></asp:Literal></span>
							</asp:HyperLink>
						</ItemTemplate>
					</asp:Repeater>
				</section>
				<section class="hotLinks">
					<h1><asp:Literal runat="server" ID="litHotlinksTitle"></asp:Literal></h1>
					<ul>
						<asp:Repeater runat="server" ID="rptHotlinks" OnItemDataBound="rptHotlink_OnItemDataBound">
							<ItemTemplate>
								<li>
									<asp:HyperLink runat="server" ID="hypHotlink"></asp:HyperLink>
								</li>
							</ItemTemplate>
						</asp:Repeater>
					</ul>
				</section>
			</aside>