using ACR.Foundation.Personify.Models.Base;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACRHelix.Feature.Bulletin.Models;
using ACRHelix.Feature.Bulletin.Models.Rendering_Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.Services
{
  public interface IContentService
  {
    Article GetBulletinArticle(ID itemId);

    Quote GetQuote(string id);

    Infographic GetInfographic(string id);

    List<IssueSearchItem> GetBulletinIssuesFromIndex();

    void GetBulletinArticlesFromIndex();

    List<ArticleSearchItem> GetRelatedBulletinArticles(ID itemId, int numMatches = 3);

    List<ArticleSearchItem> GetArticlesByTagID(ID tagId);

    List<ArticleSearchItem> GetArticlesByTagID(string tagId);

    List<ArticleSearchItem> GetArticlesByTagID(string tagId, string year);

    List<ArticleSearchItem> GetArticlesByTopic(ID topicId);

    List<ArticleSearchItem> GetArticlesByTopic(string topicId);

    List<ArticleSearchItem> GetArticlesByTopic(string topicId, string year);

    IEnumerable<TopicPage> GetTopicPages();

    Topic GetCurrentBulletinTopic(Item item);

    PersonifyTags GetItemTags(ID itemId);

    TopicPage GetBulletinTopicPage(ID topicPageId);

    Item GetBulletinTagListPage();

    PersonifyTaxonomyItem GetTagID(string tagType, string tagname);

    List<int> GetArticleYearsByTag(ID tagId);

    List<int> GetArticleYearsByTopic(ID topicId);

    HTMLMetadata.Models.HTMLMetadata GetTagPageMetaData(ID itemID);

    Issue GetBulletinIssue(ID id);

    BulletinHomepageFeaturedArticles GetHomepageFeaturedArticles(string id);

    BulletinHomepageFeaturedQuoteArticle GetHomepageFeaturedQuoteArticle(string id);

    FeaturedArticle GetFeaturedArticle(string id);

    IssueListPage GetIssueListPage(ID id);

    List<int> GetIssueYears();

    List<IssueSearchItem> GetIssuesByYear(string year);

    BulletinArticleBreadCrumbs GetBulletinArticleBreadcrumbs(Item item, string currentPath);

    IssuesSlider GetIssueSliderContent(string datasource);

    TrendingArticles GetTrendingArticles(string datasource, int displayArticles = 3);
  }
}