<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccMammographyHero.ascx.cs" Inherits="ACRMicroSites.layouts.ACR.sublayouts.content.AccMammographyHero" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="acc-msl-hero">  
    <figure>
        <sc:image ID="heroBackground" runat="server"/>         
    </figure>
    <div class="content inner-hero-text flRight">
	    <h2 class="uppercase"><br />
            <sc:Text ID="heroHeader" runat="server" />
	    </h2>		    
	</div>    
</div>
<div class="spaced-item-spacer"> </div>