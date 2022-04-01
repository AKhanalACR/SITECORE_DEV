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

namespace ACRHelix.Feature.PfccToolkit
{
    public class PfccToolkitController : Controller
    {
        private readonly IContentService _contentService;
        private IToolkitsRepository _repository;
        
        public PfccToolkitController(IContentService contentService)
        {
            _contentService = contentService;
            _repository = new ToolkitsRepository();
        }

        public ViewResult PfccToolkit()
        {
            var viewModel = new PfccToolkitViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (string.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var PfccToolkitContent = _contentService.GetPfccToolkitContent(dataSource);
            if (PfccToolkitContent != null)
            {
                viewModel.Id = PfccToolkitContent.Id;
                viewModel.Title = PfccToolkitContent.Title;
                viewModel.Image = PfccToolkitContent.Image;
            }
            viewModel.Facets = _repository.GetFacets();
            viewModel.FacetTypes = ReferenceItems.FacetTypes;
      
            IEnumerable<Resource> resources = null;
            if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
            {
                var customerId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID; // "05082777"; //        
                viewModel.CustomerType = _repository.ChechCustomerType(customerId);
                if (string.IsNullOrWhiteSpace(viewModel.CustomerType))
                  resources = _repository.GetResources(null, null, null, null, 0, 1000).OrderByDescending(x => x.PostedDate);
                else
                  resources = _repository.GetAdminAreaResources(null, null, null, null, customerId, 0, 1000).OrderByDescending(x => x.PostedDate);
            }
            else
            {
                resources = _repository.GetResources(null, null, null, null, 0, 1000).OrderByDescending(x => x.PostedDate);
            }       
            viewModel.Resources = resources.Skip(0).Take(10);
            viewModel.TotalCount = resources.Count();
            viewModel.PageNumber = 1;
            return View(viewModel);     
        }

        public ActionResult Resources(string ps, string cont, string rt, string kw, int pageNbr, string sortDir)
        {
          var viewModel = new PfccToolkitViewModel();
          var keyword = string.IsNullOrWhiteSpace(kw) ? null : kw;
          var pSetting = string.IsNullOrWhiteSpace(ps) ? null : "'" + ps.Replace(",", "','") + "'";
          var cType = string.IsNullOrWhiteSpace(cont) ? null : "'" + cont.Replace(",", "','") + "'";
          var rType = string.IsNullOrWhiteSpace(rt) ? null : "'" + rt.Replace(",", "','") + "'";

          IEnumerable<Resource> resources = null;
          if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
          {
            var customerId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
            viewModel.CustomerType = _repository.ChechCustomerType(customerId);
            if(string.IsNullOrWhiteSpace(viewModel.CustomerType))
              resources = _repository.GetResources(pSetting, cType, rType, keyword, 0, 1000).OrderByDescending(x => x.PostedDate);
            else
              resources = _repository.GetAdminAreaResources(pSetting, cType, rType, keyword, customerId, 0, 1000).OrderByDescending(x => x.PostedDate);
          }
          else
          {
            resources = _repository.GetResources(pSetting, cType, rType, keyword, 0, 1000).OrderByDescending(x => x.PostedDate);
          }

          if (sortDir == "asc")
            resources = resources.OrderBy(x => x.PostedDate);

          viewModel.Resources = resources.Skip((pageNbr - 1) * 10).Take(10);
          viewModel.TotalCount = resources.Count();
          viewModel.PageNumber = pageNbr;    
          return PartialView("_Resources", viewModel);
        }

        [HttpGet]
        public ActionResult NewResourceData()
        {
          ResourceFormViewModel viewModel = new ResourceFormViewModel();
          var dataSource = RenderingContext.Current.Rendering.DataSource;
          if (!string.IsNullOrWhiteSpace(dataSource))
          {
            var FormContent = _contentService.GetPfccToolkitFormContent(dataSource);
            viewModel.Id = FormContent.Id;
          }
          
          //viewModel.ResourceFormData.StatesList = ReferenceItems.States;
          viewModel.ResourceFormData.PracticeSettingsList = _repository.GetFacets().Where(x => x.Type == "PFCC_CATEORY");
          viewModel.ResourceFormData.ContentTypesList = _repository.GetFacets().Where(x => x.Type == "CONTENT_TYPE");
          viewModel.ResourceFormData.ResourceTypesList = _repository.GetFacets().Where(x => x.Type == "RESOURCE_TYPE");
          return View(viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult NewResourceData(ResourceFormViewModel viewModel)
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
                //insert resource toolkit
                var FormData = viewModel.ResourceFormData;

                string FileName = "";
                if(viewModel.ResourceFile != null)
                {
                  FileName = ItemUtil.ProposeValidItemName(viewModel.ResourceFile.FileName.Replace(" ", ""));
                  FileName = FileName + "_" + DateTime.Now.ToString("yymmssfff");
                  FormData.FileName = FileName + Path.GetExtension(viewModel.ResourceFile.FileName);
                }
                
                FormData.AttachementUrl = viewModel.ResourceFile != null ? ReferenceItems.MediaFolderUrl + FileName : "";

                if (!string.IsNullOrWhiteSpace(FormData.Url))
                {
                  Uri uriResult;
                  if (!(Uri.TryCreate(FormData.Url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
                    FormData.Url = "https://" + FormData.Url;
                }
                
                var response = _repository.AddNewResource(FormData);

                //create resource toolkit media item
                if (viewModel.ResourceFile != null && viewModel.ResourceFile.ContentLength > 0)
                {
                  try
                  {
                    PfccMediaItem mediaItem = new PfccMediaItem()
                    {
                        Name = FileName,
                        Title = viewModel.ResourceFormData.Title,
                        Keywords = viewModel.ResourceFormData.Keyword,
                        MimeType = viewModel.ResourceFile.ContentType,
                        Extension = Path.GetExtension(viewModel.ResourceFile.FileName),
                        Icon = "",
                        Blob = viewModel.ResourceFile.InputStream
                    };
                    var response2 = _contentService.CreateMediaItem(mediaItem);
                  }
                  catch(Exception ex)
                  {
                    Sitecore.Diagnostics.Error.LogError("-- Failed to creat PFCC toolkit media item. " + ex.Message);
                  }            
                }

                //send email
                MailAddress from = new MailAddress(viewModel.EmailFrom);
                MailAddress to = new MailAddress(viewModel.ResourceFormData.Email);
                MailAddress copy = new MailAddress(viewModel.EmailFrom);
                MailMessage emailMessage = new MailMessage(from, to);
                emailMessage.CC.Add(copy);
                emailMessage.Subject = viewModel.EmailSubject;        
                var emailBody = viewModel.EmailBody.Replace("[Title]", FormData.Title).Replace("[Name]", FormData.FirstName + " " + FormData.LastName).Replace("[Email]", FormData.Email).Replace("[FileName]", FormData.FileName).Replace("[URL]", FormData.Url);
                emailMessage.Body = emailBody;         
                emailMessage.IsBodyHtml = true;               
                MainUtil.SendMail(emailMessage);
              }
              catch(Exception ex)
              {
                Sitecore.Diagnostics.Log.Error("-- Error PFCC Form submission: " + ex.Message, this);
                return Redirect(viewModel.ErrorPageUrl.Url);
              }
              return Redirect(viewModel.ConfirmationPageUrl.Url);
          }
          return Redirect(viewModel.ErrorPageUrl.Url);
        }

        [HttpGet]
        public ActionResult ReviewResourceData()
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

                ReviewFormViewModel viewModel = new ReviewFormViewModel();
                var dataSource = RenderingContext.Current.Rendering.DataSource;
                if (!string.IsNullOrWhiteSpace(dataSource))
                {
                  var FormContent = _contentService.GetPfccToolkitFormContent(dataSource);
                  viewModel.Id = FormContent.Id;
                }
                viewModel.CustomerType = _repository.ChechCustomerType(customerId);
                viewModel.ReviewFormData.StatesList = ReferenceItems.States;
                viewModel.ReviewFormData.PracticeSettingsList = _repository.GetFacets().Where(x => x.Type == "PFCC_CATEORY");
                viewModel.ReviewFormData.ContentTypesList = _repository.GetFacets().Where(x => x.Type == "CONTENT_TYPE");
                viewModel.ReviewFormData.ResourceTypesList = _repository.GetFacets().Where(x => x.Type == "RESOURCE_TYPE");
                viewModel.ReviewFormData.ToolId = toolId;
                ReviewFormData formData = _repository.GetResourceByID(toolId, viewModel.CustomerType == "admin" ? 1 : 0, customerId);
                viewModel.ReviewFormData.Title = formData.Title;
                viewModel.ReviewFormData.ContentType = formData.ContentType;
                viewModel.ReviewFormData.ResourceType = formData.ResourceType;
                viewModel.ReviewFormData.Description = formData.Description;                       
                viewModel.ReviewFormData.Url = formData.Url;
                viewModel.ReviewFormData.FileName = formData.FileName;
                viewModel.ReviewFormData.Keywords = formData.Keywords;
                viewModel.ReviewFormData.Comments = formData.Comments;
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
            


                foreach (var item in _repository.GetReviewers())
                {
                  ((List<SelectListItem>)viewModel.ReviewersList).Add(new SelectListItem() { Value = item.DemographicId, Text = item.FirstName + " " + item.LastName });
                }
                return View(viewModel);
              }
            }
          }
          if (!Sitecore.Context.PageMode.IsExperienceEditor)
            throw new Exception("Error: exception editing PFCC toolkit. The ToolID might be wrong.");

