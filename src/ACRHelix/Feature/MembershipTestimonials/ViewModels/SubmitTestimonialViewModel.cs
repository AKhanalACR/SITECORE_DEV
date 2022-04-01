using ACRHelix.Feature.MembershipTestimonials.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.MembershipTestimonials.ViewModels
{
    public class SubmitTestimonialViewModel
    {
        private ITestimonial _testimonial;

        private ITestimonialFolder _testimonialFolder;

        public SubmitTestimonialViewModel()
        {
            _testimonial = new Testimonial();
            _testimonialFolder = new TestimonialFolder();
        }

        public ID Id { get; set; }

        public Link EditProfilePageUrl { get; set; }

        public string EditProfileInstruction { get; set; }

        public string UploadImageInstruction { get; set; }

        public string YouTubeLinkHelpText { get; set; }

        public string EngageProfileHelpText { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public ITestimonialFolder TestimonialFolder
        {
            get { return _testimonialFolder; }
            set { _testimonialFolder = value; }
        }

        public SelectList Categories { get; set; }

        public ITestimonial Testimonial
        {
            get { return _testimonial; }
            set { _testimonial = value; }
        }
    }
}