<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.navigation.Footer" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="content row">
    <div class="col-fourth ipad-col-third flLeft mobile-col-half">
        <h4 class="uppercase">
            <sc:FieldRenderer ID="topLeftTitleFR" runat="server" />
        </h4>
        <ul>
            <asp:Repeater runat="server" ID="topLeftSectionLinksRpt">
                <ItemTemplate>
                    <li><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <br />
        <h4 class="uppercase">
            <sc:FieldRenderer ID="bottomLeftTitleFR" runat="server" />
        </h4>
        <ul>
            <asp:Repeater runat="server" ID="bottomLeftSectionLinksRpt">
                <ItemTemplate>
                    <li><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

    <div class="col-fourth mobile-flLeft ipad-col-third ipad-in-middle desktop-and-ipad-only">
        <asp:Repeater runat="server" ID="middleTopSectionLinksRpt">
            <ItemTemplate>
                 <%# Container.ItemIndex > 0 ? "<br />" : "" %>
                <h4 class="uppercase"><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></h4>              
            </ItemTemplate>
        </asp:Repeater>

        <ul>
            <asp:Repeater runat="server" ID="middleBotSectionLinksRpt">
                <ItemTemplate>
                    <li><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <br />
        <h4 class="uppercase">
            <sc:FieldRenderer ID="middleBottomMainLink" runat="server" />
        </h4>
        <ul>
            <asp:Repeater runat="server" ID="middleBottomSectionLinks">
                <ItemTemplate>
                    <li><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

    <div class="col-fourth mobile-flRight ipad-col-third ipad-in-middle mobile-col-half">
        <h4 class="uppercase"><sc:FieldRenderer ID="topRightTitleFR" runat="server" /></h4>
        <ul>
             <asp:Repeater runat="server" ID="topRightSectionLinksRpt">
                <ItemTemplate>
                    <li><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <br />
        <ul>
       <asp:Repeater runat="server" ID="botRightSectionLinksRpt">
                <ItemTemplate>
                    <li><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
            </ul>
    </div>

    <div class="col-fourth footer-address mobile-flRight ipad-col-third mobile-col-half">
        <sc:FieldRenderer ID="footerAddressFR" runat="server" />
    </div>

    <div class="col-fourth footer-login mobile-flRight ipad-col-third mobile-col-half">
        <%--<sc:FieldRenderer ID="footerLoginFR" runat="server" />--%>
        <sc:Text runat="server" ID="footerLoginLink" />
    </div>

    <div class="flLeft mobile-col-half mobile-only">
         <asp:Repeater runat="server" ID="topMobilelinksRpt">
            <ItemTemplate>
                 <br />
                <h4 class="uppercase"><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></h4>              
            </ItemTemplate>
        </asp:Repeater>
        <ul>
                <asp:Repeater runat="server" ID="bottomMobileLinksRpt">
                <ItemTemplate>
                    <li><a href="<%# Eval("LinkURL") %>"><%# Eval("Name") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>