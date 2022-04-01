using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.SSO.Logger;
using ACR.Foundation.SSO.Users;
using Sitecore.Data.Items;
using ACR.Foundation.Utilities.Url;
using Sitecore.Links;
using ACR.Foundation.SSO.Settings;

namespace ACR.Foundation.SSO.Utils
{
  public static class AcrSsoUtil
  {
    public static void CheckSsoState(HttpContext httpContext, Item contextItem)
    {
      // Check context
      if (httpContext == null)
      {       
        SSOLogger.Logger.Error("AcrSsoUtil: HttpApplication context not available.");
        return;
      }

      // Check session NOTE: session not always avaialble, that's ok, just stop processing
      if (httpContext.Session == null)
      {
        SSOLogger.Logger.Debug("AcrSsoUtil: Session not ready. Aborting.");
        return;
      }

      // If there's not Context item, return.
      if (contextItem == null)
      {
        return;
      }

      // If we're in Fake User Mode, just return
      /*
      if (UserManager.FakeUserMode)
      {
        return;
      }*/

      // NOTE: No need to pass params to check SSO state anymore.  But, I am leaving this code here in case things change, as they often do.

      // Check the "ssologgedin" param, which means the request came from another ACR site where the user should have already logged in.
      //if (!string.IsNullOrEmpty(httpContext.Request.Params[AcrConstants.SSOParams.SSOLoggedIn]) 
      //  && httpContext.Request.Params[AcrConstants.SSOParams.SSOLoggedIn] == "y")
      //{
      //  // If it's true, try to get a customer token.
      //  SSOLogger.Logger.Debug("AcrSsoUtil: ssologgedin param detected, attempting to redirect to retrieve customer token.");
      //  UserManager.CurrentUserContext.Login(string.Empty, string.Empty,
      //    UrlUtil.RemoveParameterFromUrl(GetOriginalUrl(httpContext, contextItem), AcrConstants.SSOParams.SSOLoggedIn));
      //  return;
      //}

      // BEGIN: Check the customer token
      string customerToken = AuthenticationUtil.GetCustomerToken(httpContext.Request);
      if (!string.IsNullOrEmpty(customerToken))
      {
        string redirectUrl = UrlUtil.RemoveParameterFromUrl(GetOriginalUrl(httpContext, contextItem), SSOSettings.SSOCustomerTokenParam);
        // no more product detail page items
        /*
        if (contextItem.TemplateID.ToString() == ProductDetailPageItem.TemplateId)
        {
          redirectUrl = UrlUtil.RemoveParameterFromUrl(httpContext.Request.Url.ToString(), SSOSettings.SSOCustomerTokenParam);
        }*/

        bool validated = UserManager.CurrentUserContext.ValidateCustomerToken(customerToken, false);
        if (validated)
        {
          SSOLogger.Logger.Debug(string.Format("Token {0} was validated.", customerToken));
          // If the token was stored in a cookie no need to redirect, otherwise
          // redirect to the url without the CT param
          if (!string.IsNullOrEmpty(httpContext.Request.Params[SSOSettings.SSOCustomerTokenParam]))
          {
            httpContext.Response.Redirect(redirectUrl, true);
          }
        }
        else
        {
          // The token was invalid, call login with no username/pass so we're sent to the SSO login page.
          //UserManager.CurrentUserContext.Login(string.Empty, string.Empty, redirectUrl);
          return;
        }
      }
      // END: Check customer token

      // BEGIN: Check Customer ID cookie
      // This cookie is set by login.acr.org when the user logs in, and is global to the .acr.org domain.
      string customerId = AuthenticationUtil.ReadCustomerIdCookie(httpContext.Request);
      if (string.IsNullOrEmpty(customerId) && UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        // If the cookie does not exist, and we're logged in, we must log the user out.
        UserManager.CurrentUserContext.Logout();

        //refresh page
        httpContext.Response.Redirect(httpContext.Request.RawUrl, true);
        return;
      }
      // If the cookie does exist, we must log the user in if he's not logged in.
      if (!string.IsNullOrEmpty(customerId) && !UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        // The token was invalid, call login with no username/pass so we're sent to the SSO login page.
        UserManager.CurrentUserContext.Login(string.Empty, string.Empty, GetOriginalUrl(httpContext, contextItem));
        return;
      }
      // END: Check Customer ID cookie

      // BEGIN: Check profile update cookie
      string profileUpdate = AuthenticationUtil.ReadUpdateProfileCookie(httpContext.Request);
      if (!string.IsNullOrEmpty(profileUpdate) && profileUpdate.ToLower() == "yes"
        && UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
      {
        // Delete the profile saved in session. It will reload the next time it is accessed.
        UserManager.CurrentUserContext.CurrentUser.ClearProfile();
        AuthenticationUtil.WriteUpdateProfileCookie(httpContext.Response);
      }
      // END: Check profile update cookie

    }

    public static bool IsAuthorized(HttpContext httpContext, Item contextItem)
    {
      //check for the current user if logged in already
      if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
        return true;

      if (UserManager.CurrentUserContext.CurrentUser.MasterCustomerID != null)
      {
        if (UserManager.CurrentUserContext.CurrentUser.IsInternationalUser)
          return false;
      }
      // Check context
      if (httpContext == null)
      {
        SSOLogger.Logger.Error("AcrSsoUtil: HttpApplication context not available.");
        return false;
      }

      // Check session NOTE: session not always avaialble, that's ok, just stop processing
      if (httpContext.Session == null)
      {
        SSOLogger.Logger.Debug("AcrSsoUtil: Session not ready. Aborting.");
        return false;
      }

      // If there's not Context item, return.
      if (contextItem == null)
      {
        return false;
      }

      // If we're in Fake User Mode, just return
      if (UserManager.FakeUserMode)
      {
        return false;
      }


      // BEGIN: Check the customer token
      string customerToken = AuthenticationUtil.GetCustomerToken(httpContext.Request);

      if (!string.IsNullOrEmpty(customerToken))
      {
        bool validated = UserManager.CurrentUserContext.ValidateCustomerToken(customerToken, false, true);
        if (validated)
        {
          SSOLogger.Logger.Debug(string.Format("Token {0} was validated.", customerToken));
          return true;
        }
        else
        {
          //// The token was invalid, call login with no username/pass so we're sent to the SSO login page.
          //UserManager.CurrentUserContext.Login(string.Empty, string.Empty, redirectUrl);
          // UserManager.CurrentUserContext.Logout();
          return false;
        }
      }
      else
      {
        return false;
      }

      // END: Check customer token                              

    }
    private static string GetOriginalUrl(HttpContext httpContext, Item contextItem)
    {
      if (httpContext == null || contextItem == null)
      {
        return string.Empty;
      }

      UrlOptions opts = UrlOptions.DefaultOptions;
      opts.AlwaysIncludeServerUrl = true;
      return UrlUtil.CreateUrl(LinkManager.GetItemUrl(contextItem, opts), httpContext.Request.QueryString);
    }

        public static void CheckSsoStateRadpac(HttpContext httpContext, Item contextItem)
        {
            // Check context
            if (httpContext == null)
            {
                SSOLogger.Logger.Error("AcrSsoUtil: HttpApplication context not available.");
                return;
            }

            // Check session NOTE: session not always avaialble, that's ok, just stop processing
            if (httpContext.Session == null)
            {
                SSOLogger.Logger.Debug("AcrSsoUtil: Session not ready. Aborting.");
                return;
            }

            // If there's not Context item, return.
            if (contextItem == null)
            {
                return;
            }

            
            // BEGIN: Check the customer token
            string customerToken = AuthenticationUtil.GetCustomerToken(httpContext.Request);            
            if (!string.IsNullOrEmpty(customerToken))
            {
                string redirectUrl = UrlUtil.RemoveParameterFromUrl(GetOriginalUrl(httpContext, contextItem), SSOSettings.SSOCustomerTokenParam);

                var cusId = AuthenticationUtil.GetSSOUserCutomerId(customerToken);
                httpContext.Session["radpaccustomerId"] = cusId;
                
                bool validated = UserManager.CurrentUserContext.ValidateCustomerToken(customerToken, false);
                if (validated)
                {
                    SSOLogger.Logger.Debug(string.Format("Token {0} was validated.", customerToken));
                    // If the token was stored in a cookie no need to redirect, otherwise
                    // redirect to the url without the CT param
                    if (!string.IsNullOrEmpty(httpContext.Request.Params[SSOSettings.SSOCustomerTokenParam]))
                    {
                        httpContext.Response.Redirect(redirectUrl, true);
                    }
                }
                else
                {
                    // The token was invalid, call login with no username/pass so we're sent to the SSO login page.
                    //UserManager.CurrentUserContext.Login(string.Empty, string.Empty, redirectUrl);
                    return;
                }
            }
            // END: Check customer token

            // BEGIN: Check Customer ID cookie
            // This cookie is set by login.acr.org when the user logs in, and is global to the .acr.org domain.

            string customerId = httpContext.Session["radpaccustomerId"] != null ? httpContext.Session["radpaccustomerId"].ToString() : null;
            if (string.IsNullOrEmpty(customerId) && UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
            {
                // If the cookie does not exist, and we're logged in, we must log the user out.
                UserManager.CurrentUserContext.Logout();

                //refresh page
                httpContext.Response.Redirect(httpContext.Request.RawUrl, true);
                return;
            }
            // If the cookie does exist, we must log the user in if he's not logged in.
            if (!string.IsNullOrEmpty(customerId) && !UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
            {
                // The token was invalid, call login with no username/pass so we're sent to the SSO login page.
                UserManager.CurrentUserContext.Login(string.Empty, string.Empty, GetOriginalUrl(httpContext, contextItem));
                return;
            }
        }
    }
}