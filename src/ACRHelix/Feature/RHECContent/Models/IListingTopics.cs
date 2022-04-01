using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RhecContent.Models
{
    public interface IListingTopics : ICMSEntity
    {
     ID Id { get; set; }
    [SitecoreChildren]
    IEnumerable<ITopics> Topics { get; set; }
  }
}