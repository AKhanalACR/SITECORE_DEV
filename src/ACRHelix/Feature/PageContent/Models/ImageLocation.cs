using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.Models
{

  [SitecoreType(TemplateId = "{4CB063DA-5652-44E6-8EFD-0B80223114D2}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ImageLocation
  {
    public virtual string Location { get; set; }

    [SitecoreField("Css Class")]
    public virtual string  CssClass { get; set; }

  }
}