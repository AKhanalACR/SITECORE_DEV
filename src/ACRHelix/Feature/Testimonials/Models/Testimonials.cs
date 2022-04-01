using ACRHelix.Feature.Testimonials.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Testimonials.Models
{
  public class Testimonials : ITestimonials
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<ITestimonial> TestimonialItems { get; set; }
  }
}