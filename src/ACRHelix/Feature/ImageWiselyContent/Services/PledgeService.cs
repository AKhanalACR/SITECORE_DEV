using ACR.Library;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.Data;
using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Feature.ImageWiselyContent.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
//using Velir.Net.Mail;

namespace ACRHelix.Feature.ImageWiselyContent.Services
{
  public class PledgeService
  {
    public void InitiallizeIndividualPledge(IndividualPledge pledge, string tf = "Referring Practitioners")
    {
      pledge.PracticeTypes = PledgeItems.PracticeTypes;

      pledge.ProfessionOrRoleList = PledgeItems.ProfessionsAndRoles;
      if (!(tf == "Referring Practitioners"))
        pledge.ProfessionOrRoleList = PledgeItems.Professions;

      //pledge.HowLearnAboutCampaignList = PledgeItems.ImageWiselyCampaign;
      pledge.Countries = PledgeItems.Countries;

    }

    public void InitiallizeGroupPledge(GroupPledge pledge)
    {
      pledge.Countries = PledgeItems.Countries;
      pledge.States = PledgeItems.States;
      pledge.Provinces = PledgeItems.Provinces;
    }

    public bool CheckDuplicates(string email, string id)
    {
      //check if duplicate pledge
      try
      {
        bool checkDupes = Convert.ToBoolean(Sitecore.Configuration.Settings.GetSetting("ImageWisely_CheckDuplicatePledges"));
        if (checkDupes)
        {
          return DataHelper.IsDuplicateSubmission(email, new PledgeTypeItem(Sitecore.Context.Database.GetItem(id)));
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool SaveImagingProfessionalsPledge(IndividualPledge pledge, string emailedTo)
    {
      try
      {
        var acrLibraryPledge = new ACR.Library.ImageWisely.Data.Pledge
        {
          FirstName = pledge.FirstName.Trim(),
          LastName = pledge.LastName.Trim(),
          EmailAddress = pledge.Email,
          Country = pledge.Country,
          Institution = pledge.InstitutionOrHospital.Trim(),
          PracticeType = GetOtherIfNeed(pledge.PracticeType, pledge.OtherPracticeType),
          Profession = GetOtherIfNeed(pledge.ProfessionOrRole, pledge.OtherProfesionOrRole),
          TimeSubmitted = DateTime.Now,
          //HowLearned = GetOtherIfNeed(pledge.HowLearnAboutCampaign, pledge.OtherHowLearnAboutCampaign),
          EmailedTo = emailedTo
        };

        var pledgeSubmission = new PledgeSubmission(acrLibraryPledge, emailedTo, null);
        pledgeSubmission.InsertImagingProfPledgeSubmission();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public bool SaveFacilitiesPledge(GroupPledge pledge, string emailedTo)
    {
      try
      {
        var acrLibraryPledge = new ACR.Library.ImageWisely.Data.Pledge
        {
          Institution = pledge.FacilityName.Trim(),
          City = pledge.City.Trim(),
          FirstName = pledge.FirstName.Trim(),
          LastName = pledge.LastName.Trim(),
          Profession = pledge.Title,
          EmailAddress = pledge.Email,
          DisplayOnHonorRoll = pledge.IsDisplayOnHonorRoll ? (byte)1 : (byte)0,
          TimeSubmitted = DateTime.Now,
          Country = pledge.Country,
          EmailedTo = emailedTo,
          //StateProvince = pledge.State == null ? (pledge.Province == null ? null : pledge.Province) : pledge.State
          StateProvince = pledge.Country != "United States" ? (pledge.Country != "Canada" ? null : pledge.Province) : pledge.State
        };

        var pledgeSubmission = new FacilityPledgeSubmission(acrLibraryPledge, emailedTo, null);
        pledgeSubmission.InsertFacilityPledgeSubmission();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }

    }

    public bool SaveReferringPractitionersPledge(IndividualPledge pledge, string emailedTo)
    {
      try
      {
        var acrLibraryPledge = new ACR.Library.ImageWisely.Data.Pledge
        {
          FirstName = pledge.FirstName.Trim(),
          LastName = pledge.LastName.Trim(),
          EmailAddress = pledge.Email,
          Country = pledge.Country,
          Institution = pledge.InstitutionOrHospital.Trim(),
          PracticeType = GetOtherIfNeed(pledge.PracticeType, pledge.OtherPracticeType),
          Profession = GetOtherIfNeed(pledge.ProfessionOrRole, pledge.OtherProfesionOrRole),
          TimeSubmitted = DateTime.Now,
          //HowLearned = GetOtherIfNeed(pledge.HowLearnAboutCampaign, pledge.OtherHowLearnAboutCampaign),
          EmailedTo = emailedTo
        };

        var pledgeSubmission = new ReferringPractitionerPledgeSubmission(acrLibraryPledge, emailedTo, null);
        pledgeSubmission.InsertReferringPractitionerPledgeSubmission();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public bool SaveAssosiationOrEducationalProgrammPledge(GroupPledge pledge, string emailedTo)
    {
      try
      {
        var acrLibraryPledge = new ACR.Library.ImageWisely.Data.Pledge
        {
          Institution = pledge.FacilityName.Trim(),
          City = pledge.City.Trim(),
          FirstName = pledge.FirstName.Trim(),
          LastName = pledge.LastName.Trim(),
          Profession = pledge.Title,
          EmailAddress = pledge.Email,
          DisplayOnHonorRoll = pledge.IsDisplayOnHonorRoll ? (byte)1 : (byte)0,
          TimeSubmitted = DateTime.Now,
          Country = pledge.Country,
          EmailedTo = emailedTo,
          //StateProvince = pledge.State == null ? (pledge.Province == null ? null : pledge.Province) : pledge.State
          StateProvince = pledge.Country != "United States" ? (pledge.Country != "Canada" ? null : pledge.Province) : pledge.State
        };

        var pledgeSubmission = new AssociationPledgeSubmission(acrLibraryPledge, emailedTo, null);
        pledgeSubmission.InsertAssociationPledgeSubmission();

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    public bool SendEmail_IP(IPledgeForm formItem, IndividualPledge pledge)
    {
      //build the message
      StringBuilder messageBody = new StringBuilder();

      string subject = AcrGlobals.PledgeFormDefaultSubject;

      messageBody.Append("<br/>First Name: " + pledge.FirstName + "<br/>");
      messageBody.Append("Last Name: " + pledge.LastName + "<br/>");
      messageBody.Append("Email Address: " + pledge.Email + "<br/><br/>");
      messageBody.Append("Profession/Role: " + pledge.ProfessionOrRole + "<br/><br/>");
      messageBody.Append("Primary Institution / Hospital: " + pledge.InstitutionOrHospital + "<br/><br/>");
      messageBody.Append("Country: " + pledge.Country + "<br/><br/>");
      messageBody.Append("Practice Type: " + pledge.PracticeType + "<br/><br/>");
      
      MailAddress from = new MailAddress(pledge.Email);
      MailAddress to = new MailAddress(formItem.SendFormDataTo);
      MailMessage emailMessage = new MailMessage(from, to);
      emailMessage.Body = messageBody.ToString();
      emailMessage.Subject = subject;
      emailMessage.IsBodyHtml = true;
      try
      {
        Sitecore.MainUtil.SendMail(emailMessage);
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Failed to Send pledge email"  + ex, "IW");
        return false;
      }
      return true;
    }

    public bool SendEmail_GP(IPledgeForm formItem, GroupPledge pledge)
    {
      //build the message
      StringBuilder messageBody = new StringBuilder();

      string subject = AcrGlobals.PledgeFormDefaultSubject;

      messageBody.Append("<br/>" + formItem.PledgeType + ": " + pledge.FacilityName + "<br/><br/>");
      messageBody.Append("City: " + pledge.City + "<br/><br/>");
      if (pledge.Country == "United States")
        messageBody.Append("State: " + pledge.State + "<br/><br/>");
      else if (pledge.Country == "Canada")
        messageBody.Append("Province: " + pledge.Province + "<br/><br/>");
      messageBody.Append("Country: " + pledge.Country + "<br/><br/>");
      messageBody.Append("<br/>Individual taking pledge on behalf of the " + formItem.PledgeType + "<br/><br/>");
      messageBody.Append("First Name: " + pledge.FirstName + "<br/><br/>");
      messageBody.Append("Last Name: " + pledge.LastName + "<br/><br/>");
      messageBody.Append("Title: " + pledge.Title + "<br/><br/>");
      messageBody.Append("Email Address: " + pledge.Email + "<br/><br/>");
      messageBody.Append("Display on Honor Roll: " + ((pledge.IsDisplayOnHonorRoll) ? "yes" : "no") + "<br/><br/>");

      MailAddress from = new MailAddress(pledge.Email);
      MailAddress to = new MailAddress(formItem.SendFormDataTo);
      MailMessage emailMessage = new MailMessage(from, to);
      emailMessage.Body = messageBody.ToString();
      emailMessage.Subject = subject;
      emailMessage.IsBodyHtml = true;
      try
      {
        Sitecore.MainUtil.SendMail(emailMessage);
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Failed to Send pledge email" + ex, "IW");
        return false;
      }      

      return true;
    }

    public bool SendEmailToUser(string emailAddr, IPledgeForm formItem)
    {
      if (emailAddr == "") return true;

      MailAddress from = new MailAddress(formItem.ConfirmationEmailFrom);
      MailAddress to = new MailAddress(emailAddr);
      MailMessage emailMessage = new MailMessage(from, to);
      emailMessage.Body = formItem.ConfirmationEmailBody;
      emailMessage.Subject = formItem.ConfirmationEmailSubject;
      emailMessage.IsBodyHtml = true;
      try
      {        
        Sitecore.MainUtil.SendMail(emailMessage);
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Failed to Send pledge email" + ex, "IW");
        return false;
      }
      return true;
    }

    public IEnumerable<SelectListItem> GetProvinces()
    {
      return PledgeItems.Provinces;
    }

    public IEnumerable<SelectListItem> GetStates()
    {
      return PledgeItems.States;
    }

    public void SetDefaultCountry(IEnumerable<SelectListItem> countries)
    {
      countries.FirstOrDefault(x => x.Value == "United States").Selected = true;
    }

    public void SetDefaultIsDisplayOnHonorRoll(GroupPledge pledge)
    {
      pledge.IsDisplayOnHonorRoll = true;
    }

    private string GetOtherIfNeed(string itemType, string otherValue)
    {

      if (itemType == "Other")
      {
        return otherValue == null ? string.Empty : otherValue.Trim();
      }

      return itemType;
    }

    public int ImagingProfessionalsPledgeCount()
    {
      return DataHelper.GetImagingProfessionalsPledgeCount();
    }

    public int ReferingPractitionersPledgeCount()
    {
      return DataHelper.GetReferingPractitionersPledgeCount();
    }
    //pledge counter page
    public int FacilitiesPledgeCount()
    {
      return DataHelper.GetFacilitiesPledgeCount();
    }
    //pledge counter page
    public int AssociationsPledgeCount()
    {
      return DataHelper.GetAssociationPledgeCount();
    }

    //usmap pledge count by state
    public IList<PledgeCount> FacilityHonorPledgeCountByState()
    {
      return DataHelper.GetFacilityHonorRollPledgesCountByState();
    }

    //usmap pledge count by state
    public IList<PledgeCount> AssociationHonorPledgeCountByState()
    {
      return DataHelper.GetAssociationHonorRollPledgesCountByState();
    }

    public List<InternationalFacility> GetInternationalFacilities(int year)
    {
      return DataHelper.GetInternationalFacilityHonorRoll(year);
    }

    public IList<ACR.Library.ImageWisely.Data.Pledge> GetStateFacilitiesPledge(string state)
    {
      return DataHelper.GetFacilitiesHonorRollPledges(state);
    }

    public IList<ACR.Library.ImageWisely.Data.Pledge> GetStateAssociationsPledge(string state)
    {
      return DataHelper.GetAssociationsHonorRollPledges(state);
    }
  }
}