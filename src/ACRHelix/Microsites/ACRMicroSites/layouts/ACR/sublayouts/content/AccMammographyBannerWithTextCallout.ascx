<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccMammographyBannerWithTextCallout.ascx.cs" Inherits="ACRMicroSites.layouts.ACR.sublayouts.content.AccMammographyBannerWithTextCallout" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="acc-msl-banner">  
    <figure>
        <sc:image ID="BannerBackground" runat="server"/>         
    </figure>
    
    <div class="content">        
        <div class="inner-hero-text row-nestled">
            <div class="md-col-12 lg-col-4">
                <sc:Text runat="server" ID="LeftText" />
            </div>
            <div class="md-col-12 lg-col-4">
                <sc:Text runat="server" ID="CenterText" />
            </div>
            <div class="md-col-12 lg-col-4">
                <sc:Text runat="server" ID="RightText" />
            </div>
            
        </div>
    </div>

</div>
<div class="spaced-item-spacer"> </div>


<%--<style>
    .acc-msl-banner, .acc-msl-hero {
       min-height: 192px; overflow: hidden; position: relative; /*width: 100%; */
    }
    .acc-msl-banner .content {
       position: absolute; top: 0%; left: 25%; 
    }   
    .acc-msl-banner .inner-hero-text {
        width:100%; margin-top:10px; margin-left:20px; text-align:left;
         
    }
    .acc-msl-hero .content {
       position: absolute; top: 0%; left: 20%; 
    }

    .acc-msl-hero .inner-hero-text {
        width:100%; margin-top:10px; margin-left:20px; text-align:center;  
    }
    .acc-msl-nav {
        max-width:400px;
    }
    
    @media only screen and (max-width: 768px) {
        .acc-msl-banner .content, lbl-d-none {
            display:none;
        }   
        .acc-msl-hero .content {
            position: absolute; top: 0%; left: 0%; 
        }     
    }
</style>--%>