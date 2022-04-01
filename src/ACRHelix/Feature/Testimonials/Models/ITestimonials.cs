using ACRHelix.Feature.Testimonials.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Testimonials.Models
{
  public interface ITestimonials : ICMSEntity
  {
    Guid Id { get; set; }
    string Title { get; set; }
    [SitecoreChildren]
    IEnumerable<ITestimonial> TestimonialItems { get; set; }
  }
}