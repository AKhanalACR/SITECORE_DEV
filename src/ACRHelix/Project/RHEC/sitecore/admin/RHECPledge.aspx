<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RHECPledge.aspx.cs" Inherits="RHEC.Website.sitecore.admin.RHECPledge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>RHEC Admin</title>
    <link href="../../css/imagewisely/bootstrap.min.css" rel="stylesheet" />
      <style type="text/css">           
             
              .cssPager td
            {
                  padding-left: 4px;     
                  padding-right: 4px;    
              }
        </style>
</head>
<body>
    <div style="margin-left:50px;">
   <table><tr><td><img src="../../images/RHEC/RHEC-logo.png" style="width: 100px; height: 40px;" /></td><td><h1>Radiology Health Equity Coalition Pledge Admin</h1></td></tr></table> 
    </div>
    <form id="form1" runat="server">
                <div style="margin-left:20px;">
            <table><tr>
                <td>
                    <table style="border:2px solid gray; background-color:#CCCCCC;"><tr>
                        <td><asp:Button ID="Button_IPS" runat="server" Text="Individual Submissions" OnClick="Button_IPS_Click" Height="50px" Enabled="false" /></td>                        
                        <td><asp:Button ID="Button_FPS" runat="server" Text="Facility Submissions" OnClick="Button_FPS_Click"  Height="50px" /></td>                                               
                     </tr></table>
                </td>
                <td>
                    <div style="margin-left:50px;"><a href="RHECPledge.aspx"><img src="../../images/RHEC/Reload.png" width="30" /></a></div>
                </td>
            </tr></table> 
       </div>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ACR_APP_DATA_Entities_2 %>" DeleteCommand="DELETE FROM [RhecIndividualPledgeSubmission] WHERE [ID] = @ID" InsertCommand="INSERT INTO [RhecIndividualPledgeSubmission] ([First Name], [Last Name], [Email], [Country], [TimeSubmitted], [SubmissionEmailedTo]) VALUES (@First_Name, @Last_Name, @Email, @Country, @TimeSubmitted, @SubmissionEmailedTo)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [RhecIndividualPledgeSubmission] ORDER BY [TimeSubmitted] DESC" UpdateCommand="UPDATE [RhecIndividualPledgeSubmission] SET [First Name] = @First_Name, [Last Name] = @Last_Name, [Email] = @Email, [Country] = @Country, [TimeSubmitted] = @TimeSubmitted, [SubmissionEmailedTo] = @SubmissionEmailedTo WHERE [ID] = @ID">
                 <DeleteParameters>
                     <asp:Parameter Name="ID" Type="Int32" />
                 </DeleteParameters>
                 <InsertParameters>
                     <asp:Parameter Name="First_Name" Type="String" />
                     <asp:Parameter Name="Last_Name" Type="String" />
                     <asp:Parameter Name="Email" Type="String" />
                     <asp:Parameter Name="Country" Type="String" />
                     <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                     <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                 </InsertParameters>
                 <UpdateParameters>
                     <asp:Parameter Name="First_Name" Type="String" />
                     <asp:Parameter Name="Last_Name" Type="String" />
                     <asp:Parameter Name="Email" Type="String" />
                     <asp:Parameter Name="Country" Type="String" />
                     <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                     <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                     <asp:Parameter Name="ID" Type="Int32" />
                 </UpdateParameters>
            </asp:SqlDataSource>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ACR_APP_DATA_Entities_2 %>"  DeleteCommand="DELETE FROM [RhecFacilityPledgeSubmission] WHERE [ID] = @ID" InsertCommand="INSERT INTO [RhecFacilityPledgeSubmission] ([Facility Name], [City], [Country], [State], [Zip Code], [First Name], [Last Name], [Email], [TimeSubmitted], [SubmissionEmailedTo]) VALUES (@Facility_Name, @City, @Country, @State, @Zip_Code, @First_Name, @Last_Name, @Email, @TimeSubmitted, @SubmissionEmailedTo)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [RhecFacilityPledgeSubmission]" UpdateCommand="UPDATE [RhecFacilityPledgeSubmission] SET [Facility Name] = @Facility_Name, [City] = @City, [Country] = @Country, [State] = @State, [Zip Code] = @Zip_Code, [First Name] = @First_Name, [Last Name] = @Last_Name, [Email] = @Email, [TimeSubmitted] = @TimeSubmitted, [SubmissionEmailedTo] = @SubmissionEmailedTo WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Facility_Name" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Zip_Code" Type="String" />
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Facility_Name" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="Country" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="Zip_Code" Type="String" />
                    <asp:Parameter Name="First_Name" Type="String" />
                    <asp:Parameter Name="Last_Name" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="TimeSubmitted" Type="DateTime" />
                    <asp:Parameter Name="SubmissionEmailedTo" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>                      
        </div>
        <div style="margin:20px; padding:10px;">
            <h3> <asp:Label ID="Label_Heading" runat="server" ></asp:Label><asp:Button ID="IndividualToExcel" runat="server" Text="Export To Excel" OnClick="ExportIndividualToExcel"  style="margin-left: 33px;height:40px; font-size:14px" />
             <asp:Button ID="FacilityToExcel" runat="server" Visible="false" Text="Export To Excel" OnClick="ExportFacilityToExcel"  style="margin-left: 33px;height:40px; font-size:14px" /></h3>
             
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSource1" PageSize="40" Width="100%" OnRowCommand="GridView1_RowCommand"  SelectedRowStyle-BackColor="Beige" DataKeyNames="ID" >
                <Columns>