          return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ReviewResourceData(ReviewFormViewModel viewModel)
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
                _repository.SubmitResourceReview(viewModel.ReviewFormData);

                //update status
                _repository.SetStatus(viewModel.ReviewFormData.ToolId, viewModel.ReviewFormData.Status, customerId);

                if (viewModel.CustomerType == "admin")
                {
                  //make assignment
                  _repository.SetReviewer(viewModel.ReviewFormData.ToolId, viewModel.Reviewer, viewModel.Reviewer);
                }
                

                  //send email
                  var fullName = UserManager.CurrentUserContext.CurrentUser.GetCustAddrInfo().FirstName + " " + UserManager.CurrentUserContext.CurrentUser.GetCustAddrInfo().LastName;
                  var userInfo = fullName + " " + UserManager.CurrentUserContext.CurrentUser.GetCustAddrInfo().PrimaryEmailAddress;

                  MailAddress from = new MailAddress(viewModel.EmailFrom);
                  MailAddress to = new MailAddress(viewModel.Email);
                  
                  MailMessage emailMessage = new MailMessage(from, to);
                  
                  emailMessage.Subject = viewModel.EmailSubject;
                  var emailBody = viewModel.EmailBody.Replace("[Title]", viewModel.ReviewFormData.Title).Replace("[ReviewerInfo]", userInfo).Replace("[FileName]", viewModel.ReviewFormData.FileName).Replace("[URL]", viewModel.ReviewFormData.Url).Replace("[Comments]", viewModel.ReviewFormData.Comments);
                  emailMessage.Body = emailBody;
                  emailMessage.IsBodyHtml = true;
                  MainUtil.SendMail(emailMessage);

              }
              return Redirect(viewModel.ConfirmationPageUrl.Url);
            }
            catch (Exception ex)
            {
              Sitecore.Diagnostics.Log.Error("Error reviewing PFCC toolkit" + ex.Message, this);
            }
          }
          return Redirect(viewModel.ErrorPageUrl.Url);
        }
    }
}
