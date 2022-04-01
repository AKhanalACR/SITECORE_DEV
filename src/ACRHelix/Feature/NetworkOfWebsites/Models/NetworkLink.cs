
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.NetworkOfWebsites.Models
{
  [SitecoreType(TemplateId = "{4C3207FE-97B0-4ADE-94A5-2ED42A62610A}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class NetworkLink : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual Link Link { get; set; }
    
  }
}