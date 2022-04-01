using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    [SitecoreType(TemplateId = "{37E2CE26-B79A-4B3A-AF94-97246439319F}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public interface ISlide : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        [SitecoreField("Sub Title")]
        string SubTitle { get; set; }

        Link Link { get; set; }

        Image Image { get; set; }

        [SitecoreField("Background Image")]
        Image BackgroundImage { get; set; }
    }
}