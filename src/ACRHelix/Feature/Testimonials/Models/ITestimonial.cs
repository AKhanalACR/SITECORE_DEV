using ACRHelix.Feature.Testimonials.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Testimonials.Models
{
  public interface ITestimonial : ICMSEntity
  {
    Guid Id { get; set; }
    string Quote { get; set; }
    string Citation { get; set; }
  }
}