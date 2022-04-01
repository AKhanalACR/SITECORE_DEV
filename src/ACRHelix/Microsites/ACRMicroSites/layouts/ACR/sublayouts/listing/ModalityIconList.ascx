<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalityIconList.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.listing.ModalityIconList" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>
<%@ Import Namespace="ACR.Constants" %>

<h2 class="uppercase"><sc:Text runat="server" ID="modalitySectionTitle" /></h2>

<asp:Repeater runat="server" ID="modalityIconList" OnItemDataBound="modalityIconList_ItemDataBound">
    <ItemTemplate>
        <figure class="accred-holder">
		<a href="<%# Sitecore.Links.LinkManager.GetItemUrl((Container.DataItem as Item)) %>"><sc:Image runat="server" ID="modalityIcon" />  </a>
		<figcaption><a href="<%# Sitecore.Links.LinkManager.GetItemUrl((Container.DataItem as Item)) %>" class="arrow-link"><%# ItemHelper.GetFieldValueOrItemName((Container.DataItem as Item),Types.Fields.NavNameOverride) %></a></figcaption>
	</figure>
    </ItemTemplate>
</asp:Repeater>