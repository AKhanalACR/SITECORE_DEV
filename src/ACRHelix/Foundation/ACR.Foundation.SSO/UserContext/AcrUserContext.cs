using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.Utilities.Cookies;
using ACR.Foundation.Utilities.Session;
using ACR.Foundation.SSO.Logger;
using Sitecore.Diagnostics;
using ACR.Foundation.Personify.PersonifyService;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.SSO.AcrAuthentication.SSO;
using ACR.Foundation.SSO.Utils;
using ACR.Foundation.Personify.Helpers;

namespace ACR.Foundation.SSO.UserContext
{
  public class AcrUserContext : IUserContext
  {

    private const string AnonymousCartCookieName = "AnonumousTimssCMSUser";
    private string CurrentUserSessionKey = "cab03ea7-3a97-4ba8-ab00-52656e408254";
    private string CurrentCustomerTokenSessionKey = "63d81943-a16a-4417-a715-bfbf7ed2b5d8";
    private IAcrUser _currentUser;
    private IList<string> _productPersonifyIdsInCart;

    #region Implementation of IUserContext

    public IAcrUser CurrentUser
    {
      get
      {
        if (_currentUser == null)
        {
          // try to get from session
          _currentUser = SessionManager.GetSessionValue<IAcrUser>(CurrentUserSessionKey);
          // if still null make a new anonymous user and set into session
          if (_currentUser == null)
          {
            _currentUser = new AnonymousUser();
            SessionManager.SetSessionValue(CurrentUserSessionKey, _currentUser);
          }
        }
        return _currentUser;
      }
      private set
      {
        _currentUser = value;
        SessionManager.SetSessionValue(CurrentUserSessionKey, _currentUser);
      }
    }

    public string CurrentCustomerToken
    {
      get
      {
        return SessionManager.GetSessionValue<string>(CurrentCustomerTokenSessionKey);
      }
      private set
      {
        SessionManager.SetSessionValue(CurrentCustomerTokenSessionKey, value);
      }
    }

    public SSOCustomerAuthenticateResult Authenticate(string username, string password)
    {
      var result = AuthenticationUtil.Authenticate(username, password);
      if (!result.Result && result.Errors == null)
      {
        // Set an error so we know something went wrong.  If the creds fail there is no error returned.
        result.Errors = new string[] { "Your username or password was incorrect." };
      }
      return result;
    }

    public void Login(string username, string password, string redirectUrl)
    {
      if (HttpContext.Current == null)
      {
        SSOLogger.Logger.Error("AcrUserContext.Login: Could not execute Login redirect because HttpContext.Current was null.");
        return;
      }
      // If username and password are null, we are just pinging the login server to see if they're already logged in via SSO.
      bool noPrompt = string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password);

