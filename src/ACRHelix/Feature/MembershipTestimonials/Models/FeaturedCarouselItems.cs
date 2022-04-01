using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public class FeaturedCarouselItems : IFeaturedCarouselItems
    {
        public virtual IEnumerable<CarouselItem> CarouselItems { get; set; }
    }
}