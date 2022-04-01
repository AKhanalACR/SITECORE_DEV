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
    [SitecoreType(AutoMap = true, TemplateId = "{562B7AAC-136C-4525-A0A8-6A739BD3238B}", EnforceTemplate = SitecoreEnforceTemplate.Template)]
    public interface IPledgeType : ICMSEntity
    {
        ID Id { get; set; }

        string Name { get; set; }

        [SitecoreField("Pledge Type Name")]
        string PledgeTypeName { get; set; }

    }
}