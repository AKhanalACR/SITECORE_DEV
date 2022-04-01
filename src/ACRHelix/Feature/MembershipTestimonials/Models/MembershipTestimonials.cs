using ACRHelix.Feature.MembershipTestimonials.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public class MembershipTestimonials : IMembershipTestimonials
    {
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }

        public virtual int PageSize { get; set; }

        public virtual Link FormUrl { get; set; }

        public virtual string FormBlockTitle { get; set; }

        public virtual string FormBlockButtonText { get; set; }

        public virtual ITestimonial FeaturedItem { get; set; }

        public virtual string BannerText { get; set; }

        public virtual string BannerLinkText { get; set; }

        public virtual IEnumerable<ICategory> Categories { get; set; }

        public virtual IEnumerable<ITestimonial> Testimonials { get; set; }
        
    }
}