using ACRHelix.Feature.Social.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Social.Models
{
    public interface ISocialItem : ICMSEntity
    {
        Guid Id { get; }
        [SitecoreField("CSS Class")]
        string CSSClass { get; }
        Link Link { get; }
    }
}