      // get SSO Login url
      string ssoUrl = AuthenticationUtil.ConstructSSOUrl(username, password, redirectUrl, noPrompt);
      SSOLogger.Logger.Debug(string.Format("AcrUserContext.Login: Attemping SSO Login Redirect for user {0}, pass {1}, redirectUrl {2}.\nConstructed URL is {3}.",
        username, password, redirectUrl, ssoUrl));
      // Execute the login redirect
      HttpContext.Current.Response.Redirect(ssoUrl, true);
    }
    public void LoginWithPrompt(string redirectUrl)
    {
      if (HttpContext.Current == null)
      {
        SSOLogger.Logger.Error("AcrUserContext.Login: Could not execute Login redirect because HttpContext.Current was null.");
        return;
      }
      // If username and password are null, we are just pinging the login server to see if they're already logged in via SSO.
      // bool noPrompt = string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password);

      // get SSO Login url
      string ssoUrl = AuthenticationUtil.ConstructSSOUrlWithPrompt(redirectUrl);
      SSOLogger.Logger.Debug(string.Format("AcrUserContext.Login: Attemping SSO Login Redirect for user {0}, pass {1}, redirectUrl {2}.\nConstructed URL is {3}.",
          "", "", redirectUrl, ssoUrl));
      // Execute the login redirect
      HttpContext.Current.Response.Redirect(ssoUrl, true);
    }
    public bool ValidateCustomerToken(string customerToken, bool forceRevalidate)
    {
      if (string.IsNullOrEmpty(customerToken))
      {
        // Something is wrong, log out
        Logout();
        return false;
      }

      // Check the token against the one stored in session
      if (customerToken == CurrentCustomerToken && !forceRevalidate)
      {
        // We're still logged in.
        return true;
      }

      SSOLogger.Logger.Info(string.Format("LOGIN AUDIT: Beginning ValidateCustomerToken for customerToken: {0}.", customerToken));
      var result = AuthenticationUtil.ValidateCustomerToken(customerToken);
      SSOLogger.Logger.Info(string.Format("LOGIN AUDIT: Finished ValidateCustomerToken for customerToken: {0}.", customerToken));

      if (result.Valid)
      {
        // Get the master customer id
        string customerId = AuthenticationUtil.GetVendorCustomerId(result.NewCustomerToken);
        if (string.IsNullOrEmpty(customerId))
        {
          SSOLogger.Logger.Error(string.Format("Could not get customer id from token {0}.", result.NewCustomerToken));
          ClearUserData();
          return false;
        }

        // Customer tokens are 1 time use only
        CurrentCustomerToken = result.NewCustomerToken;
        // NOTE: Not storing the customer token in a local cookie anymore. The login server creates and manages this cookie.
        //AuthenticationUtil.WriteCustomerTokenCookie(HttpContext.Current.Response, CurrentCustomerToken, false);

        //Customer ids are returned in the format: mastercustomerid + “|” + subcustomerid 
        string[] splitCustomerId = customerId.Split('|');
        //Load the user (if the customer IDs are different)
        if (CurrentUser.MasterCustomerID != splitCustomerId[0])
        {
          CurrentUser = new AcrUser(splitCustomerId[0].Trim(), splitCustomerId[1].Trim());
        }
        //Transfer items in cart if any
        SSOLogger.Logger.Info(string.Format("LOGIN AUDIT: Beginning TransferCart for customerToken: {0}.", customerToken));
        TransferCart(CurrentUser.MasterCustomerID);
        SSOLogger.Logger.Info(string.Format("LOGIN AUDIT: Beginning TransferCart for customerToken: {0}.", customerToken));

        return true;
      }

      // Otherwise, clear user data because we have a bad token. (no need to log out, the token is bad already)
      ClearUserData();
      return false;
    }
    public bool ValidateCustomerToken(string customerToken, bool forceRevalidate, bool checkInternationalUsers)
    {
      if (string.IsNullOrEmpty(customerToken))
      {
        // Something is wrong, log out
        Logout();
        return false;
      }

      // Check the token against the one stored in session
      if (customerToken == CurrentCustomerToken && !forceRevalidate)
      {
        // We're still logged in.
        return true;
      }

      var result = AuthenticationUtil.ValidateCustomerToken(customerToken);
      if (result.Valid)
      {
        // Get the master customer id
        string customerId = AuthenticationUtil.GetVendorCustomerId(result.NewCustomerToken);
        if (string.IsNullOrEmpty(customerId))
        {
          SSOLogger.Logger.Error(string.Format("Could not get customer id from token {0}.", result.NewCustomerToken));
          ClearUserData();
          return false;
        }

        // Customer tokens are 1 time use only
        CurrentCustomerToken = result.NewCustomerToken;
        // NOTE: Not storing the customer token in a local cookie anymore. The login server creates and manages this cookie.
        //AuthenticationUtil.WriteCustomerTokenCookie(HttpContext.Current.Response, CurrentCustomerToken, false);

        //Customer ids are returned in the format: mastercustomerid + “|” + subcustomerid 
        string[] splitCustomerId = customerId.Split('|');

        //check if user is an international user 
        //why do we care if international user???
        //if (!AuthenticationUtil.IsInternationalUser(splitCustomerId[0].Trim()))
        //{
          //Load the user (if the customer IDs are different)
          if (CurrentUser.MasterCustomerID != splitCustomerId[0])
          {
            CurrentUser = new AcrUser(splitCustomerId[0].Trim(), splitCustomerId[1].Trim(), false);
          }
          return true;
        //}
        //else
        //{
        //  if (CurrentUser.MasterCustomerID != splitCustomerId[0])
        //  {
        //    CurrentUser = new AcrUser(splitCustomerId[0].Trim(), splitCustomerId[1].Trim(), true);
        //  }
        //  return false;
        //}


      }

      // Otherwise, clear user data because we have a bad token. (no need to log out, the token is bad already)
      ClearUserData();
      return false;
    }

