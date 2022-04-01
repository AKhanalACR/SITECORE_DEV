<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltFeaturedWidget.ascx.cs" Inherits="ACR.layouts.RLI.widgets.sltFeaturedWidget" %>
<%@ Register TagPrefix="rli" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

<div class="item">
    <div class="inner">
        <rli:image ID="imgFeatured" runat="server" />
	    <h2><asp:Literal ID="ltlTitle" runat="server" /></h2>
        <asp:HyperLink ID="hlLearnMore" runat="server"></asp:HyperLink>
    </div> 
</div>