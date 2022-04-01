using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Services;
using ACR.Foundation.SSO.Utils;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.Utilities.Url;
using Sitecore.Mvc.Pipelines.Request.RequestBegin;
using RequiredAccess = ACR.Foundation.Personify.Constants.Templates.AcrProtectedContent.RequiredAccess;
using System.Net;
using ACR.Foundation.SSO.Logger;
using Sitecore.Links;

namespace ACR.Foundation.SSO.Pipelines
{
  public class AcrSSOProcessor : RequestBeginProcessor
  {
    private string siteName = "radpac";
    public override void Process(RequestBeginArgs args)
    {
      if (Sitecore.Context.Item != null)
      {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        if (Sitecore.Context.Site.Name.ToLower() == siteName)              
            AcrSsoUtil.CheckSsoStateRadpac(HttpContext.Current, Sitecore.Context.Item);
        else
            AcrSsoUtil.CheckSsoState(HttpContext.Current, Sitecore.Context.Item);

        SitecoreContentService contentService = new SitecoreContentService();
        var protectedItem = contentService.GetAcrProtectedContentItem(Sitecore.Context.Item.ID);

        if (protectedItem != null)
        {
          //allow coveo to crawl restricted pages
          //TODO add more restrictions to prevent user agent spoofing
          if (HttpContext.Current.Request.UserAgent != "Coveo Sitecore Search Provider" && Sitecore.Context.PageMode.IsNormal)
          {
            bool entitled = false;
            if (protectedItem.RequiredAccess != RequiredAccess.None || protectedItem.RequiredProducts.Any() || protectedItem.RequiredRoles.Any())
            {
              if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
              {
                entitled = UserManager.CurrentUserContext.CurrentUser.IsEntitled(protectedItem);

                if (!entitled)
                {
                  var url = UrlUtil.AddParameterToUrl("/Access-Denied", "returnUrl", protectedItem.Url);
                  if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                  {
                    HttpContext.Current.Response.Redirect(url, true);
                  }
                  args.AbortPipeline();
                }
              }
              else
              {
                //radpac site login 
                if (Sitecore.Context.Site.Name.ToLower() == siteName)
                {
                    var options = LinkManager.GetDefaultUrlOptions(); options.ShortenUrls = true;
                    var reqUrl = LinkManager.GetItemUrl(Sitecore.Context.Item, options);
                    var urlOther = UrlUtil.AddParameterToUrl(ItemUrls.GetLoginPageUrl(Sitecore.Context.Site.Name), "returnUrl", reqUrl);
                    if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                    {
                        HttpContext.Current.Response.Redirect(urlOther, true);
                    }
                }

                //acr.org or main site
                var url = UrlUtil.AddParameterToUrl(ItemUrls.GetLoginPageUrl(), "returnUrl", protectedItem.Url);
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                {
                  HttpContext.Current.Response.Redirect(url, true);
                }

                args.AbortPipeline();
              }
            }
          }
        }
      }
    }
  }
}