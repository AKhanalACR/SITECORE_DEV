using ACRHelix.Feature.RelatedArticles.Models;
using ACRHelix.Foundation.Index.Models;
using ACRHelix.Foundation.Repository.Content;
using ACRHelix.Foundation.Repository.Search;
using ACRHelix.Feature.RelatedArticles.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RelatedArticles.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    private readonly ISearchRepository _searchRepository;
    public SitecoreContentService(IContentRepository repository, ISearchRepository searchRepository)
    {
      _repository = repository;
      _searchRepository = searchRepository;
    }
    public IRelatedArticles GetRelatedArticlesContent(string contentGuid)
    {
      return _repository.GetContentItem<IRelatedArticles>(contentGuid);
    }

    public IEnumerable<TagSearchResult> SearchArticleTags(IEnumerable<string> tags)
    {
      List<TagSearchResult> searchResults = new List<TagSearchResult>();

      foreach (string tag in tags)
      {
        searchResults = searchResults.Union(_searchRepository.Search<TagSearchResult>(q => q.Tags.Contains(tag.ToLower()) && (q.TemplateName == "Case Study" || q.TemplateName == "NewsArticle" || q.TemplateName == "Press Release"))).ToList();
          
      }
      //this seems silly to order by, lets just get latest content
      //searchResults = (from result in searchResults orderby tags.Count(u => result.Tags.Contains(u)) descending select result).ToList();
      searchResults = searchResults.OrderByDescending(x => x.Date).ThenByDescending(x => x.Updated).ToList();
      //searchResults = (from result in searchResults orderby tags.Count(u => result.Tags.Contains(u.ToLower())) descending select result).ToList();     
      //add scheme to link
      string scheme = "http";
      if (HttpContext.Current != null)
      {
        scheme = HttpContext.Current.Request.Url.Scheme;
      }
      foreach (var r in searchResults)
      {
        r.Url = scheme + r.Url;
      }
      return searchResults;
    }
  }
}