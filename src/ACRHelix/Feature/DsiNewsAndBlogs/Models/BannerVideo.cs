using System;
using Glass.Mapper.Sc.Fields;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public class BannerVideo : IBannerVideo
    {
        public Guid Id { get; }
        public Image Poster { get; set; }
        public Link VideoLink { get; set; }
        public Image BackgroundImage { get; set; }
    }
}