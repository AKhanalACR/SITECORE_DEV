<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccMammographyRichTextSection.ascx.cs" Inherits="ACRMicroSites.layouts.ACR.sublayouts.content.AccMammographyRichTextSection" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="content header-v-tpad">
     <header runat="server" ID="header" class="row-nested">
         <h1><sc:Text runat="server" ID="sectionTitle" /></h1>
     </header>
    <div class="row-nested">
        <sc:Text runat="server" ID="richText" />
    </div>
    
</div>