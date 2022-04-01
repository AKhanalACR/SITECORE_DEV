using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{ 
  [SitecoreType(TemplateId = "{57B4E197-074C-4E3F-A85A-AFAA3017A56D}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface ILatestItemSection : ICMSEntity
  {
    ID Id { get; }
    [SitecoreField("{2EEAD172-E19E-4A8A-AAC4-D0864CAE77C6}", SitecoreFieldType.SingleLineText)]
    string Title { get; set; }

    [SitecoreField("{6188D51B-B465-4AA2-A1CF-566E22BA8A0B}", SitecoreFieldType.SingleLineText)]
    string SubTitle { get; set; }
  }
}