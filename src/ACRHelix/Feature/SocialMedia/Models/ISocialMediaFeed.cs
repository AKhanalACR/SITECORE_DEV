using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SocialMedia.Models
{
    public interface ISocialMediaFeed : ICMSEntity
    {
		Guid Id { get; set; }
        String EmbeddedHTML { get; set; }
    }
}