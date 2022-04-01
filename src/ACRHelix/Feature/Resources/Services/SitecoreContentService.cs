using ACRHelix.Feature.IdeasResources.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.IdeasResources.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }

        public IdeasResourceListings GetIdeasResourceLsitings(string contentGuid)
        {
            return _repository.GetContentItem<IdeasResourceListings>(contentGuid);
        }

        public IdeasSelectedResources GetIdeasSelectedResources(string contentGuid)
        {
            return _repository.GetContentItem<IdeasSelectedResources>(contentGuid);
        }
        public IdeasResource GetIdeasVideoResource(string contentGuid)
        {
            return _repository.GetContentItem<IdeasResource>(contentGuid);
        }

    }
}