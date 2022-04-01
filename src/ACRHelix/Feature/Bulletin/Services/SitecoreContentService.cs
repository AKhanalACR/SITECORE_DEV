using ACR.Foundation.Personify.Models.Base;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACRHelix.Feature.Bulletin.Constants;
using ACRHelix.Feature.Bulletin.Helpers;
using ACRHelix.Feature.Bulletin.Models;
using ACRHelix.Feature.Bulletin.Models.Rendering_Models;
using ACRHelix.Foundation.Repository.Content;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using static ACR.Foundation.Personify.Constants.ItemConstants;

namespace ACRHelix.Feature.Bulletin.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    private readonly SitecoreService _sitecoreService;
    private readonly BulletinHelper _bulletinHelper;

    public SitecoreContentService(IContentRepository repository, SitecoreService sitecoreService, BulletinHelper bulletinHelper)
    {
      _repository = repository;
      _sitecoreService = sitecoreService;
      _bulletinHelper = bulletinHelper;
    }

    public void GetBulletinArticlesFromIndex()
    {
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var allArticles = context.GetQueryable<ArticleSearchItem>().ToList();
        foreach (var a in allArticles)
        {
        }
      }
    }

    public List<IssueSearchItem> GetBulletinIssuesFromIndex()
    {
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinIssueIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var allIssues = context.GetQueryable<IssueSearchItem>().ToList();
        return allIssues;
      }
    }

    public List<ArticleSearchItem> GetArticlesByTagID(ID tagId)
    {
      string tagid = tagId.ToString();
      return GetArticlesByTagID(tagid);
    }

    public List<ArticleSearchItem> GetArticlesByTagID(string tagId)
    {
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var articles = context.GetQueryable<ArticleSearchItem>().Where(x => x.InterestTags.Contains(tagId) || x.ModalityTags.Contains(tagId) || x.SubspecialtiyTags.Contains(tagId))
          .OrderByDescending(x => x.DatePosted).ToList();
        return articles;
      }
    }

    public List<ArticleSearchItem> GetArticlesByTagID(string tagId, string year)
    {
      int tagYear = Convert.ToInt32(year);
      var startDate = new DateTime(tagYear, 1, 1);
      var endDate = new DateTime(tagYear, 12, 31);

      var tid = ID.Parse(tagId, ID.Null);
      var tagid = tid.ToString();

      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var articles = context.GetQueryable<ArticleSearchItem>().Where(x => (x.DatePosted >= startDate && x.DatePosted <= endDate)
        && (x.InterestTags.Contains(tagid) || x.ModalityTags.Contains(tagid) || x.SubspecialtiyTags.Contains(tagid)))
          .OrderByDescending(x => x.DatePosted).ToList();
        return articles;
      }
    }

    public List<ArticleSearchItem> GetArticlesByTopic(ID topicId)
    {
      var topic = topicId.ToShortID().ToString().ToLower();
      return GetArticlesByTopic(topic);
    }

    public List<ArticleSearchItem> GetArticlesByTopic(string topicId)
    {
      Guid topic;
      Guid.TryParse(topicId, out topic);
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var articles = context.GetQueryable<ArticleSearchItem>().Where(x => x.Topic.Contains(topic))
        .OrderByDescending(x => x.DatePosted).ToList();
        return articles;
      }
    }

    public List<ArticleSearchItem> GetArticlesByTopic(string topicId, string year)
    {
      int topicYear = Convert.ToInt32(year);
      Guid topic;
      Guid.TryParse(topicId, out topic);
      var startDate = new DateTime(topicYear, 1, 1);
      var endDate = new DateTime(topicYear, 12, 31);

      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var articles = context.GetQueryable<ArticleSearchItem>().Where(x => x.Topic.Contains(topic) && x.DatePosted >= startDate && x.DatePosted <= endDate)
          .OrderByDescending(x => x.DatePosted).ToList();
        return articles;
      }
    }

    public List<int> GetArticleYearsByTopic(ID topicId)
    {
      Guid topic;
      Guid.TryParse(topicId.ToShortID().ToString().ToLower(), out topic);
      List<int> years = new List<int>();
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var dates = context.GetQueryable<ArticleSearchItem>().Where(x => x.Topic.Contains(topic)).Select(x => x.DatePosted).ToList();
        years = dates.Select(x => x.Year).OrderByDescending(x => x).Distinct().ToList();
      }
      return years;
    }

    public List<int> GetArticleYearsByTag(ID tagId)
    {
      string tagid = tagId.ToString();
      List<int> years = new List<int>();
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var dates = context.GetQueryable<ArticleSearchItem>().Where(x => x.InterestTags.Contains(tagid) || x.ModalityTags.Contains(tagid) || x.SubspecialtiyTags.Contains(tagid)).Select(x => x.DatePosted).ToList();
        years = dates.Select(x => x.Year).OrderByDescending(x => x).Distinct().ToList();
      }
      return years;
    }

    public TopicPage GetBulletinTopicPage(ID topicPageId)
    {
      return _repository.GetContentItem<TopicPage>(topicPageId);
    }

    public Topic GetCurrentBulletinTopic(Item item)
    {
      if (item.TemplateID == BulletinTemplates.Article.ID)
      {
        var article = _sitecoreService.Cast<Article>(item);
        return article.Topic;
      }
      else if (item.TemplateID == BulletinTemplates.TopicPage.ID)
      {
        var topic = _sitecoreService.Cast<TopicPage>(item);
        return topic.Topic;
      }

      return null;
    }

    public PersonifyTags GetItemTags(ID itemId)
    {
      return _repository.GetContentItem<PersonifyTags>(itemId);
    }

    public Article GetBulletinArticle(ID itemId)
    {
      return _repository.GetContentItem<Article>(itemId);
    }

    public IEnumerable<TopicPage> GetTopicPages()
    {
      string query = $"/sitecore/content/ACR//*[@@templateid='{BulletinTemplates.TopicPage.TemplateID}']";
      var topicItems = _sitecoreService.Query<TopicPage>(query);
      return topicItems;
    }

    public Quote GetQuote(string id)
    {
      return _repository.GetContentItem<Quote>(id);
    }

    public Infographic GetInfographic(string id)
    {
      return _repository.GetContentItem<Infographic>(id);
    }

    public Item GetBulletinTagListPage()
    {
      var item = Sitecore.Context.Database.SelectSingleItem($"fast:/sitecore/content/ACR//*[@@templateid='{BulletinTemplates.TagListPage.TemplateID}']");
      return item;
    }

    public PersonifyTaxonomyItem GetTagID(string tagType, string tagname)
    {
      ID rootId = TaxonomyFolders.TaxonomyRoot;
      switch (tagType)
      {
        case TagTypes.Interests:
          rootId = TaxonomyFolders.Interests;
          break;

        case TagTypes.Modalities:
          rootId = TaxonomyFolders.Modalities;
          break;

        case TagTypes.Specialty:
          rootId = TaxonomyFolders.Subspecialties;
          break;

        default:
          break;
      }

      var folder = _repository.GetContentItem<ACR.Foundation.Personify.Models.Taxonomy.TaxonomyFolder>(rootId);
      if (folder != null)
      {
        var tag = folder.TaxonomyItems.ToList().FirstOrDefault(x => new string(x.FriendlyName.ToCharArray().Where(c => Char.IsLetterOrDigit(c)).ToArray()).Equals(tagname, StringComparison.OrdinalIgnoreCase));
        if (tag == null)
        {
          tag = folder.TaxonomyItems.ToList().FirstOrDefault(x => new string(x.DisplayName.ToCharArray().Where(c => Char.IsLetterOrDigit(c)).ToArray()).Equals(tagname, StringComparison.OrdinalIgnoreCase));
        }
        if (tag != null)
        {
          return tag;
        }
      }

      return null;
    }

    public HTMLMetadata.Models.HTMLMetadata GetTagPageMetaData(ID itemID)
    {
      return _repository.GetContentItem<HTMLMetadata.Models.HTMLMetadata>(itemID);
    }

    public Issue GetBulletinIssue(ID id)
    {
      return _repository.GetContentItem<Issue>(id);
    }

    public BulletinHomepageFeaturedArticles GetHomepageFeaturedArticles(string id)
    {
      return _repository.GetContentItem<BulletinHomepageFeaturedArticles>(id);
    }

    public BulletinHomepageFeaturedQuoteArticle GetHomepageFeaturedQuoteArticle(string id)
    {
      return _repository.GetContentItem<BulletinHomepageFeaturedQuoteArticle>(id);
    }

    public FeaturedArticle GetFeaturedArticle(string id)
    {
      return _repository.GetContentItem<FeaturedArticle>(id);
    }

    public IssueListPage GetIssueListPage(ID id)
    {
      return _repository.GetContentItem<IssueListPage>(id);
    }

    public List<int> GetIssueYears()
    {
      List<int> years = new List<int>();
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinIssueIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var dates = context.GetQueryable<IssueSearchItem>().Select(x => x.ReleaseDate).ToList();
        years = dates.Select(x => x.Year).OrderByDescending(x => x).Distinct().ToList();
      }
      return years;
    }

    public List<IssueSearchItem> GetIssuesByYear(string year)
    {
      int issueYear = Convert.ToInt32(year);

      var startDate = new DateTime(issueYear, 1, 1);
      var endDate = new DateTime(issueYear, 12, 31);

      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinIssueIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var issues = context.GetQueryable<IssueSearchItem>().Where(x => x.ReleaseDate >= startDate && x.ReleaseDate <= endDate).OrderByDescending(x => x.ReleaseDate).ToList();
        return issues;
      }
    }

    public BulletinArticleBreadCrumbs GetBulletinArticleBreadcrumbs(Item item, string currentPath)
    {
      List<Link> links = new List<Link>();

      while (item != null)
      {
        if (item.TemplateName == "Site Root")
        {
          break;
        }
        else if (item.IsDerived("{83DBDB92-38A6-4316-8075-CC61156C2A08}") && item.Fields["Short Title"] != null)
        {
          links.Add(new Link { Url = LinkManager.GetItemUrl(item), Text = item.Fields["Short Title"].ToString() });

          if (item.TemplateID == Constants.BulletinTemplates.Article.ID)
          {
            var issue = GetBulletinIssueForArticle(item);
            if (issue != null)
            {
              links.Add(new Link { Url = LinkManager.GetItemUrl(issue), Text = issue.Fields["Short Title"].ToString() });
            }
          }
        }
        else if (item.TemplateID == BulletinTemplates.TagListPage.ID)
        {
          var tagname = _bulletinHelper.GetTagNameFromPath(Sitecore.Context.Request.ItemPath);
          var tagtype = _bulletinHelper.GetTagTypeFromPath(Sitecore.Context.Request.ItemPath);

          var tag = GetTagID(tagtype, tagname);
          if (tag != null)
          {
            links.Add(new Link { Url = currentPath, Text = (string.IsNullOrWhiteSpace(tag.FriendlyName) ? tag.DisplayName : tag.FriendlyName) });
          }
        }

        item = item.Parent;
      }

      links.Reverse();

      BulletinArticleBreadCrumbs breadcrumbs = new BulletinArticleBreadCrumbs
      {
        Links = links
      };

      return breadcrumbs;
    }

    private Item GetBulletinIssueForArticle(Item article)
    {
      Guid articleShortId;
      Guid.TryParse(article.ID.ToShortID().ToString(), out articleShortId);
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinIssueIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var issue = context.GetQueryable<IssueSearchItem>().Where(x => x.Articles.Contains(articleShortId)).FirstOrDefault();
        if (issue != null)
        {
          return issue.GetItem();
        }
      }
      return null;
    }

    public List<ArticleSearchItem> GetRelatedBulletinArticles(ID itemId)
    {
      List<ArticleSearchItem> relatedItems = new List<ArticleSearchItem>();

      var tags = GetItemTags(itemId);
      if (tags != null)
      {
        var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
        using (var context = searchIndex.CreateSearchContext())
        {
          foreach (var interest in tags.RelatedInterests)
          {
            string interestID = interest.ID.ToString();
            var matches = context.GetQueryable<ArticleSearchItem>().Where(x => x.InterestTags.Contains(interestID)).ToList();
            relatedItems.AddRange(matches);
          }

          foreach (var modality in tags.RelatedModalities)
          {
            string modalID = modality.ID.ToString();
            var matches = context.GetQueryable<ArticleSearchItem>().Where(x => x.ModalityTags.Contains(modalID)).ToList();
            relatedItems.AddRange(matches);
          }

          foreach (var subspec in tags.RelatedSubspecialites)
          {
            string subspecID = subspec.ID.ToString();
            var matches = context.GetQueryable<ArticleSearchItem>().Where(x => x.SubspecialtiyTags.Contains(subspecID)).ToList();
            relatedItems.AddRange(matches);
          }
        }
      }

      return relatedItems;
    }

    public List<ArticleSearchItem> GetRelatedBulletinArticles(ID itemId, int numMatches = 3)
    {
      List<ArticleSearchItem> relatedItems = new List<ArticleSearchItem>();

      var tags = GetItemTags(itemId);
      if (tags != null)
      {
        var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
        var comparer = new ArticleSearchItemEqualityComparer();
        using (var context = searchIndex.CreateSearchContext())
        {
          foreach (var interest in tags.RelatedInterests)
          {
            string interestID = interest.ID.ToString();
            var matches = context.GetQueryable<ArticleSearchItem>().Where(x => x.InterestTags.Contains(interestID) && x.ItemId != itemId).ToList();
            relatedItems.AddRange(matches);
          }
          if (relatedItems.Count < numMatches)
          {
            foreach (var modality in tags.RelatedModalities)
            {
              string modalID = modality.ID.ToString();
              var matches = context.GetQueryable<ArticleSearchItem>().Where(x => x.ModalityTags.Contains(modalID) && x.ItemId != itemId).ToList();
              relatedItems.AddRange(matches);
              relatedItems = relatedItems.Distinct(comparer).ToList();
            }
          }

          if (relatedItems.Count < numMatches)
          {
            foreach (var subspec in tags.RelatedSubspecialites)
            {
              string subspecID = subspec.ID.ToString();
              var matches = context.GetQueryable<ArticleSearchItem>().Where(x => x.SubspecialtiyTags.Contains(subspecID) && x.ItemId != itemId).ToList();
              relatedItems.AddRange(matches);
            }
          }
          relatedItems = relatedItems.OrderByDescending(x => x.DatePosted).Distinct(comparer).Take(numMatches).ToList();
        }
      }

      return relatedItems;
    }

    public IssuesSlider GetIssueSliderContent(string datasource)
    {
      var issueSlider = _repository.GetContentItem<IssuesSlider>(datasource);

      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinIssueIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        issueSlider.Issues = context.GetQueryable<IssueSearchItem>().OrderByDescending(x => x.ReleaseDate).Take(12).ToList();
      }

      return issueSlider;
    }

    public TrendingArticles GetTrendingArticles(string datasource, int displayArticles = 3)
    {
      var trending = _repository.GetContentItem<TrendingArticles>(datasource);
      if (trending != null)
      {
        var articleList = trending.Articles.ToList();
        var currentArticles = articleList.Count;
        if (currentArticles < displayArticles)
        {
          var popularItems = GetPopularBulletinArticles(displayArticles - currentArticles);

          foreach (var popItem in popularItems)
          {
            articleList.Add(_sitecoreService.Cast<Article>(popItem));
          }
          trending.Articles = articleList;
        }
      }
      return trending;
    }

    private List<Item> GetPopularBulletinArticles(int topArticles)
    {
      List<Item> items = new List<Item>();
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.BulletinArticleIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {
        var articles = context.GetQueryable<ArticleSearchItem>().OrderByDescending(x => x.ArticlePageViews).ThenByDescending(x => x.DatePosted).Take(topArticles).ToList();
        foreach (var a in articles)
        {
          items.Add(a.GetItem());
        }
      }
      return items;
    }
  }
}