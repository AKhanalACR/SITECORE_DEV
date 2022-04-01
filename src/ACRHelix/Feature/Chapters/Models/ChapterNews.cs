using System;
using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Chapters.Models
{
  [SitecoreType(TemplateId = "{CCC08FF8-7527-45E2-BEB7-6E9C6B70E087}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ChapterNews : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Url { get; set; }

    public virtual string Title { get; set; }

    public virtual string SubTitle { get; set; }

    public virtual DateTime Date { get; set; }


    //public virtual string Author { get; set; }

  }
}