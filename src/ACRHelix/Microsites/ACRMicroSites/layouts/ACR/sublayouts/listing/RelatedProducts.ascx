<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedProducts.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.listing.RelatedProducts" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="related-products">
	<div class="content">
		<h2>Related Products</h2>		
		<div class="row">
            <asp:Repeater runat="server" ID="relatedProductRepeater" OnItemDataBound="relatedProductRepeater_ItemDataBound" >
                <ItemTemplate>
                  <div class="col-fourth related-product <%# Container.ItemIndex <= 1 ? "ipad-col-half" : "" %>">
				<h4><sc:Link runat="server" ID="titleLink"><sc:Text runat="server" ID="titleText" /></sc:Link></h4>
				<figure><sc:Link runat="server" ID="productImageLink"><sc:Image runat="server" ID="productImage" /></sc:Link>
					<figcaption><sc:Link runat="server" ID="productLink"></sc:Link></figcaption>
				</figure>
			</div>
                </ItemTemplate>
            </asp:Repeater>
		</div>
	</div>
</div>