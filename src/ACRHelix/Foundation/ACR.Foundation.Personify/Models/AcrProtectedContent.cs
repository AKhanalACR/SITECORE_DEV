using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACR.Foundation.Personify.Models
{
  [SitecoreType(TemplateId = "{C474EE7D-3B0C-483F-A578-8EF892A20F50}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public class AcrProtectedContent : ICMSEntity
  {
    public virtual ID Id
    {
      get; set;
    }

    [SitecoreField("Required Access")]
    public virtual string RequiredAccess { get; set; }

    [SitecoreField("Required Products")]
    public virtual IEnumerable<ProductStubItem> RequiredProducts
    {
      get; set;
    }

    [SitecoreField("Required Roles")]
    public virtual IEnumerable<PersonifyTaxonomyItem> RequiredRoles
    {
      get; set;
    }

    public virtual string Url { get; set; }
  }
}