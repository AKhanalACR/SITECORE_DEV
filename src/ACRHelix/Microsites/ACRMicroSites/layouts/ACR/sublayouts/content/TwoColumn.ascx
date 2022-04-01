<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwoColumn.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.content.TwoColumn" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="ACR.Constants" %>

<div class="content pad-bottom-3em">
	<h1 class="uppercase"><sc:Text runat="server" ID="contentTitle" /></h1> 
	<div class="row">
		<div class="col-half">
			<sc:FieldRenderer ID="column1" runat="server" />
		</div>
		
		<div class="col-half">
			<sc:FieldRenderer ID="column2" runat="server" />
		</div>
	</div>
</div>