<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Downloads Module.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Downloads_Module" %>

<div class="content-box"> 
		<div class="content-box-header">
		<div class="content-box-title">
			<img src="/~/media/MammographySavesLives/Images/Videos/ttl-downloads.png" alt="Downloads"  />
		</div>
	</div>	
		
	<div class="content-box-details">
		<h3><sc:fieldrenderer id="firstTitle" runat="server" FieldName="First Section Title" /></h3>
		<p><sc:fieldrenderer id="firstText" runat="server" FieldName="First Section Text" /></p><br />
		<p><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Combo_30_V1.wmv" target="_blank">Mammography Saves Lives (:30)</a></p>
        <br />
        <p><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Lidia_60_V3.wmv" target="_blank">Lidia (:60)</a><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Lidia_30_V1.wmv" target="_blank">Lidia (:30)</a></p>
        <p><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Lidia_15_V1.wmv" target="_blank">Lidia (:15)</a><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Lidia_30Sp_V5.wmv" target="_blank">Lidia (:30 - Spanish)</a></p>
        <br />
        <p><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Pam_60_V3.wmv" target="_blank">Pam (:60)</a><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Pam_30_V1.wmv" target="_blank">Pam (:30)</a><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Pam_15_V2.wmv" target="_blank">Pam (:15)</a></p>
        <br />
        <p><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Robin_60_V3.wmv" target="_blank">Robin (:60)</a><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Robin_30_V5.wmv" target="_blank">Robin (:30)</a><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Robin_15_V1.wmv" target="_blank" target="_blank">Robin (:15)</a></p>
        <br />
        <p><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Sunny_60_V3.wmv" target="_blank">Sunny (:60)</a><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Sunny_30_V1.wmv" target="_blank">Sunny (:30)</a><a class="video-download" href="/~/media/MammographySavesLives/Video Downloads/10-076_ACR_Sunny_15_V2.wmv" target="_blank">Sunny (:15)</a></p><br />
        <p></p>	
<%--			<asp:Repeater ID="downloadRepeater" runat="server">
				<ItemTemplate>
					<a class="video-download" id="downloadlink" runat="server" />
						<sc:fieldrenderer id="downloadTitle" runat="server" FieldName="Download Title" /></a>
					</ItemTemplate>
			</asp:Repeater><br />--%>
		<h3><sc:fieldrenderer id="secondTitle" runat="server" FieldName="Second Section Title" /></h3>
		<p><sc:fieldrenderer id="secondText" runat="server" FieldName="Second Section Text" /></p>
	</div>
</div>