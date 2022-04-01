<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuxiliaryNav.ascx.cs" Inherits="ACR.controls.ImageWisely.AuxiliaryNav" %>
<div id="followup">
    <asp:Hyperlink ID="hlFaceBook" title="facebook" CssClass="facebook" Target="_blank" runat="server">&nbsp;</asp:Hyperlink>
    <span id="ftweet">&nbsp;</span>
    <asp:Hyperlink ID="hlTwitter" title="twitter" CssClass="twitter" Target="_blank" runat="server">&nbsp;</asp:Hyperlink>
</div>
<ul class="top_nav">
    <asp:Repeater ID="RptNavLinks" runat="server" OnItemDataBound="RptNavLinks_ItemDataBound" >
        <ItemTemplate>
            <li id="liNav" runat="server"><asp:HyperLink id="hlNav" runat="server"/></li>
        </ItemTemplate> 
    </asp:Repeater>
</ul>

        
