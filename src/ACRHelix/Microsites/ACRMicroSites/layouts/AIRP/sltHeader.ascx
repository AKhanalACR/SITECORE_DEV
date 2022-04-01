<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltHeader.ascx.cs" Inherits="ACR.layouts.AIRP.sltHeader" %>
<header class="cf">
    <div class="home-advertisement">
        <asp:Literal runat="server" ID="litAdScript" />
    </div>


    <ul class="social">
        <li>
            <asp:HyperLink runat="server" CssClass="facebook" ID="hypFacebook" Target="_blank"></asp:HyperLink></li>
        <li>
            <asp:HyperLink runat="server" CssClass="twitter" ID="hypTwitter" Target="_blank"></asp:HyperLink></li>
        <li>
            <asp:HyperLink runat="server" CssClass="youTube" ID="hypYouTube" Target="_blank"></asp:HyperLink></li>
    </ul>
    <ul class="links">
        <asp:Repeater runat="server" ID="rptTopLinks" OnItemDataBound="rptTopLinks_OnItemDataBound">
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server" ID="hypTopLink"></asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <table style="margin-top: 50px;">
        <tr>
            <td>
                <asp:HyperLink runat="server" CssClass="logo" ID="hypLogo">
                    <asp:Image runat="server" Width="125" ID="imgLogo" /></asp:HyperLink></td>
            <td>
                <nav style="width:700px; position:relative;">
                    <ul>
                        <asp:Repeater runat="server" ID="rptMainNav" OnItemDataBound="rptMainNav_OnItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <asp:HyperLink runat="server" ID="hypMainNavItem"></asp:HyperLink>
                                    <asp:PlaceHolder ID="plcSubNav" runat="server">
                                        <ul>
                                            <asp:Repeater runat="server" ID="rptSubnav" OnItemDataBound="rptSubNav_OnItemDataBound">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:HyperLink runat="server" ID="hypSubNavItem"></asp:HyperLink>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </asp:PlaceHolder>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </nav>
            </td>
            <td>
                <%--<asp:HyperLink runat="server" CssClass="logo" ID="acrLogoLink" Target="_blank">
                    <asp:Image runat="server" Width="125" ID="acrLogo" />
                </asp:HyperLink>--%>
            </td>
        </tr>

    </table>
</header>
