<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carousel.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.content.Carousel" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="home-hero-area">
    <asp:Repeater runat="server" ID="carouselRepeater" OnItemDataBound="carouselRepeater_ItemDataBound">
        <ItemTemplate>
            <div class="home-hero-slide">
                <asp:HyperLink runat="server" ID="link" CssClass="dis-block">
                    <figure>
                        <sc:Image runat="server" ID="image"></sc:Image>
                    </figure>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
