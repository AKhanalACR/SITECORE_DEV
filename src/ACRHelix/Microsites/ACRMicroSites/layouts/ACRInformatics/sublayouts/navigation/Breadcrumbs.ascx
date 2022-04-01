<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Breadcrumbs.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.navigation.Breadcrumbs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="inline-block breadcrumbs">
    <asp:Repeater runat="server" ID="breadcrumbRepeater" OnItemDataBound="breadcrumbRepeater_ItemDataBound">
        <ItemTemplate>
             <span class="separator">/</span>
            <asp:HyperLink runat="server" ID="link" >
                <sc:Image runat="server" ID="logo" />
            </asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>
</div>