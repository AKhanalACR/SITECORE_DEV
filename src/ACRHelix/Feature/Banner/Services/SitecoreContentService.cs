using ACRHelix.Feature.IdeasBanner.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.IdeasBanner.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public Models.IdeasBanner GetIdeasBannerContent(string contentGuid)
        {
            return _repository.GetContentItem<Models.IdeasBanner>(contentGuid);
        }
    }
}