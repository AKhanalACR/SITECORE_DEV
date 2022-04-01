using ACR.Foundation.Personify.Models.Taxonomy;
using ACRHelix.Feature.News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.News.Services
{
    public interface IContentService
    {
        IRecentNewsList GetRecentNewsListContent(string contentGuid);
        CaseStudyList GetCaseStudies(string contentGuid);
        INewsIssue GetNewsIssue(string contentGuid);
        MultiSelectList GetNewsTags();

        NewsIssueList GetNewsIssueList(string contentGuid);

        IEnumerable<NewsIssueSearchResult> GetChildNewsIssues(string contentGuid, int numIssues);

        IEnumerable<NewsPressReleaseSearchResult> GetRecentNewsByInterest(ICollection<PersonifyTaxonomyItem> interests);
        IdeasSelectedNewsList GetIdeasSelectedNewsList(string contentGuid);
        IEnumerable<IdeasNewsArticle> GetIdeasNewsList(string contentGuid);
        IEnumerable<IdeasNewsYear> GetIdeasNewsYears(string contentGuid);
        IIdeasPageContent GetIdeasNewsHubPage(string contentGuid);
    }
}