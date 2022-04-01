<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltInternalPgContent.ascx.cs" Inherits="ACR.layouts.RLI.sltInternalPgContent" %>
<%@ Register TagPrefix="rli" TagName="AddThis" Src="~/controls/RLI/AddThisBodyWidget.ascx" %>

<h2 class="subheader"><asp:Literal ID="ltlSubheader" runat="server" /></h2>
								
	<asp:Literal ID="ltlBody" runat="server" />

	<div class="addthis">
		<!--addthis code/tool here-->
									<rli:AddThis runat="server" />
	</div>
