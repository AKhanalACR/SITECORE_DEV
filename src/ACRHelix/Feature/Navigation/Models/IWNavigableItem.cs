using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.Navigation.Models
{
  public class IWNavigableItem : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Name { get; set; }

	[SitecoreField("Short Title")]
    public virtual string ShortTitle { get; set; }

	[SitecoreField("Show In Navigation")]
    public virtual bool ShowInNavigation { get; set; }

    public virtual string Url { get; set; }
	
	[SitecoreField("Link Override")]
    public virtual string LinkOverride { get; set; }

	[SitecoreField("New Window")]
    public virtual bool NewWindow { get; set; }

    [SitecoreField("Page Nav Category")]
    public virtual string PageNavCategory { get; set; }

    [SitecoreField("Main Menu Css")]
    public virtual string MainMenuCss { get; set; }

    [SitecoreField("Sub Menu Css")]
    public virtual string SubMenuCss { get; set; }

    [SitecoreChildren]
    public virtual IEnumerable<IWNavigableItem> Children {get;set;}

    public virtual Item Item { get; set; }
	
	[SitecoreInfo(SitecoreInfoType.TemplateId)]
    public virtual ID TemplateID { get; set; }

    public virtual string SitemapUrl
    {
      get
      {
        string sitemapUrl = Url;
        if (!string.IsNullOrWhiteSpace(sitemapUrl))
        {
          sitemapUrl = sitemapUrl.Replace("/sitecore/content/ACR", "");

          if (HttpContext.Current != null)
          {
            sitemapUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + sitemapUrl;
          }

        }
        return sitemapUrl;

      }
    }
    
  }
}