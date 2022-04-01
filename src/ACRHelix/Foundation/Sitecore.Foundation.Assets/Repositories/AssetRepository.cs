namespace Sitecore.Foundation.Assets.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml;
  using Sitecore.Data;
  using Sitecore.Diagnostics;
  using Sitecore.Foundation.Assets.Models;
  using Sitecore.Mvc.Presentation;
  using Sitecore.Xml;

  /// <summary>A Repository for all assets required by renderings</summary>
  public class AssetRepository
  {
    [ThreadStatic]
    private static AssetRepository _current;

    private readonly List<Asset> _items = new List<Asset>();

    public static AssetRepository Current => _current ?? (_current = new AssetRepository());

    internal IEnumerable<Asset> Items => this._items;

    internal void Clear()
    {
      this._items.Clear();
    }

    internal void Add(Asset asset)
    {
      if (asset.File != null)
      {
        if (this._items.Any(x => x.File != null && x.File == asset.File))
        {
          return;
        }
      }

      // Passed the checks, add the requirement.
      this._items.Add(asset);
    }

    internal void AddAssetList(List<Asset> assets)
    {
      foreach (var asset in assets)
      {
        this._items.Add(asset);
      }
    }

    internal Asset CreateFromConfiguration(XmlNode node)
    {
      var assetTypeString = XmlUtil.GetAttribute("type", node, null);
      var assetFile = XmlUtil.GetAttribute("file", node, null);
      var scriptLocationString = XmlUtil.GetAttribute("location", node, null);
      //var site = XmlUtil.GetAttribute("site", node, null);
      var inlineValue = node.InnerXml;

      if (string.IsNullOrWhiteSpace(assetTypeString))
      {
        Log.Warn($"Invalid asset in GetPageRendering.AddAssets pipeline: {node.OuterXml}", this);
        return null;
      }
      AssetType assetType;
      if (!Enum.TryParse(assetTypeString, true, out assetType))
      {
        Log.Warn($"Invalid asset type in GetPageRendering.AddAssets pipeline: {node.OuterXml}", this);
        return null;
      }

      var scriptLocation = ScriptLocation.Body;
      if (scriptLocationString != null)
      {
        ScriptLocation location;
        if (!Enum.TryParse(scriptLocationString, true, out location))
        {
          Log.Warn($"Invalid script location in GetPageRendering.AddAssets pipeline: {node.OuterXml}", this);
          return null;
        }
        scriptLocation = location;
      }

      Asset asset = null;
      if (!string.IsNullOrEmpty(assetFile))
      {
        asset = new Asset(assetType, scriptLocation, assetFile);
      }
      else if (!string.IsNullOrEmpty(inlineValue))
      {
        asset = new Asset(assetType, scriptLocation, inline: inlineValue);
      }

      return asset;
    }
  }
}