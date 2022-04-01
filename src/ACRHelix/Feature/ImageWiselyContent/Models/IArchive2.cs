using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
  [SitecoreType(TemplateId = "{DDDBA134-91DC-4321-8D04-F9AEA0D8B11F}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface IArchive2 : ICMSEntity
  {
    ID Id { get; set; }

    string Title { get; set; }

    string SubTitle { get; set; }

    IEnumerable<IArticlePage> ArticlePages { get; set; }
  }
}
