using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{
    public interface ILinkMenu : ICMSEntity
    {
        Guid Id { get; set; }

        [SitecoreChildren]
        IEnumerable<ILinkMenuItem> MenuItems { get; set; }
    }
}