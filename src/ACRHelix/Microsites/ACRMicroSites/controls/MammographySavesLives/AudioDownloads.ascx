<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AudioDownloads.ascx.cs" Inherits="ACR.controls.MammographySavesLives.AudioDownloads" %>

<div class="tools-audio-downloads">
	<h2><asp:Literal ID="litComponentTitle" runat="server" /></h2>
	<div class="body-content single-column print-media">
		<div class="audio-download-list">
		<ul>
		<asp:Repeater id="rptAudioDownloadsRepeater" runat="server">
			<ItemTemplate>
				<li>
				<p><sc:FieldRenderer id="frAudioDownloadTitle" runat="server" FieldName="Audio Download Title"/><br />
					<asp:Repeater id="rptAudioDownloadFileRepeater" runat="server">
						<ItemTemplate>
							<asp:Hyperlink ID="hlAudioDownloadFile" runat="server" CssClass="print-media-link" />
						</ItemTemplate>
					</asp:Repeater>
				</p>
				</li>
			</ItemTemplate>
		</asp:Repeater>	
		</ul>
		</div>
	</div>
</div>