using ACRHelix.Feature.MembershipTestimonials.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.MembershipTestimonials.ViewModels
{
    public class TestimonialsViewModel : ICMSEntity
    {
        public ID Id { get; }

        public int PageSize { get; set; }
        
        public string FormUrl { get; set; }

        [SitecoreQuery("/sitecore/content//*[@@templatekey = 'Testimonial']", IsRelative = false)]
        public IEnumerable<Testimonial> Testimonials { get; set; }

        [SitecoreQuery("/sitecore/content//*[@@templatekey = 'Option']", IsRelative = false)] 
        public IEnumerable<Category> Categories { get; set; }
    }
}