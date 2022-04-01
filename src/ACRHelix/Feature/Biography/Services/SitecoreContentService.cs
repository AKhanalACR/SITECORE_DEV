using ACRHelix.Feature.Biography.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Biography.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IBiography GetBiographyContent(string contentGuid)
        {
            return _repository.GetContentItem<IBiography>(contentGuid);
        }
    }
}