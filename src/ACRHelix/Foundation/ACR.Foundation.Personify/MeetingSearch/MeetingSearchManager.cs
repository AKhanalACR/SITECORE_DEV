using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.MeetingSearch
{
  public class MeetingSearchManager
  {
    private string indexName;// = "products-master";

    public enum IndexEnum { Master, Web };

    public MeetingSearchManager(IndexEnum index)
    {
      if (index == IndexEnum.Master)
      {
        indexName = "meetings-master";
      }
      else
      {
        indexName = "meetings-web";
      }
    }

    public IEnumerable<MeetingSearchResult> GetMeetings(ID productId)
    {
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        string shortProductID = productId.ToShortID().ToString().ToLower();
        var results = context.GetQueryable<MeetingSearchResult>().Where(x => x.Products.Contains(shortProductID)).OrderByDescending(x => x.MeetingStartDate).ToList();
        return results;
      }
    }

    public IEnumerable<MeetingSearchResult> GetAllMeetings()
    {
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName);
      using (var context = searchIndex.CreateSearchContext())
      {       
        var results = context.GetQueryable<MeetingSearchResult>().OrderByDescending(x => x.MeetingStartDate).ToList();
        return results;
      }
    }
  }
}