using System;
using System.Configuration;
using ACR.Library;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.ImageWisely.Data;
using ACR.Library.ImageWisely.Interfaces;
using ACR.Library.Reference;
using Common.Logging;
using System.Net.Mail;
using Velir.Net.Mail;

namespace ACR.layouts.ImageWisely
{
	public partial class sltPledgeForm : System.Web.UI.UserControl
	{
		IPledgeFormControl _pledgeFormControl;
		private PledgeFormItem _formItem;
		private PledgeTypeItem _pledgeTypeItem;

		private static ILog _logger;
			private static ILog Logger
			{
				get
				{
					if (_logger == null)
					{
						_logger = LogManager.GetLogger(typeof(sltPledgeForm));
					}
					return _logger;
				}
			}

			protected void Page_Init(object sender, EventArgs e)
			{
				if (Sitecore.Context.Item.TemplateID.ToString() != PledgeFormItem.TemplateId)
					return;
				_formItem = Sitecore.Context.Item;
				if (_formItem.PledgeFormType.Item == null)
					return;
				_pledgeTypeItem = _formItem.PledgeFormType.Item;

				lltTextBelowForm.Text = _formItem.OptionalTextBelowForm.Rendered;

				//Dynamically loaded user controls must be loaded on every request, even postbacks
				if ((ItemReference.IW_Global_PledgeFormType_Association != null &&
					_pledgeTypeItem.ID.ToString() == ItemReference.IW_Global_PledgeFormType_Association.Guid)
					|| (ItemReference.IW_Global_PledgeFormType_Facility != null && 
					_pledgeTypeItem.ID.ToString() == ItemReference.IW_Global_PledgeFormType_Facility.Guid))
				{
					//Show group pledge form
					_pledgeFormControl = (IPledgeFormControl)LoadControl("~/controls/ImageWisely/GroupPledgeForm.ascx");
				}
				else
				{
					_pledgeFormControl = (IPledgeFormControl)LoadControl("~/controls/ImageWisely/IndividualPledgeForm.ascx");
				}
				phFormControl.Controls.Add((System.Web.UI.Control)_pledgeFormControl);

                //reset Recaptcha keys
                //recaptcha.PrivateKey = "6LelV80SAAAAAD_k15U16GXD4F0IYkEm5LuxHiei";// ConfigurationManager.AppSettings["RecaptchaPrivateKey"];
                //recaptcha.PublicKey = "6LelV80SAAAAALte7s5V8sQCS5idYbRVIf-ns0P_";// ConfigurationManager.AppSettings["RecaptchaPublicKey"];
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		
		}

		protected void Pledge_Click(object sender, EventArgs e)
		{
			//ltlRecaptchaMsg.Text = "";

			if (_formItem == null)
			{
				Logger.Error("[ERROR] Pledge: Form Item is null.\n\n");
				ltlSuccessOrFailureMessage.Text = AcrGlobals.PledgeFormFailureMessage;
				pnlMessage.Visible = true;
				pnlForm.Visible = false;
				return;
			}

			//if (!Page.IsValid)
			//{
			//	ltlRecaptchaMsg.Text = "<span class=\"req\">You have entered invalid text. Please type the two words below.</span>";
			//	return;
			//}

			lbPledge.Enabled = false;
			string failureMsg = (!String.IsNullOrEmpty(_formItem.SubmissionFailureMessage.Text))
													  ? _formItem.SubmissionFailureMessage.Text
													  : AcrGlobals.PledgeFormFailureMessage;

			string addressTo = "";
			try
			{
				addressTo = _formItem.SendFormDataTo.Raw.Trim();
			}
			catch (Exception ex)
			{
				Logger.Error("[Error] Pledge Form: " + ex.Message + "\n\n" + ex.StackTrace);
			}

			Pledge pledge;
			bool pledgeValid = _pledgeFormControl.GetPledgeObject(out pledge, _pledgeTypeItem);

			if (!pledgeValid)
			{
				lbPledge.Enabled = true;
				return;
			}

			//Send email to email address entered in Sitecore, then save to db
			bool emailSucceeded = _pledgeFormControl.SendEmail(addressTo, pledge);
			if(emailSucceeded)
				pledge.EmailedTo = addressTo;

			//Save to db
			bool succeeded = SaveToDb(emailSucceeded, addressTo, pledge);

			if (succeeded)
			{
				if(ItemReference.IW_Global_PledgeFormType_ImagingProfessional != null &&
							_pledgeTypeItem.ID.ToString() == ItemReference.IW_Global_PledgeFormType_ImagingProfessional.Guid)
				{
					IncrementImagingProfessionalsPledgeCounter();
				}

				//Send email to user
				if (SendEmailToUser(pledge.EmailAddress))
				{
					if (ItemReference.IW_Pledge_ThankYou.InnerItem != null)
						Response.Redirect(ItemReference.IW_Pledge_ThankYou.Url);
				}
			}
			else
			{
				ltlSuccessOrFailureMessage.Text = failureMsg;
			}

			pnlMessage.Visible = true;
			pnlForm.Visible = false;
		}

