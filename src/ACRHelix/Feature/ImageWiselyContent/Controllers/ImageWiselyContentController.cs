using ACRHelix.Feature.ImageWiselyContent.Services;
using ACRHelix.Feature.ImageWiselyContent.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ACRHelix.Feature.ImageWiselyContent
{
  public class ImageWiselyContentController : Controller
  {
    private readonly IContentService _contentService;
    private readonly PledgeService _pledgeService;
    public ImageWiselyContentController(IContentService contentService)
    {
      _contentService = contentService;
      _pledgeService = new PledgeService();

    }

    public ViewResult ImageWiselyContent()
    {
      var viewModel = new ImageWiselyContentViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var ImageWiselyContentContent = _contentService.GetImageWiselyContentContent(RenderingContext.Current.Rendering.DataSource);
        if (ImageWiselyContentContent != null)
        {
          viewModel.Title = ImageWiselyContentContent.Title;
        }
      }
      return View(viewModel);
    }

    public ViewResult GlobalBannerText()
    {
      var viewModel = new GlobalBannerTextViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var BannerContent = _contentService.GetGlobalBannerContent(RenderingContext.Current.Rendering.DataSource);
        if (BannerContent != null)
        {
          viewModel.Id = BannerContent.Id;
          viewModel.Text = BannerContent.Text;
        }
      }
      return View(viewModel);
    }

    public ViewResult PageTitleSection()
    {
      var viewModel = new PageTitleSectionViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var PageTitleContent = _contentService.GetPageTitleSectionContent(RenderingContext.Current.Rendering.DataSource);
        if (PageTitleContent != null)
        {
          viewModel.PageTitleSection = PageTitleContent;
        }
      }
      return View(viewModel);
    }

    public ViewResult TakeThePledge()
    {
      var viewModel = new TakeThePledgeViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var TakeThePledgeContent = _contentService.GetTakeThePledgeContent(RenderingContext.Current.Rendering.DataSource);
        if (TakeThePledgeContent != null)
        {
          viewModel.Content = TakeThePledgeContent;
        }
      }
      return View(viewModel);
    }

    public ViewResult RichTextWithImage()
    {
      var viewModel = new RichTextWithImageViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var RichTextContent = _contentService.GetRichTextWithImageContent(RenderingContext.Current.Rendering.DataSource);
        if (RichTextContent != null)
        {
          viewModel.Content = RichTextContent;
        }
      }
      return View(viewModel);
    }

    public ViewResult RadiationSafety()
    {
      var viewModel = new RadiationSafetyViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var RadiationSafety = _contentService.GetArchivesContent(RenderingContext.Current.Rendering.DataSource);
        if (RadiationSafety != null)
        {
          viewModel.Id = RadiationSafety.Id;
          viewModel.Title = RadiationSafety.Title;
          viewModel.SubTitle = RadiationSafety.SubTitle;
          viewModel.ModalitiesList = RadiationSafety.ContentPageList.Take(6);
          string url = viewModel.ModalitiesList.Where(s => s.Title.Contains("Referring")).Single().Url;
          viewModel.ModalitiesList.Where(s => s.Title.Contains("Patients")).Select(s => { s.Url = url; return s; }).ToList();
          viewModel.ModalitiesList.Where(s => s.Title.Contains("Referring")).Select(s => { s.Url = (s.Url + "#referring"); return s; }).ToList();
        }
      }
      return View(viewModel);
    }

    public ViewResult WeAreReading()
    {
      var viewModel = new WeAreReadingViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var ReadingContent = _contentService.GetArchivesContent(RenderingContext.Current.Rendering.DataSource);

        if (ReadingContent != null)
        {
          viewModel.Id = ReadingContent.Id;
          viewModel.Title = ReadingContent.Title;
          viewModel.Link = ReadingContent.Link;
          viewModel.Url = ReadingContent.Url;
          viewModel.ArticlesList = ReadingContent.ArticlePageList.OrderByDescending(x => x.Date).Take(3);
        }
      }
      return View(viewModel);
    }

    public ViewResult NewsTiles()
    {
      var viewModel = new NewsTilesViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var ArticleContent = _contentService.GetNewsListContent(RenderingContext.Current.Rendering.DataSource);

        if (ArticleContent != null)
        {
          viewModel.Id = ArticleContent.Id;
          viewModel.Title = ArticleContent.Title;
          viewModel.Url = ArticleContent.Url;
          //viewModel.ItemsToDisplay = ArticleContent.PageSize;
          viewModel.NewsArticles = ArticleContent.NewsArticleList.OrderByDescending(d => d.Date).Take(3);
          viewModel.NewsTopicList = ArticleContent.TopicFolder;
        }
      }
      return View(viewModel);
    }

    public ViewResult RichTextSection()
    {
      var viewModel = new RichTextSectionViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var RichTextContent = _contentService.GetRichTextSectionContent(RenderingContext.Current.Rendering.DataSource);

        if (RichTextContent != null)
        {
          viewModel.Id = RichTextContent.Id;
          viewModel.Title = RichTextContent.Title;
          viewModel.RichText = RichTextContent.RichText;
          viewModel.RichTextSect = RichTextContent;

        }
      }
      return View(viewModel);
    }

    public ViewResult IWPageTitle()
    {
      var viewModel = new IWPageTitleViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var PageTitleContent = _contentService.GetPageTitleContent(Sitecore.Context.Item.ID.ToString());
      if (PageTitleContent != null)
      {
        viewModel.Id = PageTitleContent.Id;
        viewModel.Title = PageTitleContent.Title;
        viewModel.SubTitle = PageTitleContent.SubTitle;
        viewModel.RichText = PageTitleContent.RichText;
      }

      return View("IWPageTitle", viewModel);
    }

    public ViewResult IWPageContent()
    {
      var viewModel = new IWPageTitleViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var PageTitleContent = _contentService.GetPageTitleContent(Sitecore.Context.Item.ID.ToString());
      if (PageTitleContent != null)
      {
        viewModel.Id = PageTitleContent.Id;
        viewModel.Title = PageTitleContent.Title;
        viewModel.SubTitle = PageTitleContent.SubTitle;
        viewModel.RichText = PageTitleContent.RichText;
        viewModel.Date = PageTitleContent.Date == null ? DateTime.MinValue : PageTitleContent.Date;

      }

      return View("IWPageContent", viewModel);
    }

    public ViewResult ArticlePageContent()
    {
      var viewModel = new IWPageTitleViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var PageTitleContent = _contentService.GetPageTitleContent(Sitecore.Context.Item.ID.ToString());
      if (PageTitleContent != null)
      {
        viewModel.Id = PageTitleContent.Id;
        viewModel.Title = PageTitleContent.Title;
        viewModel.SubTitle = PageTitleContent.SubTitle;
        viewModel.RichText = PageTitleContent.RichText;
        viewModel.Date = PageTitleContent.Date == null ? DateTime.MinValue : PageTitleContent.Date;

      }
      return View(viewModel);
    }

    public ViewResult IWPageTitleWithImage()
    {
      var viewModel = new IWPageTitleViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var PageTitleContent = _contentService.GetPageTitleWithImageContent(dataSource);
      if (PageTitleContent != null)
      {
        viewModel.Id = PageTitleContent.Id;
        viewModel.Title = PageTitleContent.Title;
        viewModel.Image = PageTitleContent.Image;
      }
      return View("IWPageTitleWithImage", viewModel);
    }

    public ViewResult ImageWithPageTitle()
    {
      var viewModel = new IWPageTitleViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var PageTitleContent = _contentService.GetPageTitleWithImageContent(dataSource);
      if (PageTitleContent != null)
      {
        viewModel.Id = PageTitleContent.Id;
        viewModel.Title = PageTitleContent.Title;
        viewModel.Image = PageTitleContent.Image;
      }
      return View("ImageWithPageTitle", viewModel);
    }

    public ViewResult ImageWithTextCallout()
    {
      var viewModel = new PageTitleSectionViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var PageTitleContent = _contentService.GetPageTitleSectionContent(RenderingContext.Current.Rendering.DataSource);
        if (PageTitleContent != null)
        {
          viewModel.PageTitleSection = PageTitleContent;
        }
      }
      return View("ImageWithTextCallout", viewModel);
    }

    public ViewResult NewsList()
    {
      var viewModel = new NewsTilesViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var ArticleContent = _contentService.GetNewsListContent(RenderingContext.Current.Rendering.DataSource);

        if (ArticleContent != null)
        {
          viewModel.Id = ArticleContent.Id;
          viewModel.Title = ArticleContent.Title;
          viewModel.Url = ArticleContent.Url;
          viewModel.NewsArticles = ArticleContent.NewsArticleList;
          viewModel.ItemsToDisplay = ArticleContent.PageSize;
          viewModel.NewsTopicList = ArticleContent.TopicFolder;
        }
      }
      return View(viewModel);
    }

    public ViewResult WhatWeReadingList()
    {
      var viewModel = new WeAreReadingViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var ReadingContent = _contentService.GetArchivesContent(RenderingContext.Current.Rendering.DataSource);

        if (ReadingContent != null)
        {
          viewModel.Id = ReadingContent.Id;
          viewModel.Title = ReadingContent.Title;
          viewModel.Image = ReadingContent.Image;
          viewModel.PageSize = ReadingContent.PageSize;
          viewModel.Link = ReadingContent.Link;
          viewModel.Url = ReadingContent.Url;
          viewModel.TopicList = ReadingContent.TopicFolder;
          viewModel.ArticlesList = ReadingContent.ArticlePageList;
        }
      }
      return View("WWRList", viewModel);
    }

    public ViewResult ModalityPageTiles()
    {
      var viewModel = new ModalityPageTilesViewModel();
      var ReadingContent = _contentService.GetArchivesContent(Sitecore.Context.Item.ID.ToString());

      if (ReadingContent != null)
      {
        viewModel.Id = ReadingContent.Id;
        viewModel.Title = ReadingContent.Title;
        viewModel.SubTitle = ReadingContent.SubTitle;
        viewModel.ArticlesList = ReadingContent.ArticlePageList;
      }
      return View("ModalityPageTiles", viewModel);
    }

    public ViewResult ModalityPageTiles2()
    {
      var viewModel = new ModalityPageTilesViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrEmpty(dataSource))
      {
        var ReadingContent = _contentService.GetArchivesContent2(dataSource);
        if (ReadingContent != null)
        {
          viewModel.Id = ReadingContent.Id;
          viewModel.Title = ReadingContent.Title;
          viewModel.SubTitle = ReadingContent.SubTitle;
          viewModel.ArticlesList = ReadingContent.ArticlePages;
        }
      }
      return View("ModalityPageTiles", viewModel);
    }
    public ViewResult RadiationSafetyArticlesList()
    {
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
      {
          dataSource = Sitecore.Context.Item.ID.ToString();
      }

      var viewModel = new RadiationSafetyViewModel();
      var RadiationSafety = _contentService.GetArchivesContent(dataSource);
      if (RadiationSafety != null)
      {
          viewModel.Id = RadiationSafety.Id;
          viewModel.Title = RadiationSafety.Title;
          viewModel.SubTitle = RadiationSafety.SubTitle;
          viewModel.ArticlePagesList = RadiationSafety.ArticlePageList.OrderByDescending(d => d.Date).Take(20);
          viewModel.NewSectionTitle = RadiationSafety.NewSectionTitle;
          viewModel.PreviousSectionTitle = RadiationSafety.PreviousSectionTitle;

      }
      return View(viewModel);
    }

    public ViewResult RsnaRecentArticlesList()
    {
      var viewModel = new RsnaDoseExhibitionViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var RsnaArticles = _contentService.GetArchivesContent(RenderingContext.Current.Rendering.DataSource);
        if (RsnaArticles != null)
        {
          viewModel.Id = RsnaArticles.Id;
          viewModel.Title = RsnaArticles.Title;
          viewModel.SubTitle = RsnaArticles.SubTitle;
          viewModel.ArticlePagesList = RsnaArticles.ArticlePageList.OrderByDescending(d => d.Date);
          viewModel.ListPage = RsnaArticles.ContentPageList;
        }
      }
      return View(viewModel);
    }
    public ViewResult RsnaArticlesList()
    {
      var viewModel = new RsnaDoseExhibitionViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();

      if (!string.IsNullOrEmpty(dataSource))
      {
        var RsnaArticles = _contentService.GetArchivesContent(dataSource);
        if (RsnaArticles != null)
        {
          viewModel.Id = RsnaArticles.Id;
          viewModel.Title = RsnaArticles.Title;
          viewModel.SubTitle = RsnaArticles.SubTitle;
          viewModel.ArticlePagesList = RsnaArticles.ArticlePageList.OrderByDescending(d => d.Date);
        }
      }
      return View(viewModel);
    }

    public ViewResult PLedgeCounterSection()
    {
      var viewModel = new PledgeCounterSectionViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var PledgeCounterContent = _contentService.GetPledgeCounterSectionContent(RenderingContext.Current.Rendering.DataSource);
        if (PledgeCounterContent != null)
        {
          viewModel.PledgeCounterSection = PledgeCounterContent;
          viewModel.ImagingPCount = _pledgeService.ImagingProfessionalsPledgeCount();
          viewModel.ReferringPCount = _pledgeService.ReferingPractitionersPledgeCount();
          viewModel.ImagingFCount = _pledgeService.FacilitiesPledgeCount();
          viewModel.AssocAEdProgCount = _pledgeService.AssociationsPledgeCount();
          viewModel.TotalPledgeCount = viewModel.ImagingPCount + viewModel.ReferringPCount + viewModel.ImagingFCount + viewModel.AssocAEdProgCount;
        }
      }
      return View(viewModel);
    }

    public ViewResult HonorRoll()
    {
      var viewModel = new HonorRollViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var HonorRollContent = _contentService.GetHonorRollContent(RenderingContext.Current.Rendering.DataSource);
        if (HonorRollContent != null)
        {
          viewModel.Id = HonorRollContent.Id;
          viewModel.Title = HonorRollContent.Title;
          viewModel.SubTitle = HonorRollContent.SubTitle;
          viewModel.RichText = HonorRollContent.RichText;
          viewModel.FilterText = HonorRollContent.FilterText;
        }
      }
      return View(viewModel);
    }

    public ViewResult IWCarousel()
    {
      var viewModel = new IWCarouselViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var sliderContent = _contentService.GetSlidesContent(RenderingContext.Current.Rendering.DataSource);
        if (sliderContent != null)
        {
          viewModel.ContentSlider = sliderContent;
        }
      }
      return View(viewModel);
    }

    public ViewResult AdditionalResources()
    {
        var viewModel = new AdditionalResourcesViewModel();
        if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
        {
            var Contents = _contentService.GetAdditionalResources(RenderingContext.Current.Rendering.DataSource);

            if (Contents != null)
            {
                viewModel.ResourcesContent = Contents;
            }
        }
        return View(viewModel);
    }

        public ViewResult BlockWithTextCallout()
        {
            var viewModel = new BlockWithTextCalloutViewModel();
            if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var Contents = _contentService.GetBlockWithTextCalloutContent(RenderingContext.Current.Rendering.DataSource);

                if (Contents != null)
                {
                    viewModel.Id = Contents.Id;
                    viewModel.RichText = Contents.RichText;
                    viewModel.Link = Contents.Link;
                }
            }
            return View(viewModel);
        }

        public JsonResult GetAssocFacilitiesPledgeCount(int t = 1)
    {
      if (t == 1)
      {
        var data = _pledgeService.FacilityHonorPledgeCountByState().ToList();
        return Json(data, JsonRequestBehavior.AllowGet);
      }
      else
      {
        var data = _pledgeService.AssociationHonorPledgeCountByState().ToList();
        return Json(data, JsonRequestBehavior.AllowGet);
      }
    }

    public JsonResult GetStateAssocFacilitiesPledge(string state, int t)
    {
      if (t == 1)
      {
        var data = _pledgeService.GetStateFacilitiesPledge(state).Select(x => new ACR.Library.ImageWisely.Data.Pledge() { City = x.City, StateProvince = x.StateProvince, Institution = x.Institution }).Distinct().OrderBy(x => x.City).ToList();
        return Json(data, JsonRequestBehavior.AllowGet);
      }
      else
      {
        var data = _pledgeService.GetStateAssociationsPledge(state).Select(x => new ACR.Library.ImageWisely.Data.Pledge() { City = x.City, StateProvince = x.StateProvince, Institution = x.Institution }).Distinct().OrderBy(x => x.City).ToList();
        return Json(data, JsonRequestBehavior.AllowGet);
      }

    }
  }
}