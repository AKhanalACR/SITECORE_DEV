<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchGlobal.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.navigation.SearchGlobal" %>
<asp:Panel runat="server" DefaultButton="globalSearch" ClientIDMode="Static" ID="siteSearch">
                <div id="site-search">
			    <ul class="inline-ul">
				    <li><asp:TextBox runat="server" ID="globalSearchPhrase" placeholder="Search this site"></asp:TextBox></li>
				    <li><asp:LinkButton runat="server" CssClass="icon site-search" ID="globalSearch" CausesValidation="false" OnClick="globalSearchBtn_Click" />                     
				    </li>
			    </ul>		
                </div>
		    </asp:Panel>