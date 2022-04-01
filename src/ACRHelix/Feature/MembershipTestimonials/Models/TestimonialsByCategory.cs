using ACRHelix.Feature.MembershipTestimonials.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public class TestimonialsByCategory : ITestimonialsByCategory
    {
        public ID Id { get; set; }

        public string Title { get; set; }

        public int NbrToItemsToDisplay { get; set; }

        public string Category { get; set; }

        public Link ArchiveLink { get; set; }

        public IEnumerable<ITestimonial> Testimonials { get; set; }
    }
}