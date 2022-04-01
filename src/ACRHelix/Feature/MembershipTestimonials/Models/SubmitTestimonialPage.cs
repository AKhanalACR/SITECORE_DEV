using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public class SubmitTestimonialPage : ISubmitTestimonialPage
    {
        public virtual ID Id { get; set; }
        public virtual Link EditProfilePageUrl { get; set; }

        public string EditProfileInstruction { get; set; }

        public string UploadImageInstruction { get; set; }
        
        public string YouTubeLinkHelpText { get; set; }

        public string EngageProfileHelpText { get; set; }
 
        public virtual ITestimonialFolder TestimonialsFolder { get; set; }

        public virtual IEnumerable<ICategory> Categories { get; set; }
    }
}