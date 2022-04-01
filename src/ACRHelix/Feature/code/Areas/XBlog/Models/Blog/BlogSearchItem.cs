using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Models.Blog
{
  public class BlogSearchItem : SearchResultItem
  {
    [IndexField("Summery")]
    public virtual List<Guid> Summery { get; set; }

    [IndexField("Title")]
    public virtual string Title { get; set; }

    [IndexField("Publish Date")]
    public virtual string PublishDate { get; set; }

    [IndexField("Category")]
    public virtual string Category { get; set; }

  }
}



