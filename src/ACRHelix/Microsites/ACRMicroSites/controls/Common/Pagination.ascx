<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagination.ascx.cs" Inherits="ACR.controls.Common.Pagination" %>
<div class="paging">
    <asp:Repeater ID="rptPageLinks" runat="server" Visible="false"  OnItemDataBound="rptPageLinks_OnItemDataBound" >
        <ItemTemplate>
            <asp:LinkButton ID="lbPageLink" runat="server" OnClick="lbPageLink_onClick" /><asp:Literal ID="ltlCurrentPage" runat="server" Visible="false" /> 
            <asp:Literal ID="ltlPipe" Text="|" runat="server"/>
        </ItemTemplate>
    </asp:Repeater>
</div>