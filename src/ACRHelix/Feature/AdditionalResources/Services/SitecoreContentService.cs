using ACRHelix.Feature.AdditionalResources.Models;
using ACRHelix.Foundation.Index.Models;
using ACRHelix.Foundation.Repository.Content;
using ACRHelix.Foundation.Repository.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.AdditionalResources.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }

    public Models.AdditionalResources GetAdditionalResourcesContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.AdditionalResources>(contentGuid);
    }
    /*
    public IEnumerable<TagSearchResult> SearchTags(IEnumerable<string> tags)
    {
      List<TagSearchResult> searchResults = new List<TagSearchResult>();

      foreach (string tag in tags)
      {
        searchResults = searchResults.Union(_searchRepository.Search<TagSearchResult>(q => q.Tags.Contains(tag) && (q.TemplateName != "Chapter News" && q.TemplateName != "Case Study" && q.TemplateName != "NewsArticle" && q.TemplateName != "Press Release"))).ToList();

      }
      //this seems silly to order by, lets just get latest content
      //searchResults = (from result in searchResults orderby tags.Count(u => result.Tags.Contains(u)) descending select result).ToList();

      searchResults = searchResults.OrderByDescending(x => x.CreatedDate).ThenByDescending(x => x.Updated).ToList();

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
    }*/
  }
}