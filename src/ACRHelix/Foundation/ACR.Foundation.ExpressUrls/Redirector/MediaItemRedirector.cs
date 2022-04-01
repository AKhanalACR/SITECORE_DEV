using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.ExpressUrls.Redirector
{
  public class MediaItemRedirector : MediaRequestHandler
  {
    protected override bool DoProcessRequest(HttpContext context)
    {
      Assert.ArgumentNotNull((object)context, "context");
      MediaRequest request = MediaManager.ParseMediaRequest(context.Request);
      if (request == null) {
        return false;
      }
      Media media = MediaManager.GetMedia(request.MediaUri);
      if (media != null) {
        return this.DoProcessRequest(context, request, media);
      }    

      using (new SecurityDisabler())
      {
        media = MediaManager.GetMedia(request.MediaUri);
      }      
      if (media == null)
      {
        bool foundRedirect = GetRedirect(context);
        if (foundRedirect)
        {
          return true;
        }
      }

      Item item = FindItemByName(request.MediaUri.MediaPath);
      if (item != null)
      {
        context.Response.RedirectPermanent(Sitecore.Links.LinkManager.GetItemUrl(item));
      }



      return base.DoProcessRequest(context);
    }

    private Item FindItemByName(string mediaPath)
    {
      string filename = string.Empty;
      int filestart = mediaPath.LastIndexOf('/') + 1;
      if (filestart > 1 && mediaPath.Length > filestart)
      {
        filename = mediaPath.Substring(filestart);
      }
      if (!string.IsNullOrWhiteSpace(filename))
      {
        var item = Sitecore.Context.Database.SelectSingleItem($"/sitecore/media library/ACR//*[@@Name='{filename}']");
        if (item != null)
        {
          //dont auto redirect to noindex pdfs
          //user must have exact link or access tot he page that lists them
          if (!item.Paths.FullPath.Contains("/NOINDEX"))
          {
            return item;
          }
        }
      }
      return null;
    }

    private bool GetRedirect(HttpContext context)
    {
      ExpressUrlRedirector redirector = new ExpressUrlRedirector();
      if (!redirector.TryPerformRedirect(HttpContext.Current))
      {
        if (Sitecore.Context.Site.Name == "website")
        {
          PageNotFoundRedirector pageNotFoundRedirector = new PageNotFoundRedirector();
          return pageNotFoundRedirector.PageNotFoundRedirect(HttpContext.Current);
        }
      }

      return false;
    }
  }
}