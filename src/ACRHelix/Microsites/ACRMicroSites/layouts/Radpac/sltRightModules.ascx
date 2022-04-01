<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltRightModules.ascx.cs"
    Inherits="ACR.layouts.Radpac.sltRightModules" %>
  <asp:Repeater runat="server" ID="rptRightModule" OnItemDataBound="rptRightModule_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>    
    <ItemTemplate>
        <li id="liMod" runat="server">
        <asp:literal id="ltlLink" runat="server"></asp:literal>
            <asp:Image runat="server" ID="image" />
            <asp:literal id="ltlLinkEnd" runat="server"></asp:literal>
            <h3 class="mod-title"><asp:Literal runat="server" ID="title"/></h3>
            <asp:Literal runat="server" ID="body"/>
        </li>
    </ItemTemplate>    
    <FooterTemplate>
        </ul>
    </FooterTemplate>    
</asp:Repeater>