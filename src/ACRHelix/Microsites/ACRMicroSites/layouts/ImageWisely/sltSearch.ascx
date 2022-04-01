<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltSearch.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltSearch" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>
<%@ Import Namespace="ACR.Constants" %>

<%--<%@ Register TagPrefix="acr" TagName="Pagination" Src="~/controls/Common/Pagination.ascx" %>
<p class="pagResults"><asp:Literal ID="ltlResults" runat="server" /></p>
<acr:Pagination ID="PaginationUpper" runat="server" />
<div class="borderdiv">&nbsp;</div>
    <asp:PlaceHolder ID="phNoSearchedItems" runat="server" Visible="false">
        <ul class="simple_list">
        <li><h4>No Items Found</h4></li>
        </ul>
    </asp:PlaceHolder>
    <ul class="simple_list" id="ulResults" runat="server">
    	<asp:Repeater ID="rptResults" runat="server" OnItemDataBound="rptResults_OnItemDataBound">
    		<ItemTemplate>
                <li>
                <h4>» <asp:HyperLink ID="hlPageTitle" runat="server" /></h4>
                <p><strong>Description: </strong><asp:Literal ID="ltlPageDescription" runat="server" /></p>
                </li>
    		</ItemTemplate>
    	</asp:Repeater>
    </ul>
<div class="borderdiv">&nbsp;</div>
<acr:Pagination ID="PaginationLower" runat="server" />--%>

<!-- Addis 4/27/2017 -->
<div class="paging">
    <asp:Literal ID="PageTop" runat="server"></asp:Literal>
</div>
<div class="borderdiv">&nbsp;</div>
<div class="info">
    <asp:PlaceHolder runat="server" ID="ErrorResults" Visible="false">
        <%# ItemHelper.GetFieldValue(Sitecore.Context.Database.GetItem(Types.Items.SearchErrorMessage), Types.Fields.SettingValue) %>
    </asp:PlaceHolder>
    <asp:Panel CssClass="" ID="ResultsMessage" runat="server"></asp:Panel>
    <asp:Label CssClass="" ID="SearchString" runat="server" Text=""></asp:Label>
</div>
<div id="searchResultsContainer">
    <asp:Repeater ID="searchResults" runat="server">
        <ItemTemplate>
            <section>
                <ul class="simple_list">
                    <li><a class="title" href="<%# GetValidUrl((Container.DataItem as SearchResult).ResultItem) %>">
                        <%# GetFriendlyName(Container.DataItem as SearchResult) %> 
                    </a></li>
                    <p class="description">
                        <asp:Literal ID="Copy" runat="server" Text="<%# GetFriendlyTeaser(Container.DataItem as SearchResult) %>"></asp:Literal>
                    </p>
                </ul>
            </section>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="borderdiv">&nbsp;</div>
<div class="paging">
   <asp:Literal ID="PageBottom" runat="server"></asp:Literal>
</div>

