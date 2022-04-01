<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="ACR.controls.RLI.Responsive.Footer" %>

<footer id="site-footer" role="contentinfo">
    <div class="content row xl-text-left md-text-left text-center">
        <div class="xl-col-4 lg-col-5 md-col-5 fl-right relative">
            <div class="social-media-footer xl-only">
                <asp:HyperLink runat="server" ID="hlFacebook" Target="_blank" CssClass="social-icon icon-facebook"></asp:HyperLink>
                <asp:HyperLink runat="server" ID="hlTwitter" Target="_blank" CssClass="social-icon icon-twitter"></asp:HyperLink>
                <div class="clear"></div>
                <br>
            </div>
            <div class="access-buttons-area xl-text-right text-center sm-wide-12">
                <asp:Repeater runat="server" ID="rptButtons" OnItemDataBound="rptButtons_OnItemDataBound">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlButton" CssClass="button-grey">
                            <asp:Image runat="server" ID="imgButtonIcon" CssClass="icon" /><asp:Literal runat="server" ID="litButtonTitle"></asp:Literal>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
        <div class="xl-col-8 lg-col-7 md-col-7">
            <div class="row-adjust inline-block-cols footer-nav">
                <asp:Repeater runat="server" ID="rptFooterLinkColumns" OnItemDataBound="rptFooterLinkColumns_OnItemDataBound">
                    <ItemTemplate>
                        <div class="xl-col-3 lg-col-6 footer-nav-list">
                            <ul>
                                <li><strong>
                                    <asp:HyperLink runat="server" ID="hypHeaderLink"></asp:HyperLink></strong></li>
                                <asp:Repeater runat="server" ID="rptFooterLinks" OnItemDataBound="rptFooterLink_OnItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                            <asp:HyperLink runat="server" ID="hypLink" /></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="content row">
        <div class="col-12 sm-only text-center">
            <div class="social-media-footer">
                <asp:HyperLink runat="server" ID="hlFacebook1" Target="_blank" CssClass="social-icon icon-facebook"></asp:HyperLink>
                <asp:HyperLink runat="server" ID="hlTwitter1" Target="_blank" CssClass="social-icon icon-twitter"></asp:HyperLink>


            </div>
        </div>
        <div id="bottom-footer-info" class="col-12 text-center">
            <asp:Literal runat="server" ID="litCopyright"></asp:Literal>
        </div>
    </div>
</footer>
