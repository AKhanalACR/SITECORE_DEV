<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeBehind="IdeasAdmin.aspx.cs" Inherits="Ideas.Website.sitecore.admin.IdeasAdmin" %>

<!DOCTYPE html>

<%--<script runat="server">

  void GridView1_RowDeleted(Object sender, GridViewDeletedEventArgs e)
  {
    
    // Display whether the delete operation succeeded.
    if(e.Exception == null)
    {
     if (HttpContext.Current.Request.Cookies["MessageDisplayed"] != null)
      {
        if (HttpContext.Current.Request.Cookies["MessageDisplayed"].Value.ToString() == "True")
        {
          // ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "deleteCookieValue('MessageDisplayed')", true);
           HttpCookie cookie = HttpContext.Current.Request.Cookies["MessageDisplayed"];
          cookie.Value = "False";
            Response.Cookies.Add(cookie);
        }
      }
      ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alertMessage();", true);
    }      
  }
    
</script>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .displaynone{
            display:none;
        }
        .paddingcustom{
            padding-right:20px;
        }
        </style>
   <%-- <link rel="stylesheet" href="/css/jquery-ui.min.css" />--%>
    <link rel="stylesheet" href="/css/Ideas/jquery-ui.css" />
    <script src="/js/jquery-2.2.0.min.js"></script>
    <script src="/js//jquery-ui.min.js"></script>
<%--    <script type="text/javascript">
        $(function () {
            $("[id*=GridView1]").find(":text").each(function () {
                var title = $(this).attr("title");
                if (title == "Contact Date") {
                    $(this).datepicker({
                        dateFormat: 'mm-dd-yy'
                    });
                }
            });
        });
    </script>--%>
     <script type="text/javascript">
