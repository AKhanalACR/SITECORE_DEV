<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.content.SearchBox" %>

<div class="inline-block search-box-header">	
    <asp:TextBox runat="server" ID="searchbox" placeHolder="Search"></asp:TextBox>
    <asp:Button runat="server" ID="searchBtn" Text="Search" OnClick="searchBtn_Click" />
			</div>