<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltTakeThePledge.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltTakeThePledge" %>

<div id="pledge">
	<asp:HyperLink ID="hlTake" ToolTip="Take the Pledge" runat="server" NavigateUrl="/Pledge" CssClass="redbutton">
		<img src="/images/ImageWisely/button_left.png" alt="button_left" class="redbutton_img"/>
		<span style="font-size: 23px; text-align: center;">Take the pledge</span>
	</asp:HyperLink>
	<p class="space"></p>
	<asp:Literal ID="ltlPledgeText" runat="server" /><p class="space"></p>
	<p class="space"></p>
	<div class="pledge2date">
		<h1><asp:Literal ID="ltlPledgeCount" runat="server" /></h1>
		<h2>PLEDGES THIS YEAR</h2>
	</div>
	<img src="/images/ImageWisely/pledge.jpg" align="pledge" class="pledgeimg" />
 </div>