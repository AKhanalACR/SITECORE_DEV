using System;
using System.Collections.Generic;
using System.Text;
using ACR.Library;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.ImageWisely.Data;
using ACR.Library.ImageWisely.Interfaces;
using System.Net.Mail;
using Velir.Net.Mail;
using Common.Logging;

namespace ACR.controls.ImageWisely
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
					_logger = LogManager.GetLogger(typeof (IndividualPledgeForm));
				}
				return _logger;
			}
		}

		private string _groupName = "";

		private IDictionary<KeyValuePair<string, string>, string> _stateData = new Dictionary<KeyValuePair<string, string>, string>();
		private IDictionary<KeyValuePair<string, string>, string> _provinceData = new Dictionary<KeyValuePair<string, string>, string>();
		private IDictionary<KeyValuePair<string, string>, string> _internationalData = new Dictionary<KeyValuePair<string, string>, string>();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Sitecore.Context.Item.TemplateID.ToString() != PledgeFormItem.TemplateId)
				return;

			PledgeFormItem formItem = Sitecore.Context.Item;
			if (formItem.PledgeFormType.Item == null)
				return;
			PledgeTypeItem pledgeTypeItem = formItem.PledgeFormType.Item;
			_groupName = pledgeTypeItem.PledgeTypeName.Text;

			_stateData = formItem.PledgeStates;
			_provinceData = formItem.PledgeProvinces;
			_internationalData = formItem.PledgeInternational;
			
			if (IsPostBack)
				return;

			ltlGroupName1.Text = _groupName;
			ltlGroupName2.Text = _groupName;
			ltlGroupName3.Text = _groupName;
			cbHonorRoll.Checked = true;

			ddlCountry.DataSource = formItem.PledgeCountries;
			ddlCountry.DataBind();
			ddlCountry.SelectedValue = "United States";
			
			BuildStateProvinceDropDown();

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

			//if (pledge.CheckDuplicates(txtEmail.Text.Trim()))
			//{
			//ltlDuplicateEmail.Text = "<span class=\"req\">This email address has already been used to make the pledge.</span>";
			//return false;
			//}

			//Get form values 
			pledge.Institution = txtInstitutionName.Text.Trim();
			pledge.City = txtCity.Text.Trim();
			pledge.StateProvince = ddlStateProvince.SelectedItem.Value;
			pledge.Country = ddlCountry.SelectedItem.Value;

			pledge.FirstName = txtFirstName.Text.Trim();
			pledge.LastName = txtLastName.Text.Trim();
			pledge.ProfessionalTitle = txtTitle.Text.Trim();
			pledge.EmailAddress = (txtEmail.Text.Trim() != "") ? txtEmail.Text.Trim() : "(not supplied)";
			byte displayOnHonorRoll = 0;
			try
			{
				displayOnHonorRoll = Convert.ToByte(cbHonorRoll.Checked);
			}
			catch (Exception ex)
			{
				Logger.Error("[Error] Group Pledge Form: " + ex.Message + "\n\n" + ex.StackTrace);
			}

			pledge.DisplayOnHonorRoll = displayOnHonorRoll;
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
			messageBody.Append("Display on Honor Roll: " + ((pledge.DisplayOnHonorRoll == 1) ? "yes" : "no") + "<br/><br/>");

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

		private void BuildStateProvinceDropDown()
		{
			IDictionary<KeyValuePair<string, string>, string> _stateProvinceData = new Dictionary<KeyValuePair<string, string>, string>();

			if (ddlCountry.SelectedValue.ToLower() == "united states")
			{
				_stateProvinceData = _stateData;
				litStateProvince.Text = "State";
			}
			else if (ddlCountry.SelectedValue.ToLower() == "canada")
			{
				_stateProvinceData = _provinceData;
				litStateProvince.Text = "Province";
			}
			else
			{
				_stateProvinceData = _internationalData;
			}

			ddlStateProvince.Items.Clear();

			foreach(KeyValuePair<KeyValuePair<string, string>, string> dataItem in _stateProvinceData)
			{
				System.Web.UI.WebControls.ListItem listItem = new System.Web.UI.WebControls.ListItem();
				KeyValuePair<string, string> stateInfo = dataItem.Key;
				listItem.Value = stateInfo.Key;
				listItem.Text = stateInfo.Value;
				listItem.Attributes["class"] = dataItem.Value;

				ddlStateProvince.Items.Add(listItem);
			}

			ddlStateProvince.SelectedIndex = 0;
			phStateProvince.Visible = _stateProvinceData != _internationalData;
		}

		protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
			BuildStateProvinceDropDown();
		}
	}
}