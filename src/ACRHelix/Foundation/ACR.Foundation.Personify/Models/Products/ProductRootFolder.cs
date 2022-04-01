using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models.Base;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace ACR.Foundation.Personify.Models.Products
{
[SitecoreType(TemplateId = "{1F20B469-2A47-40FA-8D54-CED7FA0D1225}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
public class ProductRootFolder : IBasePersonifyItem
  {
    public virtual ID ID { get; set; }
    public virtual string Name { get; set; }
    public virtual IBasePersonifyItem Parent { get; set; }

    [SitecoreChildren()]
    public virtual IEnumerable<ProductSubsytemFolder> ProductSubsytemFolders { get; set; }
  }
}