<%--                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="TimeSubmitted" HeaderText="TimeSubmitted" SortExpression="TimeSubmitted" />
                    <asp:BoundField DataField="SubmissionEmailedTo" HeaderText="SubmissionEmailedTo" SortExpression="SubmissionEmailedTo" />--%>
                   <%--  <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />--%>
                     <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="First Name" HeaderText="First Name" SortExpression="First Name" />
                    <asp:BoundField DataField="Last Name" HeaderText="Last Name" SortExpression="Last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="TimeSubmitted" HeaderText="TimeSubmitted" SortExpression="TimeSubmitted" />
                    <asp:BoundField DataField="SubmissionEmailedTo" HeaderText="SubmissionEmailedTo" SortExpression="SubmissionEmailedTo" />
                       <asp:CommandField SelectImageUrl="~/images/RHEC/delete.png" ShowSelectButton="true" ButtonType="Image" />
                    <asp:TemplateField><ItemTemplate> <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" Visible="false" /> </ItemTemplate> </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" CssClass="cssPager" />
               <%-- <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />--%>
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSource2" PageSize="40" Width="100%" Visible="False" OnRowCommand="GridView2_RowCommand"  SelectedRowStyle-BackColor="Beige" DataKeyNames="ID" >
                <Columns>
                    <%--<asp:BoundField DataField="Facility_Name" HeaderText="Facility_Name" SortExpression="Facility_Name" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField DataField="Zip_Code" HeaderText="Zip_Code" SortExpression="Zip_Code" />
                  
                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="TimeSubmitted" HeaderText="TimeSubmitted" SortExpression="TimeSubmitted" />
                    <asp:BoundField DataField="SubmissionEmailedTo" HeaderText="SubmissionEmailedTo" SortExpression="SubmissionEmailedTo" />--%>
               <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                     <asp:BoundField DataField="Facility Name" HeaderText="Facility Name" SortExpression="Facility Name" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                    <asp:BoundField DataField="Zip Code" HeaderText="Zip Code" SortExpression="Zip Code" />
                    <asp:BoundField DataField="First Name" HeaderText="First Name" SortExpression="First Name" />
                    <asp:BoundField DataField="Last Name" HeaderText="Last Name" SortExpression="Last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="TimeSubmitted" HeaderText="TimeSubmitted" SortExpression="TimeSubmitted" />
                    <asp:BoundField DataField="SubmissionEmailedTo" HeaderText="SubmissionEmailedTo" SortExpression="SubmissionEmailedTo" />
                    <asp:CommandField SelectImageUrl="~/images/RHEC/delete.png" ShowSelectButton="true" ButtonType="Image" />
                    <asp:TemplateField><ItemTemplate> <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" Visible="false" /> </ItemTemplate> </asp:TemplateField>
                    </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" CssClass="cssPager" />
               <%-- <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />--%>
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
           
        </div>
    </form>
</body>
</html>
