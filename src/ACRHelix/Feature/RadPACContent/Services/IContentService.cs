using ACRHelix.Feature.RadPACContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RadPACContent.Services
{
    public interface IContentService
    {
        IRadPACContent GetRadPACContentContent(string contentGuid);

        IPageTitle GetPageTitleContent(string contentGuid);

        IHomeBanner GetHomeBannerContent(string contentGuid);

        IRichtextSection GetRichtextSectionContent(string contentGuid);

        ICalloutCards GetCalloutCardsContent(string contentGuid);

        ILatestNewsList GetLatestNewsArticlesContent(string contentGuid);

        ITwitter GetTweetsContent(string contentGuid);

        IStateByState GetStateByStateContent(string contentGuid);

        IEventTiles GetEventTilesContent(string contentGuid);

        IChapterChallenge GetChapterChallengeContent(string contentGuid);

        IBracketStages GetBracketStagesContent(string contentGuid);

        IHighlights GetHighlightsContent(string contentGuid);

        IStateContributions GetStateContributionsContent(string contentGuid);

        IBiography GetBiographyContent(string contentGuid);

        IFAQItemList GetFAQContent(string contentGuid);

        INewsList GetNewsListContent(string contentGuid);

        INewsArticle GetNewsArticleContent(string contentGuid);

        IHighContributors GetHighContributorsContent(string contentGuid);
    }
}