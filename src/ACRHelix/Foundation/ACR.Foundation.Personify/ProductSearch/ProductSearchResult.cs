using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.ProductSearch
{
  public class ProductSearchResult : SearchResultItem
  {
    [IndexField("name")]
    public override string Name { get; set; }

    [IndexField("personify id")]
    public virtual string PersonifyId { get; set; }

    [IndexField("hasrli")]
    public virtual bool HasRLI { get; set; }
  }
}