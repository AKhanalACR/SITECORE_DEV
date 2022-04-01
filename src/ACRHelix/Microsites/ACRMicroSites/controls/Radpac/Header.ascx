<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="ACR.controls.Radpac.Header" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>
<%@ Register TagPrefix="acr" TagName="AuxiliaryNav" Src="~/controls/Radpac/AuxiliaryNav.ascx" %>
<%@ Register TagPrefix="acr" TagName="MainNav" Src="~/controls/Radpac/MainNav.ascx" %>

<div id="header">
    <div class="logo_icon">
        <a href="/"><acr:image ID="imgLogo" runat="server" alt="Radpac" style="visibility:hidden ;"/></a>
        <h1 class="page-title">RADPAC</h1>
    </div>
    <div id="logo_text">
        <%--<a href="/" title="RADPAC"><img src="/images/Radpac/logo.png" alt="IMAGE WISELY" /></a>--%>
        <%--  <p>RADPAC</p>--%>
    </div>
    <acr:AuxiliaryNav  ID="AuxiliaryNav" runat="server" />
    <!-- Addis 5/23/2017 -->
    <div class="search_div"> 
		<input type="text" class="search_box" placeholder="Search" id="searchbox" /><a href="" id="searchlink" class="searchbtn"></a>
	</div>
    <%--<asp:Panel ID="pnlSearch" runat="server" CssClass="search_div" DefaultButton="buttonSearch">
        <asp:TextBox ID="txtSearch" runat="server" Text="Search" CssClass="search_box"></asp:TextBox>
        <asp:Button ID="buttonSearch" CssClass="searchbtn" OnClick="buttonSearch_Click" runat="server" />
    </asp:Panel>--%>
    <acr:MainNav ID="MainNav" runat="server" />
</div>