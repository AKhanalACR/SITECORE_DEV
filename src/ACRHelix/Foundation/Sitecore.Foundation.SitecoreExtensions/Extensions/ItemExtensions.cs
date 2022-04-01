namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
  using Glass.Mapper.Sc.Fields;
  using Sitecore.Data;
  using Sitecore.Data.Fields;
  using Sitecore.Data.Items;
  using Sitecore.Data.Managers;
  using Sitecore.Diagnostics;
  using Sitecore.Foundation.SitecoreExtensions.Services;
  using Sitecore.Links;
  using Sitecore.Resources.Media;
  using Sitecore.Xml.Xsl;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using System.Web;

  public static class ItemExtensions
  {
    public static string Url(this Item item, UrlOptions options = null)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }
      if (options == null)
      {
        options = LinkManager.GetDefaultUrlOptions();
      }
      return LinkManager.GetItemUrl(item, options);
    }

    public static string GetCanonicalUrl(this Item item)
    {
      string url = string.Empty;

      if (item != null)
      {
        //defaults
        string scheme = "http://";
        string host = "acr.org";

        bool requestContext = false;

        //get info from current request
        if (HttpContext.Current != null)
        {
          var request = HttpContext.Current.Request;
          if (request != null)
          {
            scheme = request.Url.Scheme;
            host = request.Url.Host;
            requestContext = true;
          }
        }

        //if no current request get info from config
        if (!requestContext)
        {
          var site = Sitecore.Configuration.Factory.GetSite("website");
          if (site != null)
          {
            string hostConfig = string.IsNullOrEmpty(site.HostName) ? site.TargetHostName : site.HostName;
            if (!string.IsNullOrWhiteSpace(hostConfig))
            {
              host = hostConfig;
            }
          }
        }

        url = string.Format("{0}://{1}{2}", scheme, host, LinkManager.GetItemUrl(item));
      }
      return url;
    }

    public static string ImageUrl(this Item item, ID imageFieldId, MediaUrlOptions options = null)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      var imageField = (ImageField)item.Fields[imageFieldId];
      return imageField?.MediaItem == null ? string.Empty : imageField.ImageUrl(options);
    }

    public static Item TargetItem(this Item item, ID linkFieldId)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      var linkField = (LinkField)item.Fields[linkFieldId];
      return linkField.TargetItem;
    }

    public static string MediaUrl(this Item item, ID mediaFieldId, MediaUrlOptions options = null)
    {
      var targetItem = item.TargetItem(mediaFieldId);
      return targetItem == null ? string.Empty : (MediaManager.GetMediaUrl(targetItem) ?? string.Empty);
    }


    public static bool IsImage(this Item item)
    {
      return new MediaItem(item).MimeType.StartsWith("image/", StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool IsVideo(this Item item)
    {
      return new MediaItem(item).MimeType.StartsWith("video/", StringComparison.InvariantCultureIgnoreCase);
    }

    public static Item GetAncestorOrSelfOfTemplate(this Item item, ID templateID)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      return item.IsDerived(templateID) ? item : item.Axes.GetAncestors().Reverse().FirstOrDefault(i => i.IsDerived(templateID));
    }

    public static IList<Item> GetAncestorsAndSelfOfTemplate(this Item item, ID templateID)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      var returnValue = new List<Item>();
      if (item.IsDerived(templateID))
      {
        returnValue.Add(item);
      }

      returnValue.AddRange(item.Axes.GetAncestors().Where(i => i.IsDerived(templateID)));
      return returnValue;
    }

    public static string LinkFieldUrl(this Item item, ID fieldID)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }
      if (ID.IsNullOrEmpty(fieldID))
      {
        throw new ArgumentNullException(nameof(fieldID));
      }
      var field = item.Fields[fieldID];
      if (field == null)
      {
        return string.Empty;
      }
      var linkUrl = new LinkUrl();
      return linkUrl.GetUrl(item, fieldID.ToString());
    }

    public static string LinkFieldTarget(this Item item, ID fieldID)
    {
      return item.LinkFieldOptions(fieldID, LinkFieldOption.Target);
    }

    public static string LinkFieldOptions(this Item item, ID fieldID, LinkFieldOption option)
    {
      XmlField field = item.Fields[fieldID];
      switch (option)
      {
        case LinkFieldOption.Text:
          return field?.GetAttribute("text");
        case LinkFieldOption.LinkType:
          return field?.GetAttribute("linktype");
        case LinkFieldOption.Class:
          return field?.GetAttribute("class");
        case LinkFieldOption.Alt:
          return field?.GetAttribute("title");
        case LinkFieldOption.Target:
          return field?.GetAttribute("target");
        case LinkFieldOption.QueryString:
          return field?.GetAttribute("querystring");
        default:
          throw new ArgumentOutOfRangeException(nameof(option), option, null);
      }
    }

    public static bool IsDerived(this Item item, string templateId)
    {
      ID id = new ID(templateId);
      return item.IsDerived(id);
    }

    public static bool IsDerived(this Item item, ID templateId)
    {
      if (item == null)
      {
        return false;
      }

      return !templateId.IsNull && item.IsDerived(item.Database.Templates[templateId]);
    }

    private static bool IsDerived(this Item item, Item templateItem)
    {
      if (item == null)
      {
        return false;
      }

      if (templateItem == null)
      {
        return false;
      }
      var itemTemplate = TemplateManager.GetTemplate(item);
      if (itemTemplate == null)
      {
        return false;
      }
      if (itemTemplate.ID == templateItem.ID)
      {
        return true;
      }
      if (itemTemplate.DescendsFrom(templateItem.ID))
      {
        return true;
      }
      return false;
    }

    public static bool FieldHasValue(this Item item, ID fieldID)
    {
      return item.Fields[fieldID] != null && !string.IsNullOrWhiteSpace(item.Fields[fieldID].Value);
    }

    public static int? GetInteger(this Item item, ID fieldId)
    {
      int result;
      return !int.TryParse(item.Fields[fieldId].Value, out result) ? new int?() : result;
    }

    public static IEnumerable<Item> GetMultiListValueItems(this Item item, ID fieldId)
    {
      return new MultilistField(item.Fields[fieldId]).GetItems();
    }

    public static bool HasContextLanguage(this Item item)
    {
      var latestVersion = item.Versions.GetLatestVersion();
      return latestVersion?.Versions.Count > 0;
    }

    public static HtmlString Field(this Item item, ID fieldId)
    {
      Assert.IsNotNull(item, "Item cannot be null");
      Assert.IsNotNull(fieldId, "FieldId cannot be null");
      return new HtmlString(FieldRendererService.RenderField(item, fieldId));
    }

    public static bool ItemHasLayout(this Item item)
    {
      var layoutField = item.Fields[Sitecore.FieldIDs.LayoutField];
      if (layoutField != null)
      {
        if (!string.IsNullOrWhiteSpace(layoutField.Value))
        {
          return true;
        }
      }
      return false;
    }

    public static void FixNullLinks<T>(this T item)
    {
      Type t = item.GetType();

      PropertyInfo[] properties = t.GetProperties();

      foreach (var prop in properties)
      {
        if (prop.PropertyType == typeof(Link))
        {
          if (prop.GetValue(item) == null)
          {
            Link emptyLink = new Link();
            emptyLink.Text = "";
            emptyLink.Title = "";
            emptyLink.Anchor = "";

            prop.SetValue(item, emptyLink);
          }
        }
      }

    }
  }



  public enum LinkFieldOption
  {
    Text,
    LinkType,
    Class,
    Alt,
    Target,
    QueryString
  }
}