namespace Sitecore.Foundation.Assets.Pipelines.GetPageRendering
{
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Foundation.Assets.Models;
  using Sitecore.Foundation.Assets.Repositories;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Mvc.Pipelines.Response.GetPageRendering;
  using Sitecore.Mvc.Presentation;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using System.Web.Optimization;
  using ACR.Foundation.Utilities.Hash;

  public class AddRenderingAssets : GetPageRenderingProcessor
  {
    public override void Process(GetPageRenderingArgs args)
    {
      this.AddAssets(args.PageContext.PageDefinition.Renderings);
    }

    private void AddAssets(IEnumerable<Rendering> renderings)
    {
      string key = string.Join("", renderings.Select(x => x.RenderingItem.ID.ToShortID().ToString()));
      var lastModifiedRendering = renderings.Max(x => x.RenderingItem.InnerItem.Statistics.Updated);
      key += lastModifiedRendering.Ticks.ToString();

      List<Asset> assets = HttpContext.Current.Cache.Get(key) as List<Asset>;

      if (assets == null)
      {
        assets = new List<Asset>();
        foreach (var rendering in renderings)
        {
          var renderingItem = this.GetRenderingItem(rendering);
          if (renderingItem != null)
          {
            assets.AddRange(AddInlineAssetsFromItem(renderingItem));
          }
        }

        var bundleResult = BundleJsAssets(renderings, lastModifiedRendering);

        if (!bundleResult.Item1)
        {
          foreach (var rendering in renderings)
          {
            var renderingItem = this.GetRenderingItem(rendering);
            if (renderingItem != null)
            {
              //AddAssetsFromItem(renderingItem);
              assets.AddRange(AddScriptAssetsFromRendering(renderingItem));
            }
          }
        }
        else
        {
          assets.AddRange(bundleResult.Item2);
        }

        var cssBundleResult = BundleCssAssets(renderings, lastModifiedRendering);
        if (!cssBundleResult.Item1)
        {
          foreach (var rendering in renderings)
          {
            var renderingItem = this.GetRenderingItem(rendering);
            if (renderingItem != null)
            {
              //AddAssetsFromItem(renderingItem);
              assets.AddRange(AddStylingAssetsFromRendering(renderingItem));
            }
          }
        }
        else
        {
          assets.AddRange(cssBundleResult.Item2);
        }
        assets = assets.Distinct(new AssetEqualityComparer()).ToList();

        HttpContext.Current.Cache.Add(key, assets, null, DateTime.UtcNow.AddHours(8), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.AboveNormal, null);
      }
      AssetRepository.Current.AddAssetList(assets);
    }

    private Tuple<bool, List<Asset>> BundleCssAssets(IEnumerable<Rendering> renderings, DateTime dtkey)
    {
      bool suceess = false;
      List<Asset> assets = new List<Asset>();

      try
      {
        if (!bool.Parse(Sitecore.Configuration.Settings.GetSetting("DisableBundles", "false")))
        {
          //Bundle CSS
          BundledAsset cssBundle = GetCSSFilesFromRenderings(renderings);
          if (cssBundle.Scripts.Count > 0)
          {
            var names = cssBundle.Info.Select(x => x.Name).ToList();
            names.Add(dtkey.Ticks.ToString());

            string cssBundleFileName = HashGenerator.GetHashFromString(string.Join("", names));
            string cssBundleName = "~/renderingCss/" + cssBundleFileName + ".css";

            var bundleArray = cssBundle.Scripts.ToList();
            var externalCss = bundleArray.Where(x => x.StartsWith("http") || x.StartsWith("//")).ToList();
            foreach (var external in externalCss)
            {
              bundleArray.Remove(external);
            }
            if (bundleArray.Count > 0)
            {
              if (BundleTable.Bundles.GetRegisteredBundles().FirstOrDefault(x => x.Path == cssBundleName) == null)
              {
                BundleTable.Bundles.Add(new StyleBundle(cssBundleName).Include(bundleArray.ToArray()));
              }
            }
            if (externalCss.Count > 0)
            {
              foreach (var external in externalCss)
              {
                assets.Add(new Asset(AssetType.Css, ScriptLocation.Head, file: external));
              }
            }
            assets.Add(new Asset(AssetType.Css, ScriptLocation.Head, file: cssBundleName.Replace("~/", "/")));
          }
          suceess = true;
        }
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error Bundling CSS Assets", ex, this);
      }
      return new Tuple<bool, List<Asset>>(suceess, assets);
    }

    private Tuple<bool, List<Asset>> BundleJsAssets(IEnumerable<Rendering> renderings, DateTime dtkey)
    {
      bool suceess = false;
      List<Asset> assets = new List<Asset>();

      try
      {
        if (!bool.Parse(Configuration.Settings.GetSetting("DisableBundles", "false")))
        {
          //Bundles JS Assets
          BundledAsset bundle = GetScriptsFromRenderings(renderings);
          if (bundle.Scripts.Count > 0)
          {
            var names = bundle.Info.Select(x => x.Name).ToList();
            names.Add(dtkey.Ticks.ToString());
            string bundleFileName = "rendering-bundle-" + HashGenerator.GetHashFromString(string.Join("", names));
            string bundleName = "~/renderingJs/" + bundleFileName + ".js";

            var bundleArray = bundle.Scripts.ToList();
            var externalScripts = bundleArray.Where(x => x.StartsWith("http") || x.StartsWith("//")).ToList();
            foreach (var external in externalScripts)
            {
              bundleArray.Remove(external);
            }
            if (bundleArray.Count > 0)
            {
              if (BundleTable.Bundles.GetRegisteredBundles().FirstOrDefault(x => x.Path == bundleName) == null)
              {
                //var bundleArray = bundle.Scripts.ToList();
                BundleTable.Bundles.Add(new ScriptBundle(bundleName).Include(bundleArray.ToArray()));
              }
            }
            if (externalScripts.Count > 0)
            {
              foreach (var script in externalScripts)
              {
                assets.Add(new Asset(AssetType.JavaScript, ScriptLocation.Body, file: script));
              }
            }
            assets.Add(new Asset(AssetType.JavaScript, ScriptLocation.Body, file: bundleName.Replace("~/", "/")));
            //AssetRepository.Current.AddScript(bundleName.Replace("~/", "/"));
          }
          suceess = true;
        }
        //}
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error Bundling JS Assets", ex, this);
      }

      return new Tuple<bool, List<Asset>>(suceess, assets);
    }

