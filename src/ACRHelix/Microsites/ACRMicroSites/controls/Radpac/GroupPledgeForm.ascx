<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.controls.Radpac.GroupPledgeForm" Codebehind="GroupPledgeForm.ascx.cs" %>
		
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
      <p>State/Province<sup>*</sup>:</p>
      <asp:TextBox ID="txtState" CssClass="inputtext2" runat="server"  MaxLength="255"/>
			<asp:RequiredFieldValidator ID="rfvState" ControlToValidate="txtState" CssClass="req" ErrorMessage="Please enter a state or province." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>      
    </div>
    <div class="grid form_padding">
      <p>Country:</p>
      <asp:DropDownList ID="ddlCountry" runat="server" />
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
    <div class="full_grid">
       <p>Email address to send pledge confirmation<sup>*</sup>:</p>
      <asp:TextBox ID="txtEmail" CssClass="inputtext2" runat="server"  MaxLength="255"/>
      <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="&nbsp;Please enter your email address." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
			<asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="Invalid email address. Please try again." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  Runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
			<asp:Literal ID="ltlDuplicateEmail" runat="server" />
    </div>