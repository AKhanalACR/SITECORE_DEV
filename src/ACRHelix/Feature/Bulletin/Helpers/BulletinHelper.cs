using ACR.Foundation.Personify.Models.Taxonomy;
using ACRHelix.Feature.Bulletin.ViewModels;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ACRHelix.Feature.Bulletin.Helpers
{
  public class BulletinHelper
  {
    private const string StartBlockQuote = "<!--Start Blockquote -->";
    private const string EndBlockQuote = "<!--End Blockquote -->";
    private const string BlockQuoteHtml = "<blockquote class=\"bulletin-article-quote\"><p>{0}</p><footer>{1}</footer></blockquote>";

    public string InsertBulletinBlockQuote(string articleText, string quote, string quoteby)
    {
      if (articleText.Contains(StartBlockQuote) && articleText.Contains(EndBlockQuote))
      {
        if (!string.IsNullOrWhiteSpace(quoteby))
        {
          quoteby = "&mdash;" + quoteby;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append(articleText.Substring(0, articleText.IndexOf(StartBlockQuote)));
        sb.Append(string.Format(BlockQuoteHtml, quote, quoteby));
        sb.Append(articleText.Substring(articleText.IndexOf(EndBlockQuote) + EndBlockQuote.Length));
        return sb.ToString();
      }
      return articleText;
    }

    public string GetImageUrl(Image image)
    {
      string url = null;

      if (image != null)
      {
        if (!string.IsNullOrEmpty(image.Src))
        {
          url = image.Src;
        }
        else if (image.MediaId != null)
        {
          if (image.MediaId != Guid.Empty)
          {
            var mediaItem = Sitecore.Context.Database.GetItem(new ID(image.MediaId));
            if (mediaItem != null)
            {
              var options = LinkManager.GetDefaultUrlOptions();
              url = LinkManager.GetItemUrl(mediaItem, options);
            }
          }
        }
      }

      return url;
    }

    public List<BulletinTag> AddTagsToBulletinList(IEnumerable<PersonifyTaxonomyItem> tagItems, string tagType, List<BulletinTag> bulletinlist, string tagPageUrl)
    {
      foreach (var tag in tagItems)
      {
        string tagname = string.IsNullOrWhiteSpace(tag.FriendlyName) ? tag.DisplayName : tag.FriendlyName;
        string safetagname = new string(tagname.ToCharArray().Where(x => Char.IsLetterOrDigit(x)).ToArray());
        tagType = new string(tagType.ToCharArray().Where(x => Char.IsLetterOrDigit(x)).ToArray());
        bulletinlist.Add(new BulletinTag()
        {
          TagDisplayName = tagname,
          TagName = safetagname,
          TagLink = $"{tagPageUrl}/{tagType}/{safetagname}"
        }); ;
      }
      return bulletinlist;
    }

    public string ToTitleCase(string title)
    {
      var textinfo = Thread.CurrentThread.CurrentCulture.TextInfo;
      return textinfo.ToTitleCase(title);
    }

    public string GetTagNameFromPath(string path)
    {
      int lastpart = path.LastIndexOf("/");
      string tagname = path.Substring(lastpart + 1);
      return tagname;
    }

    public string GetTagTypeFromPath(string path)
    {
      string[] parts = path.Split(new char[] { '/' });
      return parts[parts.Length - 2];
    }
  }
}