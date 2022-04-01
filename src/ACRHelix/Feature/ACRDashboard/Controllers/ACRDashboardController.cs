using ACR.Foundation.Personify.Models.Taxonomy;
using ACR.Foundation.Personify.PersonifyService;
using ACR.Foundation.Personify.Settings;
using ACR.Foundation.SSO.Profile;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.Utilities.Session;
using ACRHelix.Feature.ACRDashboard.Entity;
using ACRHelix.Feature.ACRDashboard.Models;
using ACRHelix.Feature.ACRDashboard.Services;
using ACRHelix.Feature.ACRDashboard.ViewModels;
using Newtonsoft.Json;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ACRHelix.Feature.ACRDashboard
{
  public class ACRDashboardController : Controller
  {
    private readonly IContentService _contentService;
    private Dictionary<string, string> _optinCode;
    private string _communicationPreferencesItemId;

    public ACRDashboardController(IContentService contentService)
    {
      _contentService = contentService;
      _optinCode = new Dictionary<string, string>()
      {
        { "aCRAdvocacyinActionOptIn", "ADVOCACY" },
        { "aCRMemberUpdateOptIn", "WMU" },
        { "insideQualityandSafetyOptIn", "QS_NEWSLETTER" },
        { "rFSeNewsOptIn", "RFS" },
        { "sRSOptIn", "SRS_ENEWS" },
        { "cMEUpdateOptIn", "EDU_UPDATE" },
        { "yPSeNewsOptIn", "YPS" },
        { "digitalACRBulletinOptIn", "BULLETIN" },
        { "digitalJACROptIn", "JACR_TOC" },
        { "annualMeetingOptIn", "ANL_MTG" },
        { "edCenterOptIn", "EDU_UPDATE" },
        { "americanInstituteforRadiologicPathologyOptIn", "AIRP_LUMINARY" },
        { "caseinPointOptIn", "DAILY_CIP" },
        { "qualityandSafetyOptIn", "QS_NEWSLETTER" },
        { "rLIOptIn", "RLI_UPDATE" },
        { "dSIOptIn", "DSI_UPDATE" },
        { "healthPolicyInstituteOptIn", "HPI_UPDATE" },
        { "aCRFoundationOptIn", "ACRF_UPDATE" }
      };
      _communicationPreferencesItemId = "{B04036A8-6549-4784-B0D8-1233D998BC79}";

    }


    public ViewResult MyACRDashboard()
    {
      var viewModel = new ACRDashboardViewModel();

      var dashboardSettings = _contentService.GetACRDashboardContent(Sitecore.Context.Item.ID);
      if (dashboardSettings != null)
      {
        viewModel.DashboardModel = dashboardSettings;
      }
      viewModel.MyBookmarks = new List<BookmarkViewModel>();
      viewModel.ReccomendedArticles = new List<BookmarkViewModel>();

      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        viewModel.MessageCount = UserManager.CurrentUserContext.CurrentUser.Profile.MessagesCount;

        var personifyId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
        //set default quick links if not yet set
        bool linksInit = DashboardDataService.QuickLinksInitialized(personifyId);
        if (!linksInit)
        {
          DashboardDataService.AddDashboardLinks(_contentService.GetDefaultQuickLinks(), personifyId);
          DashboardDataService.InitializeQuickLinks(personifyId);
        }

        var bookmarks = DashboardDataService.GetMyBookmarks(personifyId);
        var articles = DashboardDataService.GetRecommendedArticles();


        foreach (var bm in bookmarks)
        {
          var item = Sitecore.Context.Database.GetItem(ID.Parse(bm.SitecoreID));
          if (item != null)
          {
            string url = Sitecore.Links.LinkManager.GetItemUrl(item);
            string title = item.Fields["Title"].Value;

            viewModel.MyBookmarks.Add(new BookmarkViewModel()
            {
              Bookmark = bm,
              Title = title,
              Url = url
            });
          }
        }
        foreach (var a in articles)
        {
          var item = Sitecore.Context.Database.GetItem(ID.Parse(a.SitecoreID));
          if (item != null)
          {
            string url = Sitecore.Links.LinkManager.GetItemUrl(item);
            string title = item.Fields["Title"].Value;

            viewModel.ReccomendedArticles.Add(new BookmarkViewModel()
            {
              Article = a,
              Title = title,
              Url = url
            });
          }
        }
      }

      viewModel = SetMemberInformation(viewModel);
      viewModel = SetCME(viewModel);

      //Add Quick link for Physicists 
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var personifyId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;

        bool isPhysicist = false;

       //default values
       //string title = "Medical Physicist Resources";
       //string url = "https://www.acr.org/Clinical-Resources/Medical-Physics-Resources";

       string title = ACRSettings.PhysicistQuickLinkTitle;
       string url = ACRSettings.PhysicistQuickLinkURL;

        string CurrentUserProfileSessionKey = "f599f85a-a105-4081-8f3a-90607e2199b7";
        IAcrProfile _currentUserProfile = SessionManager.GetSessionValue<IAcrProfile>(CurrentUserProfileSessionKey);
        if (_currentUserProfile == null)
        {
          _currentUserProfile = new AcrUserProfile(personifyId, "0");
          SessionManager.SetSessionValue(CurrentUserProfileSessionKey, _currentUserProfile);
        }        

        if (_currentUserProfile.Roles.Count > 0)
        {
          foreach (PersonifyTaxonomyItem role in _currentUserProfile.Roles)
          {            
            if (role.Name == "PHYSICIST")
              isPhysicist = true;
          }          
        } 
        DashboardDataService.Set_RoleBased_QuickLinks(personifyId, title, url, isPhysicist);

        //--- Opt-in code query string
        PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
        string email = svc.GetCustomerInfo(UserManager.CurrentUserContext.CurrentUser.MasterCustomerID, UserManager.CurrentUserContext.CurrentUser.SubCustomerID).Email;
        if (!string.IsNullOrEmpty(email))
        {
          var informzData = svc.GetInformzCustomerData(email);
          var optinString = informzData.OptInCodes;
          string querystring = "?Email=" + email + "&";

          if (!string.IsNullOrEmpty(optinString))
          {
            var optinCodesArray = optinString.Split('|');
            foreach (var st in optinCodesArray)
            {
              foreach (var code in _optinCode)
              {
                if (code.Value == st)
                {
                  querystring = querystring + code.Key + "=yes&";
                }
              }
            }
            querystring = querystring.Substring(0, querystring.Length - 1);
          }

          foreach (var lnk in viewModel.DashboardModel.SideNavigationItems)
          {
            if (lnk.Id.ToString() == _communicationPreferencesItemId)
            {
              lnk.Link.Url = lnk.Link.Url + querystring;
            }
          }
        }
        //---
      }
      return View(viewModel);
    }

    public ActionResult DeleteBookmark(string id)
    {
      bool success = false;
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var iid = Convert.ToInt32(id);
        success = DashboardDataService.DeleteBookmark(iid);
      }
      string message = "";
      if (success)
      {
        message = string.Format("Bookmark {0} deleted", id);
      }
      else
      {
        message = "Error deleting bookmark: " + id;
      }
      BookmarkJsonResult result = new BookmarkJsonResult() { Message = message };
      return Content(JsonConvert.SerializeObject(result, Formatting.Indented), "application/json");
    }


    public ActionResult AddBookmark(string id)
    {
      BookmarkJsonResult result = new BookmarkJsonResult();
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var personifyId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
        DashboardDataService.AddBookmark(personifyId, id);

        ID scid = ID.Parse(id);

        string title = Sitecore.Context.Database.GetItem(scid).Fields["Title"].Value;
        result.Message = string.Format("Success! You have added {0} to your reading list", title);
        result.Success = true;
      }
      else
      {
        result.Message = "Error, you must be logged in to create bookmarks";
        result.Success = false;
      }


      return Content(JsonConvert.SerializeObject(result, Formatting.Indented), "application/json");
    }

    public ActionResult AddReccomendedArticle(string id)
    {
      BookmarkJsonResult result = new BookmarkJsonResult();
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var personifyId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
        DashboardDataService.AddRecommended(personifyId, id);

        ID scid = ID.Parse(id);

        string title = Sitecore.Context.Database.GetItem(scid).Fields["Title"].Value;
        result.Message = string.Format("Success! You have recommended {0}", title);
        result.Success = true;
      }
      else
      {
        result.Success = false;
        result.Message = "Error, you must be logged in to reccommend articles";
      }

      return Content(JsonConvert.SerializeObject(result, Formatting.Indented), "application/json");
    }

    public ViewResult DashboardLinks()
    {
      var viewModel = new DashboardLinksViewModel();

      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var personifyId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
        //display quick links
        var links = DashboardDataService.GetDashboardLinks(personifyId);
        viewModel.MyLinks = links;
      }
      return View(viewModel);
    }

    [HttpGet]
    public ViewResult DashboardLinksModal()
    {
      var model = new DashboardLinksViewModel();
      model = DisplayDashboardLinks(model);
      return View(model);
    }

    private DashboardLinksViewModel DisplayDashboardLinks(DashboardLinksViewModel model)
    {
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var personifyId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
        model.MyLinks = DashboardDataService.GetDashboardLinks(personifyId);
        model.AllLinks = new List<ViewModelQuickLink>();

        //viewModel.AllLinks.AddRange(viewModel.MyLinks);
        foreach (var link in model.MyLinks)
        {
          model.AllLinks.Add(new ViewModelQuickLink(link, true));
        }

        var links = _contentService.GetSitecoreQuickLinks();
        foreach (var link in links)
        {
          var qlink = new QuickLink()
          {
            LinkName = link.LinkText,
            LinkUrl = link.Link.Url,
            PersonifyID = null
          };
          if (model.AllLinks.FirstOrDefault(x => x.LinkName == qlink.LinkName && x.LinkUrl == qlink.LinkUrl) == null)
          {
            model.AllLinks.Add(new ViewModelQuickLink(link, false));
          }
        }

      }
      return model;
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ViewResult DashboardLinksModal(DashboardLinksViewModel model)
    {
      var addLinks = new List<QuickLink>();
      var deleteLinks = new List<QuickLink>();

      var personifyId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
      model.MyLinks = DashboardDataService.GetDashboardLinks(personifyId);

      foreach (var link in model.AllLinks)
      {
        var existingLink = model.MyLinks.FirstOrDefault(x => x.LinkName == link.LinkName && x.LinkUrl == link.LinkUrl);
        if (link.Checked)
        {
          if (existingLink == null)
          {
            addLinks.Add(link);
          }
        }
        else
        {
          if (existingLink != null)
          {
            deleteLinks.Add(existingLink);
          }
        }
      }

      if (!string.IsNullOrWhiteSpace(model.LinkUrl))
      {
        if (!string.IsNullOrWhiteSpace(model.LinkText))
        {
          var hasHttp = model.LinkUrl.ToLower().StartsWith("http://");
          var hasHttps = model.LinkUrl.ToLower().StartsWith("https://");

          if (hasHttp == false && hasHttps == false)
          {
            model.LinkUrl = "http://" + model.LinkUrl;
          }

          List<QuickLink> customLink = new List<QuickLink>();
          customLink.Add(new QuickLink() { LinkName = model.LinkText, LinkUrl = model.LinkUrl, PersonifyID = personifyId });
          DashboardDataService.AddDashboardLinks(customLink, personifyId);
          model.Updated = true;
          model.LinkUrl = model.LinkText = string.Empty;
        }
      }

      if (addLinks.Count > 0)
      {
        model.Updated = true;
        DashboardDataService.AddDashboardLinks(addLinks, personifyId);
      }
      if (deleteLinks.Count > 0)
      {
        model.Updated = true;
        DashboardDataService.DeleteDashboardLinks(deleteLinks);
      }

      model = DisplayDashboardLinks(model);

      return View(model);
    }

    private ACRDashboardViewModel SetCME(ACRDashboardViewModel viewModel)
    {
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        var cme = viewModel.User.GetACRCMECredits();

        viewModel.CMECredits = cme.Value;
        viewModel.DisplayCME = cme.Key;
      }
      else
      {
        viewModel.CMECredits = 0.0;
        viewModel.DisplayCME = true;
      }

      return viewModel;
    }

    private ACRDashboardViewModel SetMemberInformation(ACRDashboardViewModel viewModel)
    {
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        viewModel.FullName = UserManager.CurrentUserContext.CurrentUser.Profile.LabelName;

        viewModel.User = UserManager.CurrentUserContext.CurrentUser;
        if (viewModel.User != null)
        {
          if (viewModel.User.Profile != null)
          {
            if (viewModel.User.Profile.Committees != null)
            {
              if (viewModel.User.Profile.Committees.Any())
              {
                viewModel.ChapterComissionsCommittees = new Dictionary<string, List<string>>();
                foreach (var comm in viewModel.User.Profile.Committees)
                {
                  if (viewModel.ChapterComissionsCommittees.ContainsKey(comm.Key))
                  {
                    viewModel.ChapterComissionsCommittees[comm.Key].Add(comm.Value);
                  }
                  else
                  {
                    viewModel.ChapterComissionsCommittees.Add(comm.Key, new List<string>() { comm.Value });
                  }
                }
              }
            }
            if (viewModel.User.Profile.MemberStatus == ACR.Foundation.SSO.Profile.MemberStatus.NonMember)
            {
              viewModel.RenewOrJoinText = "Join";
              viewModel.RenewOrJoinLink = ACRSettings.BecomeAMemberLink;
            }
            else
            {
              viewModel.RenewOrJoinText = "Renew Now";
              viewModel.RenewOrJoinLink = ACRSettings.RenewMembershipLink;
            }
          }
          var address = viewModel.User.GetCustAddrInfo();
          if (address != null)
          {
            viewModel.Address = FormatAddress(address);
          }
        }
      }
      else
      {
        viewModel.FullName = "Not Authenticated User";
        viewModel.RenewOrJoinText = "Join";
        viewModel.RenewOrJoinLink = ACRSettings.BecomeAMemberLink;
      }
      return viewModel;
    }

    private static string FormatAddress(ACR.Foundation.Personify.PersonifyDS.PdsCustAddrInfo address)
    {

      StringBuilder sb = new StringBuilder();
      sb.Append(address.Address1);
      if (sb.Length > 0)
      {
        sb.Append(", ");
      }
      sb.Append(address.Address2);
      if (sb.Length > 0)
      {
        sb.Append("<br>");
      }
      sb.Append(address.City);
      if (address.City.Length > 0)
      {
        sb.Append(", ");
      }
      sb.Append(address.State + " ");
      sb.Append(address.PostalCode);
      return sb.ToString();
    }
  }
}