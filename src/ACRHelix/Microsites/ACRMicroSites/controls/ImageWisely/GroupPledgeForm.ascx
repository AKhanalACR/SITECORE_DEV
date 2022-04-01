<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.controls.ImageWisely.GroupPledgeForm" CodeBehind="GroupPledgeForm.ascx.cs" %>

<div class="full_grid">
	<p><asp:Literal ID="ltlGroupName1" runat="server" /> Name<sup>*</sup>:</p>
	<asp:TextBox ID="txtInstitutionName" CssClass="inputtext2" runat="server"  MaxLength="200"/>
	<asp:RequiredFieldValidator ID="rfvInstitutionName" ControlToValidate="txtInstitutionName" CssClass="req" ErrorMessage="Please enter a name." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
</div>
<div class="clearboth">&nbsp;</div>
<div class="full_grid">
	<p>City<sup>*</sup>:</p>
	<asp:TextBox ID="txtCity" CssClass="inputtext2" runat="server"  MaxLength="200"/>
	<asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" CssClass="req" ErrorMessage="Please enter a city." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
</div>
<div class="clearboth">&nbsp;</div>
<div class="grid">
	<p>Country:</p>
	<asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
</div>
<div id="divStateProvince" class="grid form_padding">
	<asp:UpdatePanel ID="upStateProvince" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<asp:PlaceHolder ID="phStateProvince" runat="server">
				<p><asp:Literal ID="litStateProvince" Text="State" runat="server" /><sup>*</sup>:</p>
				<asp:DropDownList ID="ddlStateProvince" runat="server" />
			</asp:PlaceHolder>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged" />
		</Triggers>
	</asp:UpdatePanel>
</div>
<div class="clearboth">&nbsp;</div>
<div class="full_grid">
	<p>Individual taking pledge on behalf of the <asp:Literal ID="ltlGroupName2" runat="server" />:</p>
</div>
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
<div class="full_grid">
	<p>Title:</p>
	<asp:TextBox ID="txtTitle" CssClass="inputtext2" runat="server"  MaxLength="200"/>
</div>
<div class="clearboth">&nbsp;</div>
<div class="grid">
	<p>Email address to send pledge confirmation<sup>*</sup>:</p>
	<asp:TextBox ID="txtEmail" CssClass="inputtext2" runat="server"  MaxLength="255"/>
	<asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="&nbsp;Please enter your email address." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
	<asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="Invalid email address. Please try again." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  Runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
	<asp:Literal ID="ltlDuplicateEmail" runat="server" />
</div>
<div class="grid form_padding">
	<p>Confirm Email address<sup>*</sup>:</p>
	<asp:TextBox ID="txtEmailValidation" CssClass="inputtext2" runat="server" MaxLength="255" />
	<asp:RequiredFieldValidator ID="rfvEmailValidation" ControlToValidate="txtEmailValidation" CssClass="req" ErrorMessage="&nbsp;Please enter your email address." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm" />
	<asp:CompareValidator ID="compareValidatorEmail" ControlToValidate="txtEmailValidation" ControlToCompare="txtEmail" Operator="Equal"   CssClass="req" ErrorMessage="Email addresses do not match. Please try again." Type="String" runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm" />
</div>
<div class="full_grid">
	<p><asp:CheckBox ID="cbHonorRoll" runat="server"/> Display my <asp:Literal ID="ltlGroupName3" runat="server"/> on the honor roll</p>
</div>