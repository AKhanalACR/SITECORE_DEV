<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltCarousel.ascx.cs" Inherits="ACR.layouts.AIRP.sltCarousel" %>
<div class="carousel">
	<ul class="slideshow">
		<asp:Repeater runat="server" ID="rptCarousel" OnItemDataBound="rptCarousel_OnItemDataBound">
			<ItemTemplate>
				<li>
				    <asp:HyperLink runat="server" ID="hlCarouselImageLink" CssClass="sliderImageLink">
					    <asp:Image runat="server" ID="imgCarouselImage" Width="946" Height="311"/>
					</asp:HyperLink>
					<section>
						<h1><asp:Literal runat="server" ID="litImageHeader"></asp:Literal></h1>
						<asp:Literal runat="server" ID="litImageText"></asp:Literal>
					</section>
				</li>
			</ItemTemplate>
		</asp:Repeater>
	</ul>
	<div class="pager"></div>
	<span class="pause" runat="server" id="spnPagerButton"></span>
</div>
