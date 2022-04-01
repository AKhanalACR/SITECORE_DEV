<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderBanner.ascx.cs" Inherits="ACR.controls.RLI.Responsive.HeaderBanner" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:PlaceHolder runat="server" ID="headerBannerPLC">
    <aside class="content row mobile-nav-hide" id="banner-header">
        <div class="col-12">
            <asp:Literal ID="ltRliHeaderBannerAd" runat="server"></asp:Literal>
        </div>
    </aside>
</asp:PlaceHolder>

