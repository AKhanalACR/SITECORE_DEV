using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{ 
  [SitecoreType(TemplateId = "{6A7203FA-47B5-4C41-B692-BF634737214A}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface ISubscription : ICMSEntity
  {
    ID Id { get; }

    [SitecoreField("{66FE9A95-1307-40FC-BFFA-F73423480FE2}", SitecoreFieldType.GeneralLink)]
    Link SubscriptionLink { get; set; }

  }
}