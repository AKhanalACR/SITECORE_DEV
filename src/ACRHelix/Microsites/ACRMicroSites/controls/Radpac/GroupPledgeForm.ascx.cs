using System;
using System.Text;
using ACR.Library;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Radpac.Data;
using ACR.Library.Radpac.Interfaces;
using Common.Logging;
using System.Net.Mail;
using Velir.Net.Mail;
using Common.Logging;

namespace ACR.controls.Radpac
{
	public partial class GroupPledgeForm : System.Web.UI.UserControl, IPledgeFormControl
	{
		private static ILog _logger;
		private static ILog Logger
		{
			get
			{
				if (_logger == null)
				{
					_logger = LogManager.GetLogger(typeof(IndividualPledgeForm));
				}
				return _logger;
			}
		}

		private string _groupName = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Sitecore.Context.Item.TemplateID.ToString() != PledgeFormItem.TemplateId)
				return;

			PledgeFormItem formItem = Sitecore.Context.Item;
			if (formItem.PledgeFormType.Item == null)
					return;
			PledgeTypeItem pledgeTypeItem = formItem.PledgeFormType.Item;
			_groupName = pledgeTypeItem.PledgeTypeName.Text;

			if (IsPostBack)
				return;

			ltlGroupName1.Text = _groupName;
			ltlGroupName2.Text = _groupName;

			ddlCountry.DataSource = formItem.PledgeCountries;
			ddlCountry.DataBind();
			ddlCountry.SelectedValue = "United States";

			if (!String.IsNullOrEmpty(AcrGlobals.EmailRegex))
				regEmail.ValidationExpression = AcrGlobals.EmailRegex;
			
		}

		public bool GetPledgeObject(out Pledge pledge, PledgeTypeItem pledgeTypeItem)
		{
			ltlDuplicateEmail.Text = "";
			pledge = new Pledge(pledgeTypeItem);

			if (!Page.IsValid)
			{
				return false;
			}

			if (pledge.CheckDuplicates(txtEmail.Text.Trim()))
			{
				ltlDuplicateEmail.Text = "<span class=\"req\">This email address has already been used to make the pledge.</span>";
				return false;
			}

			//Get form values 
			pledge.Institution = txtInstitutionName.Text.Trim();
			pledge.City = txtCity.Text.Trim();
			pledge.StateProvince = txtState.Text.Trim();
			pledge.Country = ddlCountry.SelectedItem.Value;

			pledge.FirstName = txtFirstName.Text.Trim();
			pledge.LastName = txtLastName.Text.Trim();
			pledge.ProfessionalTitle = txtTitle.Text.Trim();
			pledge.EmailAddress = (txtEmail.Text.Trim() != "") ? txtEmail.Text.Trim() : "(not supplied)";

			return true;
		}

		public bool SendEmail(string addressTo, Pledge pledge)
		{
			//build the message
			StringBuilder messageBody = new StringBuilder();

			string subject = AcrGlobals.PledgeFormDefaultSubject;

			messageBody.Append("<br/>" + _groupName + ": " + pledge.Institution + "<br/><br/>");
			messageBody.Append("City: " + pledge.City + "<br/><br/>");
			messageBody.Append("State: " + pledge.StateProvince + "<br/><br/>");
			messageBody.Append("Country: " + pledge.Country + "<br/><br/>");
			messageBody.Append("<br/>Individual taking pledge on behalf of the " + _groupName + "<br/><br/>");
			messageBody.Append("First Name: " + pledge.FirstName + "<br/><br/>");
			messageBody.Append("Last Name: " + pledge.LastName + "<br/><br/>");
			messageBody.Append("Title: " + pledge.ProfessionalTitle + "<br/><br/>");
			messageBody.Append("Email Address: " + pledge.EmailAddress + "<br/><br/>");
			
			EmailSender emailSender = new EmailSender();
			MailMessage message = new MailMessage
			{
				From = new MailAddress(pledge.EmailAddress),
				Subject = subject,
				IsBodyHtml = true,
				Body = messageBody.ToString()
			};

			//send the email!
			message.To.Clear();
			message.To.Add(addressTo);
			if (!emailSender.SendEmail(message))
			{
				Logger.Error("[Error] Pledge Form: Failed to send Pledge Form to " + addressTo);
				return false;
			}
			return true;
		}
	}
}