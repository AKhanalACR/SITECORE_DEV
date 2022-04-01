<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="carousel.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.widgets.carousel" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="pride-section-cover">
    <div class="content" id="pride-section">
        <div class="col-full mobile-only">
            <h2 class="uppercase">
                <sc:Text runat="server" ID="carouselHeaderMobile" />
            </h2>
        </div>
        <div class="col-third">
            <div class="cycle-slideshow-wrapper">
                <div class="cycle-slideshow" id="home-page-slider" data-cycle-slides=".intro-slide" data-cycle-fx="fade" data-cycle-manual-fx="fadeIn" data-cycle-timeout="6000" data-cycle-pause-on-hover="true" data-cycle-prev=".prev-slide" data-cycle-next=".next-slide">

                    <asp:Repeater runat="server" ID="carouselRepeater">
                        <ItemTemplate>
                            <div class="intro-slide">
                                <%--<sc:Image runat="server" ID="carouselImage" />--%>
                                <img src="<%# Sitecore.StringUtil.EnsurePrefix('/', GetMediaUrl(Container.DataItem as Sitecore.Data.Items.Item)) %>" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="next-slide icon"></div>
                    <div class="prev-slide icon"></div>
                    <div class="cycle-pager"></div>
                </div>
            </div>

        </div>
        <div class="col-twoThirds">
            <h2 class="uppercase desktop-only">
                <sc:Text runat="server" ID="carouselHeaderMain" />
            </h2>
            <p>
                <sc:Text runat="server" ID="carouselContent" />
            </p>
            <sc:Link runat="server" ID="clink" CssClass="arrow-link" />
        </div>
    </div>
</div>