using ACRHelix.Feature.SiteSection.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.Models
{
    public interface ISiteSection : ICMSEntity
    {
        ID Id { get; }
        string Title { get; }
        [SitecoreField("Header Image")]
        Image HeaderImage { get; }
        string Heading { get; }
    }
}