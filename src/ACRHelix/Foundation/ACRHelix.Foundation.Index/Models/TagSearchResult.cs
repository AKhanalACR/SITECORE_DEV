using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch.SearchTypes;
using ACRHelix.Foundation.Dictionary.Models;
using Sitecore.ContentSearch;

namespace ACRHelix.Foundation.Index.Models
{
  public class TagSearchResult : SearchResultItem
  {
    [IndexField("tags")]
    public IEnumerable<string> Tags { get; set; }
    [IndexField("title")]
    public string Title { get; set; }
    [IndexField("date")]
    public DateTime Date { get; set; }

    public override bool Equals(object other) //note parameter is of type object
    {
      TagSearchResult t = other as TagSearchResult;
      return (t != null) ? ItemId.Equals(t.ItemId) : false;
    }

    public override int GetHashCode()
    {
      return ItemId.GetHashCode();
    }
  }
}