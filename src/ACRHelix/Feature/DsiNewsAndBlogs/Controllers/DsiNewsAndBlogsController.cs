using ACRHelix.Feature.Biography.ViewModels;
using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using ACRHelix.Feature.DsiNewsAndBlogs.Services;
using ACRHelix.Feature.DsiNewsAndBlogs.ViewModels;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ACRHelix.Feature.DsiNewsAndBlogs
{
  public class DsiNewsAndBlogsController : Controller
  {
    private readonly IContentService _contentService;

    public DsiNewsAndBlogsController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult SignUpBlogUpdates()
    {
      var viewModel = new Models.SignUpBlogUpdate();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrEmpty(dataSource))
      {
        var model = _contentService.GetBlogSignUpContent(dataSource);
        if (model != null)
        {
          viewModel = model;
          viewModel.FixNullLinks();
        }
      }
      return View(viewModel);

    }


    public ViewResult RecentBlogList()
    {
      var viewModel = new RecentBlogListViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var recentBlogListContent = _contentService.GetRecentBlogListContent(dataSource);
        if (recentBlogListContent != null)
        {
          viewModel.TagFilter = viewModel.TagFilter ?? new List<Guid>();
          viewModel.NewsArticles = recentBlogListContent.Articles.Where(x => x.Type == recentBlogListContent.Type).OrderByDescending(x => x.StartDate).Take(recentBlogListContent.DisplayNumber);

          viewModel.Id = recentBlogListContent.Id;
          viewModel.Title = recentBlogListContent.Title;
          viewModel.ArchivesLink = recentBlogListContent.ArchivesLink;

        }
      }
      return View(viewModel);
    }

    public ViewResult BlogArchive()
    {
      var viewModel = new BlogArchiveViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var blogArchiveContent = _contentService.GetBlogArchiveContent(dataSource);
        if (blogArchiveContent != null)
        {
          //viewModel.TagFilter = viewModel.TagFilter ?? new List<Guid>();
          viewModel.NewsArticles = blogArchiveContent.Articles.Where(x => x.Type == blogArchiveContent.Type).OrderByDescending(x => x.StartDate).Take(blogArchiveContent.DisplayNumber);

          viewModel.Id = blogArchiveContent.Id;
          viewModel.Title = blogArchiveContent.Title;


        }
      }
      return View(viewModel);
    }

    public ViewResult BannerVideo()
    {
      var viewModel = new BannerVideoViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var bannerVideoContent = _contentService.GetBannerVideoContent(dataSource);
        if (bannerVideoContent != null)
        {
          viewModel.Id = bannerVideoContent.Id;
          viewModel.Poster = bannerVideoContent.Poster;
          viewModel.VideoLink = bannerVideoContent.VideoLink;
          viewModel.BackgroundImage = bannerVideoContent.BackgroundImage;
        }
      }
      return View(viewModel);
    }

    public ViewResult RecentNewsList()
    {
      var viewModel = new RecentNewsListViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var recentNewsListContent = _contentService.GetRecentBlogListContent(dataSource);
        if (recentNewsListContent != null)
        {
          viewModel.TagFilter = viewModel.TagFilter ?? new List<Guid>();
          viewModel.NewsArticles = recentNewsListContent.Articles.Where(x => x.Type == recentNewsListContent.Type).OrderByDescending(x => x.StartDate).Take(recentNewsListContent.DisplayNumber);

          viewModel.Id = recentNewsListContent.Id;
          viewModel.Title = recentNewsListContent.Title;
          viewModel.ArchivesLink = recentNewsListContent.ArchivesLink;

        }
      }
      return View(viewModel);
    }

    public ViewResult NewsArchive()
    {
      var viewModel = new NewsArchiveViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var newsArchiveContent = _contentService.GetBlogArchiveContent(dataSource);
        if (newsArchiveContent != null)
        {
          viewModel.NewsArticles = newsArchiveContent.Articles.Where(x => x.Type == newsArchiveContent.Type).OrderByDescending(x => x.StartDate).Take(newsArchiveContent.DisplayNumber);
          viewModel.Title = newsArchiveContent.Title;
          viewModel.Id = newsArchiveContent.Id;
        }
      }
      return View(viewModel);
    }

    public ViewResult RecentEventTiles()
    {
      var viewModel = new RecentEventTilesViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var recentEventTilesContent = _contentService.GetRecentBlogListContent(dataSource);
        if (recentEventTilesContent != null)
        {
          viewModel.TagFilter = viewModel.TagFilter ?? new List<Guid>();
          viewModel.NewsArticles = recentEventTilesContent.Articles.Where(x => x.Type == recentEventTilesContent.Type && x.StartDate >= DateTime.Today).OrderBy(x => x.StartDate);
          if (viewModel.NewsArticles.Count() >= recentEventTilesContent.DisplayNumber)
          {
            viewModel.NewsArticles.Take(recentEventTilesContent.DisplayNumber);
          }
          else
          {
            viewModel.NewsArticles = recentEventTilesContent.Articles.Where(x => x.Type == recentEventTilesContent.Type).OrderByDescending(x => x.StartDate).Take(recentEventTilesContent.DisplayNumber);
          }

          viewModel.Id = recentEventTilesContent.Id;
          viewModel.Title = recentEventTilesContent.Title;
          viewModel.ArchivesLink = recentEventTilesContent.ArchivesLink;
        }
      }
      return View(viewModel);
    }

    public ViewResult EventArchiveTiles()
    {
      var viewModel = new EventArchiveTilesViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var eventArchiveListContent = _contentService.GetRecentBlogListContent(dataSource);
        if (eventArchiveListContent != null)
        {
          viewModel.Id = eventArchiveListContent.Id;
          viewModel.Title = eventArchiveListContent.Title;
          viewModel.NewsArticles = eventArchiveListContent.Articles.Where(x => x.Type == eventArchiveListContent.Type).OrderBy(x => x.StartDate).Take(eventArchiveListContent.DisplayNumber);

        }
      }
      return View(viewModel);
    }

    public ViewResult DsiLeadership()
    {
      var viewModel = new DsiLeadershipViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var dsiLeadershipContent = _contentService.GetDsiLeadershipContent(dataSource);
        if (dsiLeadershipContent != null)
        {
          viewModel.Id = dsiLeadershipContent.Id;
          viewModel.Title = dsiLeadershipContent.Title;
          viewModel.Biographies = dsiLeadershipContent.Biographies.Select(x => new BiographyViewModel
          {
            Id = x.Id,
            Title = x.Title,
            SubTitle = x.SubTitle,
            RichText = x.RichText,
            Email = x.Email,
            BioImage = x.BioImage,
            DisplayDetailLink = x.DisplayDetailLink,
            OtherPositions = x.OtherPositions,
            Phone = x.Phone,
            URL = x.URL
          });

        }
      }
      return View(viewModel);
    }

    public ViewResult DsiPageTitleWithImage()
    {
      var viewModel = new DsiPageTitleWithImageViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var PageTitleWithImageContent = _contentService.GetPageTitleWithImageContent(dataSource);

      if (PageTitleWithImageContent != null)
      {
        viewModel.Id = PageTitleWithImageContent.Id;
        viewModel.Title = PageTitleWithImageContent.Title;
        viewModel.TitleImage = PageTitleWithImageContent.TitleImage;
        viewModel.TitleBackgroundImage = PageTitleWithImageContent.TitleBackgroundImage;
      }

      return View(viewModel);
    }

        public ViewResult ExComponent()
        {
            var viewModel = new ExComponentViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(dataSource))
            {
                var ExComponentContent = _contentService.GetExJsComponentContent(dataSource);
                if (ExComponentContent != null)
                {
                    viewModel.Id = ExComponentContent.Id;
                    viewModel.Title = ExComponentContent.Title;
                    viewModel.RichText = ExComponentContent.RichText;
                    viewModel.ModuleUrl = ExComponentContent.ModuleUrl;
                    viewModel.ContainerClass = ExComponentContent.ContainerClass;
                }
            }
            return View(viewModel);
        }
    public ViewResult LatestBlogs()
    {
      var viewModel = new RecentBlogListViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var recentBlogListContent = _contentService.GetRecentBlogListContent(dataSource);
        if (recentBlogListContent != null)
        {
          viewModel.TagFilter = viewModel.TagFilter ?? new List<Guid>();
          viewModel.NewsArticles = recentBlogListContent.Articles.Where(x => x.Type == recentBlogListContent.Type).OrderByDescending(x => x.StartDate).Take(recentBlogListContent.DisplayNumber);

          viewModel.Id = recentBlogListContent.Id;
          viewModel.Title = recentBlogListContent.Title;
          viewModel.ArchivesLink = recentBlogListContent.ArchivesLink;

        }
      }
      return View(viewModel);
    }

    public ViewResult LatestNews()
    {
      var viewModel = new RecentNewsListViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var recentNewsListContent = _contentService.GetRecentBlogListContent(dataSource);
        if (recentNewsListContent != null)
        {
          viewModel.TagFilter = viewModel.TagFilter ?? new List<Guid>();
          viewModel.NewsArticles = recentNewsListContent.Articles.Where(x => x.Type == recentNewsListContent.Type).OrderByDescending(x => x.StartDate).Take(recentNewsListContent.DisplayNumber);

          viewModel.Id = recentNewsListContent.Id;
          viewModel.Title = recentNewsListContent.Title;
          viewModel.ArchivesLink = recentNewsListContent.ArchivesLink;

        }
      }
      return View(viewModel);
    }

    public ViewResult DSISignUp()
    {
      var viewModel = new Models.SignUpBlogUpdate();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrEmpty(dataSource))
      {
        var model = _contentService.GetBlogSignUpContent(dataSource);
        if (model != null)
        {
          viewModel = model;
          viewModel.FixNullLinks();
        }
      }
      return View(viewModel);

    }

    public ViewResult LatestItemSection()
    {
      var viewModel = new LatestItemSectionViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var latestItemSectionContent = _contentService.GetLatestItemSection(RenderingContext.Current.Rendering.DataSource);
        if (latestItemSectionContent != null)
        {
          viewModel.Id = latestItemSectionContent.Id;
          viewModel.Title = latestItemSectionContent.Title;
          viewModel.SubTitle = latestItemSectionContent.SubTitle;
        }
      }
      return View(viewModel);
    }


    public ViewResult Subscription()
    {
      var viewModel = new SubscriptionViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var subsLink = _contentService.GetSubscriptionLink(RenderingContext.Current.Rendering.DataSource);
        if (subsLink != null)
        {
          viewModel.Id = subsLink.Id;
          viewModel.SubscriptionLink = subsLink.SubscriptionLink;
        }
      }
      return View(viewModel);
    }


    public ViewResult RecentBlogPostList()
    {
      var viewModel = new RecentBlogPostListViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var recentBlogListContent = _contentService.GetRecentBlogPostListContent(dataSource);
        if (recentBlogListContent != null)
        {
          viewModel.TagFilter = viewModel.TagFilter ?? new List<Guid>();
          viewModel.NewsArticles = recentBlogListContent.Articles.Where(x => x.Type == recentBlogListContent.Type).OrderByDescending(x => x.StartDate).Take(recentBlogListContent.DisplayNumber);
          viewModel.BlogPosts = recentBlogListContent.BlogPosts.OrderByDescending(x => x.PublishDate).Take(recentBlogListContent.DisplayNumber);
          viewModel.Id = recentBlogListContent.Id;
          viewModel.Title = recentBlogListContent.Title;
          viewModel.ArchivesLink = recentBlogListContent.ArchivesLink;

        }
      }
      return View(viewModel);
    }


    public ViewResult FeaturedXBlogs()
    {
      var viewModel = new FeaturedXBlogsViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!string.IsNullOrEmpty(dataSource))
      {
        var featuredXBlogsContent = _contentService.GetFeaturedXBlogsContent(dataSource);
        if (featuredXBlogsContent != null)
        {
          viewModel.Id = featuredXBlogsContent.Id;
          
          viewModel.MainFeaturedBlog = featuredXBlogsContent.MainFeaturedBlog.Take(1);
          viewModel.SubFeaturedBlogs = featuredXBlogsContent.SubFeaturedBlogs.Take(3);
          
        }
      }
      return View(viewModel);
    }

  }

}