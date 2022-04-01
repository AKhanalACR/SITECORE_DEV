using ACRHelix.Feature.MembershipTestimonials.Models;
using ACRHelix.Foundation.Repository.Content;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.SecurityModel;
using System;

namespace ACRHelix.Feature.MembershipTestimonials.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    //private ISitecoreService _master;

    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
      //_master = new SitecoreService("custom");
    }

    public IFeaturedCarouselItems GetFeaturedCarouselItems(string contentGuid)
    {
      var x = PageContext.Current.Item;
      var tst = _repository.GetContentItem<IFeaturedCarouselItems>(contentGuid);

      return _repository.GetContentItem<IFeaturedCarouselItems>(contentGuid);
    }

    public IMembershipTestimonials GetTestimonialsContent(string contentGuid)
    {
      return _repository.GetContentItem<IMembershipTestimonials>(contentGuid);
    }

    public ITestimonial GetTestimonial(string contentGuid)
    {
      return _repository.GetContentItem<ITestimonial>(contentGuid);
    }

    public ISubmitTestimonialPage GetSubmitTestimonialContent(string contentGuid)
    {
      return _repository.GetContentItem<ISubmitTestimonialPage>(contentGuid);
    }

    public ITestimonialFolder GetTestimonialsFolder(string contentGuid)
    {
      return _repository.GetContentItem<ITestimonialFolder>(contentGuid);
    }

    public IMediaFolder GetMediaFolder(string contentGuid)
    {
      return _repository.GetContentItem<IMediaFolder>(contentGuid);
    }

    public string CreateTestimonial(ITestimonial testimonial)
    {

      return ClientService.CreateItem(testimonial, ClientService.AuthenticationToken());

      //using (new SecurityDisabler())
      //{
      //    try
      //    {
      //        testimonial.Name = ItemUtil.ProposeValidItemName(testimonial.Name);
      //        return null; // _master.Create(testimonialFolder, testimonial);
      //    }
      //    catch(Exception ex)
      //    {
      //        Sitecore.Diagnostics.Log.Error("--- vvvv --- failed to create testimonial item: " + ex.StackTrace, ex, ex.GetType());
      //        return null;
      //    }

      //}
    }

    public string CreateMediaItem(IMediaItem mediaItem)
    {
      try
      {
        mediaItem.Name = ItemUtil.ProposeValidItemName(mediaItem.Name);
        return ClientService.CreateMediaItem(mediaItem);
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("--- vvvv --- failed to create media item: " + ex.StackTrace, ex, ex.GetType());
        return null;
      }

    }

    public ITestimonialsByCategory GetTestimonialsContentByCategory(string contentGuid)
    {
      return _repository.GetContentItem<ITestimonialsByCategory>(contentGuid);
    }

    public void Save(ITestimonial testimonial, string tokenLocation)
    {
      try
      {
        ClientService.EditItem(testimonial, tokenLocation);
        //using (new SecurityDisabler())
        //{
        //    //_master.Save(testimonial);
        //}
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("--- vvvv --- failed to update testimonial: " + ex.StackTrace, ex, ex.GetType());
      }

    }

    public void Save(IMediaItem mediaItem, string tokenLocation)
    {
      try
      {
        //ClientService.EditMediaItem(mediaItem, tokenLocation);
        using (new SecurityDisabler())
        {
          //_master.Save(mediaItem);
        }
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("--- vvvv --- failed to update media item: " + ex.StackTrace, ex, ex.GetType());
      }
    }
  }
}