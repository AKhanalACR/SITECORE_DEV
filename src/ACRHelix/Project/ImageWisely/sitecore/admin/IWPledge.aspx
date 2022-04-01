<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IWPledge.aspx.cs" Inherits="ACRHelix.Project.ImageWisely.sitecore.admin.IWPledge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IW Admin</title>
    <link href="../../css/imagewisely/bootstrap.min.css" rel="stylesheet" />
     
</head>
<body><div style="margin-left:50px;">
   <table><tr><td><img src="../../images/imagewisely/iw-favicon.ico" /></td><td><h1>Image Wisely Pledge Admin</h1</td></tr></table> 
    </div>
    <form id="form1" runat="server">
        <div style="margin-left:20px;">
            <table><tr>
                <td>
                    <table style="border:2px solid gray; background-color:#CCCCCC;"><tr>
                        <td><asp:Button ID="Button_IPS" runat="server" Text="Individual Submissions" OnClick="Button_IPS_Click" Height="50px" Enabled="false" /></td>
                        <td><asp:Button ID="Button_RPPS" runat="server" Text="Referring Practitioner Submissions" OnClick="Button_RPPS_Click"  Height="50px" /></td>
                        <td><asp:Button ID="Button_FPS" runat="server" Text="Facility Submissions" OnClick="Button_FPS_Click"  Height="50px" /></td>
                        <td><asp:Button ID="Button_APS" runat="server" Text="Association Submissions" OnClick="Button_APS_Click"  Height="50px"/></td>
                     </tr></table>
                </td>
                <td>
                    <div style="margin-left:50px;"><a href="IWPledge.aspx"><img src="../../images/imagewisely/Reload.png" width="30" /></a></div>
                </td>
            </tr></table> 
       </div>
        <div>
            <asp:SqlDataSource ID="SqlDataSource_IPS" runat="server" ConnectionString="<%$ ConnectionStrings:ACR.Library.Properties.Settings.ACR_WebsiteFormSubmissionsConnectionString %>" DeleteCommand="DELETE FROM [PledgeSubmissions] WHERE [ID] = @ID" InsertCommand="INSERT INTO [PledgeSubmissions] ([First Name], [Last Name], [Email], [Profession_Role], [Primary Institution], [Country of Practice], [Primary Practice Type], [Status], [TimeSubmitted], [SubmissionEmailedTo], [Participate in Follow Up Survey], [Contact With Updates], [How Learned About Image Wisely]) VALUES (@First_Name, @Last_Name, @Email, @Profession_Role, @Primary_Institution, @Country_of_Practice, @Primary_Practice_Type, @Status, @TimeSubmitted, @SubmissionEmailedTo, @Participate_in_Follow_Up_Survey, @Contact_With_Updates, @How_Learned_About_Image_Wisely)" SelectCommand="SELECT [ID], [First Name] AS First_Name, [Last Name] AS Last_Name, [Email], [Profession_Role], [Primary Institution] AS Primary_Institution, [Country of Practice] AS Country_of_Practice, [Primary Practice Type] AS Primary_Practice_Type, [Status], [TimeSubmitted], [SubmissionEmailedTo], [Participate in Follow Up Survey] AS Participate_in_Follow_Up_Survey, [Contact With Updates] AS Contact_With_Updates, [How Learned About Image Wisely] AS How_Learned_About_Image_Wisely FROM [PledgeSubmissions] WHERE YEAR(TimeSubmitted) = YEAR(GETDATE())" UpdateCommand="UPDATE [PledgeSubmissions] SET [First Name] = @First_Name, [Last Name] = @Last_Name, [Email] = @Email, [Profession_Role] = @Profession_Role, [Primary Institution] = @Primary_Institution, [Country of Practice] = @Country_of_Practice, [Primary Practice Type] = @Primary_Practice_Type, [Status] = @Status, [TimeSubmitted] = @TimeSubmitted, [SubmissionEmailedTo] = @SubmissionEmailedTo, [Participate in Follow Up Survey] = @Participate_in_Follow_Up_Survey, [Contact With Updates] = @Contact_With_Updates, [How Learned About Image Wisely] = @How_Learned_About_Image_Wisely WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Profession_Role" Type="String" />
                    <asp:Parameter Name="Primary_Institution" Type="String" />
                    <asp:Parameter Name="Country_of_Practice" Type="String" />
                    <asp:Parameter Name="Primary_Practice_Type" Type="String" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="Participate_in_Follow_Up_Survey" Type="Byte" />
                    <asp:Parameter Name="Contact_With_Updates" Type="Byte" />
                    <asp:Parameter Name="How_Learned_About_Image_Wisely" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Profession_Role" Type="String" />
                    <asp:Parameter Name="Primary_Institution" Type="String" />
                    <asp:Parameter Name="Country_of_Practice" Type="String" />
                    <asp:Parameter Name="Primary_Practice_Type" Type="String" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="Participate_in_Follow_Up_Survey" Type="Byte" />
                    <asp:Parameter Name="Contact_With_Updates" Type="Byte" />
                    <asp:Parameter Name="How_Learned_About_Image_Wisely" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource_RPPS" runat="server" ConnectionString="<%$ ConnectionStrings:ACR.Library.Properties.Settings.ACR_WebsiteFormSubmissionsConnectionString %>" DeleteCommand="DELETE FROM [ReferringPractitionerPledgeSubmissions] WHERE [ID] = @ID" InsertCommand="INSERT INTO [ReferringPractitionerPledgeSubmissions] ([First Name], [Last Name], [Email], [Profession_Role], [Primary Institution], [Country of Practice], [Primary Practice Type], [How Learned About Image Wisely], [Contact With Updates], [Participate in Follow Up Survey], [SubmissionEmailedTo], [TimeSubmitted], [Status]) VALUES (@First_Name, @Last_Name, @Email, @Profession_Role, @Primary_Institution, @Country_of_Practice, @Primary_Practice_Type, @How_Learned_About_Image_Wisely, @Contact_With_Updates, @Participate_in_Follow_Up_Survey, @SubmissionEmailedTo, @TimeSubmitted, @Status)" SelectCommand="SELECT [ID], [First Name] AS First_Name, [Last Name] AS Last_Name, [Email], [Profession_Role], [Primary Institution] AS Primary_Institution, [Country of Practice] AS Country_of_Practice, [Primary Practice Type] AS Primary_Practice_Type, [How Learned About Image Wisely] AS How_Learned_About_Image_Wisely, [Contact With Updates] AS Contact_With_Updates, [Participate in Follow Up Survey] AS Participate_in_Follow_Up_Survey, [SubmissionEmailedTo], [TimeSubmitted], [Status] FROM [ReferringPractitionerPledgeSubmissions] WHERE YEAR(TimeSubmitted) = YEAR(GETDATE())" UpdateCommand="UPDATE [ReferringPractitionerPledgeSubmissions] SET [First Name] = @First_Name, [Last Name] = @Last_Name, [Email] = @Email, [Profession_Role] = @Profession_Role, [Primary Institution] = @Primary_Institution, [Country of Practice] = @Country_of_Practice, [Primary Practice Type] = @Primary_Practice_Type, [How Learned About Image Wisely] = @How_Learned_About_Image_Wisely, [Contact With Updates] = @Contact_With_Updates, [Participate in Follow Up Survey] = @Participate_in_Follow_Up_Survey, [SubmissionEmailedTo] = @SubmissionEmailedTo, [TimeSubmitted] = @TimeSubmitted, [Status] = @Status WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Profession_Role" Type="String" />
                    <asp:Parameter Name="Primary_Institution" Type="String" />
                    <asp:Parameter Name="Country_of_Practice" Type="String" />
                    <asp:Parameter Name="Primary_Practice_Type" Type="String" />
                    <asp:Parameter Name="How_Learned_About_Image_Wisely" Type="String" />
                    <asp:Parameter Name="Contact_With_Updates" Type="Byte" />
                    <asp:Parameter Name="Participate_in_Follow_Up_Survey" Type="Byte" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="Status" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Profession_Role" Type="String" />
                    <asp:Parameter Name="Primary_Institution" Type="String" />
                    <asp:Parameter Name="Country_of_Practice" Type="String" />
                    <asp:Parameter Name="Primary_Practice_Type" Type="String" />
                    <asp:Parameter Name="How_Learned_About_Image_Wisely" Type="String" />
                    <asp:Parameter Name="Contact_With_Updates" Type="Byte" />
                    <asp:Parameter Name="Participate_in_Follow_Up_Survey" Type="Byte" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource_FPS" runat="server" ConnectionString="<%$ ConnectionStrings:ACR.Library.Properties.Settings.ACR_WebsiteFormSubmissionsConnectionString %>" DeleteCommand="DELETE FROM [FacilityPledgeSubmissions] WHERE [ID] = @ID" InsertCommand="INSERT INTO [FacilityPledgeSubmissions] ([First Name], [Last Name], [Email], [Title], [Facility], [City], [State], [Level3], [Level2], [Level1], [DisplayOnHonorRoll], [Status], [TimeSubmitted], [SubmissionEmailedTo], [Country]) VALUES (@First_Name, @Last_Name, @Email, @Title, @Facility, @City, @State, @Level3, @Level2, @Level1, @DisplayOnHonorRoll, @Status, @TimeSubmitted, @SubmissionEmailedTo, @Country)" SelectCommand="SELECT [ID], [First Name] AS First_Name, [Last Name] AS Last_Name, [Email], [Title], [Facility], [City], [State], [Level3], [Level2], [Level1], [DisplayOnHonorRoll], [Status], [TimeSubmitted], [SubmissionEmailedTo], [Country] FROM [FacilityPledgeSubmissions] WHERE YEAR(TimeSubmitted) = YEAR(GETDATE())" UpdateCommand="UPDATE [FacilityPledgeSubmissions] SET [First Name] = @First_Name, [Last Name] = @Last_Name, [Email] = @Email, [Title] = @Title, [Facility] = @Facility, [City] = @City, [State] = @State, [Level3] = @Level3, [Level2] = @Level2, [Level1] = @Level1, [DisplayOnHonorRoll] = @DisplayOnHonorRoll, [Status] = @Status, [TimeSubmitted] = @TimeSubmitted, [SubmissionEmailedTo] = @SubmissionEmailedTo, [Country] = @Country WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Facility" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Level3" Type="Byte" />
                    <asp:Parameter Name="Level2" Type="Byte" />
                    <asp:Parameter Name="Level1" Type="Byte" />
                    <asp:Parameter Name="DisplayOnHonorRoll" Type="Byte" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Facility" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Level3" Type="Byte" />
                    <asp:Parameter Name="Level2" Type="Byte" />
                    <asp:Parameter Name="Level1" Type="Byte" />
                    <asp:Parameter Name="DisplayOnHonorRoll" Type="Byte" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource_APS" runat="server" ConnectionString="<%$ ConnectionStrings:ACR.Library.Properties.Settings.ACR_WebsiteFormSubmissionsConnectionString %>" DeleteCommand="DELETE FROM [AssociationPledgeSubmissions] WHERE [ID] = @ID" InsertCommand="INSERT INTO [AssociationPledgeSubmissions] ([First Name], [Last Name], [Email], [Title], [Association], [City], [State], [DisplayOnHonorRoll], [Status], [TimeSubmitted], [SubmissionEmailedTo], [Country]) VALUES (@First_Name, @Last_Name, @Email, @Title, @Association, @City, @State, @DisplayOnHonorRoll, @Status, @TimeSubmitted, @SubmissionEmailedTo, @Country)" SelectCommand="SELECT [ID], [First Name] AS First_Name, [Last Name] AS Last_Name, [Email], [Title], [Association], [City], [State], [DisplayOnHonorRoll], [Status], [TimeSubmitted], [SubmissionEmailedTo], [Country] FROM [AssociationPledgeSubmissions] WHERE YEAR(TimeSubmitted) = YEAR(GETDATE())" UpdateCommand="UPDATE [AssociationPledgeSubmissions] SET [First Name] = @First_Name, [Last Name] = @Last_Name, [Email] = @Email, [Title] = @Title, [Association] = @Association, [City] = @City, [State] = @State, [DisplayOnHonorRoll] = @DisplayOnHonorRoll, [Status] = @Status, [TimeSubmitted] = @TimeSubmitted, [SubmissionEmailedTo] = @SubmissionEmailedTo, [Country] = @Country WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Association" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="DisplayOnHonorRoll" Type="Byte" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Association" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="DisplayOnHonorRoll" Type="Byte" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <div style="margin:20px; padding:10px;">
            <h3> <asp:Label ID="Label_Heading" runat="server" ></asp:Label></h3>
            <br />
            
            <asp:GridView ID="GridView_IPS" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource_IPS" PageSize="40" Width="100%" OnRowCommand="GridView_IPS_RowCommand"  SelectedRowStyle-BackColor="Beige">
                <Columns> 
                    <asp:CommandField ShowEditButton="true" UpdateText="Save" EditImageUrl="~/images/imagewisely/edit.png" CancelImageUrl="~/images/imagewisely/cancel.png" UpdateImageUrl="~/images/imagewisely/save.png" ButtonType="Image" />
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Profession_Role" HeaderText="Profession_Role" SortExpression="Profession_Role" />
                    <asp:BoundField DataField="Primary_Institution" HeaderText="Primary_Institution" SortExpression="Primary_Institution" />
                    <asp:BoundField DataField="Country_of_Practice" HeaderText="Country_of_Practice" SortExpression="Country_of_Practice" />
                    <asp:BoundField DataField="Primary_Practice_Type" HeaderText="Primary_Practice_Type" SortExpression="Primary_Practice_Type" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="TimeSubmitted" HeaderText="TimeSubmitted" SortExpression="TimeSubmitted" />
                    <asp:BoundField DataField="SubmissionEmailedTo" HeaderText="SubmissionEmailedTo" SortExpression="SubmissionEmailedTo" />
                    <asp:BoundField DataField="Participate_in_Follow_Up_Survey" HeaderText="Participate_in_Follow_Up_Survey" SortExpression="Participate_in_Follow_Up_Survey" />
                    <asp:BoundField DataField="Contact_With_Updates" HeaderText="Contact_With_Updates" SortExpression="Contact_With_Updates" />
                    <asp:BoundField DataField="How_Learned_About_Image_Wisely" HeaderText="How_Learned_About_Image_Wisely" SortExpression="How_Learned_About_Image_Wisely" />
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
            <asp:GridView ID="GridView_RPPS" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource_RPPS"  PageSize="40" Width="100%" Visible="False" OnRowCommand="GridView_RPPS_RowCommand"  SelectedRowStyle-BackColor="Beige">
                <Columns>
                    <asp:CommandField ShowEditButton="true" UpdateText="Save"  EditImageUrl="~/images/imagewisely/edit.png" CancelImageUrl="~/images/imagewisely/cancel.png" UpdateImageUrl="~/images/imagewisely/save.png" ButtonType="Image"/>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Profession_Role" HeaderText="Profession_Role" SortExpression="Profession_Role" />
                    <asp:BoundField DataField="Primary_Institution" HeaderText="Primary_Institution" SortExpression="Primary_Institution" />
                    <asp:BoundField DataField="Country_of_Practice" HeaderText="Country_of_Practice" SortExpression="Country_of_Practice" />
                    <asp:BoundField DataField="Primary_Practice_Type" HeaderText="Primary_Practice_Type" SortExpression="Primary_Practice_Type" />
                    <asp:BoundField DataField="How_Learned_About_Image_Wisely" HeaderText="How_Learned_About_Image_Wisely" SortExpression="How_Learned_About_Image_Wisely" />
                    <asp:BoundField DataField="Contact_With_Updates" HeaderText="Contact_With_Updates" SortExpression="Contact_With_Updates" />
                    <asp:BoundField DataField="Participate_in_Follow_Up_Survey" HeaderText="Participate_in_Follow_Up_Survey" SortExpression="Participate_in_Follow_Up_Survey" />
                    <asp:BoundField DataField="SubmissionEmailedTo" HeaderText="SubmissionEmailedTo" SortExpression="SubmissionEmailedTo" />
                    <asp:BoundField DataField="TimeSubmitted" HeaderText="TimeSubmitted" SortExpression="TimeSubmitted" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
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
            <asp:GridView ID="GridView_FPS" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource_FPS"  PageSize="40"  Width="100%" Visible="False" OnRowCommand="GridView_FPS_RowCommand"  SelectedRowStyle-BackColor="Beige">
            <Columns>
                <asp:CommandField ShowEditButton="true" UpdateText="Save"  EditImageUrl="~/images/imagewisely/edit.png" CancelImageUrl="~/images/imagewisely/cancel.png" UpdateImageUrl="~/images/imagewisely/save.png" ButtonType="Image"/>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Facility" HeaderText="Facility" SortExpression="Facility" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                <asp:BoundField DataField="Level3" HeaderText="Level3" SortExpression="Level3" />
                <asp:BoundField DataField="Level2" HeaderText="Level2" SortExpression="Level2" />
                <asp:BoundField DataField="Level1" HeaderText="Level1" SortExpression="Level1" />
                <asp:BoundField DataField="DisplayOnHonorRoll" HeaderText="DisplayOnHonorRoll" SortExpression="DisplayOnHonorRoll" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="TimeSubmitted" HeaderText="TimeSubmitted" SortExpression="TimeSubmitted" />
                <asp:BoundField DataField="SubmissionEmailedTo" HeaderText="SubmissionEmailedTo" SortExpression="SubmissionEmailedTo" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
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
            <asp:GridView ID="GridView_APS" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource_APS"  PageSize="40"  Width="100%" Visible="False" OnRowCommand="GridView_APS_RowCommand"  SelectedRowStyle-BackColor="Beige">
                <Columns>
                    <asp:CommandField ShowEditButton="true" UpdateText="Save"  EditImageUrl="~/images/imagewisely/edit.png" CancelImageUrl="~/images/imagewisely/cancel.png" UpdateImageUrl="~/images/imagewisely/save.png" ButtonType="Image"/>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Association" HeaderText="Association" SortExpression="Association" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField DataField="DisplayOnHonorRoll" HeaderText="DisplayOnHonorRoll" SortExpression="DisplayOnHonorRoll" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="TimeSubmitted" HeaderText="TimeSubmitted" SortExpression="TimeSubmitted" />
                    <asp:BoundField DataField="SubmissionEmailedTo" HeaderText="SubmissionEmailedTo" SortExpression="SubmissionEmailedTo" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:CommandField SelectImageUrl="~/images/imagewisely/delete.png" ShowSelectButton="true" ButtonType="Image" />
                    <asp:TemplateField><ItemTemplate> <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" Visible="false" /> </ItemTemplate> </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left"  />
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