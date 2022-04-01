<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltAboutUsLinks.ascx.cs" Inherits="ACR.layouts.Radpac.sltAboutUsLinks"   %>
<asp:placeholder runat="server" id="phKeyCont">
    <h2><asp:literal id="ltlKCTitle" runat="server"></asp:literal></h2>
    <div class="borderdiv">&nbsp;</div>
    <asp:literal id="ltlKCText" runat="server"></asp:literal>
    
    <p><asp:hyperlink id="hlTaskForce" runat="server" cssclass="simple">» Task Force Members</asp:hyperlink></p>
    
    <p><asp:hyperlink id="hlKeyCont" runat="server" cssclass="simple">» Complete List of Contributors</asp:hyperlink></p>
</asp:placeholder>