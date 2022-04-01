using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RhecContent.Models
{
  public class ResourcesSearchResult : SearchResultItem
  {
    [IndexField("publish_date")]
    public DateTime PublishDate { get; set; }

    [IndexField("title")]
    public string Title { get; set; }

    [IndexField("body")]
    public string Body { get; set; }

    [IndexField("summary")]
    public string Summary { get; set; }
    [IndexField("link_override")]
    public string LinkOverride { get; set; }

    [IndexField("new_window")]
    public bool NewWindow { get; set; }

    [IndexField("resourcetopics")]
    public List<string> Topics { get; set; }




  }
}