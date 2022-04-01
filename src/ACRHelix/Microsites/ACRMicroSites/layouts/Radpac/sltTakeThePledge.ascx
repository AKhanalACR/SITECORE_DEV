<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltTakeThePledge.ascx.cs" Inherits="ACR.layouts.Radpac.sltTakeThePledge" %><div id="pledge">
        <asp:hyperlink runat="server" id="hlTake" title="Take the Pledge" navigateurl="/Pledge.aspx" cssclass="redbutton">
            <img src="/images/Radpac/button_left.jpg" alt="button_left" class="redbutton_img" />
            <span>Take the pledge</span></asp:hyperlink>
        <p class="space"></p>
        <asp:literal runat="server" id="ltlPledgeText"></asp:literal><p class="space"></p>
        <p class="space"></p>
        <div class="pledge2date">
          <h1><asp:literal runat="server" id="ltlPledgeCount"></asp:literal></h1>
          <h2>PLEDGES TO DATE</h2>
        </div>
        <img src="/images/Radpac/pledge.jpg" align="pledge" class="pledgeimg" />
 </div>