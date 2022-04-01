<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltCallToAction.ascx.cs" Inherits="ACR.layouts.RLI.widgets.sltCallToAction" %>
<%@ Register TagPrefix="rli" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

<div class="item">
	<div class="inner">
		<section>
            <h2 class="cf"><rli:image CssClass="icon" ID="imgIcon" runat="server"/><asp:Literal ID="ltlHeader" runat="server" /></h2>
			
			<asp:Literal ID="ltlSubheader" runat="server" />
			<asp:HyperLink ID="hlButton" runat="server" CssClass="button red"><rli:image runat="server" ID="imgButtonIcon"/><asp:Literal runat="server" ID="ltlBtnTitle"></asp:Literal></asp:HyperLink>
            <asp:Literal ID="ltlBottomText" runat="server" />

		</section>
	</div>
</div>