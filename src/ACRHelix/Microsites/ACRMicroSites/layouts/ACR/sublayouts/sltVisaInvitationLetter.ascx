<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltVisaInvitationLetter.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.sltVisaInvitationLetter" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<style> 
    table{
        margin-top:10px;
    } 
    table td{
        padding:10px;
        font-size:inherit;
    }    
    table input[type="text"] {
        width:320px;
        padding: 6px 12px;
        border-radius: 4px;
        border: solid 1px #7F7F7F;
        
    }
    table select{
        width: 320px; 
        height:30px;
        padding: 6px 12px;
        border-radius: 4px;
        border: solid 1px #7F7F7F;
    } 
    table input[type="submit"]{
        background-color:#D18216;
        color:white;
        font-weight:bold;
        font-size:inherit;
        padding:6px 12px;
        border:none;
        border-radius: 4px;
        
    }
    table span{
        color:#AC2610;
    }
    table label{
        color:#AC2610;
    }
    .btn-algn-rgt{
        text-align:right;
    }
    p{
        font-size:inherit;
    }
    .marg{
        margin:30px 150px;
    }

    
</style>

<div class="text">
    <div class="intro-section">
        <asp:Panel ID="FormPanel" runat="server">
            <asp:Literal ID="LtlInstruction" runat="server"></asp:Literal>
            <table>
                <tr>
                    <td>Name<span>*</span></td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <label id="lblName">Required.</label>
                    </td>
                </tr>
                <tr>
                    <td>Email<span>*</span></td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <label id="lblEmail">Required.</label>
                    </td>
                </tr>
                <tr>
                    <td>Address</td>
                    <td></td>
                </tr>
                <tr>
                    <td>Address Line 1<span>*</span></td>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                        <label id="lblAddress1">Required.</label>
                    </td>
                    
                </tr>
                <tr>
                    <td>Address Line 2</td>
                    <td><asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>City<span>*</span></td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        <label id="lblCity">Required.</label>
                    </td>
                </tr>
                <tr>
                    <td>State/Province<span>*</span></td>
                    <td>
                        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                        <label id="lblState">Required.</label>
                    </td>
                </tr>
                <tr>
                    <td>Country<span>*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server"> </asp:DropDownList>
                        <label id="lblCountry">Required.</label>
                    </td>
                </tr>
                <tr>
                    <td>ZIP/Postal Code<span>*</span></td>
                    <td>
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                        <label id="lblZip">Required.</label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    
                    <td class="btn-algn-rgt"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                </tr>
                
            </table>
        </asp:Panel>
        
        <asp:Panel ID="ConfirmationPanel" runat="server">
            <p>
                <asp:Literal ID="LtlConfirmation" runat="server"></asp:Literal> 
                <asp:LinkButton ID="btnPdf" runat="server" OnClick="btnPdf_Click">Download PDF</asp:LinkButton>                
            </p>
        </asp:Panel>
    </div>

</div>

<script>
    $j(function () {
        $j("#lblName").css("display", "none");
        $j("#lblEmail").css("display", "none");
        $j("#lblAddress1").css("display", "none");
        $j("#lblCity").css("display", "none");
        $j("#lblState").css("display", "none");
        $j("#lblCountry").css("display", "none");
        $j("#lblZip").css("display", "none");
    });

    $j("#content_0_middlecolumn_0_btnSubmit").on("click", function () {
        var validation = true;
        if ($j("#content_0_middlecolumn_0_txtName").val() == "") {
            $j("#lblName").css("display", "inline-block");
            validation = false;
        }

        if ($j("#content_0_middlecolumn_0_txtEmail").val() == "") {
            $j("#lblEmail").css("display", "inline-block");
            validation = false;
        } else if(validateEmail($j("#content_0_middlecolumn_0_txtEmail").val()) == false){
            $j("#lblEmail").text("Invalid Email Address").css("display", "inline-block");
            validation = false;
        }

        if ($j("#content_0_middlecolumn_0_txtAddress1").val() == "") {
            $j("#lblAddress1").css("display", "inline-block");
            validation = false;
        }

        if ($j("#content_0_middlecolumn_0_txtCity").val() == "") {
            $j("#lblCity").css("display", "inline-block");
            validation = false;
        }

        if ($j("#content_0_middlecolumn_0_txtState").val() == "") {
            $j("#lblState").css("display", "inline-block");
            validation = false;
        }

        if ($j("#content_0_middlecolumn_0_ddlCountry").val() == "- Select -") {
            $j("#lblCountry").css("display", "inline-block");
            validation = false;
        }

        if ($j("#content_0_middlecolumn_0_txtZip").val() == "") {
            $j("#lblZip").css("display", "inline-block");
            validation = false;
        }
        return validation;
    });

    $j("#content_0_middlecolumn_0_txtName").on("input", function () {
        $j("#lblName").css("display", "none");
    });

    $j("#content_0_middlecolumn_0_txtEmail").on("input", function () {
        $j("#lblEmail").text("Required.").css("display", "none");
    });

    $j("#content_0_middlecolumn_0_txtAddress1").on("input", function () {
        $j("#lblAddress1").css("display", "none");
    });

    $j("#content_0_middlecolumn_0_txtCity").on("input", function () {
        $j("#lblCity").css("display", "none");
    });

    $j("#content_0_middlecolumn_0_txtState").on("input", function () {
        $j("#lblState").css("display", "none");
    });

    $j("#content_0_middlecolumn_0_ddlCountry").on("change", function () {
        $j("#lblCountry").css("display", "none");
    });

    $j("#content_0_middlecolumn_0_txtZip").on("input", function () {
        $j("#lblZip").css("display", "none");
    });

    function validateEmail(sEmail) {
        var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        if (filter.test(sEmail)) {
            return true;
        }
        else {
            return false;
        }
    }

</script>

