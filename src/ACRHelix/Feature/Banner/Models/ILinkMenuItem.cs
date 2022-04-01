using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;


namespace ACRHelix.Feature.IdeasBanner.Models
{
    public interface ILinkMenuItem
    {
        ID Id { get; }
        string Title { get; }
        Link Link { get; }
        [SitecoreField("Icon CSS Class")]
        string IconCSSClass { get; }
    }
}