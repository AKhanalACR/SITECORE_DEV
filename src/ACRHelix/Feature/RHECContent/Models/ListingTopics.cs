using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RhecContent.Models
{
    public class ListingTopics : IListingTopics
  {
    public ID Id { get; set; }
    public IEnumerable<ITopics> Topics { get; set; }
    }
}