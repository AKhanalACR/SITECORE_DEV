<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftRail.ascx.cs" Inherits="ACR.controls.RLI.LeftRail" %>

<aside class="leftNav">
	<ul>
		<asp:Repeater runat="server" ID="rptNavLevel1" OnItemDataBound="rptNavLevel1_OnItemDataBound">
			<ItemTemplate>
				<li class="cf"><asp:HyperLink runat="server" ID="hlNavLink1"><span></span></asp:HyperLink>
					<asp:Repeater runat="server" ID="rptNavLevel2" OnItemDataBound="rptNavLevel2_OnItemDataBound">
						<HeaderTemplate><ul></HeaderTemplate>
						<ItemTemplate>
							<li class="cf" >
								<asp:HyperLink runat="server" ID="hlNavLink2"><span></span></asp:HyperLink>
									<asp:Repeater runat="server" ID="rptNavLevel3" OnItemDataBound="rptNavLevel3_OnItemDataBound">
										<HeaderTemplate><ul></HeaderTemplate>
										<ItemTemplate>
											<li class="cf"><asp:HyperLink runat="server" ID="hlNavLink3"><span></span></asp:HyperLink></li>
										</ItemTemplate>
										<FooterTemplate></ul></FooterTemplate>
									</asp:Repeater>
							</li>
						</ItemTemplate>
						<FooterTemplate></ul></FooterTemplate>
					</asp:Repeater>
				</li>
			</ItemTemplate>
		</asp:Repeater>
	</ul>
</aside>