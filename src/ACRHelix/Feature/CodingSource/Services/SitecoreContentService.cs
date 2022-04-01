using ACRHelix.Feature.CodingSource.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CodingSource.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public CodingSourceList GetCodingSourceListContent(string contentGuid)
    {
      return _repository.GetContentItem<CodingSourceList>(contentGuid);
    }
  }
}