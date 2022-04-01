<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadpacAdmin.aspx.cs" Inherits="ACRHelix.Project.RadPAC.sitecore.admin.RadpacAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>RADPAC Admin</title>
        <link href="../../css/radpac/bootstrap.min.css" rel="stylesheet" /> 
        <style>
            .sc-applicationHeader-row1 {
                background-color: #ca241c;
                background: url(/sitecore/shell/client/Speak/Assets/img/Speak/Layouts/breadcrumb_red_bg.png);
                background-repeat: no-repeat;
                padding-top:20px;                
                background-size: 100% 120px;
            }
            .sc-applicationHeader-row1:after {
                position: absolute;
                right: 0;
                top: 0;
                display: block;
                background: url(/sitecore/shell/client/Speak/Assets/img/Speak/Layouts/logo_spiral.png) center right;
                background-repeat: no-repeat;
                width: 113px;
                height: 90px;
                content: " ";
            }
            .sc-applicationHeader-title {
                font-size: 2em;
                color: #ffffff;
                float: left;
            }
            .sc-applicationHeader-desc {
                font-size: 1em;
                color: #ffffff;
                float: left;
            }
            .sc-padding-top {
                padding-top:20px
            }
            .input-group {
                width:80%!important;
            }
            .input-group>.custom-file:not(:last-child) .custom-file-label, .input-group>.custom-file:not(:last-child) .custom-file-label::after{
                border-radius:0;
            }
            .input-group>.input-group-append>.btn, .input-group>.input-group-append>.input-group-text, .input-group>.input-group-prepend:first-child>.btn:not(:first-child), .input-group>.input-group-prepend:first-child>.input-group-text:not(:first-child), .input-group>.input-group-prepend:not(:first-child)>.btn, .input-group>.input-group-prepend:not(:first-child)>.input-group-text {
                border-radius:0;
            }
            .btn-outline-primary {
                color: #ffffff;
                border-color: #0f416b;
                background: #0f416b;
            }
            .btn-outline-primary:focus {
                color: #fff;
                background-color: #7b98ad;
                border-color: #7b98ad;
            }
            .btn-outline-primary:hover {
                color: #fff;
                background-color: #7b98ad;
                border-color: #7b98ad;
            }
            .bg-tbl {
                background:#e9ecef;
                color:#495057;
            }
            .bg-tbl th {
                color:#495057;
            }
        </style> 
        <script type="text/javascript">
            function _getFilePath()
            {
                var fileName = (document.getElementById('<%=FileUpload1.ClientID %>').value);
                var fileName = '...' + fileName.substring(fileName.lastIndexOf("\\"));
                document.getElementById('custom-file-label').innerHTML = fileName;
            }
        </script>   
    </head>
    <body>
        <form id="form1" runat="server">  
            <div class="sc-applicationHeader-row1">
                <div class="container">
                    <div class="row">
                        <h1 class="sc-applicationHeader-title text-center">Manage RADPAC Contributions by State</h1> 
                        <br /> 
                        <p class="sc-applicationHeader-desc">
                            Upload Excel data file (NOT csv file) with columns as in below which shows the top 10 rows from RADPAC contributions database table.                                    
                        </p>
                    </div>                   
                </div>
                
            </div>
            <div class="container">  
                <div class="row">  
                    <div class="col-md-12">  
                        <div class="form-group sc-padding-top">  
                            <label>Choose excel data file</label>  
                            <div class="input-group">  
                                <div class="custom-file">  
                                    <asp:FileUpload ID="FileUpload1" CssClass="custom-file-input" runat="server" onchange="_getFilePath()" />  
                                    <label id="custom-file-label" class="custom-file-label"></label>  
                                </div>  
                                <label id="filename"></label>  
                                <div class="input-group-append">  
                                    <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-outline-primary" Text="Upload" OnClick="btnUpload_Click" />  
                                </div>  
                            </div>  
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>  
                        </div>  
                    </div>  
                </div> 
                <div class="row">
                    <p>Use the data below to validate before and after each upload. </p>
                    <asp:GridView ID="GridView1" HeaderStyle-CssClass="bg-tbl text-white" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">  
                        <EmptyDataTemplate>  
                            <div class="text-center">No record found</div>  
                        </EmptyDataTemplate>  
                        <Columns>  
                            <asp:BoundField HeaderText="First Name" DataField="First Name" />  
                            <asp:BoundField HeaderText="Middle Name" DataField="Middle Name" />  
                            <asp:BoundField HeaderText="Last Name" DataField="Last Name" />  
                            <asp:BoundField HeaderText="Suffix" DataField="Suffix" />  
                            <asp:BoundField HeaderText="Suffix 2" DataField="Suffix 2" />  
                            <asp:BoundField HeaderText="Suffix 3" DataField="Suffix 3" /> 
                            <asp:BoundField HeaderText="City" DataField="City" /> 
                            <asp:BoundField HeaderText="State" DataField="State" /> 
                            <asp:BoundField HeaderText="Date" DataField="Date" /> 
                            <asp:BoundField HeaderText="Amount" DataField="Amount" /> 
                        </Columns>  
                    </asp:GridView> 
                </div> 
            </div>  
        </form>
    </body>
</html>