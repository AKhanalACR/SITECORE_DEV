using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.ViewModels
{
  public class SitemapItem
  {
    public string Url { get; set; }
    public DateTime Updated { get; set; }


    public SitemapItem(Item item, Site site)
    {
      var options = LinkManager.GetDefaultUrlOptions();
      options.AlwaysIncludeServerUrl = false;
      options.Site = SiteContext.GetSite(site.Name);

      var requestUrl = HttpContext.Current.Request.Url;
      Url = LinkManager.GetItemUrl(item, options);
      Url = $"{requestUrl.Scheme}://{requestUrl.Host}{Url}";

      var dateUpdatedField = (DateField)item.Fields[Sitecore.FieldIDs.Updated];
      if (dateUpdatedField != null)
      {
        Updated = dateUpdatedField.DateTime;
      }
    }
  }

  public class SitemapList
  {
    public IEnumerable<SitemapItem> SiteMapItems { get; set; }
  }
}