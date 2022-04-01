using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
  [SitecoreType(TemplateId = "{4307E5A8-1923-4E33-A503-9FF8564F1B7E}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ContentSlider : ICMSEntity
    {
        public virtual ID Id { get; set; }
        public virtual IEnumerable<ISlide> Slides { get; set; }
    }
}