<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Annual Reminder.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Annual_Reminder" %>

        <script type="text/javascript">
                $(document).ready(function() {
                        $('.terms-of-use').hide();
                        $('.show-terms-of-use').click(function() {
                                $('.terms-of-use').toggle(300);
                                return false;
                        });
                });
                function ValidateTerms(source, arguments) {                                        
                        arguments.IsValid = document.getElementById('<%= chkTerms.ClientID %>').checked;  
                }
        </script>
<div class="reminder-section">
<h2>Sign Up</h2>
<p class="intro-text">
	<strong>Signing up for an annual reminder is easy.</strong> Simply provide your
	name, email, and zip code. We do not share your contact information with any party
	outside of the MSL coalition. Your information will not be used without your permission.</p>
<asp:PlaceHolder ID="ReminderForm" runat="server" Visible="true">
<div class="form-container">
	<div class="form-row">
		<asp:Label ID="lblName" runat="server" AssociatedControlID="txtName" Text="Name"
			CssClass="form-label required" />
		<asp:TextBox ID="txtName" name="txtName" runat="server" CssClass="field-text" ValidationGroup="Reminder" />
		<asp:RequiredFieldValidator runat="server" ID="reqName" CssClass="form-error" ControlToValidate="txtName"
			ValidationGroup="Reminder" ErrorMessage=" (Required)" />
	</div>
	<div class="form-row">
		<asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="Email"
			CssClass="form-label required" />
		<asp:TextBox ID="txtEmail" name="txtEmail" runat="server" CssClass="field-text" ValidationGroup="Reminder" />
		<asp:RequiredFieldValidator runat="server" ID="reqEmail" CssClass="form-error" ControlToValidate="txtEmail"
			ValidationGroup="Reminder" ErrorMessage=" (Required)" />
		<asp:RegularExpressionValidator runat="server" ID="regEmail" CssClass="form-error" ControlToValidate="txtEmail"
			ValidationGroup="Reminder" ErrorMessage="Please enter a valid Email Address"
			ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
	</div>
	<div class="form-row">
		<asp:Label ID="lblZipCode" runat="server" AssociatedControlID="txtZipCode" Text="Zip Code"
			CssClass="form-label required" />
		<asp:TextBox ID="txtZipCode" name="txtZipCode" runat="server" CssClass="field-text field-text-small"
			ValidationGroup="Reminder" />
		<asp:RequiredFieldValidator runat="server" ID="reqZipCode" ControlToValidate="txtZipCode"
			ValidationGroup="Reminder" CssClass="form-error" ErrorMessage="(Required)" />
		<asp:RegularExpressionValidator runat="server" ID="regZipCode" ControlToValidate="txtZipCode"
			ValidationGroup="Reminder" CssClass="form-error" ErrorMessage=" Please enter a valid Zip Code" ValidationExpression="\d{5}(-\d{4})?" />
	</div>
	<div class="form-row">
		<asp:Label ID="lblMonth" runat="server" AssociatedControlID="lstMonth" Text="Month"
			CssClass="form-label required" />
		<asp:DropDownList runat="server" ID="lstMonth" name="lstMonth"  CssClass="field-text field-text-small"
			ValidationGroup="Reminder">
		</asp:DropDownList>
		<asp:RequiredFieldValidator runat="server" ID="reqMonth" ControlToValidate="lstMonth"
			ValidationGroup="Reminder" ErrorMessage=" (Required)" />
	</div>
	<div class="form-row">
		<asp:Label ID="lblTerms" runat="server" AssociatedControlID="chkTerms" Text="Accept Terms"
			CssClass="form-label required" />
		<a class="show-terms-of-use" href="#">Terms of Use</a>
		<asp:CheckBox ID="chkTerms" runat="server" ValidationGroup="Reminder" Checked="False" />
		<asp:CustomValidator ID="termsCustomValidator" ClientValidationFunction="ValidateTerms"
			OnServerValidate="IsTermsChecked" ValidationGroup="Reminder" runat="server" CssClass="form-error" ErrorMessage=" (Required)"> (Required)</asp:CustomValidator>
		<div class="terms-of-use">
			<p>
				<strong>Mammogram Reminder Disclaimer and Terms of Use</strong></p>
			<p>
				The Mammography Saves Lives Coalition - including the American College of Radiology
				(ACR), Society of Breast Imaging, and American Society of Breast Disease, provide
				this web site to patients only as a general information resource on breast imaging.
				The MSL coalition cannot provide medical advice regarding screening, diagnosis or
				treatment of individual patients. Patients should seek the expert advice of a physician
				for advice regarding their individual health situations. The MSL coalition does
				not assume any liability or responsibility for any act or omission that a patient
				may make based on the information provided.</p>
			<p>
				This reminder is an attempt to help you remember to have a mammogram for the early
				detection of breast cancer. However, for a number of reasons, you may not receive
				a reminder. The sole responsibility to schedule and have a mammogram rests with
				you. All member organizations of the Mammography Saves Lives Coalition disclaim
				any duty to provide you with any reminder. The MSL coalition reserves the right
				to terminate this program at any time without notice. Moreover, the MSL Coalition
				may exclude from the program anyone who it believes may be abusing the program.
				The Coalition member organizations have no obligation to send you any reminder or
				to make sure you have made an appointment.</p>
			<p>
				The member organizations of the Mammography Saves Lives coalition do not share your
				contact information with any party outside of the MSL coalition. Your information
				will not be used without your permission. By accepting these terms of use, you also
				agree to receive periodic updates regarding breast cancer screening issues from
				the Mammography Saves Lives coalition.</p>
		</div>
	</div>
	<div class="form-buttons">
		<asp:LinkButton  runat="server" ID="btnCancel" CssClass="cancel-button" OnClientClick="form1.reset();$('.form-error').hide();return false;">cancel</asp:LinkButton>
		<asp:ImageButton runat="server" ID="btnSubmit" CssClass="submit-button" ValidationGroup="Reminder" ImageUrl="/images/MammographySavesLives/submit-button.png" OnClick="btnSubmit_Click" />
	</div>
 </div>
</div>
</asp:PlaceHolder>


