using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
  [SitecoreType(TemplateId = "{1EA192A7-9088-4510-A24D-18FA37296A37}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ResourcesHomePage : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("{25DDB8FB-42E2-459F-A63C-8BE3BFB447EB}", SitecoreFieldType.SingleLineText)]
    public virtual string Title { get; set; }
    [SitecoreField("{39785039-DC57-4D9D-9094-C2B0AB429D90}", SitecoreFieldType.SingleLineText)]
    public virtual string SubTitle { get; set; }
    [SitecoreField("{EB0C455E-0875-437C-8974-9754E02ABCB2}", SitecoreFieldType.Multilist)]
    public virtual IEnumerable<Models.Resource> Resources { get; set; }
    [SitecoreField("{73A12732-8DC5-4723-BF03-AC5C9E71D9CE}", SitecoreFieldType.SingleLineText)]
    public virtual string TopicTitle { get; set; }
    [SitecoreField("{AAE5EB89-5C70-4A14-98F3-C184A8A59211}", SitecoreFieldType.Multilist)]
    public virtual IEnumerable<ITopics> Topics { get; set; }  
}
}