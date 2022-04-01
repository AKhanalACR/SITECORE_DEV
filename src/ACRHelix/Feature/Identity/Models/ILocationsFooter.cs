using ACRHelix.Feature.Identity.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public interface ILocationsFooter : ICMSEntity
    {
        Guid Id { get; }
        string Text { get; }
        [SitecoreField("Link Text")]
        string LinkText { get; }
        Link Link { get; }
        [SitecoreChildren]
        IEnumerable<ILocation> Locations { get; }
    }
}