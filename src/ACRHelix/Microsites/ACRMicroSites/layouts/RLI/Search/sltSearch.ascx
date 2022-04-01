<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltSearch.ascx.cs" Inherits="ACR.layouts.RLI.Search.sltSearch" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>
<%@ Import Namespace="ACR.Constants" %>


<article>
    <div id="rliSearchList" class="list search">
        <section class="cf">
            <div class="info">
                <asp:PlaceHolder runat="server" ID="ErrorResults" Visible="false">
                    <%# ItemHelper.GetFieldValue(Sitecore.Context.Database.GetItem(Types.Items.SearchErrorMessage), Types.Fields.SettingValue) %>
                </asp:PlaceHolder>
                <asp:Panel CssClass="" ID="ResultsMessage" runat="server"></asp:Panel>
                <asp:Label CssClass="" ID="SearchString" runat="server" Text=""></asp:Label>

            </div>
            <div class="pagination">
                <%--	<a href="#" class="nextButtons">Next</a>--%>

                <asp:Literal ID="PageTop" runat="server"></asp:Literal>

                <%--	<a href="#" class="previousButtons">Previous</a>--%>
            </div>
        </section>

        <div id="searchResultsContainer">
            <asp:Repeater ID="searchResults" runat="server">
                <ItemTemplate>
                    <section>
                        <ul>
                            <li><a class="title" href="<%# GetValidUrl((Container.DataItem as ACRAccreditationInformaticsLibrary.SearchResult).ResultItem) %>">
                                <%# GetFriendlyName(Container.DataItem as ACRAccreditationInformaticsLibrary.SearchResult) %> 
                            </a></li>
                            <p class="description">
                                <asp:Literal ID="Copy" runat="server" Text="<%# GetFriendlyTeaser(Container.DataItem as ACRAccreditationInformaticsLibrary.SearchResult) %>"></asp:Literal>
                            </p>
                        </ul>
                    </section>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <section class="cf">
            <div class="pagination">
                <%--	<a href="#" class="nextButtons">Next</a>--%>

                <asp:Literal ID="PageBottom" runat="server"></asp:Literal>

                <%--		<a href="#" class="previousButtons">Previous</a>--%>
            </div>
        </section>
    </div>
</article>



