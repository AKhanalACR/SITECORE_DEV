<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.controls.Radpac.IndividualPledgeForm" Codebehind="IndividualPledgeForm.ascx.cs" %>

<div class="grid">
      <p>Name<sup></sup>:</p>
      <asp:TextBox ID="txtName" CssClass="inputtext2" runat="server" MaxLength="50"/>
	 <%-- <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtName" CssClass="req" ErrorMessage="Please enter your first name." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>      --%>
    </div>
    <div class="clearboth">&nbsp;</div>
    <div class="grid">
      <p>Description<sup>*</sup>:</p>
      <asp:TextBox ID="txtDesc" CssClass="inputtext2" runat="server" TextMode ="MultiLine"  Height="100px" Width="300px" />
	  <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtDesc" CssClass="req" ErrorMessage="Please enter Description." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>      
    </div>
    <div class="clearboth">&nbsp;</div>
   <div class="grid">
      <p>Email address to send pledge confirmation<sup>*</sup>:</p>
      <asp:TextBox ID="txtEmail" CssClass="inputtext2" runat="server"  MaxLength="255"/>
      <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="&nbsp;Please enter your email address." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
	  <asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="Invalid email address. Please try again." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  Runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
	  <asp:Literal ID="ltlDuplicateEmail" runat="server" />
    </div>
    <div class="clearboth">&nbsp;</div>
    <%--<div class="grid">
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
    <div class="grid form_padding">
      <p>If other, please provide:</p>
      <asp:TextBox ID="txtCampaignOther" CssClass="inputtext2" runat="server" MaxLength="255"/>
    </div>
    <div class="clearboth">&nbsp;</div>
    <div class="full_grid">
      <p>Do you wish to be contacted with updates on radiation safety?</p>
      <div class="clearboth">&nbsp;</div>
      <asp:RadioButtonList ID="rbUpdates" RepeatDirection="Horizontal"  runat="server">
        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
      </asp:RadioButtonList>
    </div>
    <div class="full_grid">
      <p>Are you willing to participate in a follow-up survey?</p>
      <div class="clearboth">&nbsp;</div>
      <asp:RadioButtonList ID="rbParticipate" RepeatDirection="Horizontal" runat="server">
        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
      </asp:RadioButtonList>
    </div>--%>