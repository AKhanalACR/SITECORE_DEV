using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{    
    public interface ITestimonial : ICMSEntity
    {
        Guid Id { get; set; } 

        [SitecoreInfo(SitecoreInfoType.Name)]
        string Name { get; set; }

        [SitecoreField("Customer ID")]
        string CustomerId { get; set; }

        [SitecoreField("Full Name")]
        string FullName { get; set; }

        string Chapter { get; set; }

        [SitecoreField("Member Date")]
        DateTime MemberDate { get; set; }

        [SitecoreField("Profile Image")]
        Image ProfileImage { get; set; }

        string FaceBook { get; set; }

        [SitecoreField("Twitter Handle")]
        string TwitterHandle { get; set; }

        string LinkedIn { get; set; }

        [SitecoreField("Engage Profile")]
        string EngageProfile { get; set; }

        [SitecoreField("YouTube Link")]
        string YouTubeLink { get; set; }

        //IEnumerable<Category> Category { get; set; }

        string Category { get; set; }

        [SitecoreField("Intro Message")]
        string IntroMessage { get; set; }

        [SitecoreField("Brief Message")]
        string BriefMessage { get; set; }

        [SitecoreField("Testimonial Message", Setting = SitecoreFieldSettings.RichTextRaw)]
        string TesimonialMessage { get; set; }

        [SitecoreField("__Created")]
        DateTime DateCreated { get; set; }

        [SitecoreField("SubTitle", Setting = SitecoreFieldSettings.RichTextRaw)]
        string SubTitle { get; set; }

        bool Display { get; set; }
    }
}
