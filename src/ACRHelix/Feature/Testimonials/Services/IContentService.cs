using ACRHelix.Feature.Testimonials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Testimonials.Services
{
  public interface IContentService
  {
    ITestimonials GetTestimonialsContent(string contentGuid);
  }
}