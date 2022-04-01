<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltRadiationSafetyCase.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltRadiationSafetyCase" %>
<div >
	<p class="adHeading">&nbsp;</p>
	<p class="ad">
		<a href="/Case" target="_blank">
			<img runat="server" class="imgRadSafetyCase" id="imgRadSafetyCase" 
				title="Radiation Safety Case"
				alt="Radiation Safety Case" />
		</a>
		<span style="display: inline-block;" class="RadSafetyCaseBtn">
			<asp:HyperLink ID="hlSubscribe" Title="Radiation Safety Cases" runat="server" NavigateUrl="/Case" CssClass="redbutton">
				<img src="/images/ImageWisely/button_left.png" alt="button_left" class="redbutton_img"/>
				<span class="radiation-safety-case">
					Radiation Safety Cases
				</span>
			</asp:HyperLink>
		</span>
	</p>
</div>
