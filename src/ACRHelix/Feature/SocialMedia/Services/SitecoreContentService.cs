using ACRHelix.Feature.SocialMedia.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SocialMedia.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public ISocialMedia GetSocialMediaContent(string contentGuid)
        {
            return _repository.GetContentItem<ISocialMedia>(contentGuid);
        }
        public ISocialMediaLinkList GetSocialMediaLinkListContent(string contentGuid)
        {
            return _repository.GetContentItem<ISocialMediaLinkList>(contentGuid);
        }
        public ISocialMediaFeed GetSocialMediaFeedContent(string contentGuid)
        {
            return _repository.GetContentItem<ISocialMediaFeed>(contentGuid);
        }

    }
}