<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltAboutUsLinks.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltAboutUsLinks" %>
<asp:PlaceHolder ID="phKeyCont" runat="server">
    <h2><asp:Literal ID="ltlKCTitle" runat="server" /></h2>
    <div class="borderdiv">&nbsp;</div>
    <asp:Literal ID="ltlKCText" runat="server" />
    
    <p><asp:HyperLink ID="hlTaskForce" runat="server" cssclass="simple">» Task Force Members</asp:HyperLink></p>
    <p><asp:HyperLink ID="hlExecutiveCommitteeMembers" runat="server" cssclass="simple">» Executive Committee Members</asp:HyperLink></p>
    <p><asp:HyperLink ID="hlKeyCont" runat="server" cssclass="simple">» Complete List of Contributors</asp:HyperLink></p>
</asp:PlaceHolder>