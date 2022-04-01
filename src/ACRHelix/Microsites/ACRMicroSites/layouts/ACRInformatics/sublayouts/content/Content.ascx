<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Content.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.content.Content" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<h2 class="inline-block xl-pad-right-1">
    <sc:Text runat="server" ID="pageTitle" />
</h2>
<sc:Link runat="server" ID="link" CssClass="button"></sc:Link>
<div class="text-content">
    <p>
        <sc:Text runat="server" ID="pageText" />
    </p>
</div>
