<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="ACR.controls.RLI.Responsive.Header" %>
<header id="site-header">
    <div class="content">
        <asp:HyperLink runat="server" ID="hlLogo" CssClass="logo">
            <asp:Image runat="server" ID="imgLogo" />
        </asp:HyperLink>

        <div id="site-utility" class="xl-col-3 md-col-4 fl-right">
            <ul class="mobile-nav-show mobile-header-social-area inline-ul">
                <li>
                    <asp:HyperLink runat="server" ID="hlFacebook" CssClass="social-icon icon-facebook" Target="_blank"></asp:HyperLink></li>
                <li>
                    <asp:HyperLink runat="server" ID="hlTwitter" CssClass="social-icon icon-twitter" Target="_blank"></asp:HyperLink></li>
            </ul>
            <div class="header-utility-links inline-ul">
                <ul>
                    <asp:Repeater runat="server" ID="rptTopLinks" OnItemDataBound="rptTopLinks_OnItemDataBound">
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink runat="server" ID="hlTopLink" /></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:HyperLink runat="server" ID="hlFacebook1" CssClass="social-icon icon-facebook" Target="_blank"></asp:HyperLink>
                    <asp:HyperLink runat="server" ID="hlTwitter1" CssClass="social-icon icon-twitter" Target="_blank"></asp:HyperLink>
                    
                </ul>
            </div>

            <div class="site-search">
  <%--              <input placeholder="Search" id="searchbox" type="text"><a href="" id="searchlink"></a>--%>
                <input placeholder="Search" id="searchbox" type="text" /><a href="" id="searchlink"></a>
            </div>
        </div>

        <div id="mobile-nav-btn">
            <div class="nav-top-bar"></div>
            <div class="nav-mid-bar"></div>
            <div class="nav-bot-bar"></div>
        </div>

        <%--
		<div class="topNav">
			<asp:Repeater runat="server" ID="rptTopLinks" OnItemDataBound="rptTopLinks_OnItemDataBound">
				<ItemTemplate>
					<asp:HyperLink runat="server" ID="hlTopLink"/>
				</ItemTemplate>
			</asp:Repeater>
			<asp:HyperLink runat="server" ID="hlFacebook" CssClass="facebook" Target="_blank"></asp:HyperLink>
			<asp:HyperLink runat="server" ID="hlTwitter" CssClass="twitter" Target="_blank"></asp:HyperLink>
		</div>

		<div class="search">
			<input type="text/css" placeholder="Search" id="searchbox" /><a href="" id="searchlink"></a>
		</div>
	</div>
</header>--%>
        <nav id="main-nav">
         <%--   <div class="wrapper cf">--%>
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
          <%--  </div>--%>
        </nav>
</header>
