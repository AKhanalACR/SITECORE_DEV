using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.IdeasContent.Models
{

    [SitecoreType(TemplateId = "{0387FF2B-7B57-42BC-AC42-35A1722E4D82}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasMapWidgetText : IdeasMapWidget
  {
        public virtual string Text { get; set; }    
        public new struct Template
    {
      public const string TemplateID = "{0387FF2B-7B57-42BC-AC42-35A1722E4D82}";
    }
 
  }
}