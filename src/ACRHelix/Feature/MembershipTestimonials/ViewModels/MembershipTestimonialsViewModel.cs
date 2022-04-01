using ACRHelix.Feature.MembershipTestimonials.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.ViewModels
{
    public class MembershipTestimonialsViewModel
    {
        public ID Id { get; set; }

        public int PageSize { get; set; }

        public Link FormUrl { get; set; }

        public string FormBlockTitle { get; set; }

        public string FormBlockButtonText { get; set; }

        public string FeaturedItemId { get; set; }

        public string BannerText { get; set; }

        public string BannerLinkText { get; set; }

        public IEnumerable<ICategory> Categories { get; set; }

        public IEnumerable<ITestimonial> Testimonials { get; set; }

        public int MaxIndex { get; set; }
        
    }
}