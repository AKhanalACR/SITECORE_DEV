namespace Sitecore.Foundation.Assets.Services
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web;
  using Sitecore.Foundation.Assets.Models;
  using Sitecore.Foundation.Assets.Repositories;
  using Sitecore.Text;
  using System.Web.Optimization;

  /// <summary>
  ///   A service which helps add the required JavaScript at the end of a page, and CSS at the top of a page.
  ///   In component based architecture it ensures references and inline scripts are only added once.
  /// </summary>
  public class RenderAssetsService
  {
    private static RenderAssetsService _current;
    public static RenderAssetsService Current => _current ?? (_current = new RenderAssetsService());

    public HtmlString RenderScript(ScriptLocation location)
    {
      var sb = new StringBuilder();
      var assets = AssetRepository.Current.Items.Where(asset => (asset.Type == AssetType.JavaScript && asset.Location == location));
      foreach (var item in assets)
      {
        if (!string.IsNullOrEmpty(item.File))
        {
          sb.AppendFormat("<script src=\"{0}\"></script>", item.File.Trim()).AppendLine();
        }
        else if (!string.IsNullOrEmpty(item.Inline))
        {
          if (item.Type == AssetType.Raw)
          {
            sb.AppendLine(HttpUtility.HtmlDecode(item.Inline));
          }
          else
          {
            sb.AppendLine("<script>\njQuery(document).ready(function() {");
            sb.AppendLine(item.Inline);
            sb.AppendLine("});\n</script>");
          }
        }
      }
      return new HtmlString(sb.ToString());
    }

    public HtmlString RenderStyles(ScriptLocation location)
    {
      var sb = new StringBuilder();
      foreach (var item in AssetRepository.Current.Items.Where(asset => asset.Type == AssetType.Css && asset.Location == location))
      {
        if (!string.IsNullOrEmpty(item.File))
        {
          sb.AppendFormat("<link href=\"{0}\" rel=\"stylesheet\" />", item.File.Trim()).AppendLine();
        }
        else if (!string.IsNullOrEmpty(item.Inline))
        {
          sb.AppendLine("<style type=\"text/css\">");
          sb.AppendLine(item.Inline);
          sb.AppendLine("</style>");
        }
      }

      return new HtmlString(sb.ToString());
    }

    public HtmlString RenderBodyAssets(ScriptLocation location)
    {
      var sb = new StringBuilder();
      var assets = AssetRepository.Current.Items.Where(asset => asset.Type == AssetType.Body && asset.Location == location);
      foreach (var item in assets)
      {
        sb.Append(item.Inline);
      }
      return new HtmlString(sb.ToString());
    }

    public HtmlString RenderVersionedJs(ScriptLocation location)
    {
      var sb = new StringBuilder();
      var assets = AssetRepository.Current.Items.Where(asset => asset.Type == AssetType.RawVersionedJs && asset.Location == location);
      foreach (var item in assets)
      {
        sb.Append(item.Inline);
      }
      return new HtmlString(sb.ToString());
    }

    public HtmlString RenderVersionedCSS(ScriptLocation location)
    {
      var sb = new StringBuilder();
      var assets = AssetRepository.Current.Items.Where(asset => asset.Type == AssetType.RawVersionedCss && asset.Location == location);
      foreach (var item in assets)
      {
        sb.Append(item.Inline);
      }
      return new HtmlString(sb.ToString());
    }

    public HtmlString RenderRawAssetsHead(ScriptLocation location)
    {
      var sb = new StringBuilder();
      var assets = AssetRepository.Current.Items.Where(asset => asset.Type == AssetType.Raw && asset.Location == location);
      foreach (var item in assets)
      {
        sb.Append(item.Inline);
      }
      return new HtmlString(sb.ToString());
    }
  }
}