using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.Models
{
  public class IssueSearchItem : SearchResultItem
  {
    [IndexField("Issue Name")]
    public string IssueName { get; set; }

    [IndexField("Articles")]
    public List<Guid> Articles { get; set; }

    [IndexField("Release Date")]
    public DateTime ReleaseDate { get; set; }

    [IndexField("Link Text")]
    public string LinkText { get; set; }

    [IndexField("IssuePDF")]
    public string IssuePDFUrl { get; set; }

    [IndexField("TileImage")]
    public string TileImageUrl { get; set; }
  }
}