<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltMainContent.ascx.cs" Inherits="ACR.layouts.RLI.sltMainContent" %>
<article>
	<h1><asp:Literal ID="ltlTitle" runat="server" /></h1>

	<sc:Placeholder ID="phInternalContent" runat="server" Key="InternalContent" />
</article>