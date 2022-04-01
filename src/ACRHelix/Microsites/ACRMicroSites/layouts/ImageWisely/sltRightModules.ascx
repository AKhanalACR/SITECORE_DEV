<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltRightModules.ascx.cs"
    Inherits="ACR.layouts.ImageWisely.sltRightModules" %>

<asp:Repeater runat="server" ID="rptRightModule" OnItemDataBound="rptRightModule_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>    
    <ItemTemplate>
        <li id="liMod" runat="server">
            <asp:Image runat="server" ID="image" />            
            <h3 class="mod-title"><asp:Literal runat="server" ID="title"/></h3>
            <asp:Literal runat="server" ID="body"/>
        </li>
    </ItemTemplate>    
    <FooterTemplate>
        </ul>
    </FooterTemplate>    
</asp:Repeater>
