<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeAwards.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.content.HomeAwards" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div id="gold-standard">
	<div class="content row">
		<div class="col-half">
			<h2 class="uppercase"><sc:Text runat="server" ID="homeAwardHeader" /></h2>
			<p><sc:Text runat="server" ID="homeAwardIntro" /></p>
			
			<div class="has-arrow-link desktop-only">
			<p>
			<sc:Text runat="server" ID=homeAwardContent />
			</p>
			</div>
			
		</div>
		<div class="col-half gold-standard-logos">
	<sc:Text runat="server" ID="awardSectionImages" />
		</div>
		
	</div>
</div>