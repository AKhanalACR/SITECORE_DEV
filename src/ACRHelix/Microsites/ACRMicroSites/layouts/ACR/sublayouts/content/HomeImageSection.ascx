<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeImageSection.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.content.HomeImageSection" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div id="home-pg-image-cred">
    <div class="content row">
        <div class="col-half">
            <h2 class="uppercase">
                <sc:Text runat="server" ID="imageGentlyHeader" />
            </h2>
            <p>
                <sc:Text runat="server" ID="homeImageIntro" />
            </p>
            <div class="has-arrow-link desktop-only">
                <sc:Text runat="server" ID="homeImageContent" />
            </div>
        </div>
        <div class="col-half image-cred-col">        
               <sc:FieldRenderer runat="server" ID="imageContent" />           
        </div>
    </div>
</div>
