using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.DsiNewsAndBlogs.ViewModels
{
    public class BannerVideoViewModel
    {
        public Guid Id { get; set; }
        public Image Poster { get; set; }
        public Link VideoLink { get; set; }
        public Image BackgroundImage { get; set; }
    }
}