<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.listing.SearchResults" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>
<%@ Import Namespace="ACR.Constants" %>
    
<div class="content">
            <asp:PlaceHolder runat="server" ID="ErrorResults" Visible="false">
                <%# ItemHelper.GetFieldValue(Sitecore.Context.Database.GetItem(Types.Items.SearchErrorMessage), Types.Fields.SettingValue) %>
            </asp:PlaceHolder>
            <div> 
                <label for="SearchInput">Search
                    <asp:TextBox ID="SearchInput" runat="server" CssClass="sanded search"></asp:TextBox>
                </label> 
                <asp:Button OnClick="SearchClick" runat="server" ID="search" text="search" />
                <%--<asp:Literal ID="Test" runat="server" Text="Begin" />--%>
            </div>         
            <asp:Panel CssClass="" ID="ResultsMessage" runat="server"></asp:Panel>
			<asp:Label CssClass="" ID="SearchString" runat="server" Text=""></asp:Label>
            <div>
                <asp:Literal ID="PageTop" runat="server"></asp:Literal>
            </div>
			<dl>
            <asp:Repeater ID="searchResults" runat="server">
                <ItemTemplate>
                    <dt>
                        <a class="title" href="<%# GetValidUrl((Container.DataItem as ACRAccreditationInformaticsLibrary.SearchResult).ResultItem) %>">
                            <%# GetFriendlyName(Container.DataItem as ACRAccreditationInformaticsLibrary.SearchResult) %> 
                        </a>
                    </dt>
                    <dd>
                        <asp:Literal ID="Copy" runat="server" Text="<%# GetFriendlyTeaser(Container.DataItem as ACRAccreditationInformaticsLibrary.SearchResult) %>"></asp:Literal>                               
					</dd>        
                </ItemTemplate>
            </asp:Repeater>
			</dl>
            <div>					
			<asp:Literal ID="PageBottom" runat="server"></asp:Literal>
            </div>
    </div>