using ACRHelix.Feature.Testimonials.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Testimonials.Models
{
  public class Testimonial : ITestimonial
  {
    public Guid Id { get; set; }
    public string Quote { get; set; }
    public string Citation { get; set; }
  }
}