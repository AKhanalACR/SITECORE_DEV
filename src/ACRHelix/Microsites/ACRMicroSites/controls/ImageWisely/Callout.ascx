<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Callout.ascx.cs" Inherits="ACR.controls.ImageWisely.Callout" %>

<div class="callout cf">
    <div class="callout-text">
        <asp:Literal ID="CalloutText" runat="server" />
    </div>
  	<div class="button-div">
	    <a id="callout_button" class="redbutton" title="Let Us Know" href="mailto:imagewisely@acr.org">
            <img src="/images/ImageWisely/button_left.png" alt="button_left" class="redbutton_img">
            <span><asp:Literal runat="server" ID="CalloutButton"></asp:Literal></span>
        </a>
    </div>
</div>