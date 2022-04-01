using ACRHelix.Feature.Bulletin.Helpers;
using ACRHelix.Feature.Bulletin.Models;
using ACRHelix.Feature.Bulletin.Models.Rendering_Models;
using ACRHelix.Feature.Bulletin.Services;
using ACRHelix.Feature.Bulletin.ViewModels;
using Sitecore.Mvc.Presentation;
using System.Linq;
using System.Web.Mvc;

namespace ACRHelix.Feature.Bulletin
{
  public class BulletinController : Controller
  {
    private readonly IContentService _contentService;
    private readonly BulletinHelper _bulletinHelper;

    public BulletinController(IContentService contentService, BulletinHelper bulletinHelper)
    {
      _contentService = contentService;
      _bulletinHelper = bulletinHelper;
    }

    public ViewResult BulletinHomeFeaturedArticles()
    {
      var model = new BulletinHomepageFeaturedArticles();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        model = _contentService.GetHomepageFeaturedArticles(RenderingContext.Current.Rendering.DataSource);
      }
      return View("~/Views/Bulletin/Home/FeaturedArticles.cshtml");
    }

    public ViewResult FeaturedQuote()
    {
      var model = new BulletinHomepageFeaturedQuoteArticle();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        model = _contentService.GetHomepageFeaturedQuoteArticle(RenderingContext.Current.Rendering.DataSource);
      }
      return View("~/Views/Bulletin/Home/FeaturedQuote.cshtml", model);
    }

    public ActionResult FullWidthFeaturedArticle()
    {
      var viewModel = new ArticleViewModel();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var featured = _contentService.GetFeaturedArticle(RenderingContext.Current.Rendering.DataSource);
        if (featured != null && featured.Article != null)
        {
          viewModel = new ArticleViewModel(featured.Article, _bulletinHelper);
        }
      }
      return View("~/Views/Bulletin/Home/FullWidthFeaturedArticle.cshtml", viewModel);
    }

    public ViewResult BulletinMastHead()
    {
      var viewModel = new MastHeadViewModel();

      var topicPages = _contentService.GetTopicPages();
      var currentTopic = _contentService.GetCurrentBulletinTopic(Sitecore.Context.Item);

      var homePage = Sitecore.Context.Database.SelectSingleItem($"fast:/sitecore/content//*[@@templateid='{Constants.BulletinTemplates.BulletinHomePage.TemplateID}']");
      if (homePage != null)
      {
        viewModel.BulletinHomePageUrl = Sitecore.Links.LinkManager.GetItemUrl(homePage);
      }
      viewModel.CurrentTopic = currentTopic;
      viewModel.Topics = topicPages.OrderBy(x => x.Topic.Name).ToList();

      //_contentService.GetBulletinArticlesFromIndex();
      //_contentService.GetBulletinIssuesFromIndex();

      return View("~/Views/Bulletin/General/Masthead.cshtml", viewModel);
    }

    public ViewResult Infographic()
    {
      var infographic = new Infographic();
      if (!string.IsNullOrWhiteSpace(RenderingContext.Current.Rendering.DataSource))
      {
        infographic = _contentService.GetInfographic(RenderingContext.Current.Rendering.DataSource);
        if (infographic != null)
        {
          infographic.InfographicUrl = _bulletinHelper.GetImageUrl(infographic.InfographicImage);
        }
      }
      return View("~/Views/Bulletin/Articles/Infographic.cshtml", infographic);
    }

    public ViewResult QuoteSidebar()
    {
      var quote = new Quote();

      if (!string.IsNullOrWhiteSpace(RenderingContext.Current.Rendering.DataSource))
      {
        quote = _contentService.GetQuote(RenderingContext.Current.Rendering.DataSource);
      }
      return View("~/Views/Bulletin/Articles/SideBlockQuote.cshtml", quote);
    }

    public ActionResult BulletinArticle()
    {
      var viewModel = new ArticleViewModel();
      if (Sitecore.Context.Item != null)
      {
        var article = _contentService.GetBulletinArticle(Sitecore.Context.Item.ID);
        if (article != null)
        {
          viewModel = new ArticleViewModel(article, _bulletinHelper);
        }
      }
      return View("~/Views/Bulletin/Articles/BulletinArticle.cshtml", viewModel);
    }

    public ViewResult SpecialIssueArticle()
    {
      var viewModel = new ArticleViewModel();
      if (Sitecore.Context.Item != null)
      {
        var article = _contentService.GetBulletinArticle(Sitecore.Context.Item.ID);
        if (article != null)
        {
          viewModel = new ArticleViewModel(article, _bulletinHelper);
        }
      }
      return View("~/Views/Bulletin/Articles/SpecialIssueArticle.cshtml", viewModel);
    }

    public ActionResult BulletinAccordion()
    {
      var viewModel = new ArticleViewModel();
      if (Sitecore.Context.Item != null)
      {
        var article = _contentService.GetBulletinArticle(Sitecore.Context.Item.ID);
        if (article != null)
        {
          viewModel = new ArticleViewModel(article, _bulletinHelper);
        }
      }
      return View("~/Views/Bulletin/Articles/BulletinAccordion.cshtml", viewModel);
    }

    public ViewResult BulletinTags()
    {
      var tags = new TagsViewModel();

      if (Sitecore.Context.Item != null)
      {
        var tagInfo = _contentService.GetItemTags(Sitecore.Context.Item.ID);
        var tagPage = _contentService.GetBulletinTagListPage();

        string tagPageUrl = "/ACR-Bulletin/Tags";
        if (tagPage != null)
        {
          tagPageUrl = Sitecore.Links.LinkManager.GetItemUrl(tagPage);
          tagPageUrl = tagPageUrl.Replace("/,-w-,", "");
        }

        tags.BulletinTags = _bulletinHelper.AddTagsToBulletinList(tagInfo.RelatedInterests, Constants.TagTypes.Interests, tags.BulletinTags, tagPageUrl);
        tags.BulletinTags = _bulletinHelper.AddTagsToBulletinList(tagInfo.RelatedModalities, Constants.TagTypes.Modalities, tags.BulletinTags, tagPageUrl);
        tags.BulletinTags = _bulletinHelper.AddTagsToBulletinList(tagInfo.RelatedSubspecialites, Constants.TagTypes.Specialty, tags.BulletinTags, tagPageUrl);
      }
      return View("~/Views/Bulletin/General/BulletinTags.cshtml", tags);
    }

    public ViewResult ArticlesByTopic()
    {
      var viewModel = new ArticlesByTagViewModel();

      var item = Sitecore.Context.Item;
      if (item != null)
      {
        var topicPage = _contentService.GetBulletinTopicPage(item.ID);
        if (topicPage != null)
        {
          viewModel.Years = _contentService.GetArticleYearsByTopic(topicPage.Topic.Id);
          viewModel.Title = topicPage.Title;
          viewModel.CurrentTagID = topicPage.Topic.Id.ToShortID().ToString().ToLower();
        }
      }

      return View("~/Views/Bulletin/Lists/ArticlesByTopic.cshtml", viewModel);
    }

    [HttpPost]
    public ActionResult GetTopicArticles(string topic, string year)
    {
      var viewModel = new ArticleListModel();
      viewModel.Articles = _contentService.GetArticlesByTopic(topic, year);
      return PartialView("~/Views/Bulletin/Lists/ArticleList.cshtml", viewModel);
    }

    [HttpPost]
    public ActionResult GetTagArticles(string tag, string year)
    {
      var viewModel = new ArticleListModel();
      viewModel.Articles = _contentService.GetArticlesByTagID(tag, year);
      return PartialView("~/Views/Bulletin/Lists/ArticleList.cshtml", viewModel);
    }

    public ActionResult BulletinIssue()
    {
      var model = _contentService.GetBulletinIssue(Sitecore.Context.Item.ID);

      if (model.Articles.Count() == 0)
      {
        if (model.BulletinPDF != null && !Sitecore.Context.PageMode.IsExperienceEditor)
        {
          return Redirect(model.BulletinPDF.Src);
        }
      }
      return View("~/Views/Bulletin/Issues/BulletinIssue.cshtml", model);
    }

    public ViewResult BulletinTagPageMetaData()
    {
      var viewModel = new TagPageMetaData();

      var tagname = _bulletinHelper.GetTagNameFromPath(Sitecore.Context.Request.ItemPath);
      var tagtype = _bulletinHelper.GetTagTypeFromPath(Sitecore.Context.Request.ItemPath);

      var tag = _contentService.GetTagID(tagtype, tagname);
      if (tag != null)
      {
        string tagName = string.IsNullOrWhiteSpace(tag.FriendlyName) ? tag.DisplayName : tag.FriendlyName;
        viewModel.PageTitle = $"{tagName} Bulletin Articles";
        viewModel.MetaDescription = $"List of all Bulletin Articles related to {tagName}";
        viewModel.MetaKeywords = $"ACR Bulletin, {tagName}, {tagtype}";
        viewModel.PageUrl = Request.Url.PathAndQuery;
      }

      var ogInfo = _contentService.GetTagPageMetaData(Sitecore.Context.Item.ID);
      if (ogInfo != null && ogInfo.OG_Image != null)
      {
        viewModel.OG_Image = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Host, ogInfo.OG_Image.Src);
      }

      return View("~/Views/Bulletin/MetaData/BulletinTagPageMetaData.cshtml", viewModel);
    }

    public ActionResult ArticlesByTag()
    {
      var viewModel = new ArticlesByTagViewModel();

      var tagname = _bulletinHelper.GetTagNameFromPath(Sitecore.Context.Request.ItemPath);
      var tagtype = _bulletinHelper.GetTagTypeFromPath(Sitecore.Context.Request.ItemPath);

      var tag = _contentService.GetTagID(tagtype, tagname);
      if (tag != null)
      {
        viewModel.CurrentTagID = tag.ID.ToShortID().ToString().ToLower();
        viewModel.Title = string.IsNullOrWhiteSpace(tag.FriendlyName) ? tag.DisplayName : tag.FriendlyName;
        viewModel.Years = _contentService.GetArticleYearsByTag(tag.ID);
      }
      else
      {
        if (Sitecore.Context.PageMode.IsExperienceEditor)
        {
          viewModel.Title = "Bulletin Articles By Tag";
        }
        else
        {
          return HttpNotFound();
        }
      }

      return View("~/Views/Bulletin/Lists/ArticlesByTag.cshtml", viewModel);
    }

    public ViewResult IssueList()
    {
      var viewModel = new IssueListViewModel();
      viewModel.IssueListPage = _contentService.GetIssueListPage(Sitecore.Context.Item.ID);
      viewModel.Years = _contentService.GetIssueYears();
      return View("~/Views/Bulletin/Issues/BulletinIssueList.cshtml", viewModel);
    }

    public ActionResult GetIssuesByYear(string year)
    {
      var issues = _contentService.GetIssuesByYear(year);

      return PartialView("~/Views/Bulletin/Issues/IssueListJs.cshtml", issues);
    }

    public ViewResult BulletinArticleBreadBreadcrumb()
    {
      var viewModel = new BulletinArticleBreadcrumbsViewModel();

      var NavigationContent = _contentService.GetBulletinArticleBreadcrumbs(Sitecore.Context.Item, Request.Url.PathAndQuery);
      if (NavigationContent != null)
      {
        viewModel.Links = NavigationContent.Links;
      }

      return View("~/Views/Bulletin/Articles/BulletinArticleBreadcrumb.cshtml", viewModel);
    }

    public ViewResult RelatedBulletinArticles3Box()
    {
      var viewModel = new ArticleListModel();
      viewModel.Articles = _contentService.GetRelatedBulletinArticles(Sitecore.Context.Item.ID);

      return View("~/Views/Bulletin/Related/RelatedBulletinArticles3Box.cshtml", viewModel);
    }

    public ViewResult ReccomendedReadingList()
    {
      var viewModel = new ArticleListModel();
      viewModel.Articles = _contentService.GetRelatedBulletinArticles(Sitecore.Context.Item.ID);

      return View("~/Views/Bulletin/Related/BulletinReccomendedReading.cshtml", viewModel);
    }

    public ViewResult IssuesSlider()
    {
      var model = new IssuesSlider();

      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        model = _contentService.GetIssueSliderContent(RenderingContext.Current.Rendering.DataSource);
      }
      return View("~/Views/Bulletin/Issues/IssuesSlider.cshtml", model);
    }

    public ViewResult TrendingArticles()
    {
      var model = new TrendingArticles();
      if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        model = _contentService.GetTrendingArticles(RenderingContext.Current.Rendering.DataSource);
      }
      return View("~/Views/Bulletin/Home/TrendingArticles.cshtml", model);
    }
  }
}