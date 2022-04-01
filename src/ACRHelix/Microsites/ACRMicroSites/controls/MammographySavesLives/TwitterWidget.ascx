<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwitterWidget.ascx.cs"	Inherits="ACR.controls.MammographySavesLives.TwitterWidget" %>

<div class="home-section-row-4-primary">
	<asp:PlaceHolder ID="phTwitterWidget" runat="server" Visible="false">
		<p class="text-box-title"><asp:Literal ID="litComponentTitle" runat="server" /></p>
        <div class="cookieconsent-optout-marketing cookiebot-general" style="display: none;height:31px">Please <a href="javascript:Cookiebot.renew()">accept marketing cookies</a> to to view this content.</div>
		<asp:Literal runat="server" ID="litTwitterWidget" />
	</asp:PlaceHolder>
</div>
<script type="text/plain" data-cookieconsent="marketing">	!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
