using ACRHelix.Feature.RadPACContent.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RadPACContent.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IRadPACContent GetRadPACContentContent(string contentGuid)
        {
            return _repository.GetContentItem<IRadPACContent>(contentGuid);
        }

        public IPageTitle GetPageTitleContent(string contentGuid)
        {
            return _repository.GetContentItem<IPageTitle>(contentGuid);
        }

        public IHomeBanner GetHomeBannerContent(string contentGuid)
        {
            return _repository.GetContentItem<IHomeBanner>(contentGuid);
        }

        public IRichtextSection GetRichtextSectionContent(string contentGuid)
        {
            return _repository.GetContentItem<IRichtextSection>(contentGuid);
        }

        public ICalloutCards GetCalloutCardsContent(string contentGuid)
        {
            return _repository.GetContentItem<ICalloutCards>(contentGuid);
        }

        public ILatestNewsList GetLatestNewsArticlesContent(string contentGuid)
        {
            return _repository.GetContentItem<ILatestNewsList>(contentGuid);
        }

        public ITwitter GetTweetsContent(string contentGuid)
        {
            return _repository.GetContentItem<ITwitter>(contentGuid);
        }

        public IStateByState GetStateByStateContent(string contentGuid)
        {
            return _repository.GetContentItem<IStateByState>(contentGuid);
        }

        public IEventTiles GetEventTilesContent(string contentGuid)
        {
            return _repository.GetContentItem<IEventTiles>(contentGuid);
        }

        public IChapterChallenge GetChapterChallengeContent(string contentGuid)
        {
            return _repository.GetContentItem<IChapterChallenge>(contentGuid);
        }

        public IBracketStages GetBracketStagesContent(string contentGuid)
        {
            return _repository.GetContentItem<IBracketStages>(contentGuid);
        }

        public IHighlights GetHighlightsContent(string contentGuid)
        {
            return _repository.GetContentItem<IHighlights>(contentGuid);
        }

        public IStateContributions GetStateContributionsContent(string contentGuid)
        {
            return _repository.GetContentItem<IStateContributions>(contentGuid);
        }

        public IBiography GetBiographyContent(string contentGuid)
        {
            return _repository.GetContentItem<IBiography>(contentGuid);
        }

        public IFAQItemList GetFAQContent(string contentGuid)
        {
            return _repository.GetContentItem<IFAQItemList>(contentGuid);
        }

        public INewsList GetNewsListContent(string contentGuid)
        {
            return _repository.GetContentItem<INewsList>(contentGuid);
        }

        public INewsArticle GetNewsArticleContent(string contentGuid)
        {
            return _repository.GetContentItem<INewsArticle>(contentGuid);
        }

        public IHighContributors GetHighContributorsContent(string contentGuid)
        {
            return _repository.GetContentItem<IHighContributors>(contentGuid);
        }
    }
}