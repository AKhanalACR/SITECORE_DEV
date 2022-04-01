<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltListMembers.ascx.cs" Inherits="ACR.layouts.Radpac.sltListMembers" %><ul class="jenerallist">
    <asp:repeater runat="server" id="rptHeadings" onitemdatabound="rptHeadings_OnItemDataBound">
        <itemtemplate>
        <li id="liMemberBlock" runat="server" visible="false">
          <h2 class="clearboth"><asp:literal id="ltlHeading" runat="server"></asp:literal></h2>
          <div class="borderdiv">&nbsp;</div>
          <ul>
            <asp:repeater id="rptMembers" runat="server" onitemdatabound="rptMembers_OnItemDataBound">
                <itemtemplate>
                    <li><asp:literal id="ltlMember" runat="server"></asp:literal></li>
                </itemtemplate>
            </asp:repeater>
            </ul>
        </li>
        </itemtemplate>
    </asp:repeater>
</ul>