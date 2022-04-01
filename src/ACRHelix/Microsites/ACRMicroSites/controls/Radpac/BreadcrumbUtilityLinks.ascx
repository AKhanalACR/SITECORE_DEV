<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BreadcrumbUtilityLinks.ascx.cs" Inherits="ACR.controls.Radpac.BreadcrumbUtilityLinks" %>
<div class="breadcrumb">
  <asp:Repeater runat="server" ID="rptBreadcrumb" OnItemDataBound="rptBreadcrumb_ItemDataBound">
    <ItemTemplate><asp:Literal runat="server" ID="litCrumb" /></ItemTemplate>
    <SeparatorTemplate>&nbsp;&gt;&nbsp;</SeparatorTemplate>
  </asp:Repeater>
</div>
<div class="share">
    <span class="ic_icon ic_print">&nbsp;</span>
    <a href="javascript:window.print();">Print</a>
    <span class="ic_icon ic_share">&nbsp;</span>
    <a href="http://www.addthis.com/bookmark.php?v=20" onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')" onmouseout="addthis_close()" onclick="return addthis_sendto()">Share</a>
    <span >&nbsp;</span>
    <asp:LinkButton id="lnkBtnLogout" Text="Logout" runat="server" OnClientClick ="javascript:return hideLogoutBtn();" OnClick ="lnkBtnLogout_Click" Visible="false" Font-Underline ="true" ForeColor ="Red" />
    <asp:Literal ID="ltlPdfDownload" runat="server" />
</div>
  
<script type="text/javascript">
    var addthis_pub = "Radpac";
	var addthis_hover_delay = 200;
	var addthis_options = 'email, facebook, twitter, linkedin';

	function hideLogoutBtn() {
	  
	     var btn = document.getElementById("<%=lnkBtnLogout.ClientID%>");
	     if (btn != null) {	       
	         btn.style.visibility = 'hidden';
	     }
 	   return true;
	}
</script>
<script type="text/javascript" src="http://s7.addthis.com/js/200/addthis_widget.js"></script>

  
