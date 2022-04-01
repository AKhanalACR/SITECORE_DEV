using ACRHelix.Feature.VORBlogContent.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.VORBlogContent.Models
{ 
  [SitecoreType(TemplateId = "{AF116FF8-2350-4FBF-919F-0FF498C81166}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface IVORSubscription : ICMSEntity
  {
    ID Id { get; }

    [SitecoreField("{3915E404-5BFB-4C09-A81F-A1FEFE5C9575}", SitecoreFieldType.GeneralLink)]
    Link SubscriptionLink { get; set; }

  }
}