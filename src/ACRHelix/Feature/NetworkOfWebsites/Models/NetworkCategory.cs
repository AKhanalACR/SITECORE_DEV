using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.NetworkOfWebsites.Models
{
  [SitecoreType(TemplateId = "{2291E5A7-0508-4741-AFDE-BCAAA3523570}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class NetworkCategory : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Column { get; set; }

    [SitecoreChildren]
    public virtual IEnumerable<NetworkLink> Children { get; set; } = new List<NetworkLink>();
  }
}