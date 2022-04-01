
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System.Collections.Generic;
using Sitecore.Data;

namespace ACRHelix.Feature.Callouts.Models
{
  [SitecoreType(TemplateId = "{7FCAD795-3C0E-4544-BBAB-8A033C12AFA2}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface ICallouts : ICMSEntity
  {
    ID Id { get; set; }

    string Title { get; set; }

    [SitecoreChildren(InferType = true)]
    IEnumerable<ICalloutsItem> CalloutItems { get; set; }

    [SitecoreChildren(InferType = true)]
    IEnumerable<ChapterLocatorCallout> ChaperLocator { get; set; }

  }
}