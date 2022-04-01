<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.layouts.ImageWisely.sltRotatingCarousel"	CodeBehind="sltRotatingCarousel.ascx.cs" %>

<asp:Repeater ID="rptHomeSlider" runat="server" OnItemDataBound="rptHomeSlider_ItemDataBound">
	<HeaderTemplate>
		<div class="homeSlider slides homeSection cf">
			<div class="slides_container">
	</HeaderTemplate>
	<ItemTemplate>
		<div>
			<asp:HyperLink runat="server" ID="hlLink" CssClass="carouselLink">
				<div>
					<div class="overlay">
						<h1><asp:Literal runat="server" ID="litTitle"></asp:Literal></h1>
						<h2><asp:Literal runat="server" ID="litDesc"></asp:Literal></h2>
						<asp:PlaceHolder runat="server" ID="phButton" Visible="false">
							<div class="redbutton button">
								<img src="images/ImageWisely/button_left.png" alt="button_left" class="redbutton_img" />
								<span><asp:Literal runat="server" ID="litButtonLabel"></asp:Literal></span>
							</div>
						</asp:PlaceHolder>
					</div>
					<asp:Image ID="img" runat="server" Width="694" Height="287" CssClass="background"/>
				</div>
			</asp:HyperLink>
		</div>
	</ItemTemplate>
	<FooterTemplate>
			</div>
		</div>
	</FooterTemplate>
</asp:Repeater>
