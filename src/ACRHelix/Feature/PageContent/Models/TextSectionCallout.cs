using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
  [SitecoreType(TemplateId = "{6DB9264F-5167-4253-9878-547B91C47CA8}", AutoMap = true,EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class TextSectionCallout : TextSection
  {
    public virtual ID Id { get; set; }
    [SitecoreField("Top Text")]
    public virtual string TopText { get; set; }
    [SitecoreField("Bottom Text")]
    public virtual string BottomText { get; set; }
    public virtual Link Link { get; set; }

    public new struct Template
    {
      public const string TemplateID = "{6DB9264F-5167-4253-9878-547B91C47CA8}";
    }

    public new struct DefaultRendering
    {
      public const string RenderingID = "{680CC74B-3500-43FA-BAD1-75FC748B2D1B}";
    }
  }
}