    private BundledAsset GetCSSFilesFromRenderings(IEnumerable<Rendering> renderings)
    {
      List<BundleInfo> info = new List<BundleInfo>();
      List<string> scripts = new List<string>();

      foreach (var rendering in renderings)
      {
        var renderingItem = this.GetRenderingItem(rendering);
        if (renderingItem != null)
        {
          bool infoAdded = false;

          var javaScriptAssets = renderingItem[Templates.RenderingAssets.Fields.StylingFiles];
          foreach (var cssAsset in javaScriptAssets.Split(';', ',', '\n'))
          {
            if (!string.IsNullOrWhiteSpace(cssAsset))
            {
              if (!infoAdded)
              {
                info.Add(new BundleInfo()
                {
                  Id = renderingItem.ID,
                  Name = renderingItem.Name
                });
                infoAdded = true;
              }

              scripts.Add("~" + cssAsset.ToLower().Replace("\r", ""));
            }
          }
        }
      }
      info = info.Distinct().ToList();
      scripts = scripts.Distinct().ToList();

      return new BundledAsset(info, scripts);
    }

    private BundledAsset GetScriptsFromRenderings(IEnumerable<Rendering> renderings)
    {
      List<BundleInfo> info = new List<BundleInfo>();
      List<string> scripts = new List<string>();

      foreach (var rendering in renderings)
      {
        var renderingItem = this.GetRenderingItem(rendering);
        if (renderingItem != null)
        {
          bool infoAdded = false;

          var javaScriptAssets = renderingItem[Templates.RenderingAssets.Fields.ScriptFiles];
          foreach (var javaScriptAsset in javaScriptAssets.Split(';', ',', '\n'))
          {
            if (!string.IsNullOrWhiteSpace(javaScriptAsset))
            {
              if (!infoAdded)
              {
                info.Add(new BundleInfo()
                {
                  Id = renderingItem.ID,
                  Name = renderingItem.Name
                });
                infoAdded = true;
              }

              scripts.Add("~" + javaScriptAsset.ToLower().Replace("\r", ""));
            }
          }
        }
      }
      info = info.Distinct().ToList();
      scripts = scripts.Distinct().ToList();

      return new BundledAsset(info, scripts);
      //return scripts;
    }

    internal List<Asset> AddInlineAssetsFromItem(Item renderingItem)
    {
      List<Asset> assets = new List<Asset>();
      if (renderingItem.IsDerived(Templates.RenderingAssets.ID))
      {
        var scriptAsset = AddInlineScriptFromRendering(renderingItem);
        if (scriptAsset != null)
        {
          assets.Add(scriptAsset);
        }

        var cssAsset = AddInlineStylingFromAssets(renderingItem);
        if (cssAsset != null)
        {
          assets.Add(cssAsset);
        }
      }
      return assets;
    }

    private Asset AddInlineStylingFromAssets(Item renderingItem)
    {
      Asset asset = null;
      var cssInline = renderingItem[Templates.RenderingAssets.Fields.InlineStyling];
      if (!string.IsNullOrEmpty(cssInline))
      {
        asset = new Asset(AssetType.Css, ScriptLocation.Head, inline: cssInline);
      }
      return asset;
    }

    private List<Asset> AddStylingAssetsFromRendering(Item renderingItem)
    {
      List<Asset> assets = new List<Asset>();
      var cssAssets = renderingItem[Templates.RenderingAssets.Fields.StylingFiles];
      foreach (var cssAsset in cssAssets.Split(';', ',', '\n'))
      {
        assets.Add(new Asset(AssetType.Css, ScriptLocation.Head, file: cssAsset));
      }
      return assets;
    }

    private Asset AddInlineScriptFromRendering(Item renderingItem)
    {
      Asset asset = null;
      var cssInline = renderingItem[Templates.RenderingAssets.Fields.InlineScript];
      if (!string.IsNullOrEmpty(cssInline))
      {
        asset = new Asset(AssetType.JavaScript, ScriptLocation.Body, inline: cssInline);
      }
      return asset;
    }

    private List<Asset> AddScriptAssetsFromRendering(Item renderingItem)
    {
      List<Asset> assets = new List<Asset>();
      var javaScriptAssets = renderingItem[Templates.RenderingAssets.Fields.ScriptFiles];

      foreach (var javaScriptAsset in javaScriptAssets.Split(';', ',', '\n'))
      {
        assets.Add(new Asset(AssetType.JavaScript, ScriptLocation.Body, file: javaScriptAsset));
      }
      return assets;
    }

    private Item GetRenderingItem(Rendering rendering)
    {
      if (rendering.RenderingItem == null || rendering.RenderingItem.InnerItem.IsDerived(Templates.RenderingAssets.ID) == false)
      {
        Log.Warn($"rendering.RenderingItem is null for {rendering.RenderingItemPath}", this);
        return null;
      }
      return rendering.RenderingItem.InnerItem;
    }
  }
}