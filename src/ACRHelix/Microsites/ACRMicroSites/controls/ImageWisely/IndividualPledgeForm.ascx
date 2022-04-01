<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndividualPledgeForm.ascx.cs" Inherits="ACR.controls.ImageWisely.IndividualPledgeForm" %>

<div class="grid">
	<p>First Name<sup>*</sup>:</p>
	<asp:TextBox ID="txtFirstName" CssClass="inputtext2" runat="server" MaxLength="50"/>
	<asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" CssClass="req" ErrorMessage="Please enter your first name." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>      
</div>
<div class="grid form_padding">
	<p>Last Name<sup>*</sup>:</p>
	<asp:TextBox ID="txtLastName" CssClass="inputtext2" runat="server"  MaxLength="100"/>
	<asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtLastName" CssClass="req" ErrorMessage="Please enter your last name." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>      
</div>
<div class="clearboth">&nbsp;</div>
<div class="grid">
	<p>Email address to send pledge confirmation<sup>*</sup>:</p>
	<asp:TextBox ID="txtEmail" CssClass="inputtext2 key-up-validation pledgefield" runat="server" MaxLength="255" />
	<asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="&nbsp;Please enter your email address." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
	<asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="Invalid email address. Please try again." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  Runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
	<asp:Literal ID="ltlDuplicateEmail" runat="server" />
</div>
<div class="grid form_padding">
	<p>Confirm Email address<sup>*</sup>:</p>
	<asp:TextBox ID="txtEmailValidation" CssClass="inputtext2 key-up-validation pledgefield" runat="server" MaxLength="255" />
	<asp:RequiredFieldValidator ID="rfvEmailValidation" ControlToValidate="txtEmailValidation" CssClass="req" ErrorMessage="&nbsp;Please enter your email address." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm" />
	<asp:CompareValidator ID="compareValidatorEmail" ControlToValidate="txtEmailValidation" ControlToCompare="txtEmail" Operator="Equal" CssClass="req" ErrorMessage="Email addresses do not match. Please try again." Type="String" runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeFormOnKeyUp"/>
</div>
<div class="clearboth">&nbsp;</div>
<div class="grid">
	<p>Profession / Role<sup>*</sup>:</p>
	<asp:DropDownList ID="ddlProfession" runat="server"/>
</div>
<div class="grid form_padding">
	<p>If other, please provide:</p>
	<asp:TextBox ID="txtProfessionOther" CssClass="inputtext2" runat="server"  MaxLength="200"/>
</div>
<div class="clearboth">&nbsp;</div>
<div class="grid">
	<p>Primary Institution / Hospital<sup>*</sup>:</p>
	<asp:TextBox ID="txtInstitution" CssClass="inputtext2" runat="server"  MaxLength="255"/>
	<asp:RequiredFieldValidator ID="rfvInstitution" ControlToValidate="txtInstitution" CssClass="req" ErrorMessage="Please enter your primary institution or hospital." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>      
</div>
<div class="grid form_padding">
	<p>Country:</p>
	<asp:DropDownList ID="ddlCountry" runat="server" />
</div>
<div class="clearboth">&nbsp;</div>
<div class="grid">
	<p>Practice Type:</p>
	<asp:DropDownList ID="ddlPracticeType" runat="server"/>
</div>
<div class="grid form_padding">
	<p>If other, please provide:</p>
	<asp:TextBox ID="txtPracticeTypeOther" CssClass="inputtext2" runat="server"  MaxLength="100"/>
</div>
<div class="clearboth">&nbsp;</div>
<div class="grid">
	<p>How did you learn about the Image Wisely</p><p>campaign?:</p>
	<asp:DropDownList ID="ddlCampaign" runat="server"/>
</div>
<div class="grid form_padding" style="padding-top:34px;">
	<p>If other, please provide:</p>
	<asp:TextBox ID="txtCampaignOther" CssClass="inputtext2" runat="server" MaxLength="255"/>
</div>
