using ACRHelix.Feature.SocialMedia.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SocialMedia.Models
{
    public class SocialMediaFeed: ISocialMediaFeed
    {
        public Guid Id { get; set; }
        public string EmbeddedHTML { get; set; }
    }
}