    public SSOCustomerLogoutResult Logout()
    {
      var result = AuthenticationUtil.Logout(CurrentCustomerToken);
      ClearUserData();
      return result;
    }

    /// <summary>
    /// Adds product to the shopping cart with a default quantity of 1
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public bool AddToCart(ProductStubItem product, bool saveForLater = false)
    {
      //return AddToCart(product.PersonifyID );   
      PersonifyEntitiesACR cart = new PersonifyEntitiesACR();
      bool success = cart.AddToCart(CurrentUser.MasterCustomerID, CurrentUser.SubCustomerID, product.PersonifyID, !CurrentUser.IsAnonymous, product.GetProductSubsytem(),saveForLater);
      if (success)
      {
        // Add the id to our local cart copy, if we have it, to keep in sync.
        if (_productPersonifyIdsInCart != null)
        {
          _productPersonifyIdsInCart.Add(product.PersonifyID);
        }
        return true;
      }
      return false;
    }

    /// <summary>
    /// Gets the number of product order lines in the cart
    /// </summary>
    /// <returns>int</returns>
    public int GetCartOrderLineCount()
    {
      PersonifyEntitiesACR cart = new PersonifyEntitiesACR();

      //int count = cart.GetCartProductCount(CurrentUser.MasterCustomerID, CurrentUser.SubCustomerID);
      //int count2 = cart.GetCartProductIds(CurrentUser.MasterCustomerID, CurrentUser.SubCustomerID).Count;
      //return Math.Max(count1, count2);
      //return 0;
      return cart.GetCartProductCount(CurrentUser.MasterCustomerID, CurrentUser.SubCustomerID);
    }

    public IList<string> ProductPersonifyIdsInCart()
    {
      if (_productPersonifyIdsInCart == null)
      {
        if (String.IsNullOrEmpty(CurrentUser.MasterCustomerID))
        {
          return new List<string>();
        }
        PersonifyEntitiesACR cart = new PersonifyEntitiesACR();
        //note: for anonym users the MasterCustomerId has been set as the session id, and subcustomerid is 0
        _productPersonifyIdsInCart = cart.GetCartProductIds(CurrentUser.MasterCustomerID, CurrentUser.SubCustomerID);
      }
      return _productPersonifyIdsInCart;
    }
    #endregion


    /// <summary>
    /// Transfers cart contents from an anonymous user to an authenticated user
    /// </summary>
    public void TransferCart(string masterCustomerId)
    {
      if (!CurrentUser.IsAuthenticated || String.IsNullOrEmpty(masterCustomerId))
        return;

      string anonymousCartGuid = String.Empty;
      //Anonymous users had there session id guid stored in a cookie to track their cart actions
      //Retireve that cookie 
      HttpCookie cartCookie = CookieUtil.GetCookie(AnonymousCartCookieName);
      if (cartCookie != null)
      {
        anonymousCartGuid = cartCookie.Value;
      }

      //Only call TransferCart if the anonymous user has a shopping cart already started,
      //and therefore the tracking cookie exists.
      if (anonymousCartGuid != String.Empty)
      {
        PersonifyEntitiesACR cart = new PersonifyEntitiesACR();
        if (cart.TransferCart(masterCustomerId, CurrentUser.SubCustomerID, anonymousCartGuid))
        {
          CookieUtil.DeleteCookie(AnonymousCartCookieName);
        }
      }
    }

    private void ClearUserData()
    {
      // Clear customer token cookie, customer ID Cookie, session value, and current user.
      //AuthenticationUtil.DeleteCustomerTokenCookie(HttpContext.Current.Response);
      AuthenticationUtil.DeleteCustomerIdCookie(HttpContext.Current.Response);
      CurrentUser.ClearProfile();
      CurrentCustomerToken = null;
      CurrentUser = null;
      CookieUtil.DeleteCookie(AnonymousCartCookieName);
    }
  }
}