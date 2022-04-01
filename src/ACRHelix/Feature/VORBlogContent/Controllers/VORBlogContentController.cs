using ACRHelix.Feature.VORBlogContent.Models;
using ACRHelix.Feature.VORBlogContent.Services;
using ACRHelix.Feature.VORBlogContent.ViewModels;
using Glass.Mapper.Sc;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.VORBlogContent
{
  public class VORBlogContentController : Controller
  {
    private readonly IContentService _contentService;

    public VORBlogContentController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult VORFeaturedBlog()
    {
      var viewModel = new VORFeaturedBlogViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      Models.IVORFeaturedBlog featuredXBlogsContent=null;
      if (!string.IsNullOrEmpty(dataSource))
      {
        featuredXBlogsContent = _contentService.GetVORFeaturedXBlogContent(dataSource);
        if (featuredXBlogsContent != null)
        {
          viewModel.Id = featuredXBlogsContent.Id;
          viewModel.MainFeaturedBlog = featuredXBlogsContent.MainFeaturedBlog.Take(1);
          
        }
      }
      if(featuredXBlogsContent == null || featuredXBlogsContent.MainFeaturedBlog.Count()==0)
      {
        string latestBlogId = "";
        try {
          latestBlogId = Sitecore.Feature.XBlog.Areas.XBlog.Search.BlogManager.GetLatestVORBlogPost();
        }
        catch { }
        if(!string.IsNullOrEmpty(latestBlogId))
        {
          var mainFeaturedBlogToAdd = new IVORBlogPost[] { new SitecoreContext().Cast<IVORBlogPost>(Sitecore.Context.Database.GetItem(latestBlogId)) };
          IEnumerable<IVORBlogPost> mainFeaturedBlog = mainFeaturedBlogToAdd;
          if (!string.IsNullOrEmpty(latestBlogId) && mainFeaturedBlog!=null)
          {
            viewModel.Id = Sitecore.Data.ID.Parse(latestBlogId);
            viewModel.MainFeaturedBlog = mainFeaturedBlog;
          }
        }
       
      }
      return View(viewModel);
    }


    public ViewResult VORSubscription()
    {
      var viewModel = new VORSubscriptionViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var subsLink = _contentService.GetVORSubscriptionLink(RenderingContext.Current.Rendering.DataSource);
        if (subsLink != null)
        {
          viewModel.Id = subsLink.Id;
          viewModel.SubscriptionLink = subsLink.SubscriptionLink;
        }
      }
      return View(viewModel);
    }


  }
}