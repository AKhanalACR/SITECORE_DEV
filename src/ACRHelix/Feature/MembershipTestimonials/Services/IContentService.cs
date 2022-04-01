using ACRHelix.Feature.MembershipTestimonials.Models;
using ACRHelix.Feature.MembershipTestimonials.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Services
{
    public interface IContentService
    {
        IFeaturedCarouselItems GetFeaturedCarouselItems(string contentGuid);

        IMembershipTestimonials GetTestimonialsContent(string contentGuid);

        ITestimonial GetTestimonial(string contentGuid);

        ISubmitTestimonialPage GetSubmitTestimonialContent(string contentGuid);

        ITestimonialFolder GetTestimonialsFolder(string contentGuid);

        IMediaFolder GetMediaFolder(string contentGuid);

        string CreateTestimonial(ITestimonial testimonial);

        string CreateMediaItem(IMediaItem mediaItem);

        ITestimonialsByCategory GetTestimonialsContentByCategory(string contentGuid);

        void Save(ITestimonial testimonial, string resp);

        void Save(IMediaItem mediaItem, string resp);

    }
}