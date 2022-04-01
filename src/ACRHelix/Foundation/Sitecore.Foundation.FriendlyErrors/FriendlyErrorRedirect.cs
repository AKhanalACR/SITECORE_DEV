using Sitecore.Configuration;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.FriendlyErrors
{
  public class FriendlyErrorRedirect : global::Sitecore.Pipelines.HttpRequest.ExecuteRequest
  {
    protected override void PerformRedirect(string url)
    {
      if (Context.Site == null || Context.Database == null || Context.Database.Name == "core")
      {

        Sitecore.Diagnostics.Log.Info($"Attempting to redirect url {url}, but no Context Site or DB defined (or core db redirect attempted)", this);
        return;
      }

      // need to retrieve not found item to account for sites utilizing virtualFolder attribute
      //var notFoundItem = Context.Database.GetItem(Context.Site.RootPath + Settings.ItemNotFoundUrl);
      var notFoundUrl = Settings.ItemNotFoundUrl;
      /*
      if (notFoundItem == null)
      {
        Sitecore.Diagnostics.Log.Info($"No 404 item found on site: {Context.Site.Name}", this);
        return;
      }*/


      Sitecore.Diagnostics.Log.Info($"Redirecting to {notFoundUrl}", this);
      if (Settings.RequestErrors.UseServerSideRedirect)
      {
        HttpContext.Current.Server.TransferRequest(notFoundUrl);
      }
      else
        WebUtil.Redirect(notFoundUrl, false);
    }
  }
}