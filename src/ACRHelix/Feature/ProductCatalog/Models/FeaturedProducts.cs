using ACR.Foundation.Personify.Models.Products;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ProductCatalog.Models
{
  [SitecoreType(TemplateId = "{5C28CE2F-4BA7-4544-AE1D-EF179895F67A}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class FeaturedProducts : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Section Title")]
    public virtual string SectionTitle
    {
      get; set;
    }

    [SitecoreField("Join Link",FieldType = SitecoreFieldType.GeneralLink)]
    public virtual Link JoinLink { get; set; }

    [SitecoreField("Featured Products", FieldType = SitecoreFieldType.Multilist)]
    public virtual IEnumerable<ProductStubItem> Products { get; set; }

  }
}