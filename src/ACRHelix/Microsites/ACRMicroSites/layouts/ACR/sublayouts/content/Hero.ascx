<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hero.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.content.Hero" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
        <div id="innerHero" runat="server">           
	        <div class="content">
		        <figure>
                    <sc:image id="heroImage" runat="server" />
		        </figure>
		        <div class="inner-hero-text flRight">
			        <h2 class="uppercase"><br /><sc:FieldRenderer ID="heroHeader" runat="server" /></h2>
			        <sc:FieldRenderer ID="heroContent" runat="server" />
                     <sc:Link ID="heroLink" runat="server" CssClass="home-hero-cta"></sc:Link>
		        </div>
	        </div>
        </div>