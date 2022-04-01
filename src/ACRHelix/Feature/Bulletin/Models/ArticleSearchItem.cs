using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.Models
{
  public class ArticleSearchItem : SearchResultItem
  {
    [IndexField("Topic")]
    public virtual List<Guid> Topic { get; set; }

    [IndexField("Title")]
    public virtual string Title { get; set; }

    [IndexField("MainArticleImage")]
    public virtual string MainArticleImage { get; set; }

    [IndexField("DatePosted")]
    public virtual DateTime DatePosted { get; set; }

    [IndexField("PersonifyInterests")]
    public string InterestTags { get; set; }

    [IndexField("PersonifyModalties")]
    public string ModalityTags { get; set; }

    [IndexField("PersonifySubspecialties")]
    public string SubspecialtiyTags { get; set; }

    [IndexField("Tile Text")]
    public string TileText { get; set; }

    [IndexField("TileImage")]
    public string TileImageUrl { get; set; }

    [IndexField("Link Text")]
    public string LinkText { get; set; }

    [IndexField("PageViewsLast30Days")]
    public int ArticlePageViews { get; set; }
  }

  public class ArticleSearchItemEqualityComparer : IEqualityComparer<ArticleSearchItem>
  {
    public bool Equals(ArticleSearchItem x, ArticleSearchItem y)
    {
      if (x == null && y == null)
      {
        return true;
      }
      else if (x == null || y == null)
      {
        return false;
      }
      else if (x.ItemId == y.ItemId)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public int GetHashCode(ArticleSearchItem obj)
    {
      return obj.ItemId.GetHashCode();
    }
  }
}