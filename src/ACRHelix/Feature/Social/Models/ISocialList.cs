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
    public interface ISocialList : ICMSEntity
    {
        Guid Id { get; }
        [SitecoreChildren]
        IEnumerable<SocialItem> SocialItems { get; }
    }
}