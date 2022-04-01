using ACRHelix.Feature.RhecContent.DAL;
using ACRHelix.Feature.RhecContent.Helpers;
using ACRHelix.Feature.RhecContent.Models;
using ACRHelix.Feature.RhecContent.Services;
using ACRHelix.Feature.RhecContent.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.RhecContent.Controllers
{
  public class RHECContentController : Controller
  {
    private readonly IContentService _contentService;
    private readonly IPledgeRepository _pledgeService;

    public RHECContentController(IContentService contentService)
    {
      _contentService = contentService;
      _pledgeService = new PledgeRepository();
    }
      /// <summary>
      /// To get setting item for settings to be set in sitecore(Url's, page item id,etc).
      /// </summary>
      /// <returns>Setting Model </returns>
    public Models.Setting GetSettingItem()
    {
      Setting SettingItem = new Models.Setting();
      Setting SettingItemContent = _contentService.GetSettingItem(RHECHelper.SettingsItemID);

      if (SettingItemContent != null)
      {
        SettingItem = SettingItemContent;
      }

      return SettingItem;
    }
    /// <summary>
    /// To get Homepage our vision section data
    /// </summary>
    /// <returns></returns>
    public ViewResult OurVision()
    {
      OurVisionViewModel viewModel = new OurVisionViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        IOurVision OurVisionContent = _contentService.GetOurVisionContent(RenderingContext.Current.Rendering.DataSource);
        if (OurVisionContent != null)
        {
          //selected tiles to be displayed.
          viewModel.Tiles = OurVisionContent.Tiles.Select(i => new OurVisionTilesViewModel { Id = i.Id, Name = i.Name, Title = i.Title, Icon = i.Icon, Text = i.Text });
          viewModel.Id = OurVisionContent.Id;
          viewModel.Title = OurVisionContent.Title;
          viewModel.SubTitle = OurVisionContent.SubTitle;
          viewModel.Image = OurVisionContent.Image;
          viewModel.Link = OurVisionContent.Link;
          viewModel.LinkText = OurVisionContent.LinkText;

        }
      }
      return View(viewModel);
    }
    /// <summary>
    /// To get selected resources and topics to be displayed on homepage.
    /// </summary>
    /// <returns></returns>
    public ViewResult ResourcesHomePageDisplay()
    {
      ResourcesHomePageViewModel viewModel = new ResourcesHomePageViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        Setting settingItem = GetSettingItem();//To get the url of resource homepage for redirecting.
        ResourcesHomePage ResourcesHomePageContent = _contentService.GetResourcesHomePageContent(RenderingContext.Current.Rendering.DataSource);
        if (ResourcesHomePageContent != null)
        {
          viewModel.Id = ResourcesHomePageContent.Id;
          viewModel.Title = ResourcesHomePageContent.Title;
          viewModel.Subtitle = ResourcesHomePageContent.SubTitle;
          //To get selected resources.
          viewModel.Resources = ResourcesHomePageContent.Resources;
          viewModel.TopicTitle = ResourcesHomePageContent.TopicTitle;
          //To get the selected Topics
          viewModel.Topics = ResourcesHomePageContent.Topics.Select(i => new TopicViewModel { Id = i.Id, Name = i.Name, TopicName = i.TopicName, redirectUrl = settingItem.ResourceHomeUrl + "?topics=" + i.Name.Replace(" ", "-").Replace("+", "-") });
        }
      }
      return View(viewModel);
    }
    /// <summary>
    /// To get the Rich text content with title and Button(used on homepage).
    /// </summary>
    /// <returns></returns>
    public ViewResult RichTextButton()
    {
      RichTextButton viewModel = new RichTextButton();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        RichTextButton RichTextButtonContent = _contentService.GetRichTextButtonContent(RenderingContext.Current.Rendering.DataSource);
        if (RichTextButtonContent != null)
        {
          viewModel = RichTextButtonContent;
        }
      }
      return View(viewModel);
    }
    /// <summary>
    /// Can be used for rendering only rich tex content, no rendering made in sitecore for this only to be used when neccessary.
    /// </summary>
    /// <returns></returns>
    public ViewResult RichTextOnly()
    {
      RichTextButton viewModel = new RichTextButton();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        RichTextButton RichTextButtonContent = _contentService.GetRichTextButtonContent(RenderingContext.Current.Rendering.DataSource);
        if (RichTextButtonContent != null)
        {
          viewModel = RichTextButtonContent;
        }
      }
      return View(viewModel);
    }
    /// <summary>
    /// Used to render Content of page(Title,subtitle,Rich text and to display according to design).
    /// </summary>
    /// <returns></returns>
    public ViewResult PageContent()
    {
      PageContent viewModel = new PageContent();
      Models.PageContent PageContentContent = new Models.PageContent();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        PageContentContent = _contentService.GetPageContentContent(RenderingContext.Current.Rendering.DataSource);
      }
      else if (Sitecore.Context.Item != null)
      {
        PageContentContent = _contentService.GetPageContentContent(Sitecore.Context.Item.ID.ToString());
      }

      if (PageContentContent != null)
      {
        viewModel = PageContentContent;
      }

      return View(viewModel);
    }
    /// <summary>
    /// Used to display Content of single Resource.
    /// </summary>
    /// <returns></returns>
    public ActionResult ResourceDetail()
    {
      ResourceDetailViewModel viewModel = new ResourceDetailViewModel();
      Models.Resource ResourceContent = new Resource();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        ResourceContent = _contentService.GetResourceDetailContent(RenderingContext.Current.Rendering.DataSource);
      }
      else if (Sitecore.Context.Item != null)
      {
        ResourceContent = _contentService.GetResourceDetailContent(Sitecore.Context.Item.ID.ToString());
      }

      if (ResourceContent != null)
      {
        Setting settingItem = GetSettingItem();
        viewModel.Id = ResourceContent.Id;
        viewModel.Body = ResourceContent.Body;
        viewModel.image = ResourceContent.image;
        viewModel.LinkOverride = ResourceContent.LinkOverride;
        viewModel.NewWindow = ResourceContent.NewWindow;
        viewModel.PublishDate = ResourceContent.PublishDate;
        viewModel.Summary = ResourceContent.Summary;
        viewModel.Title = ResourceContent.Title;
        viewModel.Url = ResourceContent.Url;
        viewModel.Topics = ResourceContent.Topics.Select(i => new TopicViewModel { Id = i.Id, Name = i.Name, TopicName = i.TopicName, redirectUrl = settingItem.ResourceHomeUrl + "?topics=" + i.Name.Replace(" ", "-").Replace("+", "-") });
      }
      if (!string.IsNullOrEmpty(ResourceContent.LinkOverride))
      {
        return Redirect(ResourceContent.LinkOverride);
      }
      return View(viewModel);
    }
    /// <summary>
    /// Used to display listing of all resources.SOLR is used to index and get resources data.
    /// </summary>
    /// <returns></returns>
    public ViewResult ResourceListing()
    {
      ResourceListingViewModel viewModel = new ResourceListingViewModel();
      Setting settingItem = GetSettingItem();
      bool showAlltopics = false;
      bool isReferredSamePage = true;
        try { isReferredSamePage=Request.UrlReferrer == null ? false : Request.UrlReferrer.AbsolutePath == settingItem.ResourceHomeUrl; } catch(Exception ex) { isReferredSamePage = false; }
      bool initialVisit = Request.Url.PathAndQuery == settingItem.ResourceHomeUrl;
      if (Request.Cookies["ShowAllTopics"] != null)
      {
        if (Request.Cookies["ShowAllTopics"].Value.ToString() == "True")
        {
          if(!isReferredSamePage&&initialVisit)
          {            
            Response.Cookies["ShowAllTopics"].Value = "False";
            Response.Cookies["ShowAllTopics"].Expires = DateTime.Now.AddDays(1);
          }
          else
          {
            showAlltopics = true;
          }
        }
      }
          List<string> topicslist = new List<string>();
      if (settingItem.RemoveTopicsOnCount) { topicslist = Helpers.RHECHelper.GetTopicsWithCount(settingItem.ResourceTemplateID, settingItem.ResourcePageId); }
      IListingTopics ListingTopics = _contentService.GetListingTopics(settingItem.TopicSourceId, topicslist);//setting item contains id for topics containing folder
      if (ListingTopics != null)
      {
        viewModel.Topics = ListingTopics.Topics.Select(i => new TopicViewModel { Id = i.Id, Name = i.Name, TopicName = i.TopicName, redirectUrl = settingItem.ResourceHomeUrl + "?topics=" + i.Name.Replace(" ", "-") });
      }
      if (ListingTopics.Topics.Count()<= settingItem.NumberOfTopics)
      {
        showAlltopics = true;
      }
      Models.PageContent PageContentContent = new Models.PageContent();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        PageContentContent = _contentService.GetPageContentContent(RenderingContext.Current.Rendering.DataSource);
      }
      else if (Sitecore.Context.Item != null)
      {
        PageContentContent = _contentService.GetPageContentContent(Sitecore.Context.Item.ID.ToString());
      }

      if (PageContentContent != null)
      {
        viewModel.id = PageContentContent.Id;
        viewModel.Title = PageContentContent.Title;
        viewModel.SubTitle = PageContentContent.SubTitle;
      }
      viewModel.SummaryLength = settingItem.SummaryLength;
      
      viewModel.PageResult = false;
      int currentPage = 1;
      int maximumRows = 6;
      if (settingItem.PageSize > 0) { maximumRows = settingItem.PageSize; }
      int startRowIndex = 0;
      List<string> categoryList = new List<string>();
      string paginationTopics = "";
      string[] querystring = Request.QueryString.AllKeys;
      //To check query string for sitering resoures.
      string allTopicsButton = "<div class='topics-list' style='padding-bottom: 0px;'><a style='margin-bottom: 8px;' href='"+ settingItem.ResourceHomeUrl  + "' class= 'topic active' >ALL</a></div>";
      if (querystring != null && querystring.Count() > 0)
      {
        foreach (string query in querystring)
        {
          if (query.ToLower() == "page")
          {
            viewModel.PageResult = int.TryParse(Request.QueryString[query], out currentPage);
            if (!viewModel.PageResult || currentPage < 1)
            {
              currentPage = 1;
            }            
          }
          else if (query.ToLower() == "topics")
          {
            paginationTopics = HttpUtility.UrlDecode(Request.QueryString[query]).Replace(" ", "-").Replace("+", "-");
            string[] categ = HttpUtility.UrlDecode(Request.QueryString[query]).Replace(",", ",").Replace(" ", "-").Replace("+", "-").Split(new string[] { "," }, StringSplitOptions.None);
            if (categ.Length > 0 && !string.IsNullOrEmpty(categ[0]))
            {
              allTopicsButton= allTopicsButton.Replace("active", " ");
              
              if (!isReferredSamePage)
              {
                showAlltopics = true;
                if (Request.Cookies["ShowAllTopics"] != null)
                {
                  Response.Cookies["ShowAllTopics"].Value = "True";
                  Response.Cookies["ShowAllTopics"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                  System.Web.HttpCookie showTopicsCookie = new System.Web.HttpCookie("ShowAllTopics");
                  showTopicsCookie.Value = "True";
                  showTopicsCookie.Expires = DateTime.Now.AddDays(1);
                  Response.Cookies.Add(showTopicsCookie);
                }
              }                        
            }
            foreach (string category in categ)
            {
              if (!string.IsNullOrEmpty(category)) { categoryList.Add(category.Replace("%20", " ").Replace("+", " ").Replace("-", " ")); }

            }
            if (ListingTopics != null)
            {
              viewModel.Topics = ListingTopics.Topics.Select(i => new TopicViewModel { isActive = categoryList.Contains(i.Name), Name = i.Name, TopicName = i.TopicName, redirectUrl = categoryList.Contains(i.Name) ? settingItem.ResourceHomeUrl + "?topics=" + HttpUtility.UrlDecode(Request.QueryString[query]).Replace(",", ",").Replace(" ", "-").Replace("+", "-").Replace(i.Name.Replace(" ", "-").Replace("+", "-") + ",", "").Replace("+", "-").Replace("," + i.Name.Replace(" ", "-").Replace("+", "-"), "").Replace(i.Name.Replace(" ", "-").Replace("+", "-"), "") : (settingItem.ResourceHomeUrl + "?topics=" + HttpUtility.UrlDecode(Request.QueryString[query]).Replace(",", ",").Replace(" ", "-").Replace("+", "-") + "," + i.Name.Replace(" ", "-")).Replace("?topics=,", "?topics=") });
            }

          }
        }
      }
      viewModel.ShowAllTopics = showAlltopics;
      viewModel.AllButtonString = allTopicsButton;
      viewModel.settingTopicsCount = settingItem.NumberOfTopics;
      //get count of resources with filter to find pages and number of resources.
      viewModel.TotalRows = RHECHelper.GetResourcesCount(categoryList, settingItem.ResourceTemplateID, settingItem.ResourcePageId, settingItem.Filter);
      double decMaxPages = System.Convert.ToDouble(viewModel.TotalRows) / System.Convert.ToDouble(maximumRows);
      int maxPages = System.Convert.ToInt32(Math.Ceiling(decMaxPages));     
      if (currentPage > maxPages) { currentPage = maxPages; }
      startRowIndex = (currentPage - 1) * maximumRows;
      //get resources to be displayed on page.
      viewModel.Resources = RHECHelper.GetResources(categoryList, startRowIndex, maximumRows, viewModel.TotalRows, settingItem.ResourceTemplateID, settingItem.ResourcePageId, settingItem.Filter);
      viewModel.CurrentPage = currentPage;      
      viewModel.MaxPages = maxPages;
      viewModel.DisplayTopics = settingItem.DisplayTopics;
      viewModel.NoResourcetext = settingItem.NoResourceText;
      //Get Pagintaion string start(to set pagination html)
      string url = "";
      if (!string.IsNullOrEmpty(paginationTopics))
      {
        url = settingItem.ResourceHomeUrl + "?topics=" + paginationTopics + "&page=";
      }
      else
      {
        url = settingItem.ResourceHomeUrl + "?page=";
      }
      string paginationString = "<div class='pagination'>";
      if (currentPage > 1)
      {
        paginationString = paginationString + "<a href='" + url + (currentPage - 1) + "' class='arrow-wrapper'><div class='material-icons-outlined material-icons arrow'>arrow_left</div></a>";
      }
      else
      {
        paginationString = paginationString + "<a disabled class='arrow-wrapper'><div class='material-icons-outlined material-icons arrow'>arrow_left</div></a>";
      }
      paginationString = paginationString + "<div><label for='page-number'></label><input onclick='this.select();' oninput='myInputFunction()' type = 'number' id='page-number' value='" + currentPage + "'> <input id='urlVal' name='urlVal' type='hidden' value='" + url + "'></div> <p class='pages'>of<a href='" + url + maxPages + "' class='max-page'>  " + maxPages + "</a></p>";
      if (currentPage < maxPages)
      {
        paginationString = paginationString + "<a href='" + url + (currentPage + 1) + "' class='arrow-wrapper'><div class='material-icons-outlined material-icons arrow'> arrow_right</div></a>";
      }
      else
      {
        paginationString = paginationString + "<a disabled class='arrow-wrapper'><div class='material-icons-outlined material-icons arrow'> arrow_right</div></a>";
      }
      paginationString = paginationString + "</div>";
      if (maxPages <= 1)
      {
        paginationString = "";
      }
      //Get Pagintaion string end
      viewModel.PaginationString = paginationString;
      return View(viewModel);
    }
    /// <summary>
    /// Used to get Pledge Page data.
    /// </summary>
    /// <returns></returns>
    public ViewResult Pledge()
    {
      PledgeViewModel viewModel = new PledgeViewModel();
      Models.Pledge PledgePageContent = new Models.Pledge();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        PledgePageContent = _contentService.GetPledgePageContent(RenderingContext.Current.Rendering.DataSource);
      }
      else if (Sitecore.Context.Item != null)
      {
        PledgePageContent = _contentService.GetPledgePageContent(Sitecore.Context.Item.ID.ToString());
      }

      if (PledgePageContent != null)
      {
        viewModel.Id = PledgePageContent.Id;
        viewModel.Title = PledgePageContent.Title;
        viewModel.SubTitle = PledgePageContent.SubTitle;
        viewModel.RichText = PledgePageContent.RichText;
        viewModel.ProTabTex = PledgePageContent.ProTabText;
        viewModel.FacTabText = PledgePageContent.FacTabText;
        viewModel.ProPledgeTitle = PledgePageContent.ProPledgeTitle;
        viewModel.ProPledgeText = PledgePageContent.ProPledgeText;
        viewModel.FacPledgeTitle = PledgePageContent.FacPledgeTitle;
        viewModel.FacPledgeText = PledgePageContent.FacPledgeText;

      }

      return View(viewModel);
    }
    /// <summary>
    /// Used to get Pledges data for pledge counter to display from database.
    /// </summary>
    /// <returns></returns>
    public ViewResult PledgeCounter()
    {
      PledgeCounterViewModel viewModel = new PledgeCounterViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        PledgeCounter pledgeCounterContent = _contentService.GetPledgeCounterContent(RenderingContext.Current.Rendering.DataSource);
        if (pledgeCounterContent != null)
        {
          string date = "2021-10-13";
          if (pledgeCounterContent.Date != null)
          {
            date = pledgeCounterContent.Date.ToString("yyyy-MM-dd");
          }

          viewModel.Id = pledgeCounterContent.Id;
          viewModel.Title = pledgeCounterContent.Title;
          viewModel.DisplayCounter = false;
          int pledgeCount = _pledgeService.PledgesCount(date);
          if (pledgeCount >= pledgeCounterContent.MinimumPledgeCount)
          {
            viewModel.DisplayCounter = true;
          }

          viewModel.PledgeCount = pledgeCount;

        }
      }
      return View(viewModel);
    }
    public ViewResult BoxCallout()
    {
      BoxCallout viewModel = new BoxCallout();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        BoxCallout boxCallout = _contentService.GetBoxCalloutContent(RenderingContext.Current.Rendering.DataSource);
        if (boxCallout != null)
        {
          viewModel = boxCallout;

        }
      }
      return View(viewModel);
    }
    /// <summary>
    /// used to ajax submit invidual Pledge data to database.
    /// </summary>
    [HttpPost]
    public ActionResult ProPledgeSubmit(string firstName, string lastName, string email, string country, string capchaResponse)
    {
      bool isCaptchaValid = Helpers.RHECHelper.ValidateCaptcha(capchaResponse);
      bool isValidEmail = Helpers.RHECHelper.IsValidEmail(email);

      if (isCaptchaValid && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && isValidEmail && !string.IsNullOrEmpty(country))
      {
        Setting settingItem = GetSettingItem();
        string errorUrl = settingItem.PledgeErrorUrl;
        string successUrl = settingItem.PledgeSuccessUrl;
        try
        {
          //var settingItem = GetSettingItem();
          bool emailExists = _pledgeService.IsDuplicate(email);
          if (emailExists)
          {
            string erroMessage = settingItem.PledgeEmailExistsError;
            return Json(new { success = "unsuccessful", message = "EmailExists", existemail = email, errormsg = erroMessage });
          }

          Models.Pledge pledgeDetails = string.IsNullOrEmpty(settingItem.PledgePageId) ? _contentService.GetPledgePageContent("{B75C6C8E-632E-4670-862E-2B1405581A06}") : _contentService.GetPledgePageContent(settingItem.PledgePageId);

          if (!string.IsNullOrEmpty(pledgeDetails.ProEmailFrom) && !string.IsNullOrEmpty(pledgeDetails.ProEmailTo) && !string.IsNullOrEmpty(pledgeDetails.ProEmailBody) && !string.IsNullOrEmpty(pledgeDetails.ProEmailSubject))
          {

            MailAddress from = new MailAddress(pledgeDetails.ProEmailFrom);
            MailAddress to = new MailAddress(pledgeDetails.ProEmailTo);
            MailMessage emailMessage = new MailMessage(from, to);
            //var emailSubject = pledgeDetails.ProEmailSubject;
            emailMessage.Subject = pledgeDetails.ProEmailSubject;
            // var emailBody = pledgeDetails.ProEmailBody.Replace("[Fname]", firstName).Replace("[Lname]", lastName).Replace("[Email]", email).Replace("[Country]", country);
            emailMessage.Body = pledgeDetails.ProEmailBody.Replace("[Fname]", firstName).Replace("[Lname]", lastName).Replace("[Email]", email).Replace("[Country]", country);
            emailMessage.IsBodyHtml = true;
            Helpers.RHECHelper.SendEmail(emailMessage, "ACR internal");
            //MainUtil.SendMail(emailMessage);
          }
          bool saveData = _pledgeService.CreateIndividualPledge(firstName, lastName, email, country, pledgeDetails.ProEmailTo);
          if (!saveData)
          {
            return Json(new { success = "unsuccessful", message = "DataNotSaved", redirecturl = errorUrl });
          }


          if (!string.IsNullOrEmpty(pledgeDetails.ProConfirmEmailFrom) && !string.IsNullOrEmpty(pledgeDetails.ProConfirmEmailBody) && !string.IsNullOrEmpty(pledgeDetails.ProConfirmEmailSubject))
          {

            MailAddress from = new MailAddress(pledgeDetails.ProConfirmEmailFrom);
            MailAddress to = new MailAddress(email);
            MailMessage emailMessage = new MailMessage(from, to);
            //var emailSubject = pledgeDetails.ProEmailSubject;
            emailMessage.Subject = pledgeDetails.ProConfirmEmailSubject;
            // var emailBody = pledgeDetails.ProEmailBody.Replace("[Fname]", firstName).Replace("[Lname]", lastName).Replace("[Email]", email).Replace("[Country]", country);
            emailMessage.Body = pledgeDetails.ProConfirmEmailBody.Replace("[Fname]", firstName).Replace("[Lname]", lastName).Replace("[Email]", email).Replace("[Country]", country);
            emailMessage.IsBodyHtml = true;
            Helpers.RHECHelper.SendEmail(emailMessage, "To user");
            //MainUtil.SendMail(emailMessage);
          }
        }
        catch (Exception ex)
        {
          Sitecore.Diagnostics.Log.Error("Failed to submit individual pledge" + ex, "RHEC");
          return Json(new { success = "unsuccessful", message = "DataNotSaved", redirecturl = errorUrl });
        }
        return Json(new { success = "success", message = "pledge submitted", redirecturl = successUrl });
      }

      if (!isCaptchaValid)
      {
        return Json(new { success = "unsuccessful", message = "invalidCaptcha" });
      }

      if (!isValidEmail)
      {
        return Json(new { success = "unsuccessful", message = "invalidEmail" });
      }

      return Json(new { success = "unsuccessful", message = "error" });

    }
    /// <summary>
    /// Used to submit Facility Pledge Form.
    /// </summary>
 
    [HttpPost]
    public ActionResult FacPledgeSubmit(string faciityName, string city, string state, string zipcode, string firstName, string lastName, string email, string country, string capchaResponse)
    {
      bool isCaptchaValid = Helpers.RHECHelper.ValidateCaptcha(capchaResponse);
      bool isValidEmail = Helpers.RHECHelper.IsValidEmail(email);

      if (isCaptchaValid && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && isValidEmail && !string.IsNullOrEmpty(country) && !string.IsNullOrEmpty(faciityName) && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(zipcode))
      {
        Setting settingItem = GetSettingItem();
        string errorUrl = settingItem.PledgeErrorUrl;
        string successUrl = settingItem.PledgeSuccessUrl;
        if ((country== "United States" || country== "Canada") &&(state== "NotRequired" || zipcode== "NotRequired"))
        {
          return Json(new { success = "unsuccessful", message = "StateZipRequired" });
        }
        if (country!= "United States" && country != "Canada")
        {
          state = "";
          zipcode = "";
        }
        
        try
        {
          //var settingItem = GetSettingItem();
          //bool emailExists = _pledgeService.IsDuplicate(email);
          //if (emailExists)
          //{
          //  string erroMessage = settingItem.PledgeEmailExistsError;
          //  return Json(new { success = "unsuccessful", message = "EmailExists", existemail = email, errormsg = erroMessage });
          //}

          Models.Pledge pledgeDetails = string.IsNullOrEmpty(settingItem.PledgePageId) ? _contentService.GetPledgePageContent("{B75C6C8E-632E-4670-862E-2B1405581A06}") : _contentService.GetPledgePageContent(settingItem.PledgePageId);

          if (!string.IsNullOrEmpty(pledgeDetails.FacEmailFrom) && !string.IsNullOrEmpty(pledgeDetails.FacEmailTo) && !string.IsNullOrEmpty(pledgeDetails.FacEmailBody) && !string.IsNullOrEmpty(pledgeDetails.FacEmailSubject))
          {

            MailAddress from = new MailAddress(pledgeDetails.FacEmailFrom);
            MailAddress to = new MailAddress(pledgeDetails.FacEmailTo);
            MailMessage emailMessage = new MailMessage(from, to);
            //var emailSubject = pledgeDetails.ProEmailSubject;
            emailMessage.Subject = pledgeDetails.FacEmailSubject;
            // var emailBody = pledgeDetails.ProEmailBody.Replace("[Fname]", firstName).Replace("[Lname]", lastName).Replace("[Email]", email).Replace("[Country]", country);
            emailMessage.Body = pledgeDetails.FacEmailBody.Replace("[Facilityname]", faciityName).Replace("[State]", state).Replace("[City]", city).Replace("[Zip]", zipcode).Replace("[Fname]", firstName).Replace("[Lname]", lastName).Replace("[Email]", email).Replace("[Country]", country);
            emailMessage.IsBodyHtml = true;
            Helpers.RHECHelper.SendEmail(emailMessage, "Facility ACR internal");
            //MainUtil.SendMail(emailMessage);
          }
          bool saveData = _pledgeService.CreateFacilityPledge(faciityName, city, country, state, zipcode, firstName, lastName, email, pledgeDetails.ProEmailTo);
          if (!saveData)
          {
            return Json(new { success = "unsuccessful", message = "DataNotSaved", redirecturl = errorUrl });
          }


          if (!string.IsNullOrEmpty(pledgeDetails.FacConfirmEmailFrom) && !string.IsNullOrEmpty(pledgeDetails.FacConfirmEmailBody) && !string.IsNullOrEmpty(pledgeDetails.FacConfirmEmailSubject))
          {

            MailAddress from = new MailAddress(pledgeDetails.FacConfirmEmailFrom);
            MailAddress to = new MailAddress(email);
            MailMessage emailMessage = new MailMessage(from, to);
            //var emailSubject = pledgeDetails.ProEmailSubject;
            emailMessage.Subject = pledgeDetails.FacConfirmEmailSubject;
            // var emailBody = pledgeDetails.ProEmailBody.Replace("[Fname]", firstName).Replace("[Lname]", lastName).Replace("[Email]", email).Replace("[Country]", country);
            emailMessage.Body = pledgeDetails.FacConfirmEmailBody.Replace("[Facilityname]", faciityName).Replace("[State]", state).Replace("[City]", city).Replace("[Zip]", zipcode).Replace("[Fname]", firstName).Replace("[Lname]", lastName).Replace("[Email]", email).Replace("[Country]", country);
            emailMessage.IsBodyHtml = true;

            Helpers.RHECHelper.SendEmail(emailMessage, "Facility To user");
            //MainUtil.SendMail(emailMessage);
          }
        }
        catch (Exception ex)
        {
          Sitecore.Diagnostics.Log.Error("Failed to submit Facility pledge" + ex, "RHEC");
          return Json(new { success = "unsuccessful", message = "DataNotSaved", redirecturl = errorUrl });
        }
        return Json(new { success = "success", message = "pledge submitted", redirecturl = successUrl });
      }

      if (!isCaptchaValid)
      {
        return Json(new { success = "unsuccessful", message = "invalidCaptcha" });
      }

      if (!isValidEmail)
      {
        return Json(new { success = "unsuccessful", message = "invalidEmail" });
      }

      return Json(new { success = "unsuccessful", message = "error" });

    }

  }
}