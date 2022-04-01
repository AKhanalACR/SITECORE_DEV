using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Configuration;
using ACR.Foundation.Personify.Models.Base;

namespace ACR.Foundation.Personify.Models.Taxonomy
{
  [SitecoreType(TemplateId = "{96588098-9C3A-479A-B385-9F220FDD843C}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class TaxonomyFolder : IBasePersonifyItem
  {
    public static ID TemplateID = new ID("{96588098-9C3A-479A-B385-9F220FDD843C}");

    public virtual ID ID { get; set; }
    public virtual string Name { get; set; }
    public virtual IBasePersonifyItem Parent { get; set; }

    [SitecoreChildren()]
    public virtual IEnumerable<PersonifyTaxonomyItem> TaxonomyItems { get; set; }

  }
}