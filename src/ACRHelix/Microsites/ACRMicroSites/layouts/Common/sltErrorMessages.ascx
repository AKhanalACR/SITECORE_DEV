<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltErrorMessages.ascx.cs" Inherits="ACR.layouts.Common.sltErrorMessages" %>


<div class="errorpage-banner">
	<h2><asp:Literal ID="litErrorBanner" runat="server"></asp:Literal></h2>
	<h4><asp:Literal ID="litErrorItem" runat="server"></asp:Literal></h4>
</div>
<div class="errorpage-msg">
	<asp:Literal ID="ltlErrorMsg" runat="server" />
</div>
