using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.Models
{
  public class NewsPressReleaseSearchResult : SearchResultItem
  {
    [IndexField("date")]
    public DateTime Date { get; set; }

    [IndexField("type")]
    public string Type { get; set; }

    [IndexField("author")]
    public string Author { get; set; }

    [IndexField("subtitle")]
    public string Subtitle { get; set; }

    [IndexField("title")]
    public string Title { get; set; }

    //[IndexField("tags")]
    //public string Tags { get; set; }

    [IndexField("NewsTags")]
    public string NewsTags { get; set; }

    [IndexField("PersonifyInterests")]
    public string PersonifyInterests { get; set; }

    [IndexField("PersonifyModalties")]
    public string PersonifyModalties { get; set; }

    [IndexField("PersonifySubspecialties")]
    public string PersonifySubspecialties { get; set; }



  }
}