using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public interface IRichTextSection : ICMSEntity
    {
        ID Id { get; set; }

        string Title { get; set; }

        [SitecoreField("Rich Text", Setting = SitecoreFieldSettings.Default)]
        string RichText { get; set; }
       
       
    }
}