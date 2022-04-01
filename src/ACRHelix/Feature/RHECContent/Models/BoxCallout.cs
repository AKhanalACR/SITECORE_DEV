using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
  [SitecoreType(TemplateId = "{33981BF8-A009-40AB-8C00-75F8D8447A2A}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class BoxCallout : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("{E4406641-75CB-46BA-A246-A833E14D6500}", SitecoreFieldType.SingleLineText)]
    public virtual string Text { get; set; }
    [SitecoreField("{5BA17139-A519-4292-812E-A38F1A7E90AB}", SitecoreFieldType.SingleLineText)]
    public virtual string ButtonText { get; set; }
    [SitecoreField("{4F6AA21F-45D8-4F1C-AAA4-FD56359D0951}", SitecoreFieldType.GeneralLink)]
    public virtual Link Link { get; set; }



  }
}