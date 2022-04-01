using ACRHelix.Feature.Navigation.ViewModels;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System.Collections.Generic;

namespace ACRHelix.Feature.Navigation.Services
{
  public class SitemapService : SiteHostResolverService
  {
    private List<SitemapItem> SiteMapItems { get; set; } = new List<SitemapItem>();


    public SitemapService(string host) : base(host)
    {

    }

    private void AddSitemapItems(Item item)
    {
      if (item.ItemHasLayout())
      {
        SiteMapItems.Add(new SitemapItem(item, this.Site));
      }
      foreach (Item child in item.GetChildren())
      {
        //exclude personify items and biography detail pages
        if (child.TemplateID.ToString() != "{1F20B469-2A47-40FA-8D54-CED7FA0D1225}" && child.TemplateID.ToString() != "{ 9246FCDE-D9A7-4C29-8544-4D36A8F185EB}")
        {
          AddSitemapItems(child);
        }
      }
    }

    public List<SitemapItem> GetAllItemsWithLayout(Item rootItem)
    {
      AddSitemapItems(rootItem);
      return SiteMapItems;
    }


  }
}