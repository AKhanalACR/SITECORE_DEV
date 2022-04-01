<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carousel.ascx.cs" Inherits="ACR.controls.RLI.Carousel" %>
<div class="wrapper carousel">
	<div class="slideshow">
		<asp:Repeater runat="server" ID="rptCarousel" OnItemDataBound="rptCarousel_OnItemDataBound">
			<ItemTemplate>
				<div class="slide df">
					
					<asp:Image runat="server" ID="imgSlideImage" Width="1680" Height="476"/>
					<asp:PlaceHolder ID="plcContent" runat="server">
					<asp:HyperLink runat="server" ID="hlSlideLink" CssClass="content"><h1><asp:Literal runat="server" ID="litSlideTitle"></asp:Literal></h1><asp:Literal runat="server" ID="litSlideText"/></asp:HyperLink>
					</asp:PlaceHolder>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
	<div class="nav cf"></div>
	<div class="controls">
		<a href="#" class="pause">Pause</a>
		<a href="#" class="play">Play</a>
	</div>
</div>