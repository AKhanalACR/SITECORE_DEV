<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltContributors.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltContributors" %>
<div id="fullbluebox" class="fullbluebox">
    <ul class="alphasort">
        <asp:Literal ID="ltlAlphaNav" runat="server"/>
      <!-- <li><a href="#"  title="A" class="alphabets">A</a></li> -->
    </ul>
</div>
<ul class="jenerallist">
    <asp:Repeater ID="rptAlpha" runat="server" OnItemDataBound="rptAlpha_OnItemDataBound" >
        <ItemTemplate>
        <li id="liAlphaBlock" runat="server" Visible="false" >
          <h2 class="clearboth"><asp:Literal ID="ltlAlpha" runat="server"/></h2>
          <div class="borderdiv">&nbsp;</div>
          <ul>
            <asp:Repeater ID="rptContributors" runat="server" OnItemDataBound="rptContributors_OnItemDataBound" >
                <ItemTemplate>
                <li><asp:Literal ID="ltlContr" runat="server" /></li>
                </ItemTemplate>
            </asp:Repeater>
          </ul>
        </li>
        <li id="liAlphaBlockTop" runat="server" Visible="false" ><a href="#" title="backToTop" class="backToTop"><span>&nbsp;</span>Back to Top</a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>