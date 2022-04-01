using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.Models
{
    public interface ILinkMenu : ICMSEntity
    {
        string Name { get; }
        [SitecoreField("Include Character Based Divider")]
        bool IncludeCharacterBasedDivider { get; }
        [SitecoreChildren]
        IEnumerable<ILinkMenuItem> MenuItems { get; }
    }
}