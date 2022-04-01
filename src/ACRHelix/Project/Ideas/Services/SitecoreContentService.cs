using ACRHelix.Feature.Ideas.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Ideas.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IIdeas GetIdeasContent(string contentGuid)
        {
            return _repository.GetContentItem<IIdeas>(contentGuid);
        }
    }
}