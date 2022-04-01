namespace Sitecore.Foundation.Assets.Pipelines.GetPageRendering
{
  using ACR.Foundation.Utilities.Hash;
  using Sitecore.Data.Items;
  using Sitecore.Foundation.Assets.Models;
  using Sitecore.Foundation.Assets.Repositories;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Mvc.Pipelines.Response.GetPageRendering;
  using Sitecore.Mvc.Presentation;
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Web;

  public class AddSiteAssets : GetPageRenderingProcessor
  {
    public override void Process(GetPageRenderingArgs args)
    {
      this.AddAssets();
    }

    protected void AddAssets()
    {
      Item siteItem = Sitecore.Context.Site.GetContextSiteEE().GetRootItem(); //Sitecore.Context.Database.GetItem("/sitecore/content/ACR"); //get site root item
      if (siteItem != null)
      {
        AssetRepository.Current.AddAssetList(GetSiteAssets(siteItem));
      }
    }

    private List<Asset> GetSiteAssets(Item siteItem)
    {
      string key = $"site-assets-{siteItem.ID}-{siteItem.Statistics.Updated.Ticks}";
      List<Asset> assets = HttpContext.Current.Cache.Get(key) as List<Asset>;
      if (assets == null)
      {
        assets = new List<Asset>();

        var javascriptAssets = siteItem[Templates.SiteAssets.Fields.JavaScript];
        if (!string.IsNullOrWhiteSpace(javascriptAssets))
        {
          assets.Add(new Asset(AssetType.Raw, ScriptLocation.Body, inline: javascriptAssets));
        }

        var cssAssets = siteItem[Templates.SiteAssets.Fields.Css];
        if (!string.IsNullOrWhiteSpace(cssAssets))
        {
          assets.Add(new Asset(AssetType.Raw, ScriptLocation.Head, inline: cssAssets));
        }

        var fonts = siteItem[Templates.SiteAssets.Fields.Fonts];
        if (!string.IsNullOrWhiteSpace(fonts))
        {
          assets.Add(new Asset(AssetType.Raw, ScriptLocation.Head, inline: fonts));
        }

        var favicons = siteItem[Templates.SiteAssets.Fields.Favicons];
        if (!string.IsNullOrWhiteSpace(favicons))
        {
          assets.Add(new Asset(AssetType.Raw, ScriptLocation.Head, inline: favicons));
        }

        var bodyAssets = siteItem[Templates.SiteAssets.Fields.BodyAssets];
        if (!string.IsNullOrWhiteSpace(bodyAssets))
        {
          assets.Add(new Asset(AssetType.Body, ScriptLocation.Body, inline: bodyAssets));
        }

        try
        {
          var versionedCss = siteItem[Templates.SiteAssets.Fields.VersionedCSS];
          if (!string.IsNullOrWhiteSpace(versionedCss))
          {
            StringBuilder cssAsset = new StringBuilder();
            string[] css = versionedCss.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var c in css)
            {
              string path = HttpContext.Current.Server.MapPath(c);
              string asset = $"<link rel=\"stylesheet\" href=\"{c}?v={HashGenerator.GetHashFromFile(path)}\" />".Replace("\r\n", "");
              cssAsset.Append(asset);
            }
            assets.Add(new Asset(AssetType.RawVersionedCss, ScriptLocation.Head, inline: cssAsset.ToString()));
          }
        }
        catch (Exception ex)
        {
          Diagnostics.Log.Error("Error finded css asset on siteitem in field VersionedCSS", ex, this);
        }

        try
        {
          var versionedJs = siteItem[Templates.SiteAssets.Fields.VersionedJS];
          if (!string.IsNullOrWhiteSpace(versionedJs))
          {
            StringBuilder jsAsset = new StringBuilder();
            string[] js = versionedJs.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var j in js)
            {
              string path = HttpContext.Current.Server.MapPath(j);
              string asset = $"<script src=\"{j}?v={HashGenerator.GetHashFromFile(path)}\"></script>".Replace("\r\n", "");
              jsAsset.Append(asset);
            }
            assets.Add(new Asset(AssetType.RawVersionedJs, ScriptLocation.Body, inline: jsAsset.ToString()));

            HttpContext.Current.Cache.Add(key, assets, null, DateTime.UtcNow.AddHours(3), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.AboveNormal, null);
          }
        }
        catch (Exception ex)
        {
          Diagnostics.Log.Error("Error finded js asset on siteitem in field VersionedJS", ex, this);
        }
      }
      return assets;
    }
  }
}