		/// <summary>
		/// Checks the type of pledge that is beeing submitted and  submits the Pledge to the appropriate database table
		/// </summary>
		/// <param name="emailSucceeded"></param>
		/// <param name="sentTo"></param>
		/// <param name="pledge"></param>
		/// <returns></returns>
		private  bool SaveToDb(bool emailSucceeded, string sentTo, Pledge pledge)
		{
			//Checks the type of pledge that is being submitted and 
			//submits the Pledge to the appropriate database table
			string typeId = pledge.PledgeType.ID.ToString();
			try
			{
				if (ItemReference.IW_Global_PledgeFormType_Association != null &&
					typeId == ItemReference.IW_Global_PledgeFormType_Association.Guid)
				{
					//Association table
					var pledgeSubmission = new AssociationPledgeSubmission(pledge, sentTo,
																											(emailSucceeded) ? null : "Submission not emailed.");
					pledgeSubmission.InsertAssociationPledgeSubmission();
				}
				else if (ItemReference.IW_Global_PledgeFormType_Facility != null &&
					typeId == ItemReference.IW_Global_PledgeFormType_Facility.Guid)
				{
					//Facility
					var pledgeSubmission = new FacilityPledgeSubmission(pledge, sentTo,
													(emailSucceeded) ? null : "Submission not emailed.");
					pledgeSubmission.InsertFacilityPledgeSubmission();
				}
				else if (ItemReference.IW_Global_PledgeFormType_ReferringProvider != null &&
					typeId == ItemReference.IW_Global_PledgeFormType_ReferringProvider.Guid)
				{
					//Referring Provider/Practitioner
					var pledgeSubmission = new ReferringPractitionerPledgeSubmission(pledge, sentTo,
																											(emailSucceeded) ? null : "Submission not emailed.");
					pledgeSubmission.InsertReferringPractitionerPledgeSubmission();
				}
				else
				{
					//Imaging Professional
					var pledgeSubmission = new PledgeSubmission(pledge, sentTo,
																											(emailSucceeded) ? null : "Submission not emailed.");
					pledgeSubmission.InsertImagingProfPledgeSubmission();
				}
			}
			catch (Exception ex)
			{
					Logger.Fatal("[FATAL] Pledge form submission not saved to database : " + ex.Message + "\n\n" + ex.StackTrace);

					if (!emailSucceeded)
							return false;
			}
			return true;
		}

		private bool SendEmailToUser(string emailAddr)
		{
			if (emailAddr == "") return true;
			try
			{
				EmailSender emailSender = new EmailSender();
				MailMessage message = new MailMessage
				{
					From = new MailAddress(_formItem.ConfirmationEmailFrom.Raw),
					Subject = _formItem.ConfirmationEmailSubject.Text,
					IsBodyHtml = true,
					Body = _formItem.ConfirmationEmailBody.Text
				};

				//send the email!
				message.To.Clear();
				message.To.Add(emailAddr);
				if (!emailSender.SendEmail(message))
				{
					Logger.Error("[Error] Pledge Form: Failed to send Pledge Form to " + emailAddr);
				}
			}
			catch (Exception ex)
			{
				Logger.Error("[Error] Failed to send Pledge Form.", ex);
			}
			return true;
		  
		}

		private void IncrementImagingProfessionalsPledgeCounter()
		{
      //The web service, com.imagewisely.PledgesService, increments the "Pledges Made" 
      //field on the home node in the authoring environment and then publishes it back out


      ACRMicroSites.com.imagewisely.PledgesService.PledgesService pledgesService = new ACRMicroSites.com.imagewisely.PledgesService.PledgesService();
			string sKey = AcrGlobals.WebServicesSecurityKey;
			if (sKey != "")
			{
				bool pledgesIncremented = pledgesService.IncrementPledgeCounter(sKey);
				if (!pledgesIncremented)
				{
					Logger.Error(
						@"[Error] Pledge Form: The field, ""Pledges Made,"" could not be incremented. 
																		Check that the PledgesService web service is accessible on the authoring server. ");
				}
			}
			else
			{
				Logger.Error(
					@"[Error] Pledge Form: The field, ""Pledges Made"", could not be incremented. Could not get the security key. ");
			}
		}

	}
}