<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.layouts.Radpac.sltPledgeForm" Codebehind="sltPledgeForm.ascx.cs" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %><div class="borderdiv">&nbsp;</div>
<asp:panel runat="server" id="pnlForm" cssclass="formdiv" defaultbutton="btnPledge">
    <asp:placeholder id="phFormControl" runat="server"></asp:placeholder>
    <div class="full_grid">
    <div class="grid">
      <p>Name:</p>
      <asp:TextBox ID="txtName" CssClass="inputtext2" runat="server" MaxLength="50"/>
	  <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtName" CssClass="req" ErrorMessage="Please enter your name." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>      
    </div>
    <div class="clearboth">&nbsp;</div>
    <div class="grid">
      <p>Description<sup>*</sup>:</p>
      <asp:TextBox ID="txtDesc" CssClass="inputtext2" runat="server" TextMode ="MultiLine"  Height="100px" Width="300px" />
	  <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtDesc" CssClass="req" ErrorMessage="Please enter the Description." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>      
    </div>
    <div class="clearboth">&nbsp;</div>
    <div class="grid">
      <p>Email address to send confirmation<sup>*</sup>:</p>
      <asp:TextBox ID="txtEmail" CssClass="inputtext2" runat="server"  MaxLength="255"/>
      <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="&nbsp;Please enter your email address." runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
	  <asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmail" CssClass="req" ErrorMessage="Invalid email address. Please try again." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  Runat="server" Display="Dynamic" ForeColor="#c41230" ValidationGroup="PledgeForm"/>
	  <asp:Literal ID="ltlDuplicateEmail" runat="server" />
    </div>   
        <div id="more" class="pledge-now">
            <asp:linkbutton id="lbPledge" onclick="Pledge_Click" validationgroup="PledgeForm" cssclass="redbutton1" text="&lt;div&gt;&lt;span&gt&lt;div&gt;&lt;span&gt;Submit&lt;/span&gt;&lt;/div&gt;" runat="server"></asp:linkbutton>
            <asp:button style="display:none" id="btnPledge" onclick="Pledge_Click" validationgroup="Submit" runat="server"></asp:button>
        </div>
    </div>
</asp:panel>

<asp:panel runat="server" id="pnlMessage" visible="false">
		<p><asp:literal id="ltlSuccessOrFailureMessage" runat="server"></asp:literal></p>
</asp:panel>
<div class="clearboth">&nbsp;</div>
<p>&nbsp;</p>

<asp:literal runat="server" id="lltTextBelowForm"></asp:literal>