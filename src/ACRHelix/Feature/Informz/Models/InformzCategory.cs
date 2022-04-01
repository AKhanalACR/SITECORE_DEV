using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Informz.Models
{
  [SitecoreType(TemplateId = "{8E9884F7-2E78-4F9F-A7CD-32CDC5538430}", AutoMap = true, EnforceTemplate = SitecoreEnforceTemplate.Template)]
  public class InformzCategory : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField(FieldId = "{9BD3003C-9D2D-42F3-B95C-8431E195D7BE}")]
    public virtual string CategoryName { get; set; }

    [SitecoreChildren]
    public virtual IEnumerable<InformzNewsletter> Newsletters { get; set; }

  }
}