using ACR.Foundation.Personify.Models.Taxonomy;
using ACRHelix.Feature.News.Models;
using ACRHelix.Foundation.Repository.Content;
using Glass.Mapper.Sc;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.News.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        private readonly SitecoreService _service;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
            _service = new SitecoreService(Sitecore.Context.Database);
        }

        public IRecentNewsList GetRecentNewsListContent(string contentGuid)
        {
            var newsContent = _repository.GetContentItem<IRecentNewsList>(contentGuid);


            List<NewsPressReleaseSearchResult> newsItems = new List<NewsPressReleaseSearchResult>();
            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("news-pressrelease-web");
            using (var context = searchIndex.CreateSearchContext())
            {
                var news = context.GetQueryable<NewsPressReleaseSearchResult>().Where(x => x.Type == newsContent.Type || string.IsNullOrEmpty(newsContent.Type)).OrderByDescending(x => x.Date).Take(newsContent.DisplayNumber).ToList();
                List<NewsArticle> articles = new List<NewsArticle>();
                foreach (var n in news)
                {
                    articles.Add(_service.Cast<NewsArticle>(n.GetItem()));
                }
                newsContent.Articles = articles;

            }

            return newsContent;


        }
        public CaseStudyList GetCaseStudies(string contentGuid)
        {
            return _repository.GetContentItem<CaseStudyList>(contentGuid);
        }

        public INewsIssue GetNewsIssue(string contentGuid)
        {
            return _repository.GetContentItem<INewsIssue>(contentGuid);
        }

        public MultiSelectList GetNewsTags()
        {
            List<SelectListItem> tagList = new List<SelectListItem>();

            Item tagFolder = Sitecore.Context.Database.GetItem("013E6D91-C30F-4CE9-B6E3-0A91C1B0B587");
            foreach (Item tag in tagFolder.Children.Where(x => x.TemplateName == "DictionaryEntry"))
            {
                tagList.Add(new SelectListItem { Text = tag.Name, Value = tag.ID.ToShortID().ToString() });
            }

            return new MultiSelectList(tagList, "Value", "Text");
        }

        public NewsIssueList GetNewsIssueList(string contentGuid)
        {
            return _repository.GetContentItem<NewsIssueList>(contentGuid);
        }

        public IEnumerable<NewsPressReleaseSearchResult> GetRecentNewsByInterest(ICollection<PersonifyTaxonomyItem> interests)
        {
            List<NewsPressReleaseSearchResult> newsItems = new List<NewsPressReleaseSearchResult>();
            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("news-pressrelease-web");
            using (var context = searchIndex.CreateSearchContext())
            {
                if (interests != null)
                {
                    if (interests.Count > 0)
                    {
                        foreach (var interest in interests)
                        {
                            var id = interest.ID.ToString();
                            var items = context.GetQueryable<NewsPressReleaseSearchResult>().Where(x => x.PersonifyInterests.Contains(id)).ToList();

                            foreach (var i in items)
                            {
                                if (newsItems.FirstOrDefault(x => x.ItemId == i.ItemId) == null)
                                {
                                    newsItems.Add(i);
                                }
                            }
                            //newsItems.AddRange(items);
                        }
                    }
                }
                if (newsItems.Count == 0)
                {
                    //if no matching interests get top 15 most recent news items
                    var items = context.GetQueryable<NewsPressReleaseSearchResult>().OrderByDescending(x => x.Date).ThenByDescending(x => x.CreatedDate).Take(15).ToList();
                    newsItems.AddRange(items);
                }
            }
            newsItems = newsItems.OrderByDescending(x => x.Date).ThenByDescending(x => x.CreatedDate).Take(15).ToList();
            return newsItems;
        }


        public IEnumerable<NewsIssueSearchResult> GetChildNewsIssues(string contentGuid, int numIssues)
        {
            ID ds;
            List<NewsIssueSearchResult> issues = null;
            if (ID.TryParse(contentGuid, out ds))
            {
                var datasourceItem = Sitecore.Context.Database.GetItem(ds);
                if (datasourceItem != null)
                      {
                        var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("news-issues");
                        using (var context = searchIndex.CreateSearchContext())
                        {
                          issues = context.GetQueryable<NewsIssueSearchResult>().Where(x => x.Path.StartsWith(datasourceItem.Paths.Path.ToLower())).OrderByDescending(x => x.IssueDate).Take(numIssues).ToList();
                        }

                        return issues;
                      }
            }
            return null;
        }
        public IdeasSelectedNewsList GetIdeasSelectedNewsList(string contentGuid)
        {
            return _repository.GetContentItem<IdeasSelectedNewsList>(contentGuid);
        }


        IEnumerable<IdeasNewsArticle> IContentService.GetIdeasNewsList(string contentGuid)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IdeasNewsYear> IContentService.GetIdeasNewsYears(string contentGuid)
        {
            throw new NotImplementedException();
        }

        public IIdeasPageContent GetIdeasNewsHubPage(string contentGuid)
        {
            return _repository.GetContentItem<IIdeasPageContent>(contentGuid);
        }
    }
}