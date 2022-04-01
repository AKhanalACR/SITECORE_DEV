using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models.Base;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace ACR.Foundation.Personify.Models.Products 
{
  [SitecoreType(TemplateId = "{124A9B41-6045-4007-AB87-29E5DAB8F9D3}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ProductSubsytemFolder : IBasePersonifyItem
  {
    public virtual ID ID { get; set; }
    public virtual string Name { get; set; }
    public IBasePersonifyItem Parent { get; set; }

    [SitecoreChildren()]
    public virtual IEnumerable<ProductClassFolder> ProductClasses { get; set; }
  }
}