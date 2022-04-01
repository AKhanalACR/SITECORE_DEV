using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    [SitecoreType(EnforceTemplate = SitecoreEnforceTemplate.Template, TemplateId = "{F8C25D64-FEA9-49A2-A763-78DF7A277FF8}", AutoMap = true)]
    public class Testimonial : ITestimonial
    {
        public virtual Guid Id { get; set; } 

        public virtual string Name { get; set; }

        public virtual string CustomerId { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Chapter { get; set; }

        public virtual DateTime MemberDate { get; set; }

        public virtual Image ProfileImage { get; set; }

        public virtual string FaceBook { get; set; }
        
        public virtual string TwitterHandle { get; set; }
        
        public virtual string LinkedIn { get; set; }
        
        public virtual string EngageProfile { get; set; }
        public virtual string YouTubeLink { get; set; }
        
        public virtual string Category { get; set; }
       
        public virtual string IntroMessage { get; set; }

        public virtual string BriefMessage { get; set; }

        public virtual string TesimonialMessage { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual string SubTitle { get; set; }

        public virtual bool Display { get; set; }
    }
}