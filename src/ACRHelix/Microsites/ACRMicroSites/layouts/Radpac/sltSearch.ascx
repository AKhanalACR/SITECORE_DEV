<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltSearch.ascx.cs" Inherits="ACR.layouts.Radpac.sltSearch" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>
<%@ Import Namespace="ACR.Constants" %>

<%--<%@ Register TagPrefix="acr" TagName="Pagination" Src="~/controls/Common/Pagination.ascx" %>

<p class="pagResults">
    <asp:literal runat="server" id="ltlResults"></asp:literal>
</p>
<acr:pagination runat="server" id="PaginationUpper" xmlns:acr="http://www.sitecore.net/xhtml"></acr:pagination>
<div class="borderdiv">&nbsp;</div>
<asp:placeholder runat="server" id="phNoSearchedItems" visible="false"><ul class="simple_list"><li><h4>No Items Found</h4></li></ul></asp:placeholder>
<ul class="simple_list" id="ulResults" runat="server">
	<asp:repeater runat="server" id="rptResults" onitemdatabound="rptResults_OnItemDataBound">
		<itemtemplate>
            <li>
            <h4>» <asp:hyperlink id="hlPageTitle" runat="server"></asp:hyperlink></h4>
            <p><strong>Description: </strong><asp:literal id="ltlPageDescription" runat="server"></asp:literal></p>
            </li>
		</itemtemplate>
	</asp:repeater>
</ul>
<div class="borderdiv">&nbsp;</div>
<acr:pagination runat="server" id="PaginationLower" xmlns:acr="http://www.sitecore.net/xhtml"></acr:pagination>--%>

<!-- Addis 5/23/2017 -->
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