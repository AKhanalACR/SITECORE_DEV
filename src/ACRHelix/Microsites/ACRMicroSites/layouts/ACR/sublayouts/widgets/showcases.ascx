<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="showcases.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.widgets.showcases" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACR.Constants" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>

<asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
        <div class="content showcase-tabs">
            <asp:Repeater ID="Tabs" runat="server" OnItemDataBound="Tabs_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton ID="Locale" runat="server" 
                        CommandArgument="<%# (Container.DataItem as Item).ID %>" 
                        Text="<%# (Container.DataItem as Item).DisplayName %>" 
                        OnClick="Locale_Click">LinkButton</asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="content row showcase-body">
            <asp:Repeater ID="Showcases" runat="server">
                <ItemTemplate>
                    <div class="col-half ipad-col-half showcase-item">
		                <figure>
                            <a class="group3" href="<%# Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl((Container.DataItem as Item))) %>"><img src="<%# Sitecore.StringUtil.EnsurePrefix('/', GetMediaUrl((Container.DataItem as Item), new Sitecore.Resources.Media.MediaUrlOptions {MaxHeight = 400, MaxWidth = 300})) %>" /></a>
			                <figcaption>
				                <a href="<%# Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl((Container.DataItem as Item))) %>" class="arrow-link group1">
                                    <%# ItemHelper.GetFieldValueOrItemName((Container.DataItem as Item), "Alt") %></a>
				                <a href="<%# Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl((Container.DataItem as Item))) %>" class="icon showcase group2"></a>
			                </figcaption>
		                </figure>
	                </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
