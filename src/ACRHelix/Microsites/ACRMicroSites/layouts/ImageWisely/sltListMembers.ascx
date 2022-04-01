<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltListMembers.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltListMembers" %>
<ul class="jenerallist">
    <asp:Repeater ID="rptHeadings" runat="server" OnItemDataBound="rptHeadings_OnItemDataBound" >
        <ItemTemplate>
        <li id="liMemberBlock" runat="server" Visible="false" >
          <h2 class="clearboth"><asp:Literal ID="ltlHeading" runat="server"/></h2>
          <div class="borderdiv">&nbsp;</div>
          <ul>
            <asp:Repeater ID="rptMembers" runat="server" OnItemDataBound="rptMembers_OnItemDataBound" >
                <ItemTemplate>
                    <li><asp:Literal ID="ltlMember" runat="server" /></li>
                </ItemTemplate>
            </asp:Repeater>
            </ul>
        </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
