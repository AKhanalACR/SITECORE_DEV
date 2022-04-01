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
  [SitecoreType(TemplateId = "{BADC0179-4E3F-43D8-A7DF-C99428C18AAB}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class PledgeCounter : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("{9EC16A60-1695-4C45-8574-34D16E790CB6}", SitecoreFieldType.SingleLineText)]
    public virtual string Title { get; set; }
    [SitecoreField("{93E5177A-4654-49BA-9F7B-36928D650088}", SitecoreFieldType.Integer)]
    public virtual int MinimumPledgeCount { get; set; }
    [SitecoreField("{FEFE7EAD-54A3-46D1-AAB4-F8F76B67EA67}", SitecoreFieldType.DateTime)]
    public virtual DateTime Date { get; set; }



  }
}