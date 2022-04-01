using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasContent.Models
{
  [SitecoreType(TemplateId = "{F51F5515-A618-4257-8EFC-F313CDAF5C6E}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface ILinkMenuItem
    {
        ID Id { get; }
        string Title { get; }
        Link Link { get; }
        [SitecoreField("Icon CSS Class")]
        string IconCSSClass { get; }
    }
}