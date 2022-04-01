using ACRHelix.Feature.SiteSection.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.Models
{
    public interface ISubSiteSection : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }
        string Heading { get; }
        string Description { get; }
        [SitecoreQuery("./Tiles/*", IsRelative = true)]
        IEnumerable<ITile> Tiles { get; }
    }
}