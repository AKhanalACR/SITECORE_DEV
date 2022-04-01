using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models;
using ACR.Foundation.Personify.PersonifyDS;
using ACR.Foundation.SSO.Profile;
using ACR.Foundation.Utilities.Cookies;
using RequiredAccess = ACR.Foundation.Personify.Constants.Templates.AcrProtectedContent.RequiredAccess;

namespace ACR.Foundation.SSO.Users
{
  [Serializable]
  public class AnonymousUser : IAcrUser
  {
    private const string AnonymousCartCookieName = "AnonumousTimssCMSUser";

    #region Implementation of IAcrUser

    public bool IsAnonymous
    {
      get { return true; }
    }

    public bool IsAuthenticated
    {
      get { return false; }
    }
    public bool IsInternationalUser
    {
      get { return false; }
    }
    public bool IsAcrMember
    {
      get { return false; }
    }

    public string PersonifyAuthToken
    {
      get { return null; }
    }

    public string MasterCustomerID
    {
      get
      {
        string uniqueId = GetAnonymousCartGuid();
        if (String.IsNullOrEmpty(uniqueId))
        {
          //if an anonymous cart cookie does not exist, create one
          uniqueId = System.Web.HttpContext.Current.Session.SessionID;
          HttpCookie cookie = CookieUtil.CreateCookie(AnonymousCartCookieName, uniqueId, "acr.org");
        }
        return uniqueId;
      }
    }

    public string SubCustomerID
    {
      get { return "0"; }
    }

    public IAcrProfile Profile
    {
      get { return new AnonymousProfile(); }
    }

  
    public bool IsEntitled(AcrProtectedContent contentItem)
    {
      if (contentItem == null)
      {
        return false;
      }
      if (contentItem.RequiredAccess != RequiredAccess.None)
      {
        return false;
      }
      if (contentItem.RequiredProducts.Any())
      {
        return false;
      }
      if (contentItem.RequiredRoles.Any())
      {
        return false;
      }
      return true;
    }

    public void ClearProfile()
    {
    }

    #endregion

    public string GetAnonymousCartGuid()
    {
      string guid = String.Empty;
      //Anonymous users have their shopping cart guid stored in a cookie
      HttpCookie cartCookie = CookieUtil.GetCookie(AnonymousCartCookieName);
      if (cartCookie != null)
      {
        guid = cartCookie.Value;
      }
      return guid;
    }

   

    public PdsCustomerInfo GetRawCustomerInfo()
    {
      return null;
    } 

    public PdsCustMbrAddrInfo GetCustMbrAddrInfo()
    {
      return null;
    }

    public PdsCustAddrInfo GetCustAddrInfo()
    {
      return null;
    }

    public KeyValuePair<bool,double> GetACRCMECredits()
    {
      return new KeyValuePair<bool, double>(false, 0);
    }
  }
}