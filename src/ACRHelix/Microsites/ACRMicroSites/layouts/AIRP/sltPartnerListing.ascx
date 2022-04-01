<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltPartnerListing.ascx.cs" Inherits="ACR.layouts.AIRP.PartnerListing" %>
<ul class="partnerList">
	<asp:Repeater runat="server" ID="rptPartners" OnItemDataBound="rtpPartners_OnItemDataBound">
		<ItemTemplate>
			<li class="cf">
				<h4><asp:HyperLink runat="server" ID="hypPartnerImageLink"><asp:Image runat="server" ID="imgPartnerImage"/></asp:HyperLink></h4>
				<section>
					<p><asp:Literal runat="server" ID="litPartnerName"/></p>
					<p><asp:Literal runat="server" ID="litPartnerLocation"/></p>
					<p><asp:Literal runat="server" ID="litEventDates"></asp:Literal></p>
					<p><asp:HyperLink runat="server" ID="hypPartnerLink"/></p>
					<p><asp:Literal runat="server" ID="litCourseOrgs"/></p>
				</section>
			</li>
		</ItemTemplate>
	</asp:Repeater>
					
				</ul>