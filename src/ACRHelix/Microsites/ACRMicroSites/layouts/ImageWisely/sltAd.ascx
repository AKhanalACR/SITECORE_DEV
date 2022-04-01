<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltAd.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltAd" %>
<%@ Register TagPrefix="acr" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

 <!-- Removed 10/24/2012 by C.Castle --
 <p class="ad">
    <asp:HyperLink runat="server" ID="newsLink">
            <asp:Image runat="server" ID="newsImage" ImageUrl="/images/ImageWisely/InTheNewsButton.png" Width="190" Height="39" />
    </asp:HyperLink>
</p>

<div class="borderdiv">&nbsp;</div>
<div class="borderdiv">&nbsp;</div>
-->
 
<asp:Repeater runat="server" ID="rptAdItem" OnItemDataBound="rptAdItem_ItemDataBound">
    <ItemTemplate>
        <p class="ad"><asp:Literal ID="ltlLink" runat="server"/>
        <acr:image runat="server" ID="adImage" />
        <asp:Literal ID="ltlLinkEnd" runat="server"/></p>
    </ItemTemplate>    
</asp:Repeater>