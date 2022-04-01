using ACRHelix.Feature.SocialMedia.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SocialMedia.Models
{
    public class SocialMediaLinkList : ISocialMediaLinkList
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<ISocialMediaLink> Links { get; set; }
    }
}