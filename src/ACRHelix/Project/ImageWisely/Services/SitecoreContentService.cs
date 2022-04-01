using ACRHelix.Project.ImageWisely.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.ImageWisely.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public ISearchSettings GetSearchSettingsContent(string contentGuid)
        {
            return _repository.GetContentItem<ISearchSettings>(contentGuid);
        }
    }
}