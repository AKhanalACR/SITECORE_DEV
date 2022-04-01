using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public class TestimonialFolder : ITestimonialFolder
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }
    }
}