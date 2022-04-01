using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using ACR.Foundation.Personify.Models.Taxonomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration;

namespace ACR.Foundation.Personify.Models.Base
{
  [SitecoreType(TemplateId = TemplateID, AutoMap = true, EnforceTemplate = SitecoreEnforceTemplate.TemplateAndBase)]
  public class PersonifyTags : ICMSEntity
  {
    public const string TemplateID = "{8BE6148F-8657-4756-BCBE-DF824F90C04C}";

    public virtual ID ID { get; set; }

    [SitecoreField("Related Modalities", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<PersonifyTaxonomyItem> RelatedModalities { get; set; }

    [SitecoreField("Related Subspecialites", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<PersonifyTaxonomyItem> RelatedSubspecialites { get; set; }

    [SitecoreField("Related Interests", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<PersonifyTaxonomyItem> RelatedInterests { get; set; }


  }
}