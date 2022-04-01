<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltPledgeForm.ascx.cs" Inherits="ACR.layouts.ImageWisely.sltPledgeForm" %>
<%--<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>--%>

<div class="borderdiv">&nbsp;</div>
<asp:Panel ID="pnlForm" CssClass="formdiv" runat="server" DefaultButton="btnPledge">
    <asp:PlaceHolder ID="phFormControl" runat="server"/>
    <div class="full_grid">
        <%--<div class="recaptcha">
            <asp:Literal ID="ltlRecaptchaMsg" runat="server"/>
						<recaptcha:RecaptchaControl ID="recaptcha" Theme="clean" runat="server" PrivateKey="setincodebehind" PublicKey="setincodebehind"/>
        </div>--%>       
        <div id="more" class="pledge-now" style="margin-top:10px; padding-left:0;">
            <asp:LinkButton ID="lbPledge" OnClick="Pledge_Click" ValidationGroup="PledgeForm" CssClass="redbutton1" text="<div><span>Pledge Now</span></div>" runat="server" />
            <asp:Button style="display:none" ID="btnPledge" OnClick="Pledge_Click" ValidationGroup="PledgeForm" runat="server" />
        </div>
    </div>
</asp:Panel>

<asp:Panel runat="server" ID="pnlMessage" Visible="false">
		<p><asp:Literal ID="ltlSuccessOrFailureMessage" runat="server" /></p>
</asp:Panel>
<div class="clearboth">&nbsp;</div>
<p>&nbsp;</p>

<asp:Literal ID="lltTextBelowForm" runat="server" />