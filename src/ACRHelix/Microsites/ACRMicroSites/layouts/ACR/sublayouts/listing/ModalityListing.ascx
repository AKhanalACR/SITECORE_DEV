<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalityListing.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.listing.ModalityListing" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="Sitecore.Links" %>
<%@ Import Namespace="ACR.Constants" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>


<div class="content pad-bottom-3em">
<asp:Repeater runat="server" ID="modalityList" OnItemDataBound="modalityList_ItemDataBound">
    <ItemTemplate>
        <section class="modality">
		<h3><%# (Container.DataItem as Item).Name %></h3>
			<figure>
                <sc:Image runat="server" ID="modalImage" />                
			</figure>
			<div class="modalities-content">
				<p><%# ItemHelper.GetFieldValue(Container.DataItem as Item,"Teaser")  %></p>
				<p><a href="<%# LinkManager.GetItemUrl((Container.DataItem as Item)) %>" class="arrow-link"><%# ItemHelper.GetFieldValue(Container.DataItem as Item,Types.Fields.ModalityLinkText) %></a>
			</p></div>
		</section>
    </ItemTemplate>
</asp:Repeater>
    </div>