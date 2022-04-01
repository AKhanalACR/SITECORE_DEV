using ACRHelix.Feature.PageContent.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.ViewModels
{
    public class VideoSectionViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public Link VideoLink { get; set; }
        public IEnumerable<VideoSection> Videos { get; set; }
    }
}