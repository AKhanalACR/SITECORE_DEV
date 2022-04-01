using ACRHelix.Feature.HTMLHead.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.HTMLHead.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IHTMLHead GetHTMLHeadContent(string contentGuid)
        {
            return _repository.GetContentItem<IHTMLHead>(contentGuid);
        }
    }
}