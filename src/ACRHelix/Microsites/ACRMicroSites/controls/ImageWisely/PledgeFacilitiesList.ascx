<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PledgeFacilitiesList.ascx.cs" Inherits="ACR.controls.ImageWisely.PledgeFacilitiesList" %>

<asp:Repeater ID="rptStateOrCountry" runat="server" OnItemDataBound="rptStateOrCountry_ItemDataBound">
	<HeaderTemplate>
		<asp:Literal ID="litDivLevel" runat="server" />
		<asp:Literal ID="litLevelDescription" runat="server" />
	</HeaderTemplate>
	<ItemTemplate>
		<div class="listItem">
			<h3><asp:Literal ID="litStateOrCountry" runat="server" /></h3>
			<div class="inner">
				<asp:Repeater ID="rptFacility" runat="server" OnItemDataBound="rptFacility_ItemDataBound">
					<HeaderTemplate>
						<ul class="cf">
					</HeaderTemplate>
					<ItemTemplate>
                    <div class="sublistItem">
			         <h4><asp:Literal ID="litCity" runat="server" /></h4>
                    
			        <div class="subinner">
                    <asp:Repeater ID="rptCity" runat="server" OnItemDataBound="rptCity_ItemDataBound">
					<HeaderTemplate>
						<ul class="cf">
					</HeaderTemplate>
					<ItemTemplate>
						<li class="subodd">
							<p><asp:Literal ID="litFacilityName" runat="server" /></p>
							<p><asp:Literal ID="litFacilityLocation" runat="server" /></p>
						</li>
					</ItemTemplate>
					<AlternatingItemTemplate>
						<li>
							<p><asp:Literal ID="litFacilityName" runat="server" /></p>
							<p><asp:Literal ID="litFacilityLocation" runat="server" /></p>
						</li>
					</AlternatingItemTemplate>
					<FooterTemplate>
						</ul>
					</FooterTemplate>
				</asp:Repeater>
                </div>
                </li>
                </div>
                    </ItemTemplate> 
                    <FooterTemplate>
				</ul>
					</FooterTemplate>
                </asp:Repeater>
			</div>
		</div>
	</ItemTemplate>
	<FooterTemplate>
		</div>
	</FooterTemplate>
</asp:Repeater>
