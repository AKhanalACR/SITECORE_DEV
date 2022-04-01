using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.Models
{
  [SitecoreType(TemplateId = "{3CC161C2-1262-441A-B2F9-4C2A9A66C9FA}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class TextVideoSection : TextSection
  {
    public virtual Link Video { get; set; }
  }
}