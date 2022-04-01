using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Feature.Identity.Models;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public interface IIWFooterTopSection : ICMSEntity
    {
        Guid Id { get; set; }

        [SitecoreField("Section Intro")]
        string SectionIntro { get; set; }

        [SitecoreChildren]
        IEnumerable<IWFooterTopSectionItem> SectionItems { get; }
    }
}