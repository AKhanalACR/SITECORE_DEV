using ACRHelix.Feature.Toolkits.DAL;
using ACRHelix.Feature.Toolkits.Services;
using ACRHelix.Feature.Toolkits.Models;
using ACRHelix.Feature.Toolkits.ViewModels;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Web.Mvc;
using System.Linq;
using System.IO;
using System.Net.Mail;
using Sitecore;
using ACR.Foundation.SSO.Users;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ACRHelix.Feature.MesoToolkit
{
  public class MesoToolkitController : Controller
  {
    private readonly IContentService _contentService;
    private ToolkitsRepository _repository;

    public MesoToolkitController(IContentService contentService)
    {
      _contentService = contentService;
      _repository = new ToolkitsRepository();
    }

    public ViewResult SignupWithEmail()
    {
      var viewModel = new SignupWithEmailViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var signupContent = _contentService.GetSignupWithEmailContent(dataSource);
      if (signupContent != null)
      {
        viewModel.Id = signupContent.Id;
        viewModel.Title = signupContent.Title;
        viewModel.Teaser = signupContent.Teaser;
      }
      return View(viewModel);
    }

    public ViewResult MesoToolkit()
    {
      var viewModel = new MesoToolkitViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var ToolkitContent = _contentService.GetMesoToolkitContent(dataSource);
      if (ToolkitContent != null)
      {
        viewModel.Id = ToolkitContent.Id;
        viewModel.Title = ToolkitContent.Title;
        viewModel.Image = ToolkitContent.Image;
        viewModel.FeedbackEmail = ToolkitContent.Email;
      }
      viewModel.Facets = _repository.GetMesoFacets();
      viewModel.FacetTypes = ReferenceItems.MesoFacetTypes;

      var mediaFiles = _contentService.GetMesoFilesContent(ReferenceItems.MesoMediaFolderId);
      // Sitecore.Diagnostics.Log.Info("--- meso pdf exist" + mediaFiles.PdfMesoFiles.Count(), this);
      IEnumerable<MesoResource> resources = null;
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var customerId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID; // "05082777"; //        
        viewModel.CustomerType = _repository.CheckMesoCustomerType(customerId);
        if (string.IsNullOrWhiteSpace(viewModel.CustomerType))
        {
          resources = _repository.GetMesoResources(null, null, null, null, null, 0, 1000).OrderByDescending(x => x.PostedDate);
          foreach (var rscd in resources)
          {
            if (!string.IsNullOrWhiteSpace(rscd.Description))
            {
              string txt = rscd.Description;
              string newDescription = Regex.Replace(txt, @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", "<a href=\"$1\" target=\"_blank\">$1</a>", RegexOptions.IgnoreCase).Replace("href=\"www", "href=\"https://www");
              rscd.Description = newDescription;
            }
          }
          foreach (var file in mediaFiles.PdfMesoFiles)
          {
            foreach (var rsc in resources)
            {
              if (!string.IsNullOrWhiteSpace(rsc.FileName) && (rsc.FileName.Split('.')[0].ToLower() + "_2") == file.Name.ToLower())
              {
                rsc.PdfLink = rsc.Link.Replace(rsc.FileName, file.Name + ".pdf");
              }
            }
          }
        }
        else
        {
          resources = _repository.GetAdminAreaMesoResources(null, null, null, null, null, customerId, 0, 1000).OrderByDescending(x => x.PostedDate);
          foreach (var rscd in resources)
          {
            if (!string.IsNullOrWhiteSpace(rscd.Description))
            {
              string txt = rscd.Description;
              string newDescription = Regex.Replace(txt, @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", "<a href=\"$1\" target=\"_blank\">$1</a>", RegexOptions.IgnoreCase).Replace("href=\"www", "href=\"https://www");
              rscd.Description = newDescription;
            }
          }
          foreach (var file in mediaFiles.PdfMesoFiles)
          {
            foreach (var rsc in resources)
            {
              if (!string.IsNullOrWhiteSpace(rsc.FileName) && (rsc.FileName.Split('.')[0].ToLower() + "_2") == file.Name.ToLower())
              {
                rsc.PdfLink = rsc.Link.Replace(rsc.FileName, file.Name + ".pdf");
              }
            }
          }
        }
      }
      else
      {
        resources = _repository.GetMesoResources(null, null, null, null, null, 0, 1000).OrderByDescending(x => x.PostedDate);
        foreach (var rscd in resources)
        {
          if (!string.IsNullOrWhiteSpace(rscd.Description))
          {
            string txt = rscd.Description;
            string newDescription = Regex.Replace(txt, @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", "<a href=\"$1\" target=\"_blank\">$1</a>", RegexOptions.IgnoreCase).Replace("href=\"www", "href=\"https://www");
            rscd.Description = newDescription;
          }
        }
        foreach (var file in mediaFiles.PdfMesoFiles)
        {
          foreach (var rsc in resources)
          {
            if (!string.IsNullOrWhiteSpace(rsc.FileName) && (rsc.FileName.Split('.')[0].ToLower() + "_2") == file.Name.ToLower())
            {
              rsc.PdfLink = rsc.Link.Replace(rsc.FileName, file.Name + ".pdf");
            }
          }
        }
      }
      viewModel.Resources = resources.Skip(0).Take(10);
      viewModel.TotalCount = resources.Count();
      viewModel.PageNumber = 1;
      return View(viewModel);
    }

    public ActionResult Resources(string tgtype, string cktype, string asctype, string rtype, string kword, int pageNbr, string sortDir)
    {
      ////Check for possible SQL injection (Rapid7 Report)
      var keyword = checkForPossibleSQLInjection(kword) ? null : kword;
      var targettype = checkForPossibleSQLInjection(tgtype) ? null : tgtype;
      var coretype = checkForPossibleSQLInjection(cktype) ? null : cktype;
      var anatomytype = checkForPossibleSQLInjection(asctype) ? null : asctype;
      var resourcetype = checkForPossibleSQLInjection(rtype) ? null : rtype;

      var viewModel = new MesoToolkitViewModel();
      keyword = string.IsNullOrWhiteSpace(keyword) ? null : keyword;
      targettype = string.IsNullOrWhiteSpace(targettype) ? null : "'" + targettype.Replace(",", "','") + "'";
      coretype = string.IsNullOrWhiteSpace(coretype) ? null : "'" + coretype.Replace(",", "','") + "'";
      anatomytype = string.IsNullOrWhiteSpace(anatomytype) ? null : "'" + anatomytype.Replace(",", "','") + "'";
      resourcetype = string.IsNullOrWhiteSpace(resourcetype) ? null : "'" + resourcetype.Replace(",", "','") + "'";



      var mediaFiles = _contentService.GetMesoFilesContent(ReferenceItems.MesoMediaFolderId);
      IEnumerable<MesoResource> resources = null;
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var customerId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
        viewModel.CustomerType = _repository.CheckMesoCustomerType(customerId);
        if (string.IsNullOrWhiteSpace(viewModel.CustomerType))
        {
          resources = _repository.GetMesoResources(targettype, coretype, anatomytype, resourcetype, keyword, 0, 1000).OrderByDescending(x => x.PostedDate);
          foreach (var rscd in resources)
          {
            if (!string.IsNullOrWhiteSpace(rscd.Description))
            {
              string txt = rscd.Description;
              string newDescription = Regex.Replace(txt, @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", "<a href=\"$1\" target=\"_blank\">$1</a>", RegexOptions.IgnoreCase).Replace("href=\"www", "href=\"https://www");
              rscd.Description = newDescription;
            }
          }
          foreach (var file in mediaFiles.PdfMesoFiles)
          {
            foreach (var rsc in resources)
            {
              if (!string.IsNullOrWhiteSpace(rsc.FileName) && (rsc.FileName.Split('.')[0].ToLower() + "_2") == file.Name.ToLower())
              {
                rsc.PdfLink = rsc.Link.Replace(rsc.FileName, file.Name + ".pdf");
              }
            }
          }
        }
        else
        {
          resources = _repository.GetAdminAreaMesoResources(targettype, coretype, anatomytype, resourcetype, keyword, customerId, 0, 1000).OrderByDescending(x => x.PostedDate);
          foreach (var rscd in resources)
          {
            if (!string.IsNullOrWhiteSpace(rscd.Description))
            {
              string txt = rscd.Description;
              string newDescription = Regex.Replace(txt, @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", "<a href=\"$1\" target=\"_blank\">$1</a>", RegexOptions.IgnoreCase).Replace("href=\"www", "href=\"https://www");
              rscd.Description = newDescription;
            }
          }
          foreach (var file in mediaFiles.PdfMesoFiles)
          {
            foreach (var rsc in resources)
            {
              if (!string.IsNullOrWhiteSpace(rsc.FileName) && (rsc.FileName.Split('.')[0].ToLower() + "_2") == file.Name.ToLower())
              {
                rsc.PdfLink = rsc.Link.Replace(rsc.FileName, file.Name + ".pdf");
              }
            }
          }
        }
      }
      else
      {
        resources = _repository.GetMesoResources(targettype, coretype, anatomytype, resourcetype, keyword, 0, 1000).OrderByDescending(x => x.PostedDate);
        foreach (var rscd in resources)
        {
          if (!string.IsNullOrWhiteSpace(rscd.Description))
          {
            string txt = rscd.Description;
            string newDescription = Regex.Replace(txt, @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])", "<a href=\"$1\" target=\"_blank\">$1</a>", RegexOptions.IgnoreCase).Replace("href=\"www", "href=\"https://www");
            rscd.Description = newDescription; // new MvcHtmlString(newDescription)
          }
        }
        foreach (var file in mediaFiles.PdfMesoFiles)
        {
          foreach (var rsc in resources)
          {
            if (!string.IsNullOrWhiteSpace(rsc.FileName) && (rsc.FileName.Split('.')[0].ToLower() + "_2") == file.Name.ToLower())
            {
              rsc.PdfLink = rsc.Link.Replace(rsc.FileName, file.Name + ".pdf");
            }
          }
        }
      }

      if (sortDir == "asc")
        resources = resources.OrderBy(x => x.PostedDate);

      viewModel.Resources = resources.Skip((pageNbr - 1) * 10).Take(10);
      viewModel.TotalCount = resources.Count();
      viewModel.PageNumber = pageNbr;
      return PartialView("_Resources", viewModel);
    }

    [HttpGet]
    public ActionResult MesoNewFormData()
    {
      MesoNewFormViewModel viewModel = new MesoNewFormViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var FormContent = _contentService.GetPfccToolkitFormContent(dataSource);
        viewModel.Id = FormContent.Id;
        viewModel.Disclaimer = FormContent.Disclaimer;
        viewModel.DisclaimerCheckboxText = FormContent.DisclaimerCheckboxText;
      }

      viewModel.MesoFormData.TargetAudienceList = _repository.GetMesoFacets().Where(x => x.Type == "MESO_TARGET");
      viewModel.MesoFormData.CoreKnowledgeTypeList = _repository.GetMesoFacets().Where(x => x.Type == "MESOCORETYPE");
      viewModel.MesoFormData.AnatomySubcategoryTypeList = _repository.GetMesoFacets().Where(x => x.Type == "MESOSUBCATEGORY");
      viewModel.MesoFormData.ResourceTypeList = _repository.GetMesoFacets().Where(x => x.Type == "MESORESOURCETYPE");
      return View(viewModel);
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult MesoNewFormData(MesoNewFormViewModel viewModel)
    {
      var dataSource = viewModel.Id;
      if (dataSource != null)
      {
        var FormContent = _contentService.GetPfccToolkitFormContent(dataSource.ToString());
        if (FormContent != null)
        {
          viewModel.Id = FormContent.Id;
          viewModel.ConfirmationPageUrl = FormContent.ConfirmationPageUrl;
          viewModel.ErrorPageUrl = FormContent.ErrorPageUrl;
          viewModel.Email = FormContent.Email;
          viewModel.EmailFrom = FormContent.EmailFrom;
          viewModel.EmailBody = FormContent.EmailBody;
          viewModel.EmailSubject = FormContent.EmailSubject;
          viewModel.Disclaimer = FormContent.Disclaimer;
          viewModel.DisclaimerCheckboxText = FormContent.DisclaimerCheckboxText;

        }
      }

      if (ModelState.IsValid)
      {
        try
        {
          //insert resource toolkit
          var FormData = viewModel.MesoFormData;

          string FileName = "";
          if (viewModel.ResourceFile != null)
          {
            FileName = ItemUtil.ProposeValidItemName(viewModel.ResourceFile.FileName.Replace(" ", ""));
            FileName = FileName + "_" + DateTime.Now.ToString("yymmssfff");
            FormData.FileName = FileName + Path.GetExtension(viewModel.ResourceFile.FileName);
          }

          FormData.AttachementUrl = viewModel.ResourceFile != null ? ReferenceItems.MesoMediaFolderUrl + FileName : "";

          if (!string.IsNullOrWhiteSpace(FormData.Url))
          {
            Uri uriResult;
            if (!(Uri.TryCreate(FormData.Url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
              FormData.Url = "https://" + FormData.Url;
          }

          var response = _repository.AddNewMesoData(FormData);

          //create resource toolkit media item
          if (viewModel.ResourceFile != null && viewModel.ResourceFile.ContentLength > 0)
          {
            try
            {
              PfccMediaItem mediaItem = new PfccMediaItem()
              {
                Name = FileName,
                Title = viewModel.MesoFormData.Title,
                Keywords = viewModel.MesoFormData.Keyword,
                MimeType = viewModel.ResourceFile.ContentType,
                Extension = Path.GetExtension(viewModel.ResourceFile.FileName),
                Icon = "",
                Blob = viewModel.ResourceFile.InputStream
              };
              var response2 = _contentService.CreateMesoMediaItem(mediaItem);
            }
            catch (Exception ex)
            {
              Sitecore.Diagnostics.Error.LogError("-- Failed to creat MESO toolkit media item. " + ex.Message);
            }
          }

          //send email
          MailAddress from = new MailAddress(viewModel.EmailFrom);
          MailAddress to = new MailAddress(viewModel.MesoFormData.Email);
          MailAddress copy = new MailAddress(viewModel.EmailFrom);
          MailMessage emailMessage = new MailMessage(from, to);
          emailMessage.CC.Add(copy);
          emailMessage.Subject = viewModel.EmailSubject;
          var emailBody = viewModel.EmailBody.Replace("[Title]", FormData.Title).Replace("[Name]", FormData.FirstName + " " + FormData.LastName).Replace("[Email]", FormData.Email).Replace("[FileName]", FormData.FileName).Replace("[URL]", FormData.Url);
          emailMessage.Body = emailBody;
          emailMessage.IsBodyHtml = true;
          MainUtil.SendMail(emailMessage);
        }
        catch (Exception ex)
        {
          Sitecore.Diagnostics.Log.Error("-- Error MESO Form submission: " + ex.Message, this);
          return Redirect(viewModel.ErrorPageUrl.Url);
        }
        return Redirect(viewModel.ConfirmationPageUrl.Url);
      }
      return Redirect(viewModel.ErrorPageUrl.Url);
    }

    [HttpGet]
    public ActionResult MesoReviewFormData()
    {
      int toolId = 0;
      var qs = Request.QueryString["toolId"];
      if (!string.IsNullOrWhiteSpace(qs))
      {
        bool result = int.TryParse(qs, out toolId);
        if (result)
        {
          if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
          {
            var customerId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID; // "05082777"; //

            MesoReviewFormViewModel viewModel = new MesoReviewFormViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(dataSource))
            {
              var FormContent = _contentService.GetPfccToolkitFormContent(dataSource);
              viewModel.Id = FormContent.Id;
            }

            viewModel.CustomerType = _repository.CheckMesoCustomerType(customerId);
            viewModel.ReviewFormData.StatesList = ReferenceItems.States;
            viewModel.ReviewFormData.PracticeSettingsList = _repository.GetMesoFacets().Where(x => x.Type == "MESO_TARGET"); //audience group
            viewModel.ReviewFormData.ContentTypesList = _repository.GetMesoFacets().Where(x => x.Type == "MESOCORETYPE"); //core knowledge type
            viewModel.ReviewFormData.ResourceTypesList = _repository.GetMesoFacets().Where(x => x.Type == "MESOSUBCATEGORY"); //anatomy subcategory type
            viewModel.ReviewFormData.ResourceFormatsList = _repository.GetMesoFacets().Where(x => x.Type == "MESORESOURCETYPE"); //content type
            viewModel.ReviewFormData.ToolId = toolId;
            MesoReviewFormData formData = _repository.GetMesoResourceByID(toolId, viewModel.CustomerType == "admin" ? 1 : 0, customerId);
            viewModel.ReviewFormData.Title = formData.Title;
            viewModel.ReviewFormData.ContentType = formData.ContentType;
            viewModel.ReviewFormData.ResourceType = formData.ResourceType;
            viewModel.ReviewFormData.ResourceFormat = formData.ResourceFormat;
            viewModel.ReviewFormData.Description = formData.Description;
            viewModel.ReviewFormData.Url = formData.Url;
            viewModel.ReviewFormData.FileName = formData.FileName;
            viewModel.ReviewFormData.Keywords = formData.Keywords;
            viewModel.ReviewFormData.Status = formData.Status;

            viewModel.ReviewFormData.FirstName = formData.FirstName;
            viewModel.ReviewFormData.LastName = formData.LastName;
            viewModel.ReviewFormData.Address1 = formData.Address1;
            viewModel.ReviewFormData.Address1 = formData.Address2;
            viewModel.ReviewFormData.City = formData.City;
            viewModel.ReviewFormData.State = formData.State;
            viewModel.ReviewFormData.ZipCode = formData.ZipCode;
            viewModel.ReviewFormData.PhoneArea = formData.PhoneArea;
            viewModel.ReviewFormData.Phone = formData.PhoneArea + " " + formData.Phone;
            viewModel.ReviewFormData.Email = formData.Email;
            viewModel.ReviewFormData.PracticeSetting = formData.PracticeSetting;



            foreach (var item in _repository.GetMesoReviewers())
            {
              ((List<SelectListItem>)viewModel.ReviewersList).Add(new SelectListItem() { Value = item.DemographicId, Text = item.FirstName + " " + item.LastName });
            }
            return View(viewModel);
          }
        }
      }
      if (!Sitecore.Context.PageMode.IsExperienceEditor)
        throw new Exception("Error: exception editing Meso toolkit. The ToolID might be wrong.");
      return View();
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult MesoReviewFormData(MesoReviewFormViewModel viewModel)
    {
      var dataSource = viewModel.Id;
      if (dataSource != null)
      {
        var FormContent = _contentService.GetPfccToolkitFormContent(dataSource.ToString());
        if (FormContent != null)
        {
          viewModel.Id = FormContent.Id;
          viewModel.ConfirmationPageUrl = FormContent.ConfirmationPageUrl;
          viewModel.ErrorPageUrl = FormContent.ErrorPageUrl;
          viewModel.Email = FormContent.Email;
          viewModel.EmailFrom = FormContent.EmailFrom;
          viewModel.EmailBody = FormContent.EmailBody;
          viewModel.EmailSubject = FormContent.EmailSubject;
        }
      }

      if (ModelState.IsValid)
      {
        try
        {
          if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
          {
            var customerId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID; // "05082777"; //

            //submit review
            if (!string.IsNullOrWhiteSpace(viewModel.ReviewFormData.Url))
            {
              Uri uriResult;
              if (!(Uri.TryCreate(viewModel.ReviewFormData.Url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
                viewModel.ReviewFormData.Url = "https://" + viewModel.ReviewFormData.Url;
            }
            _repository.SubmitMesoResourceReview(viewModel.ReviewFormData);

            //update status
            _repository.SetMesoStatus(viewModel.ReviewFormData.ToolId, viewModel.ReviewFormData.Status, customerId);

            if (viewModel.CustomerType == "admin")
            {
              //make assignment
              _repository.SetMesoReviewer(viewModel.ReviewFormData.ToolId, viewModel.Reviewer, viewModel.Reviewer);
            }

            //send email
            var fullName = UserManager.CurrentUserContext.CurrentUser.GetCustAddrInfo().FirstName + " " + UserManager.CurrentUserContext.CurrentUser.GetCustAddrInfo().LastName;
            var userInfo = fullName + " " + UserManager.CurrentUserContext.CurrentUser.GetCustAddrInfo().PrimaryEmailAddress;

            MailAddress from = new MailAddress(viewModel.EmailFrom);
            MailAddress to = new MailAddress(viewModel.Email);

            MailMessage emailMessage = new MailMessage(from, to);

            emailMessage.Subject = viewModel.EmailSubject;
            var emailBody = viewModel.EmailBody.Replace("[Title]", viewModel.ReviewFormData.Title).Replace("[ReviewerInfo]", userInfo).Replace("[FileName]", viewModel.ReviewFormData.FileName).Replace("[URL]", viewModel.ReviewFormData.Url);
            emailMessage.Body = emailBody;
            emailMessage.IsBodyHtml = true;
            MainUtil.SendMail(emailMessage);
          }
          return Redirect(viewModel.ConfirmationPageUrl.Url);
        }
        catch (Exception ex)
        {
          Sitecore.Diagnostics.Log.Error("Error reviewing MESO toolkit" + ex.Message, this);
        }
      }
      return Redirect(viewModel.ErrorPageUrl.Url);
    }
    public static Boolean checkForPossibleSQLInjection(string userInput)
    {
      bool isSQLInjection = false;
      if (!String.IsNullOrEmpty(userInput))
      {
        string[] sqlCheckList = { "'", "--", ";--", ";", "/*", "*/", "@@", "@", "char", "nchar", "varchar", "nvarchar", "alter", "begin", "cast", "create", "cursor", "declare", "delete", "drop", "end", "exec", "execute", "fetch", "insert", "kill", "select", "sys", "sysobjects", "syscolumns", "table", "update" };

        //string CheckString = userInput.Replace("'", "''");
        string CheckString = userInput;
        for (int i = 0; i <= sqlCheckList.Length - 1; i++)
        {
          if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
          {
            isSQLInjection = true;
          }
        }
      }
      return isSQLInjection;
    }

  }
}
