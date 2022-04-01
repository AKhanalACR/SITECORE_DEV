using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MeetingsCalendar.Models
{

  [SitecoreType(TemplateId = "{8DEDA316-0323-467D-B058-3FCC56FE71B1}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class RegistrationPriceTable : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }

    [SitecoreField(FieldId = "{C5407666-1E47-41E1-BDFB-D993ED72E940}")]
    public virtual string Prices { get; set; }

    public virtual string RegisterLink { get; set; }
  }
}
