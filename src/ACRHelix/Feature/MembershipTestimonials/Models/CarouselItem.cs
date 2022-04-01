using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public class CarouselItem : ICarouselItem
    {
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual Link FeatureLink { get; set; }

        public virtual Image FeatureImage { get; set; }
       
    }
}