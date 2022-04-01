using ACRHelix.Feature.Advertisements.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Advertisements.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public ITopBannerAd GetAdvertisementsContent(string contentGuid)
        {
            return _repository.GetContentItem<ITopBannerAd>(contentGuid);
        }

        public IAdBar GetAdBarContent(string contentGuid)
        {
            return _repository.GetContentItem<IAdBar>(contentGuid);
        }
    }
}