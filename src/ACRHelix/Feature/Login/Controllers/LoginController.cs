using ACR.Foundation.SSO.Logger;
using ACR.Foundation.SSO.Profile;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.SSO.Utils;
using ACR.Foundation.Utilities.Url;
using ACRHelix.Feature.Login.Services;
using ACRHelix.Feature.Login.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ACRHelix.Feature.Login
{
  public class LoginController : Controller
  {
    private readonly IContentService _contentService;

    public LoginController(IContentService contentService)
    {
      _contentService = contentService;
    }

    [HttpGet]
    public ActionResult LoginForm()
    {
      var viewModel = new LoginViewModel();

      var LoginContent = _contentService.GetLoginContent(Sitecore.Context.Item.ID.ToString());
      if (LoginContent != null)
      {
        viewModel = new LoginViewModel(LoginContent);

        string customerRememberMeCookie = AuthenticationUtil.ReadCustomerRememberMeCookie(System.Web.HttpContext.Current.Request);
        if (!String.IsNullOrEmpty(customerRememberMeCookie))
        {
          viewModel.Username = customerRememberMeCookie;
          viewModel.RememberMe = true;
        }

      }

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LoginForm(LoginViewModel login)
    {
      var viewModel = new LoginViewModel();

      string username = login.Username;
      string password = login.Password;

      var LoginContent = _contentService.GetLoginContent(Sitecore.Context.Item.ID.ToString());
      if (LoginContent != null)
      {
        viewModel = new LoginViewModel(LoginContent);
        viewModel.Username = username;
        viewModel.RememberMe = login.RememberMe;
      }

      if (login.HiddenCaptcha == "login" && !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
      {
        SSOLogger.Logger.Info("LOGIN AUDIT: About to initiate login authentiation from widget.");
        var loginResult = UserManager.CurrentUserContext.Authenticate(username, password);
        SSOLogger.Logger.Info("LOGIN AUDIT: Completed login authentication from widget.");

        if (loginResult.Result)
        {
          if (login.RememberMe)
          {
            AuthenticationUtil.WriteCustomerRememberMeCookie(System.Web.HttpContext.Current.Response, username, true);
          }
          else
          {
            AuthenticationUtil.DeleteCustomerRememberMeCookie(System.Web.HttpContext.Current.Response);
          }

          string redirectUrl = Request.QueryString["returnUrl"];
          if (string.IsNullOrWhiteSpace(redirectUrl))
          {
            redirectUrl = ItemUrls.GetDashboardUrl();
          }
          if (redirectUrl.StartsWith("/"))
          {
            redirectUrl = Request.Url.Scheme + "://" + Request.Url.Host + redirectUrl;
          }
          UserManager.CurrentUserContext.Login(username, password, redirectUrl);
          return null;
        }
        else
        {
          viewModel.LoginError = true;
          return View(viewModel);
        }
      }
      else
      {
        viewModel.LoginError = true;
        return View(viewModel);
      }
    }

    [HttpGet]
    public ViewResult LoginTest()
    {
      var viewModel = new LoginTestViewModel();

      viewModel = PopulateViewModel(viewModel);

      return View(viewModel);
    }

    private LoginTestViewModel PopulateViewModel(LoginTestViewModel viewModel)
    {
      try
      {
        viewModel.PersonifyIDs = UserManager.CurrentUserContext.ProductPersonifyIdsInCart().ToList();
        viewModel.CustomerToken = UserManager.CurrentUserContext.CurrentCustomerToken;

        var acrUser = (AcrUser)UserManager.CurrentUserContext.CurrentUser;
        var profile = (AcrUserProfile)acrUser.Profile;

        viewModel.UserProfile = JsonConvert.SerializeObject(profile, Formatting.Indented);
        viewModel.UserData = JsonConvert.SerializeObject(acrUser, Formatting.Indented);

        viewModel.Interests = profile.Interests.ToList();
        viewModel.Modalities = profile.Modalities.ToList();
        viewModel.Subspecialties = profile.Subspecialities.ToList();

        Type log = typeof(AcrUserProfile);
        PropertyInfo[] props = log.GetProperties();
        foreach (var p in props)
        {
          try
          {
            viewModel.InfoPairs.Add(new KeyValuePair<string, string>(p.Name, p.GetValue(profile).ToString()));
          }
          catch { }
        }
      }
      catch (Exception ex)
      {

      }
      return viewModel;
    }

    /*
    [HttpPost]
    public ViewResult LoginTest(LoginTestViewModel viewModel)
    {

      string pid = "1214344390";

      ProductSearchManager psm = new ProductSearchManager();

      var presults = ProductSearchManager.GetProducts(pid);

      viewModel = PopulateViewModel(viewModel);

      
      return View(viewModel);
    }*/

  }
}