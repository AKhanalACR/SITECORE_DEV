using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.ComputedFields
{
  public class NewsIssueDate : AbstractComputedIndexField
  {
    public override object ComputeFieldValue(IIndexable indexable)
    {
      // item is currently being indexed.
      Item item = indexable as SitecoreIndexableItem;
      // null check on item
      if (item != null)
      {
        var firstNews = item.Children.FirstOrDefault(x => x.TemplateName == "NewsArticle");
        if (firstNews != null)
        {
          DateField date = firstNews.Fields["Date"];
          return date.DateTime;
        }
      }
      return null;
    }
  }
}