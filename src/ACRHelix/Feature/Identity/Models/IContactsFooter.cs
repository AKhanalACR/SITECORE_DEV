using ACRHelix.Feature.Identity.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public interface IContactsFooter : ICMSEntity
    {
        Guid Id { get; }
        [SitecoreField("Column 1")]
        string Column1 { get; }
        [SitecoreField("Column 2")]
        string Column2 { get; }
        [SitecoreField("Column 3")]
        string Column3 { get; }
        [SitecoreField("Column 4")]
        string Column4 { get; }
    }
}