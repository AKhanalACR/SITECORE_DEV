<%@ Control Language="C#" AutoEventWireup="True" Inherits="ACR.layouts.ImageWisely.sltPledgeLanding" Codebehind="sltPledgeLanding.ascx.cs" %>

<!-- Begin: New Pledge html -->
<asp:Repeater ID="rptPledge" runat="server" OnItemDataBound="rptPledge_ItemBound">
	<HeaderTemplate>
		<div class="takePledge">
			<h2>Take the pledge</h2>
			<p>Select the pledge most appropriate to your individual role and, if appropriate, for your entire group or society.</p>
	</HeaderTemplate>
	<ItemTemplate>
	<fieldset class="cf">
		<div class="content">
			<p><asp:Literal ID="litPledge" runat="server" /></p>
		</div>
		<asp:Hyperlink ID="hlBtnPledge" runat="server" />
		<asp:Hyperlink ID="hlHelp" runat="server" CssClass="help" />
	</fieldset>
	</ItemTemplate>
	<FooterTemplate>
		</div>
	</FooterTemplate>
</asp:Repeater>
<!-- End: New Pledge html -->

<div style="padding-top:20px">
	<asp:Literal ID="ltlBttmText" runat="server" />
</div>