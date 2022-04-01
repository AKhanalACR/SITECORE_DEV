<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ACRPageNotFoundRedirector.aspx.cs" Inherits="ACR.Foundation.ExpressUrls.PageNotFound.ACRPageNotFoundRedirector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update ACR Redirects</h1>
            <p>Upload a CSV file containing the redirects</p>
            <asp:FileUpload runat="server" ID="fileUpload" />
            <asp:Button runat="server" ID="upload" Text="Update Redirects" OnClick="upload_Click" />
            <a href="/App_Data/acr-redirects.csv">Download current redirect list</a>

        </div>
    </form>
</body>
</html>
