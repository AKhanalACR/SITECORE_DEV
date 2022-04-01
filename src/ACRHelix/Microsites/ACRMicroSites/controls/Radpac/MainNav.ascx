<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainNav.ascx.cs" Inherits="ACR.controls.Radpac.MainNav" %>
<!-- START OF MAIN NAVIGATION -->
<div class="menu">
    <ul id="xp_menu">
        <asp:Repeater runat="server" ID="rptMainNav" OnItemDataBound="rptMainNav_ItemDataBound">
            <ItemTemplate>
                <li runat="server" id="liMain">
                <asp:Repeater runat="server" ID="rptSubNav" OnItemDataBound="rptSubNav_ItemDataBound">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li runat="server" id="liSub">
                    <asp:Repeater runat="server" ID="rptSubSubNav" OnItemDataBound="rptSubSubNav_ItemDataBound">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li>
                    <asp:HyperLink runat="server" ID="hlSubSubNavItem" />
                   
                    </li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul></FooterTemplate>
                </asp:Repeater>
                    <asp:HyperLink runat="server" ID="hlSubNavItem" />
                   
                    </li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul></FooterTemplate>
                </asp:Repeater>
                <div>
                <asp:HyperLink runat="server" ID="hlNavItem" />
                <%--<asp:HyperLink runat="server"  ID="hlSepItem" Target="_blank"  />--%>
                 </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>