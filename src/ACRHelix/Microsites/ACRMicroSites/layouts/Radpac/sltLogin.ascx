<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"  Inherits="ACR.layouts.Radpac.sltLogin" Codebehind="~/layouts/Radpac/sltLogin.ascx.cs" %>

<%--<section class="module personal">--%>
	<h4 class="header-forth icon-user"></h4>
	<panel id="loginPanel" runat="server">
	<p class="descr">Please login below to continue to your requested Page.</p>

	<asp:ValidationSummary runat="server" ID="vsLoginBox" EnableClientScript="True"  />
		
	<ul class="form-login">
		<asp:Label CssClass="label" ID="lblUser" runat="server" AssociatedControlID="txtUserName">Username</asp:Label>
        &nbsp;
		
			<asp:TextBox runat="server" ID="txtUserName" runat="server" />
			<asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUserName" 
				EnableClientScript="True" >*</asp:RequiredFieldValidator>
		</br>
		
			<asp:Label CssClass="label" ID="lblPass" runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
		&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtPassword" runat="server" TextMode="Password" AutoCompleteType="None" />
			<asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPassword" 
				EnableClientScript="True" >*</asp:RequiredFieldValidator>
		</br>
		<div style="width:200px;padding-left:120px; " >
			<asp:Button runat="server" ID="btnLogin" runat="server" 
				CssClass="login-btn link-attention" OnClick="btnLogin_Click" Text="Login"
				 CausesValidation="True" /></br>
                 </div>
			<div class="check-box">
				<asp:CheckBox runat="server" ID="chkRemember" Text="Remember Me" />               
			</div>
            
			<!-- / check-box -->
							
	</ul>	
	
	<div class="links">
		<asp:HyperLink runat="server" ID="lnkForgot" target="_blank" CssClass="link-external">Forgot Username/Password?</asp:HyperLink>
		<%--<asp:HyperLink runat="server" ID="lnkAccred" target="_blank" CssClass="link-more">Access ACR Accreditation <span class="arrow">programs</span></asp:HyperLink>--%>
	</div>
	<!-- / links -->
		</panel>							
<%--</section>--%>
<!-- / module -->
 <asp:Label ID="LoginResult" runat="server" Text=""  visible="false"/>							
<asp:HiddenField runat="server" ID="hdnUrlReferrer" />
