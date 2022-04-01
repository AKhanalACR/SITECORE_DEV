using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models.Base;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace ACR.Foundation.Personify.Models.Products
{
  [SitecoreType(TemplateId = "{6770A627-3CCE-44F7-ABBF-C1CAEE0ECF20}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ProductClassFolder : IBasePersonifyItem
  {
    public virtual ID ID { get; set; }
    public virtual string Name { get; set; }
    public virtual IBasePersonifyItem Parent { get; set; }

    [SitecoreChildren()]
    public virtual IEnumerable<ProductStubItem> ProductStubs { get; set; }
  }
}