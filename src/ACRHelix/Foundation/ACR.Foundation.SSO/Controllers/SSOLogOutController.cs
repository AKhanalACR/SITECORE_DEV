using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACR.Foundation.SSO.Users;

namespace ACR.Foundation.SSO.Controllers
{
  public class SSOLogOutController : Controller
  {
    public ActionResult LogOut()
    {
      UserManager.CurrentUserContext.Logout();
      HttpContext.Session["radpaccustomerId"] = null;
      string returnUrl = string.Concat(Personify.Settings.ACRSettings.LogOffUrl, HttpUtility.UrlEncode(Request.Url.Scheme + "://" + Request.Url.Host + "/"));
      return Redirect(returnUrl);
    }
  }
}