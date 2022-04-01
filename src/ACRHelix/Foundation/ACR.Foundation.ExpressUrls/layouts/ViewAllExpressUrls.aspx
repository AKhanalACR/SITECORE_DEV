<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllExpressUrls.aspx.cs" Inherits="ACR.Foundation.ExpressUrls.layouts.ViewAllExpressUrls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage All Express Urls</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Express Urls</h1>
              
        <asp:GridView runat="server" ID="expressUrlsGV" AutoGenerateColumns="true" >
            <Columns>
            </Columns>
        </asp:GridView>

        <asp:Label runat="server" ID="resultsLabel">
        </asp:Label>
    </div>
    </form>
</body>
</html>
