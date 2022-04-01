<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideNavigation.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.navigation.SideNavigation" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="side-panel xl-col-4th md-col-3rd col-full">
				<figure class="product-logo">
					<asp:HyperLink runat="server" ID="logoLink" ><sc:Image runat="server" ID="image" /></asp:HyperLink>
				</figure>
				<div class="product-navigation sm-closed">
					<div class="side-panel-heading">
						<h2><asp:Literal runat="server" ID="sideNavTitle"></asp:Literal></h2>
					</div>
					<nav> 
						<ul>
                            <asp:PlaceHolder runat="server" ID="sideNav"></asp:PlaceHolder>							
						</ul>
					</nav>
				</div>
				
			</div>