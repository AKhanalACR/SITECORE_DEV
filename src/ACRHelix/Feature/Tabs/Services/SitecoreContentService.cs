using ACRHelix.Feature.Tabs.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Tabs.Services
{
  public class SitecoreContentService : IContentService
  {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
          _repository = repository;
        }
        public Models.Tabs GetTabsContent(string contentGuid)
        {
          return _repository.GetContentItem<Models.Tabs>(contentGuid);
        }
        public RLITabs GetRliTabsContent(string contentGuid)
        {
            return _repository.GetContentItem<RLITabs>(contentGuid);
        }
  }
}