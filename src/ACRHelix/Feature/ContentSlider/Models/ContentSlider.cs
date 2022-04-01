using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.ContentSlider.Models
{
  [SitecoreType(TemplateId = "{59AB703F-BEB5-431D-9EDC-2BF81F1C1016}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ContentSlider : ICMSEntity
    {
        public virtual ID Id { get; set; }
        public virtual IEnumerable<Slide> Slides { get; set; }
    }
}