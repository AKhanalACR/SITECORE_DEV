<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YouTubeVideo.ascx.cs" Inherits="ACR.controls.MammographySavesLives.YouTubeVideo" %>

<asp:Label ID="ErrorLabel" runat="server" Visible="false" ForeColor="Red" />

<asp:Literal ID="VideoScriptLiteral" runat="server" />

<asp:PlaceHolder ID="DescriptionBoxPlaceHolder" runat="server">
    <div class="video-title-ribbon">
        <h3 class="video-title"><asp:Literal id="TitleLiteral" runat="server" /></h3>
    </div>
    <div class="video-description-box">
            <!--p class="video-stats">From: ACR_Mammography | June 23, 2010  | 490 views</p-->
            <p class="video-stats">From: <asp:Literal id="UserNameLiteral" runat="server" /> | <asp:Literal id="PublishedLiteral" runat="server" />  | <asp:Literal id="ViewsLiteral" runat="server" /> views</p>
            <p><asp:Literal id="DescriptionLiteral" runat="server" /></p>
    </div>
</asp:PlaceHolder>