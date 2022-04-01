using System;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DSIHomeBanner.Models
{
  [SitecoreType(TemplateId = "{94806F84-CA44-4569-8B5B-E4AFB3D6476D}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface IHomeBanner: ICMSEntity
  {
    ID Id { get; set; }

    [SitecoreField("{E8D3E1F7-C83D-4874-9BE9-2A65FC4D917B}", SitecoreFieldType.SingleLineText)]
    string Title { get; set; }

    [SitecoreField("{CC40A424-EC52-475D-A66D-6C299E870D41}", SitecoreFieldType.SingleLineText)]
    string SubTitle { get; set; }

    [SitecoreField("{AEC5238B-66EF-4495-AA3E-BC81D31D6383}", SitecoreFieldType.GeneralLink)]
    Link Link { get; set; }

    [SitecoreField("{CE4F7ADB-AF9F-477F-AD86-64C94483DC61}", SitecoreFieldType.Image)]
    Image BGImage { get; set; }
  }
}
