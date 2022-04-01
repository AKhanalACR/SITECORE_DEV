using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.Tags.Models
{
  public class ACRTagSearchResult : SearchResultItem
  {
    [IndexField("ContentTags")]
    public string ContentTags { get; set; }

    [IndexField("PersonifyInterests")]
    public string PersonifyInterests { get; set; }

    [IndexField("PersonifyModalties")]
    public string PersonifyModalities { get; set; }

    [IndexField("PersonifySubspecialties")]
    public string PersonifySubspecialties { get; set; }
  }
}