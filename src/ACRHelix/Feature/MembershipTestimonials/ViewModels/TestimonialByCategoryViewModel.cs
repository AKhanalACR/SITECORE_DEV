using ACRHelix.Feature.MembershipTestimonials.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;

namespace ACRHelix.Feature.MembershipTestimonials.ViewModels
{
    public class TestimonialByCategoryViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public int NbrOfItemsToDisplay { get; set; }
        public string Category { get; set; }
        public Link ArchiveLink { get; set; }
        public IEnumerable<ITestimonial> Testimonials { get; set; }
 
    }
}