using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public interface ITakeThePledge : ICMSEntity
    {
        Guid Id { get; set; }
        string Title { get; set; }

        [SitecoreField("Dropdown Head Text")]
        string DdlHeadText { get; set; }

        [SitecoreChildren]
        IEnumerable<ILinkMenuItem> MenuItems { get; }
    }
}