using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Models.Base
{
  public interface IBasePersonifyItem : ICMSEntity
  {
    ID ID { get; set; }

    [SitecoreInfo(Type = SitecoreInfoType.Name)]
    string Name { get; set; }

    IBasePersonifyItem Parent { get; set; }
  }
}