<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="ACR.controls.Radpac.Footer" %>
<asp:Panel id="pnlShareThis" runat="server" cssclass="sharethis" Visible="false">
    <div>
        <a href="http://www.addthis.com/bookmark.php?v=250&amp;username=noelleneu" onmouseover="return addthis_open(this, '', '[URL]', '[TITLE]')" onmouseout="addthis_close()" onclick="return addthis_sendto()"><img src="/images/Radpac/share.jpg" align="absmiddle" alt=""/>Share this site</a>
    </div>
<!-- AddThis Button END -->
    <script type="text/javascript">
        var addthis_config = {
            ui_delay: 200,
            data_track_clickback: true,
            services_compact: 'email, facebook, twitter, linkedin',
            services_expanded: 'email, facebook, twitter, linkedin'
        };
    </script>
    <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#username=noelleneu"></script>
 </asp:Panel>
<div id="footer">
    <ul id="footer_nav">
      <asp:Repeater ID="RptNavLinks" runat="server" OnItemDataBound="RptNavLinks_ItemDataBound" >
        <ItemTemplate>
            <li id="liNav" runat="server"><asp:HyperLink id="hlNav" runat="server"/></li>
        </ItemTemplate> 
        </asp:Repeater>
    </ul>
    <div class="borderdiv">&nbsp;</div>
    <div class="borderdiv">&nbsp;</div>
    <asp:Literal ID="ltlFooter" runat="server"/>
</div>
