using System;
using System.Configuration;
using ACR.Library;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Radpac.Data;
using ACR.Library.Radpac.Interfaces;
using ACR.Library.Reference;
using Common.Logging;
using System.Net.Mail;
using Velir.Net.Mail;
using System.Text;

namespace ACR.layouts.Radpac
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
            //if ((ItemReference.IW_Global_PledgeFormType_Association != null &&
            //    _pledgeTypeItem.ID.ToString() == ItemReference.IW_Global_PledgeFormType_Association.Guid)
            //    || (ItemReference.IW_Global_PledgeFormType_Facility != null &&
            //    _pledgeTypeItem.ID.ToString() == ItemReference.IW_Global_PledgeFormType_Facility.Guid))
            //{
            //    //Show group pledge form
            //    _pledgeFormControl = (IPledgeFormControl)LoadControl("~/controls/Radpac/GroupPledgeForm.ascx");
            //}
            //else
           // {
              //  _pledgeFormControl = (IPledgeFormControl)LoadControl("~/controls/Radpac/IndividualPledgeForm.ascx");
           // }
           // phFormControl.Controls.Add((System.Web.UI.Control)_pledgeFormControl);

            //reset Recaptcha keys
           // recaptcha.PrivateKey = ConfigurationManager.AppSettings["RecaptchaPrivateKey"];
           // recaptcha.PublicKey = ConfigurationManager.AppSettings["RecaptchaPublicKey"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //private bool SendEmailToUser1(string emailAddr, string Name, string Desc)
        //{
        //    if (emailAddr == "") return true;
        //    try
        //    {
        //        EmailSender emailSender = new EmailSender();
        //        MailMessage message = new MailMessage
        //        {
        //            From = new MailAddress(_formItem.ConfirmationEmailFrom.Raw),
        //            Subject = Desc,
        //            IsBodyHtml = true,
        //            Body = _formItem.ConfirmationEmailBody.Text
        //        };

        //        //send the email!
        //        message.To.Clear();
        //        message.To.Add(emailAddr);
        //        if (!emailSender.SendEmail(message))
        //        {
        //            Logger.Error("[Error] Pledge Form: Failed to send Pledge Form to " + emailAddr);
        //            return false;
        //        }
        //        return true;
        //    }
        //}
        private bool SendEmailToUser(string addressTo, string Name, string Desc)
        {
            //build the message
            StringBuilder messageBody = new StringBuilder();

           
            messageBody.Append("<br/> From: " + Name + "<br/>");
            messageBody.Append("Description: " + Desc + "<br/>");
            messageBody.Append("Email Address: " + addressTo + "<br/><br/>");

            EmailSender emailSender = new EmailSender();
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_formItem.ConfirmationEmailFrom.Raw),
                Subject = _formItem.ConfirmationEmailSubject.Text,
                IsBodyHtml = true,
                Body = messageBody.ToString()
            };

            //send the email!
            message.To.Clear();
            message.To.Add(addressTo);
            if (!emailSender.SendEmail(message))
            {
                Logger.Error("[Error] Ask a Question: Failed to send Pledge Form to " + addressTo);
                return false;
            }
            return true;
        }
        protected void Pledge_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(AcrGlobals.EmailRegex))
                regEmail.ValidationExpression = AcrGlobals.EmailRegex;

            if (!Page.IsValid)
            {                
                return;
            }

            if (SendEmailToUser(txtEmail.Text.Trim (), txtName.Text, txtDesc.Text))
            {
                ltlSuccessOrFailureMessage.Text = "Message sent successfully";
            }
            else
            {
                ltlSuccessOrFailureMessage.Text = "Could not send the Message";
            }

            pnlMessage.Visible = true;
            pnlForm.Visible = false;
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

   

    }
}