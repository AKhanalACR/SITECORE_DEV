<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RenderingHelper.aspx.cs" Inherits="ACRHelix.Foundation.RenderingHelper.sitecore.admin.RenderingHelper" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Renderings Helper</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Find youtube embeds</h2>
        <asp:Button runat="server" ID="fixYoutubeIframes" OnClick="fixYoutubeIframes_Click" />

        <asp:Literal runat="server" ID="youtube_Output"></asp:Literal>

     <%--   <h1>FIX DSI Templates</h1>
        <asp:Button runat="server" Text="FIX DSI Tempaltes" ID="fixDSI" OnClick="fixDSI_Click" />

        <h1>Personify Committee Test</h1>
        <asp:Button runat="server" ID="GetPersonifyComittees" OnClick="GetPersonifyComittees_Click" Text="Retrieve Personify Committess" />
        <asp:Button runat="server" ID="ChapterDataText" OnClick="ChapterDataText_Click" Text="Retrieve Personify Chapters" />

        <asp:Button runat="server" ID="updateChapterRenderings" OnClick="updateChapterRenderings_Click" Text="UpdateChapterRenderings" />

        <asp:Label runat="server" ID="positionsLbl"></asp:Label>

    <div>

        <h1>Fix Deleted

        </h1>
        <asp:Button runat="server" ID="fixd" Text="restore from bin" OnClick="fixd_Click" />
        <asp:Literal runat="server" ID="resultsRestore"></asp:Literal>
        <br />
        <br />
        <br />
    <h1>Convert Final Renderings to Shared Rendering</h1>
        <p>use this tool to update Sitecore Shared Renderings from whatever is used on the Final Rendering</p>
        <br />
        <label>ItemID:</label><asp:TextBox runat="server" ID="itemInput" ></asp:TextBox><br />
        <label>Copy to Template</label><asp:CheckBox runat="server" ID="copyToTemplateCB" Checked="true" />
        <asp:Button runat="server" ID="updateRenderings" Text="Update Renderings" OnClick="updateRenderings_Click" />
        <br />
        <asp:Label runat="server" ID="resultLbl" ForeColor="Red"></asp:Label>
   
        <h1>Delete unused items under all local content folders</h1>
         <asp:Button runat="server" ID="deleteLocalContent" Text="Delete local content" OnClick="deleteLocalContent_Click" />
        <p>Items Deleted:</p>
        <asp:Literal runat="server" ID="deletedItems"></asp:Literal>


          <asp:Button runat="server" ID="testLinks" Text="Test Link" OnClick="testlink_Click" />
         <asp:Literal runat="server" ID="linksLt"></asp:Literal>
 
         </div>--%>
    </form>
</body>
</html>
