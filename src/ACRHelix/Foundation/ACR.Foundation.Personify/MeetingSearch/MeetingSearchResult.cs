using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.MeetingSearch
{
  public class MeetingSearchResult : SearchResultItem
  {
    [IndexField("products")]
    public string Products { get; set; }

    [IndexField("start date")]
    public DateTime MeetingStartDate { get; set; }

    [IndexField("end date")]
    public DateTime MeetingEndDate { get; set; }

    [IndexField("meeting type")]
    public string MeetingType { get; set; }
  }
}