<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Standard.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.content.Standard" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<div class="content">

<h1><sc:Text runat="server" ID="contentTitle" /></h1>
<sc:FieldRenderer ID="mainContent" runat="server" />

    </div>