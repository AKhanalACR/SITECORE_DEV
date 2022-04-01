using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.ProductSearch
{
  public class ProductSearchManager
  {
    private string indexName;// = "products-master";

    public enum IndexEnum { Master, Web };
   
    public ProductSearchManager(IndexEnum index)
    {
      if (index == IndexEnum.Master)
      {
        indexName = "products-master";
      }
      else
      {
        indexName = "products-web";
      }
    }

    public IEnumerable<ProductSearchResult> GetProducts(string personifyId)
    {
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var results = context.GetQueryable<ProductSearchResult>().Where(x => x.PersonifyId == personifyId).ToList();
        return results;
      }
    }

    public IEnumerable<ProductSearchResult> GetRLIProducts()
    {
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var results = context.GetQueryable<ProductSearchResult>().Where(x => x.HasRLI == true).ToList();
        return results;
      }
    }
  }

}