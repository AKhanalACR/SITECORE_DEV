using ACRHelix.Feature.Testimonials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Testimonials.ViewModels
{
  public class TestimonialsViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<ITestimonial> Testimonials { get; set; }
  }
}