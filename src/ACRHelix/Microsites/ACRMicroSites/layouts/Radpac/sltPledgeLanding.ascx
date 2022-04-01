<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.layouts.Radpac.sltPledgeLanding" Codebehind="sltPledgeLanding.ascx.cs" %><div>
	<asp:dropdownlist runat="server" id="ddlPledgeItems" autopostback="True" onselectedindexchanged="ddlPledgeItems_SelectedIndexChanged"></asp:dropdownlist>
</div>
<div style="padding-top:20px">
<asp:literal runat="server" id="ltlBttmText"></asp:literal>
</div>