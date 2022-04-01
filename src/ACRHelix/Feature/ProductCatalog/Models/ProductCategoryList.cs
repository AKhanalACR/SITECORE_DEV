using ACR.Foundation.Personify.Models.Taxonomy;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ProductCatalog.Models
{
  [SitecoreType(TemplateId = "{1A76B0F4-1337-4182-B00E-5DD6A3243887}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ProductCategoryList : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Section Title")]
    public virtual string SectionTitle
    {
      get; set;
    }

    [SitecoreField("Product Categories",FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<PersonifyTaxonomyItem> ProductCategories { get; set; }

  }
}