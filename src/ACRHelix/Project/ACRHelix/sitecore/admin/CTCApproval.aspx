<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CTCApproval.aspx.cs" Inherits="ACRHelix.Website.sitecore.admin.CTCApproval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body><div style="margin-left:50px;">
   <table><tr><td><img src="" /></td><td><h1>My CT Colonography Facility Approval</h1</td></tr></table> 
    </div>
    <form id="form1" runat="server">
        <div style="margin-left:20px;">
       </div>
        <div>
            <asp:SqlDataSource 
                ID="SqlDataSource_CTC" 
                runat="server" 
                ConnectionString="<%$ ConnectionStrings:ACR_APP_DATA_Entities_2 %>" 
                DeleteCommand="DELETE FROM [CT_Colonography_Locations] WHERE [ID] = @ID" 
                InsertCommand="INSERT INTO [CT_Colonography_Locations] ([Store], [Address1], [Address2], [City], [State], [Zip], [Country], [Latitude], [Longitude], [Tags], [Description], [Email], [Url], [sl_hours], [Phone], [Fax], [Private], [Neat_Title], [Category], [Category_Slug], [FirstName], [LastName], [DISPLAY_FLAG]) VALUES (@Store, @Address1, @Address2, @City, @State, @Zip, @Country, @Latitude, @Longitude, @Tags, @Description, @Email, @Url, @sl_hours, @Phone, @Fax, @Private, @Neat_Title, @Category, @Category_Slug, @FirstName, @LastName, @DISPLAY_FLAG)" 
                SelectCommand="SELECT [ID], [Store], [Address1], [Address2], [City], [State], [Zip], [Country], [Latitude], [Longitude], [Tags], [Description], [Email], [Url], [sl_hours], [Phone], [Fax], [Private], [Neat_Title], [Category], [Category_Slug], [FirstName], [LastName], [DISPLAY_FLAG], [ADDDATE] FROM [CT_Colonography_Locations]" 
                UpdateCommand="UPDATE [CT_Colonography_Locations] SET [Store] = @Store, [Address1] = @Address1, [Address2] = @Address2, [City] = @City, [State] = @State, [Zip] = @Zip, [Country] = @Country, [Latitude] = @Latitude, [Longitude] = @Longitude, [Tags] = @Tags, [Description] = @Description, [Email] = @Email, [Url] = @Url, [sl_hours] = @sl_hours, [Phone] = @Phone, [Fax] = @Fax, [Private] = @Private, [Neat_Title] = @Neat_Title, [Category] = @Category, [Category_Slug] = @Category_Slug, [FirstName] = @FirstName, [LastName] = @LastName, [DISPLAY_FLAG] = @DISPLAY_FLAG WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Store" Type="String" />
                    <asp:Parameter Name="Address1" Type="String" />
                    <asp:Parameter Name="Address2" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Zip" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="Latitude" Type="Decimal" />
                    <asp:Parameter Name="Longitude" Type="Decimal" />
                    <asp:Parameter Name="Tags" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Url" Type="String" />
                    <asp:Parameter Name="sl_hours" Type="String" />
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="Fax" Type="String" />
                    <asp:Parameter Name="Private" Type="String" />
                    <asp:Parameter Name="Neat_Title" Type="String" />
                    <asp:Parameter Name="Category" Type="String" />
                    <asp:Parameter Name="Category_Slug" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="DISPLAY_FLAG" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Store" Type="String" />
                    <asp:Parameter Name="Address1" Type="String" />
                    <asp:Parameter Name="Address2" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Zip" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="Latitude" Type="Decimal" />
                    <asp:Parameter Name="Longitude" Type="Decimal" />
                    <asp:Parameter Name="Tags" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Url" Type="String" />
<asp:Parameter Name="sl_hours" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Phone" Type="String" />
                    <asp:Parameter Name="Fax" Type="String" />
                    <asp:Parameter Name="Private" Type="String" />
                    <asp:Parameter Name="Neat_Title" Type="String" />
                    <asp:Parameter Name="Category" Type="String" />
                    <asp:Parameter Name="Category_Slug" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="DISPLAY_FLAG" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <div style="margin:20px; padding:10px;">
            
            <br />
            
            <asp:GridView ID="GridView_CTC" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource_CTC" PageSize="40" Width="100%" OnRowCommand="GridView_CTC_RowCommand"  SelectedRowStyle-BackColor="Beige">
                <Columns>                    
                    <asp:CommandField ShowEditButton="true" UpdateText="Save" EditImageUrl="~/images/imagewisely/edit.png" CancelImageUrl="~/images/imagewisely/cancel.png" UpdateImageUrl="~/images/imagewisely/save.png" ButtonType="Image" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Store" HeaderText="Store" SortExpression="Store" />
                    <asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="Address1" />
                    <asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="Address2" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                    <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
                    <asp:BoundField DataField="Tags" HeaderText="Tags" SortExpression="Tags" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="Url" />
                    <asp:BoundField DataField="sl_hours" HeaderText="sl_hours" SortExpression="sl_hours" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                    <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
                    <asp:BoundField DataField="Private" HeaderText="Private" SortExpression="Private" />
                    <asp:BoundField DataField="Neat_Title" HeaderText="Neat_Title" SortExpression="Neat_Title" />
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                    <asp:BoundField DataField="Category_Slug" HeaderText="Category_Slug" SortExpression="Category_Slug" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="ADDDATE" HeaderText="ADDDATE" SortExpression="ADDDATE"  />
                    <asp:BoundField DataField="DISPLAY_FLAG" HeaderText="DISPLAY_FLAG" SortExpression="DISPLAY_FLAG"></asp:BoundField>
                    <asp:CommandField SelectImageUrl="~/images/imagewisely/delete.png" ShowSelectButton="true" ButtonType="Image" />
                    <asp:TemplateField><ItemTemplate> <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" Visible="false" /> </ItemTemplate> </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            
        </div>
    </form>

</body>
</html>
