using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public interface IBannerVideo : ICMSEntity
    {
        Guid Id { get; }
        Image Poster { get; } 

        [SitecoreField("VideoLink")]
        Link VideoLink { get; set; }

        [SitecoreField("Background Image")]
        Image BackgroundImage { get; set; }
    }
}