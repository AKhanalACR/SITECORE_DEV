using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;

namespace ACRHelix.Feature.CodingSource.Models
{
  [SitecoreType(TemplateId = "{620574DB-8759-4EE7-A709-8798C78D1309}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class CodingSourceList : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }

    [SitecoreQuery("../..//*[@@templateid='{8E7BCEC6-4380-4112-8B0F-2A8CA42E082D}']", IsRelative = true)]
    public virtual IEnumerable<CodingSource> CodingSources { get; set; }

  }
}