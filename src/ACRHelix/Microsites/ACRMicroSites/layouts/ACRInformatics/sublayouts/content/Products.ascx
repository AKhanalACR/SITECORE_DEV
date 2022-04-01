<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Products.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.content.Products" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="launchpad-area">
    <div class="content row inline-block-cols">
        <asp:Repeater runat="server" ID="productRepeater" OnItemDataBound="productRepeater_ItemDataBound">
            <ItemTemplate>
                <section class="launchpad xl-col-4th sm-col-half md-col-half xs-col-full">
                    <figure class="launchpad-logo">
                        <sc:Link runat="server" ID="imageLink" CssClass="productLink"><sc:Image runat="server" ID="image" /></sc:Link>
                    </figure>
                    <h2>
                       <sc:Link runat="server" ID="link" CssClass="productLink"><sc:Text runat="server" ID="title" /></sc:Link>
                    </h2>
                    <div class="text-content">
                        <p>
                            <sc:Text runat="server" ID="text" />
                        </p>
                    </div>
                </section>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

<script type="text/javascript">
    jQuery(function () {
        jQuery(".productLink").attr('target', '');
    });
</script>
