using System;
using System.Text;
using ACR.Library;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.ImageWisely.Data;
using ACR.Library.ImageWisely.Interfaces;
using ACR.Library.Reference;
using System.Net.Mail;
using Velir.Net.Mail;
using Common.Logging;

namespace ACR.controls.ImageWisely
{
	public partial class IndividualPledgeForm : System.Web.UI.UserControl, IPledgeFormControl
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

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Sitecore.Context.Item.TemplateID.ToString() != PledgeFormItem.TemplateId)
				return;

			PledgeFormItem formItem = Sitecore.Context.Item;
			if (formItem.PledgeFormType.Item == null)
				return;

			PledgeTypeItem pledgeTypeItem = formItem.PledgeFormType.Item;

			if (!IsPostBack)
			{
				if ((ItemReference.IW_Global_PledgeFormType_ReferringProvider != null &&
					pledgeTypeItem.ID.ToString() == ItemReference.IW_Global_PledgeFormType_ReferringProvider.Guid))
				{
					ddlProfession.DataSource = formItem.ReferringPractitionerProfessionsAndRoles;					
				}
				else
				{
					ddlProfession.DataSource = formItem.ProfessionsAndRoles;
				}
				
				ddlProfession.DataBind();

				ddlCountry.DataSource = formItem.PledgeCountries;
				ddlCountry.DataBind();
				ddlCountry.SelectedValue = "United States";

				ddlPracticeType.DataSource = formItem.PrimaryPracticeTypes;
				ddlPracticeType.DataBind();

				ddlCampaign.DataSource = formItem.ImageWiselyCampaign;
				ddlCampaign.DataBind();

				if (!String.IsNullOrEmpty(AcrGlobals.EmailRegex))
					regEmail.ValidationExpression = AcrGlobals.EmailRegex;
			}
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
				//TODO : Store the below text in a field or dictionary item in sitecore.
				ltlDuplicateEmail.Text = "<span class=\"req\">This email address has already been used to make the pledge.  Therefore, you are not eligible to re-pledge until Jan. 1, " + (DateTime.Today.Year + 1) + ".</span>";
				return false;
			}

			
			//Get form values 
			pledge.FirstName = txtFirstName.Text.Trim();
			pledge.LastName = txtLastName.Text.Trim();
			pledge.EmailAddress = (txtEmail.Text.Trim() != "") ? txtEmail.Text.Trim() : "(not supplied)";
			pledge.Profession = pledge.CheckOther(ddlProfession.SelectedItem.Value, txtProfessionOther.Text.Trim());
			pledge.Institution = txtInstitution.Text.Trim();
			pledge.Country = ddlCountry.SelectedItem.Value;
			pledge.PracticeType = pledge.CheckOther(ddlPracticeType.SelectedItem.Value, txtPracticeTypeOther.Text.Trim());
			pledge.HowLearned = pledge.CheckOther(ddlCampaign.SelectedItem.Value, txtCampaignOther.Text.Trim());

			return true;
		}

		public bool SendEmail(string addressTo, Pledge pledge)
		{
			//build the message
			StringBuilder messageBody = new StringBuilder();

			string subject = AcrGlobals.PledgeFormDefaultSubject;

			messageBody.Append("<br/>First Name: " + pledge.FirstName + "<br/>");
			messageBody.Append("Last Name: " + pledge.LastName + "<br/>");
			messageBody.Append("Email Address: " + pledge.EmailAddress + "<br/><br/>");
			messageBody.Append("Profession/Role: " + pledge.Profession + "<br/><br/>");
			messageBody.Append("Primary Institution / Hospital: " + pledge.Institution + "<br/><br/>");
			messageBody.Append("Country: " + pledge.Country + "<br/><br/>");
			messageBody.Append("Practice Type: " + pledge.PracticeType + "<br/><br/>");
			messageBody.Append("How did you hear about the Image Wisely campaign?<br/>" + pledge.HowLearned + "<br/><br/>");
			messageBody.Append("Do you wish to be contacted with updates on radiation safety? " + ((pledge.ReceiveUpdates == 1) ? "yes" : "no") + "<br/><br/>");
			messageBody.Append("Are you willing to participate in a follow-up survey? " + ((pledge.Participate == 1) ? "yes" : "no") + "<br/><br/>");

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