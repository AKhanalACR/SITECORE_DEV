using ACRHelix.Feature.Testimonials.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Testimonials.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public ITestimonials GetTestimonialsContent(string contentGuid)
    {
      return _repository.GetContentItem<ITestimonials>(contentGuid);
    }
  }
}