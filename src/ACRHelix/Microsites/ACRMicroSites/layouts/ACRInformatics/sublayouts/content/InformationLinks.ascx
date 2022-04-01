<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InformationLinks.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.content.InformationLinks" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="content">
	<div class="row">
		<div class="col-full text-center">
			<h3 class="uppercase"></h3>
		</div>
	</div>
	<div class="row inline-block-cols info-links-home">
		<div class="xl-col-5th lg-col-3rd md-col-3rd col-half xs-col-full">
			<div class="inline-ul block-li">
			<sc:Text runat="server" ID="column1" />
			</div>
		</div>
		
		<div class="xl-col-5th lg-col-3rd md-col-3rd col-half xs-col-full">
			<div class="inline-ul block-li">
			<sc:Text runat="server" ID="column2" />
			</div>
		</div>
		
		<div class="xl-col-5th lg-col-3rd md-col-3rd col-half xs-col-full">
			<div class="inline-ul block-li">
			<sc:Text runat="server" ID="column3" />
			</div>
		</div>
		
		<div class="xl-col-5th lg-col-3rd md-col-3rd col-half xs-col-full">
			<div class="inline-ul block-li">
				<sc:Text runat="server" ID="column4" />
			</div>
		</div>
		
		<div class="xl-col-5th lg-col-3rd md-col-3rd col-half xs-col-full">
			<div class="inline-ul block-li">
				<sc:Text runat="server" ID="column5" />
			</div>
		</div>
		
	</div>
	
</div>