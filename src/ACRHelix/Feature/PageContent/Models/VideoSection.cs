using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class VideoSection : IVideoSection
    {
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual Link VideoLink { get; set; }
        public virtual IEnumerable<VideoSection> Videos { get; set; }
    }
}