<%--    function CheckDuplicates(sender,args)
    {
        var $k = jQuery.noConflict();
        alert($k("#" + ($k("#" + sender.id).attr('data-val-controltovalidate')).toString()).val());
        var grid = document.getElementById("<%=GridView1.ClientID %>");
 
        //Reference all Rows of the GridView.
        var rows = grid.getElementsByTagName("TR");
        for (var i = 1; i < rows.length; i++) {
            if (document.getElementById("GridView1_Label1_" + [i - 1])) {
                console.log(document.getElementById("GridView1_Label1_" + [i - 1]).textContent);
            }
            else if (document.getElementById("GridView1_TextboxIdEdit_" + [i - 1])) {
                console.log(document.getElementById("GridView1_TextboxIdEdit_" + [i - 1]).value);
            }
            else {
               console.log(document.getElementById("GridView1_txtId").value); 
            }
            
            console.log("#GridView1_Label1_" + [i - 1]);
            //Reference the Cells of the Row.
            var cells = rows[i].getElementsByTagName("TD");

            //Fetch the values from the Cells.
           // alert(cells[1].innerHTML);
           
        }
        args.IsValid = true;
                return;
}--%>
         var $j = jQuery.noConflict();
        $j(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindPicker);
            bindPicker();
        });
        function bindPicker() {
            $j("input[type=text][id*=TextBox11]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=TextBox12]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=TextBox17]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=TextBox19]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=TextBox21]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=TextBox22]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=TextBox23]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=TextBox24]").datepicker({ changeMonth: true, changeYear: true, showButtonPanel: true, dateFormat: 'mm-dd-yy' });


             $j("input[type=text][id*=txtRegDate]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=txtLastUpdateDate]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=txtCreatedDate]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=txtLastModifiedDate]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=txtOriginalIrbApprovalDate]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=txtIrbExpirationDate]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=txtSiteActivationDate]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });
            $j("input[type=text][id*=txtSiteWithdrawalDate]").datepicker({ changeMonth: true,changeYear: true,showButtonPanel: true, dateFormat: 'mm-dd-yy' });

            
         }
         function alertDelete() {  
                 $j("#deletedSite").show();
                        setTimeout(function () {$("#deletedSite").hide(); }, 7000);
         } 
         function alertUpdate() {  
                 $j("#updatedSite").show();
                        setTimeout(function () {$("#updatedSite").hide(); }, 7000);
         } 
         function alertAddition() {  
                 $j("#addedSite").show();
                        setTimeout(function () {$("#addedSite").hide(); }, 7000);
         } 
    </script>
</head>
<body>
    <div style="margin-left:50px;">
   <table>  <tr><td><img src="/-/media/Ideas/Images/Logos/NewIdeas_Logo_Color_brandcolors.png?h=190&amp;w=337&amp;la=en&amp;hash=932EB21B9D5A0FC661FE2CB938A1EF88" alt="New IDEAS study logo" title="New IDEAS study logo" style="width: 200px;height: 100px;margin-top: 20px;"></td></tr><tr><td><h1 style="margin-bottom: 30px;">Ideas Sites Administrator</h1><h3 style="margin-bottom: 30px;">For calculating Longitude and Latitude Please refer : https://www.latlong.net/convert-address-to-lat-long.html </h3><h4 id="deletedSite" style="display:none; margin-bottom: 16px; color:green;">Facility/Physician has been successfully removed</h4><h4 id="updatedSite" style="display:none; margin-bottom: 16px; color:green;">Facility/Physician information has been successfully updated</h4><h4 id="addedSite" style="display:none; margin-bottom: 16px; color:green;">Facility/Physician has been successfully added</h4></td></tr>     
   </table> 
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" PageSize="15" AutoGenerateColumns="False" CellPadding="5" 
            DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" ShowFooter="True" OnRowDeleted="GridView1_RowDeleted" OnRowUpdated="GridView1_RowUpdated">      
          <%--  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"--%>
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField ItemStyle-CssClass="paddingcustom" FooterStyle-CssClass="paddingcustom" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update" ForeColor="White"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="Cancel" ForeColor="White"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate> 
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                        &nbsp;<%--<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to remove this site?');" Text="Delete"></asp:LinkButton>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ValidationGroup="Insert" CausesValidation="True" OnClick="lbInsert_Click" ID="lbInsert" ForeColor="White" runat="server">Add</asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"  SortExpression="ID" >
                <%--    <EditItemTemplate>                      
                        <asp:TextBox ID="TextboxIdEdit" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvEditId" runat="server"
                            ErrorMessage="ID is a required field"
                            ControlToValidate="TextboxIdEdit" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" text="Duplicate" runat="server" ErrorMessage="Duplicate Id" ControlToValidate="TextboxIdEdit" ForeColor="Red" OnServerValidate="CheckDuplicates"></asp:CustomValidator>

                    </EditItemTemplate>--%>
                   <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" ForeColor="White" Text='<%# Bind("ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label111" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                       <%-- <asp:RequiredFieldValidator ID="rfvInsertId" runat="server"
                            ErrorMessage="Id is a required field"
                            ControlToValidate="txtId" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                       <asp:CustomValidator ValidationGroup="Insert" ID="IDCustomValidator" text="Duplicate" runat="server" ErrorMessage="Duplicate Id"  ControlToValidate="txtId" ForeColor="Red" ValidateWhenEmpty="True" OnServerValidate="CheckDuplicates">
                         </asp:CustomValidator>--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NAME" SortExpression="NAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NAME") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEditName" runat="server"
                            ErrorMessage="Name is a required field"
                            ControlToValidate="TextBox1" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvInsertName" runat="server"
                            ErrorMessage="Name is a required field"
                            ControlToValidate="txtName" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STREET" SortExpression="STREET">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("STREET") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("STREET") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STREET2" SortExpression="STREET2">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("STREET2") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("STREET2") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtStreet2" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CITY" SortExpression="CITY">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CITY") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("CITY") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STATE_ID" SortExpression="STATE_ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("STATE_ID") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEditStateID" runat="server"
                            ErrorMessage="State ID is a required field"
                            ControlToValidate="TextBox5" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TextBox5" ForeColor="Red" Text="Wrong Format"
                            ValidationExpression="[a-zA-Z]{1,2}" ErrorMessage="Valid characters: 2 Alphabets." />

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("STATE_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtStateId" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvInsertStateID" runat="server"
                            ErrorMessage="State ID is a required field"
                            ControlToValidate="txtStateId" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtStateId" ForeColor="Red" Text="Wrong Format"
                            ValidationExpression="[a-zA-Z]{1,2}" ErrorMessage="Valid characters: 2 Alphabets." ValidationGroup="Insert" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ZIP" SortExpression="ZIP">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ZIP") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEditZIP" runat="server"
                            ErrorMessage="ZIP is a required field"
                            ControlToValidate="TextBox6" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ControlToValidate="TextBox6" ForeColor="Red" Text="Wrong Format"
                            ValidationExpression="[a-zA-Z0-9]{1,10}" ErrorMessage="Valid characters: 10 Alphanumeric." />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ZIP") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvInsertZip" runat="server"
                            ErrorMessage="ZIP is a required field"
                            ControlToValidate="txtZip" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server" ControlToValidate="txtZip" ForeColor="Red" Text="Wrong Format"
                            ValidationExpression="[a-zA-Z0-9]{1,10}" ErrorMessage="Valid characters: 10 Alphanumeric." ValidationGroup="Insert" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PHONE" SortExpression="PHONE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("PHONE") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEditPhone" runat="server"
                            ErrorMessage="Phone is a required field"
                            ControlToValidate="TextBox7" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                       
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("PHONE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvInsertPhone" runat="server"
                            ErrorMessage="Phone is a required field"
                            ControlToValidate="txtPhone" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FAX" SortExpression="FAX">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("FAX") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("FAX") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EMAIL" SortExpression="EMAIL">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("EMAIL") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEditEmail" runat="server"
                            ErrorMessage="Email is a required field"
                            ControlToValidate="TextBox9" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("EMAIL") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvInsertEmail" runat="server"
                            ErrorMessage="Email is a required field"
                            ControlToValidate="txtEmail" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STATUS" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone" SortExpression="STATUS">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("STATUS") %>'></asp:TextBox>
                       <%-- <asp:RequiredFieldValidator ID="rfvEditStatus" runat="server"
                            ErrorMessage="Status is a required field"
                            ControlToValidate="TextBox10" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>--%>
                        <%--<asp:CompareValidator ID="cvStatus" runat="server" ControlToValidate="TextBox10" Type="Integer" Text="Wrong Format" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Value must be an integer."></asp:CompareValidator>--%>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("STATUS") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>
                       <%-- <asp:RequiredFieldValidator ID="rfvInsertStatus" runat="server"
                            ErrorMessage="Status is a required field"
                            ControlToValidate="txtStatus" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>--%>
                       <%-- <asp:CompareValidator ID="cvInsertStatus" runat="server" ControlToValidate="txtStatus" Type="Integer" Text="Invalid" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Value must be an integer." ValidationGroup="Insert"></asp:CompareValidator>--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="REGISTRATION_DATE" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="REGISTRATION_DATE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server"
                            Text='<%# Bind("REGISTRATION_DATE") %>'></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvEditRegDate" runat="server"
                            ErrorMessage="Registration Date is a required field"
                            ControlToValidate="TextBox11" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>--%>
                        <%--<asp:Calendar ID="EditRegistrationDate" VisibleDate='<%# Eval("REGISTRATION_DATE") %>'  SelectedDate='<%# Bind("REGISTRATION_DATE") %>' runat="server"></asp:Calendar>--%>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("REGISTRATION_DATE") %>'></asp:Label>
                        <%--  <asp:Calendar ID="EditRegistrationDate" VisibleDate='<%# Bind("REGISTRATION_DATE") %>'  SelectedDate='<%# Bind("REGISTRATION_DATE") %>' runat="server"></asp:Calendar>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtRegDate" runat="server"></asp:TextBox>
                      <%--  <asp:RequiredFieldValidator ID="rfvInsertRegDate" runat="server"
                            ErrorMessage="Registration Date  is a required field"
                            ControlToValidate="txtRegDate" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LAST_UPDATE_DATE" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="LAST_UPDATE_DATE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox12" runat="server"
                            Text='<%# Bind("LAST_UPDATE_DATE") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("LAST_UPDATE_DATE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLastUpdateDate" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PRACTICE_TYPE" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone" SortExpression="PRACTICE_TYPE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("PRACTICE_TYPE") %>'></asp:TextBox>
                        <asp:CompareValidator ID="cvPracticeType" runat="server" ControlToValidate="TextBox13" Type="Integer" Text="Wrong Format" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Value must be an integer."></asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("PRACTICE_TYPE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPracticeType" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="cvInsertPracticeType" runat="server" ControlToValidate="txtPracticeType" Type="Integer" Text="Wrong Format" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Value must be an integer." ValidationGroup="Insert"></asp:CompareValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PHONE_EXT" SortExpression="PHONE_EXT">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("PHONE_EXT") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("PHONE_EXT") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPhoneExt" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LAST_UPDATE_USER_ID" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="LAST_UPDATE_USER_ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox15" runat="server"
                            Text='<%# Bind("LAST_UPDATE_USER_ID") %>'></asp:TextBox>
                        <asp:CompareValidator ID="cvLastUpdateUserId" runat="server" ControlToValidate="TextBox15" Type="Integer" Text="Wrong Format" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Value must be an integer."></asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server"
                            Text='<%# Bind("LAST_UPDATE_USER_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLastUpdatedUserid" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="cvInsertLastUpdatedUserid" runat="server" ControlToValidate="txtLastUpdatedUserid" Type="Integer" Text="Wrong Format" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Value must be an integer." ValidationGroup="Insert"></asp:CompareValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Facility_TYPE"
                    SortExpression="IRB_APPROVAL_TYPE">
                    <EditItemTemplate>
                          <asp:DropDownList ID="DropDownList1" runat="server" 
                    SelectedValue='<%# Bind("IRB_APPROVAL_TYPE") %>' >
                    <asp:ListItem value="">Select Facility Type</asp:ListItem>
                    <asp:ListItem value="1">Referring Physicians</asp:ListItem>
                    <asp:ListItem value="0">PET Facilities</asp:ListItem>
                </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="rfvIrbApprovalType" runat="server"
                            ErrorMessage="Please select Facility Type"
                            ControlToValidate="DropDownList1" Text="Please Select Type" ForeColor="Red" InitialValue="">
                        </asp:RequiredFieldValidator>
                      <%--  <asp:TextBox ID="TextBox16" runat="server"
                            Text='<%# Bind("IRB_APPROVAL_TYPE") %>'></asp:TextBox>
                        <asp:CompareValidator ID="cvIrbApprovalType" runat="server" ControlToValidate="TextBox16" Type="Integer" Text="Wrong Format" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Value must be an integer."></asp:CompareValidator>--%>
                    </EditItemTemplate>
                    <ItemTemplate>
                         <asp:DropDownList ID="DropDownList2" runat="server" 
                    SelectedValue='<%# Bind("IRB_APPROVAL_TYPE") %>' Enabled="false">
                    <asp:ListItem value="">Select Facility Type</asp:ListItem>
                    <asp:ListItem value="1">Referring Physicians</asp:ListItem>
                    <asp:ListItem value="0">PET Facilities</asp:ListItem>
                </asp:DropDownList>
                        <%--<asp:Label ID="Label17" runat="server" Text='<%# Bind("IRB_APPROVAL_TYPE") %>'></asp:Label>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                              <asp:DropDownList ID="DropDownListIrbApprovalType" runat="server">
                    <asp:ListItem value="">Select Facility Type</asp:ListItem>
                    <asp:ListItem value="1">Referring Physicians</asp:ListItem>
                    <asp:ListItem value="0">PET Facilities</asp:ListItem>
                </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="rfvInsertIrbApprovalType" runat="server"
                            ErrorMessage="Please select Facility Type"
                            ControlToValidate="DropDownListIrbApprovalType" Text="Please Select Type" ForeColor="Red" InitialValue="" ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                        <%--<asp:TextBox ID="txtIrbApprovalType" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="cvIrbApprovalType" runat="server" ControlToValidate="txtIrbApprovalType" Type="Integer" Text="Wrong Format" ForeColor="Red" Operator="DataTypeCheck" ErrorMessage="Value must be an integer." ValidationGroup="Insert"></asp:CompareValidator>--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IS_PARTICIPATING_SITE_APPROVAL_EXECUTED" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="IS_PARTICIPATING_SITE_APPROVAL_EXECUTED">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server"
                            Checked='<%# Bind("IS_PARTICIPATING_SITE_APPROVAL_EXECUTED") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server"
                            Checked='<%# Bind("IS_PARTICIPATING_SITE_APPROVAL_EXECUTED") %>'
                            Enabled="false" />
                        <asp:Label ID="Label17555" runat="server" Text='<%# Bind("IS_PARTICIPATING_SITE_APPROVAL_EXECUTED") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxIsApprovalExecuted" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IS_IRB_APPROVED" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="IS_IRB_APPROVED">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server"
                            Checked='<%# Bind("IS_IRB_APPROVED") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server"
                            Checked='<%# Bind("IS_IRB_APPROVED") %>' Enabled="false" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxIsIrbApproved" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IS_FACILITY_APPROVED" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="IS_FACILITY_APPROVED">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox3" runat="server"
                            Checked='<%# Bind("IS_FACILITY_APPROVED") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox3" runat="server"
                            Checked='<%# Bind("IS_FACILITY_APPROVED") %>' Enabled="false" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxIsFacilityApproved" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IS_DEMENTIA_SPECIALIST_APPROVED" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="IS_DEMENTIA_SPECIALIST_APPROVED">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox4" runat="server"
                            Checked='<%# Bind("IS_DEMENTIA_SPECIALIST_APPROVED") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox4" runat="server"
                            Checked='<%# Bind("IS_DEMENTIA_SPECIALIST_APPROVED") %>' Enabled="false" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxIsDemantiaSpecialistApproved" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CREATED_DATETIME" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="CREATED_DATETIME">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox17" runat="server"
                            Text='<%# Bind("CREATED_DATETIME") %>'></asp:TextBox>
                       <%-- <asp:RequiredFieldValidator ID="rfvEditCreatedDate" runat="server"
                            ErrorMessage="Created Date is a required field"
                            ControlToValidate="TextBox17" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>--%>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("CREATED_DATETIME") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCreatedDate" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvInsertCreatedDate" runat="server"
                            ErrorMessage="Created Date  is a required field"
                            ControlToValidate="txtCreatedDate" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>--%>
                    </FooterTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="CREATED_BY" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone" SortExpression="CREATED_BY">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("CREATED_BY") %>'></asp:TextBox>
                      <%--  <asp:RequiredFieldValidator ID="rfvEditCreatedBy" runat="server"
                            ErrorMessage="CREATED BY is a required field"
                            ControlToValidate="TextBox18" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>--%>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" Text='<%# Bind("CREATED_BY") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCreatedBy" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvInsertCreatedBy" runat="server"
                            ErrorMessage="Created By  is a required field"
                            ControlToValidate="txtCreatedBy" Text="Required" ForeColor="Red"
                            ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LAST_MODIFIED_DATETIME" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="LAST_MODIFIED_DATETIME">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox19" runat="server"
                            Text='<%# Bind("LAST_MODIFIED_DATETIME") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label20" runat="server"
                            Text='<%# Bind("LAST_MODIFIED_DATETIME") %>'></asp:Label>

                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLastModifiedDate" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LAST_MODIFIED_BY" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="LAST_MODIFIED_BY">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox20" runat="server"
                            Text='<%# Bind("LAST_MODIFIED_BY") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label21" runat="server" Text='<%# Bind("LAST_MODIFIED_BY") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLastModifiedBy" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IS_ACTIVE" SortExpression="IS_ACTIVE">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox5" runat="server"
                            Checked='<%# Bind("IS_ACTIVE") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("IS_ACTIVE") %>'
                            Enabled="false" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxIsActive" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IS_DATA_COLLECTION_AVAILABLE" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="IS_DATA_COLLECTION_AVAILABLE">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox6" runat="server"
                            Checked='<%# Bind("IS_DATA_COLLECTION_AVAILABLE") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox6" runat="server"
                            Checked='<%# Bind("IS_DATA_COLLECTION_AVAILABLE") %>' Enabled="false" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxIsDataCollectionAvailable" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ORIGINAL_IRB_APPROVAL_DATE" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="ORIGINAL_IRB_APPROVAL_DATE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox21" runat="server"
                            Text='<%# Bind("ORIGINAL_IRB_APPROVAL_DATE") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!!!!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label22" runat="server"
                            Text='<%# Bind("ORIGINAL_IRB_APPROVAL_DATE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtOriginalIrbApprovalDate" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IRB_EXPIRATION_DATE" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="IRB_EXPIRATION_DATE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox22" runat="server"
                            Text='<%# Bind("IRB_EXPIRATION_DATE") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label23" runat="server"
                            Text='<%# Bind("IRB_EXPIRATION_DATE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtIrbExpirationDate" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SITE_ACTIVATION_DATE" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="SITE_ACTIVATION_DATE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox23" runat="server"
                            Text='<%# Bind("SITE_ACTIVATION_DATE") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label24" runat="server"
                            Text='<%# Bind("SITE_ACTIVATION_DATE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtSiteActivationDate" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SITE_WITHDRAWAL_DATE" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="SITE_WITHDRAWAL_DATE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox24" runat="server"
                            Text='<%# Bind("SITE_WITHDRAWAL_DATE") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label25" runat="server"
                            Text='<%# Bind("SITE_WITHDRAWAL_DATE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtSiteWithdrawalDate" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IS_TERMINATED" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone" SortExpression="IS_TERMINATED">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox7" runat="server"
                            Checked='<%# Bind("IS_TERMINATED") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox7" runat="server"
                            Checked='<%# Bind("IS_TERMINATED") %>' Enabled="false" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBoxIsTerminated" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="REASON_OF_TERMINATION" HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone" FooterStyle-CssClass="displaynone"
                    SortExpression="REASON_OF_TERMINATION">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox25" runat="server"
                            Text='<%# Bind("REASON_OF_TERMINATION") %>'></asp:TextBox>
                        <asp:Label ForeColor="#2461BF" runat="server" Text='!!!!!!!!!!!!!!!!!!'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label26" runat="server"
                            Text='<%# Bind("REASON_OF_TERMINATION") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtReasonofTermination" runat="server"></asp:TextBox>
                        <asp:Label ForeColor="#507CD1" runat="server" Text='!!!!!!!!!!!!!!!!!!'></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LATITUDE" SortExpression="LATITUDE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox26" runat="server" Text='<%# Bind("LATITUDE") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvEditLatitue" runat="server"
                            ErrorMessage="Latitude is a required field"
                            ControlToValidate="TextBox26" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" ControlToValidate="TextBox26" runat="server" ErrorMessage="Decimal(18,12) accepted" MaximumValue="999999999999999999.999999999999" MinimumValue="-999999999999999999.999999999999" Type="Double" Text="Wrong Format" ForeColor="Red"></asp:RangeValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label27" runat="server" Text='<%# Bind("LATITUDE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox> 
                         <asp:RequiredFieldValidator ID="rfvInsertLatitue" runat="server"
                            ErrorMessage="Latitude is a required field"
                            ControlToValidate="txtLatitude" Text="Required" ForeColor="Red" ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtLatitude" runat="server" ErrorMessage="Decimal(18,12) accepted" MaximumValue="999999999999999999.999999999999" MinimumValue="-999999999999999999.999999999999" Type="Double" Text="Wrong Format" ForeColor="Red" ValidationGroup="Insert"></asp:RangeValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LONGITUDE" SortExpression="LONGITUDE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox27" runat="server" Text='<%# Bind("LONGITUDE") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvEditLongitue" runat="server"
                            ErrorMessage="LONGITUDE is a required field"
                            ControlToValidate="TextBox27" Text="Required" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator3" ControlToValidate="TextBox27" runat="server" ErrorMessage="Decimal(18,12) accepted" MaximumValue="999999999999999999.999999999999" MinimumValue="-999999999999999999.999999999999" Type="Double" Text="Wrong Format" ForeColor="Red"></asp:RangeValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label28" runat="server" Text='<%# Bind("LONGITUDE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvInsertLongitue" runat="server"
                            ErrorMessage="LONGITUDE is a required field"
                            ControlToValidate="txtLongitude" Text="Required" ForeColor="Red" ValidationGroup="Insert">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator4" ControlToValidate="txtLongitude" runat="server" ErrorMessage="Decimal(18,12) accepted" MaximumValue="999999999999999999.999999999999" MinimumValue="-999999999999999999.999999999999" Type="Double" Text="Wrong Format" ForeColor="Red" ValidationGroup="Insert"></asp:RangeValidator>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" VerticalAlign="Top" HorizontalAlign="center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:ValidationSummary ValidationGroup="Insert" ID="ValidationSummary1" runat="server" ForeColor="red" />
        <asp:ValidationSummary  ID="ValidationSummary2" runat="server" ForeColor="red" />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ACR_APP_DATA_Entities_2 %>" 
            DeleteCommand="DELETE FROM [PRACTICE] WHERE [ID] = @ID" 
            InsertCommand="INSERT INTO [PRACTICE] ([NAME], [STREET], [STREET2], [CITY], [STATE_ID], [ZIP], [PHONE], [FAX], [EMAIL], [STATUS], [REGISTRATION_DATE], [LAST_UPDATE_DATE], [PRACTICE_TYPE], [PHONE_EXT], [LAST_UPDATE_USER_ID], [IRB_APPROVAL_TYPE], [IS_PARTICIPATING_SITE_APPROVAL_EXECUTED], [IS_IRB_APPROVED], [IS_FACILITY_APPROVED], [IS_DEMENTIA_SPECIALIST_APPROVED], [CREATED_DATETIME], [CREATED_BY], [LAST_MODIFIED_DATETIME], [LAST_MODIFIED_BY], [IS_ACTIVE], [IS_DATA_COLLECTION_AVAILABLE], [ORIGINAL_IRB_APPROVAL_DATE], [IRB_EXPIRATION_DATE], [SITE_ACTIVATION_DATE], [SITE_WITHDRAWAL_DATE], [IS_TERMINATED], [REASON_OF_TERMINATION], [LATITUDE], [LONGITUDE]) VALUES (@NAME, @STREET, @STREET2, @CITY, @STATE_ID, @ZIP, @PHONE, @FAX, @EMAIL, @STATUS, @REGISTRATION_DATE, @LAST_UPDATE_DATE, @PRACTICE_TYPE, @PHONE_EXT, @LAST_UPDATE_USER_ID, @IRB_APPROVAL_TYPE, @IS_PARTICIPATING_SITE_APPROVAL_EXECUTED, @IS_IRB_APPROVED, @IS_FACILITY_APPROVED, @IS_DEMENTIA_SPECIALIST_APPROVED, @CREATED_DATETIME, @CREATED_BY, @LAST_MODIFIED_DATETIME, @LAST_MODIFIED_BY, @IS_ACTIVE, @IS_DATA_COLLECTION_AVAILABLE, @ORIGINAL_IRB_APPROVAL_DATE, @IRB_EXPIRATION_DATE, @SITE_ACTIVATION_DATE, @SITE_WITHDRAWAL_DATE, @IS_TERMINATED, @REASON_OF_TERMINATION, @LATITUDE, @LONGITUDE)" 
            OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT TOP (100000) [ID],[NAME],[STREET],[STREET2],[CITY],[STATE_ID],[ZIP],[PHONE],[FAX],[EMAIL],[STATUS],[REGISTRATION_DATE],[LAST_UPDATE_DATE],[PRACTICE_TYPE],[PHONE_EXT],[LAST_UPDATE_USER_ID],CASE WHEN ([IRB_APPROVAL_TYPE] != 0 AND [IRB_APPROVAL_TYPE] != 1) THEN NULL ELSE [IRB_APPROVAL_TYPE] END as [IRB_APPROVAL_TYPE],ISNULL([IS_PARTICIPATING_SITE_APPROVAL_EXECUTED],0) as [IS_PARTICIPATING_SITE_APPROVAL_EXECUTED],ISNULL([IS_IRB_APPROVED],0) as [IS_IRB_APPROVED],ISNULL([IS_FACILITY_APPROVED],0) as [IS_FACILITY_APPROVED],ISNULL([IS_DEMENTIA_SPECIALIST_APPROVED],0) as [IS_DEMENTIA_SPECIALIST_APPROVED],[CREATED_DATETIME],[CREATED_BY],[LAST_MODIFIED_DATETIME],[LAST_MODIFIED_BY],ISNULL([IS_ACTIVE],0) as [IS_ACTIVE],[IS_DATA_COLLECTION_AVAILABLE],[ORIGINAL_IRB_APPROVAL_DATE],[IRB_EXPIRATION_DATE],[SITE_ACTIVATION_DATE],[SITE_WITHDRAWAL_DATE],[IS_TERMINATED],[REASON_OF_TERMINATION],[LATITUDE],[LONGITUDE] FROM [PRACTICE]" 
            UpdateCommand="UPDATE [PRACTICE] SET [NAME] = @NAME, [STREET] = @STREET, [STREET2] = @STREET2, [CITY] = @CITY, [STATE_ID] = @STATE_ID, [ZIP] = @ZIP, [PHONE] = @PHONE, [FAX] = @FAX, [EMAIL] = @EMAIL, [STATUS] = @STATUS, [REGISTRATION_DATE] = @REGISTRATION_DATE, [LAST_UPDATE_DATE] = @LAST_UPDATE_DATE, [PRACTICE_TYPE] = @PRACTICE_TYPE, [PHONE_EXT] = @PHONE_EXT, [LAST_UPDATE_USER_ID] = @LAST_UPDATE_USER_ID, [IRB_APPROVAL_TYPE] = @IRB_APPROVAL_TYPE, [IS_PARTICIPATING_SITE_APPROVAL_EXECUTED] = @IS_PARTICIPATING_SITE_APPROVAL_EXECUTED, [IS_IRB_APPROVED] = @IS_IRB_APPROVED, [IS_FACILITY_APPROVED] = @IS_FACILITY_APPROVED, [IS_DEMENTIA_SPECIALIST_APPROVED] = @IS_DEMENTIA_SPECIALIST_APPROVED, [CREATED_DATETIME] = @CREATED_DATETIME, [CREATED_BY] = @CREATED_BY, [LAST_MODIFIED_DATETIME] = @LAST_MODIFIED_DATETIME, [LAST_MODIFIED_BY] = @LAST_MODIFIED_BY, [IS_ACTIVE] = @IS_ACTIVE, [IS_DATA_COLLECTION_AVAILABLE] = @IS_DATA_COLLECTION_AVAILABLE, [ORIGINAL_IRB_APPROVAL_DATE] = @ORIGINAL_IRB_APPROVAL_DATE, [IRB_EXPIRATION_DATE] = @IRB_EXPIRATION_DATE, [SITE_ACTIVATION_DATE] = @SITE_ACTIVATION_DATE, [SITE_WITHDRAWAL_DATE] = @SITE_WITHDRAWAL_DATE, [IS_TERMINATED] = @IS_TERMINATED, [REASON_OF_TERMINATION] = @REASON_OF_TERMINATION, [LATITUDE] = @LATITUDE, [LONGITUDE] = @LONGITUDE WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                  <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="STREET" Type="String" />
                <asp:Parameter Name="STREET2" Type="String" />
                <asp:Parameter Name="CITY" Type="String" />
                <asp:Parameter Name="STATE_ID" Type="String" />
                <asp:Parameter Name="ZIP" Type="String" />
                <asp:Parameter Name="PHONE" Type="String" />
                <asp:Parameter Name="FAX" Type="String" />
                <asp:Parameter Name="EMAIL" Type="String" />
                <asp:Parameter Name="STATUS" Type="Int32" />
                <asp:Parameter Name="REGISTRATION_DATE" Type="DateTime" />
                <asp:Parameter Name="LAST_UPDATE_DATE" Type="DateTime" />
                <asp:Parameter Name="PRACTICE_TYPE" Type="Int32" />
                <asp:Parameter Name="PHONE_EXT" Type="String" />
                <asp:Parameter Name="LAST_UPDATE_USER_ID" Type="Int32" />
                <asp:Parameter Name="IRB_APPROVAL_TYPE" Type="Int32" />
                <asp:Parameter Name="IS_PARTICIPATING_SITE_APPROVAL_EXECUTED" Type="Boolean" />
                <asp:Parameter Name="IS_IRB_APPROVED" Type="Boolean" />
                <asp:Parameter Name="IS_FACILITY_APPROVED" Type="Boolean" />
                <asp:Parameter Name="IS_DEMENTIA_SPECIALIST_APPROVED" Type="Boolean" />
                <asp:Parameter Name="CREATED_DATETIME" Type="DateTime" />
                <asp:Parameter Name="CREATED_BY" Type="String" />
                <asp:Parameter Name="LAST_MODIFIED_DATETIME" Type="DateTime" />
                <asp:Parameter Name="LAST_MODIFIED_BY" Type="String" />
                <asp:Parameter Name="IS_ACTIVE" Type="Boolean" />
                <asp:Parameter Name="IS_DATA_COLLECTION_AVAILABLE" Type="Boolean" />
                <asp:Parameter Name="ORIGINAL_IRB_APPROVAL_DATE" Type="DateTime" />
                <asp:Parameter Name="IRB_EXPIRATION_DATE" Type="DateTime" />
                <asp:Parameter Name="SITE_ACTIVATION_DATE" Type="DateTime" />
                <asp:Parameter Name="SITE_WITHDRAWAL_DATE" Type="DateTime" />
                <asp:Parameter Name="IS_TERMINATED" Type="Boolean" />
                <asp:Parameter Name="REASON_OF_TERMINATION" Type="String" />
                <asp:Parameter Name="LATITUDE" Type="Decimal" />
                <asp:Parameter Name="LONGITUDE" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="STREET" Type="String" />
                <asp:Parameter Name="STREET2" Type="String" />
                <asp:Parameter Name="CITY" Type="String" />
                <asp:Parameter Name="STATE_ID" Type="String" />
                <asp:Parameter Name="ZIP" Type="String" />
                <asp:Parameter Name="PHONE" Type="String" />
                <asp:Parameter Name="FAX" Type="String" />
                <asp:Parameter Name="EMAIL" Type="String" />
                <asp:Parameter Name="STATUS" Type="Int32" />
                <asp:Parameter Name="REGISTRATION_DATE" Type="DateTime" />
                <asp:Parameter Name="LAST_UPDATE_DATE" Type="DateTime" />
                <asp:Parameter Name="PRACTICE_TYPE" Type="Int32" />
                <asp:Parameter Name="PHONE_EXT" Type="String" />
                <asp:Parameter Name="LAST_UPDATE_USER_ID" Type="Int32" />
                <asp:Parameter Name="IRB_APPROVAL_TYPE" Type="Int32" />
                <asp:Parameter Name="IS_PARTICIPATING_SITE_APPROVAL_EXECUTED" Type="Boolean" />
                <asp:Parameter Name="IS_IRB_APPROVED" Type="Boolean" />
                <asp:Parameter Name="IS_FACILITY_APPROVED" Type="Boolean" />
                <asp:Parameter Name="IS_DEMENTIA_SPECIALIST_APPROVED" Type="Boolean" />
                <asp:Parameter Name="CREATED_DATETIME" Type="DateTime" />
                <asp:Parameter Name="CREATED_BY" Type="String" />
                <asp:Parameter Name="LAST_MODIFIED_DATETIME" Type="DateTime" />
                <asp:Parameter Name="LAST_MODIFIED_BY" Type="String" />
                <asp:Parameter Name="IS_ACTIVE" Type="Boolean" />
                <asp:Parameter Name="IS_DATA_COLLECTION_AVAILABLE" Type="Boolean" />
                <asp:Parameter Name="ORIGINAL_IRB_APPROVAL_DATE" Type="DateTime" />
                <asp:Parameter Name="IRB_EXPIRATION_DATE" Type="DateTime" />
                <asp:Parameter Name="SITE_ACTIVATION_DATE" Type="DateTime" />
                <asp:Parameter Name="SITE_WITHDRAWAL_DATE" Type="DateTime" />
                <asp:Parameter Name="IS_TERMINATED" Type="Boolean" />
                <asp:Parameter Name="REASON_OF_TERMINATION" Type="String" />
                <asp:Parameter Name="LATITUDE" Type="Decimal" />
                <asp:Parameter Name="LONGITUDE" Type="Decimal" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
