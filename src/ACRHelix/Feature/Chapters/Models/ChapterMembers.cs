using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Chapters.Models
{
  [SitecoreType(TemplateId = "{F3AC6B3E-4091-4320-8DC2-F624A0960142}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ChapterMembers : ICMSEntity
  {
    public virtual ID Id { get; set; }

    //public virtual string Title { get; set; }
    public virtual string Chapter { get; set; }
  }
}