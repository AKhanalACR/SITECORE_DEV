using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Chapters.Models
{
  [SitecoreType(TemplateId = "{F7143031-A1CA-4F9E-9D8E-4F9C40F3ED64}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class CommitteeMemberList : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Committee { get; set; }
  }
}