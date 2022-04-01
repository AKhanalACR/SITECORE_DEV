using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CodingSource.Models
{
  [SitecoreType(TemplateId = "{8E7BCEC6-4380-4112-8B0F-2A8CA42E082D}", AutoMap = true)]
  public class CodingSource : ICMSEntity
  {
    public virtual Guid Id { get; set; }

    [SitecoreField("Title")]
    public virtual string Title { get; set; }

    [SitecoreField("Date")]
    public virtual DateTime Date { get; set; }

    [SitecoreField("SubTitle")]
    public virtual string SubTitle { get; set; }

    [SitecoreInfo(Glass.Mapper.Sc.Configuration.SitecoreInfoType.Url)]
    public virtual string Url { get; set; }

  }
}