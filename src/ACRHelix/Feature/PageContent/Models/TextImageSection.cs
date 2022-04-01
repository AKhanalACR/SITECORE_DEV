using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.Models
{

    [SitecoreType(TemplateId = "{B3D2B4F5-1125-4512-8A52-BE6F31B694AC}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class TextImageSection : TextSection
    {
        public virtual Image Image { get; set; }

        public virtual Link ImageLink { get; set; }
        public virtual ImageLocation ImageLocation { get; set; }
        public new struct Template
    {
      public const string TemplateID = "{B3D2B4F5-1125-4512-8A52-BE6F31B694AC}";
    }


    public new struct DefaultRendering
    {
      public const string RenderingID = "{E389F825-9902-4B52-9C6E-A34BA8D603DB}";
    }

  }
}