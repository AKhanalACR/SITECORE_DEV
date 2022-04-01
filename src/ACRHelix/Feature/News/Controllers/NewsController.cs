using ACRHelix.Feature.News.Services;
using ACRHelix.Feature.News.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ACRHelix.Feature.News.Models;
using Sitecore.Data;
using Glass.Mapper.Sc;
using ACR.Foundation.SSO.UserContext;
using ACR.Foundation.SSO.Users;
using Sitecore.Links;

namespace ACRHelix.Feature.News
{
    public class NewsController : Controller
    {
        private readonly IContentService _contentService;
        private const string NewsPressIndexName = "news-pressrelease-web";

        public NewsController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ViewResult DashboardLatestNews()
        {
            var viewModel = new DashboardNewsViewModel();

            if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
            {

                var personifyInterests = UserManager.CurrentUserContext.CurrentUser.Profile.Interests;
                //var personifyModalities = UserManager.CurrentUserContext.CurrentUser.Profile.Modalities;
                //var personifySubspecialties = UserManager.CurrentUserContext.CurrentUser.Profile.Subspecialities;

                var news = _contentService.GetRecentNewsByInterest(personifyInterests);

                viewModel.DashboardNews = news;

            }
            else
            {
                viewModel.DashboardNews = _contentService.GetRecentNewsByInterest(null);
            }

            return View(viewModel);

        }

        public ViewResult RecentNewsList(RecentNewsListViewModel viewModel)
        {
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                var RecentNewsListContent = _contentService.GetRecentNewsListContent(dataSource);
                if (RecentNewsListContent != null)
                {
                    //viewModel.TagFilter = viewModel.TagFilter ?? new List<Guid>();


                    //if (viewModel.TagFilter.Count() > 0)
                    //{
                    //  viewModel.NewsArticles = RecentNewsListContent.Articles.Where(x => x.Type == RecentNewsListContent.Type &&
                    //                                                                     viewModel.TagFilter.Intersect(x.Tags).Count() == viewModel.TagFilter.Count())
                    //                                                                     .OrderByDescending(x => x.Date)
                    //                                                                     .Take(RecentNewsListContent.DisplayNumber);
                    //}
                    //else
                    //{
                    //  viewModel.NewsArticles = RecentNewsListContent.Articles.Where(x => x.Type == RecentNewsListContent.Type).OrderByDescending(x => x.Date).Take(RecentNewsListContent.DisplayNumber);
                    //}
                    viewModel.Id = RecentNewsListContent.Id;
                    viewModel.Title = RecentNewsListContent.Title;
                    viewModel.ArchivesLink = RecentNewsListContent.ArchivesLink;
                    viewModel.NewsArticles = RecentNewsListContent.Articles;
                    //viewModel.TagList = _contentService.GetNewsTags();
                }
            }
            return View(viewModel);
        }

        public ViewResult NewsArchive(NewsArchiveViewModel viewModel, int? page)
        {
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                int pageSize = 20;
                int pageNumber = (page ?? 1);

                var RecentNewsListContent = _contentService.GetRecentNewsListContent(dataSource);

                if (RecentNewsListContent != null)
                {
                    //List<NewsArticle> newsArticles = new List<NewsArticle>();

                    //if (viewModel.TagFilter.Count() > 0)
                    //{
                    //  newsArticles = RecentNewsListContent.Articles.Where(x => x.Type == RecentNewsListContent.Type &&
                    //                                                                     viewModel.TagFilter.Intersect(x.Tags).Count() == viewModel.TagFilter.Count())
                    //                                                                     .OrderByDescending(x => x.Date)
                    //                                                                     .ToList();
                    //}
                    //else
                    //{
                    //  newsArticles = RecentNewsListContent.Articles.Where(x => x.Type == RecentNewsListContent.Type).OrderByDescending(x => x.Date).ToList();
                    //}

                    viewModel.Id = RecentNewsListContent.Id;
                    viewModel.Title = RecentNewsListContent.Title;
                    viewModel.PageCount = Math.Max(RecentNewsListContent.Articles.Count() / pageSize, 1);

                    viewModel.NewsArticles = RecentNewsListContent.Articles.ToPagedList(pageNumber, pageSize);
                    viewModel.TagList = _contentService.GetNewsTags();
                    viewModel.PageNumber = pageNumber;
                }
            }

            return View(viewModel);
        }

        public ViewResult RecentNewsTiles()
        {

            var viewModel = new NewsTileViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (!string.IsNullOrWhiteSpace(dataSource))
            {

                //var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(NewsPressIndexName);
                //using (var context = searchIndex.CreateSearchContext())
                //{
                //  var results = context.GetQueryable<NewsPressReleaseSearchResult>().Where(x => x != null).ToList();
                //  var results1 = context.GetQueryable<NewsPressReleaseSearchResult>().Where(x => x.Tags != "").ToList();

                //  List<string> typesn = new List<string>();
                //  var ntypes = context.GetQueryable<NewsPressReleaseSearchResult>().Where(x => x.Type != null).ToList();
                //  var ntypes1 = context.GetQueryable<NewsPressReleaseSearchResult>().Where(x => x.Type != "").ToList();

                //  foreach (var n in ntypes)
                //  {
                //    typesn.Add(n.Type);
                //  }

                //}

                var RecentNewsListContent = _contentService.GetRecentNewsListContent(dataSource);
                if (RecentNewsListContent != null)
                {
                    viewModel.Id = RecentNewsListContent.Id;
                    viewModel.Title = RecentNewsListContent.Title;
                    //remove tags that arent in our lsit of news
                    //viewModel.TagList = RemoveNonmatchTags(_contentService.GetNewsTags(), RecentNewsListContent.Articles);
                    viewModel.NewsArticles = RecentNewsListContent.Articles; //RecentNewsListContent.Articles.Where(x => x.Type == RecentNewsListContent.Type || RecentNewsListContent.Type == "").OrderByDescending(x => x.Date).Take(RecentNewsListContent.DisplayNumber);
                                                                             //viewModel.TagFilter = GetTagFilterFromQueryString(NewsTileViewModel.FilterKey);
                                                                             //do we want dropdown or multiselect tags??

                    //if (viewModel.TagFilter.Count() > 0)
                    //{
                    //  viewModel.NewsArticles = RecentNewsListContent.Articles.Where(x => (x.Type == RecentNewsListContent.Type || RecentNewsListContent.Type == "") &&
                    //                                                                     viewModel.TagFilter.Intersect(x.Tags).Count() == viewModel.TagFilter.Count())
                    //                                                                     .OrderByDescending(x => x.Date).ToList();
                    //}
                    //if (viewModel.TagList.Count() == 0)
                    //{
                    //  viewModel.TagList = null;
                    //}
                }
            }
            return View(viewModel);
        }

        public ViewResult RecentNewsListTitleOnly()
        {
            var viewModel = new RecentNewsListViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                var RecentNewsListContent = _contentService.GetRecentNewsListContent(dataSource);
                if (RecentNewsListContent != null)
                {
                    viewModel.Id = RecentNewsListContent.Id;
                    viewModel.Title = RecentNewsListContent.Title;
                    viewModel.NewsArticles = RecentNewsListContent.Articles;//.Where(x => x.Type == RecentNewsListContent.Type || RecentNewsListContent.Type == "").OrderByDescending(x => x.Date).Take(RecentNewsListContent.DisplayNumber);
                    viewModel.ArchivesLink = RecentNewsListContent.ArchivesLink;
                }
            }
            return View(viewModel);
        }

        public ViewResult NewsIssue(int? page)
        {
            var viewModel = new NewsArchiveViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                int pageSize = 20;
                int pageNumber = (page ?? 1);

                var newsIssueContent = _contentService.GetNewsIssue(dataSource);

                if (newsIssueContent != null)
                {
                    var newsArticles = newsIssueContent.Articles.OrderByDescending(x => x.Date);
                    viewModel.Id = newsIssueContent.Id.ToGuid();
                    viewModel.Title = newsIssueContent.Title;
                    viewModel.PageCount = Math.Max(newsArticles.Count() / pageSize, 1);
                    viewModel.NewsArticles = newsArticles.ToPagedList(pageNumber, pageSize);
                    //viewModel.TagList = _contentService.GetNewsTags();
                    viewModel.PageNumber = pageNumber;
                }
            }

            return View("NewsIssue", viewModel);
        }

        public ViewResult CaseStudyList(CaseStudyList viewModel, int? page)
        {
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (string.IsNullOrWhiteSpace(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                //IEnumerable<Guid> tagFilter = viewModel.TagFilter;
                viewModel = _contentService.GetCaseStudies(dataSource);
                //viewModel.TagFilter = tagFilter ?? new List<Guid>();

                //if (viewModel.TagFilter.Count() > 0)
                //{
                //  viewModel.CaseStudies = viewModel.CaseStudies.Where(x => viewModel.TagFilter
                //                                   .Intersect(x.Tags).Count() == viewModel.TagFilter.Count())
                //                                   .OrderByDescending(x => x.Date);
                //}
                //else
                //{
                //viewModel.CaseStudies = viewModel.CaseStudies.OrderByDescending(x => x.Date);
                //}

                viewModel.CaseStudies = viewModel.CaseStudies.OrderByDescending(x => x.Date);
                //viewModel.TagList = _contentService.GetNewsTags();

                //int pageNum = page ?? 1;
                //int pageSize = viewModel.TilesPerPage ?? 6;

                //int totalCaseStudies = viewModel.CaseStudies.Count();

                //viewModel.CaseStudies = viewModel.CaseStudies.ToPagedList(pageNum, pageSize);

                //viewModel.PageCount = pageSize != 0 ? Math.Max(totalCaseStudies / pageSize, 1) : 0;
                //viewModel.PageNumber = pageSize != 0 ? pageNum : 0;

            }
            return View(viewModel);
        }

        private MultiSelectList RemoveNonmatchTags(MultiSelectList tags, IEnumerable<NewsArticle> articles)
        {
            List<SelectListItem> tagList = new List<SelectListItem>();

            var newsTags = GetTagGuids(articles);
            var tagsid = new List<string>();
            foreach (var t in newsTags)
            {
                tagsid.Add(ID.Parse(t).ToShortID().ToString());
            }
            tagList.Add(new SelectListItem() { Value = ID.Parse(Guid.Empty).ToShortID().ToString(), Text = "All" });
            foreach (SelectListItem i in tags.Items)
            {
                if (tagsid.Contains(i.Value))
                {
                    tagList.Add(i);
                }
            }
            return new MultiSelectList(tagList, "Value", "Text");
        }

        public ViewResult NewsIssueList()
        {
            var viewModel = new NewsIssueListViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(dataSource))
            {
                var newsIssueList = _contentService.GetNewsIssueList(dataSource);
                if (newsIssueList != null)
                {
                    viewModel.Id = newsIssueList.Id;
                    viewModel.Title = newsIssueList.Title;
                    //viewModel.Issues = _contentService.GetChildNewsIssues(newsIssueList.Datasource);

                    var issues = _contentService.GetChildNewsIssues(newsIssueList.Datasource, newsIssueList.IssuesPerPage);
                    List<int> years = new List<int>();
                    SitecoreService articleService = new SitecoreService(Sitecore.Context.Database.Name);
                    foreach (var i in issues)
                    {
                        List<NewsArticle> newsArticles = new List<NewsArticle>();
                        var item = i.GetItem();

                        if (item != null)
                        {
                            if (!years.Contains(i.IssueDate.Year))
                            {
                                years.Add(i.IssueDate.Year);
                            }
                            foreach (var m in item.GetChildren().Where(x => x.TemplateName == "NewsArticle"))
                            {
                                newsArticles.Add(articleService.Cast<NewsArticle>(m));
                            }
                        }
                        i.NewsArticles = newsArticles;
                    }
                    viewModel.Issues = issues;
                    viewModel.Years = years;
                }
            }

            return View(viewModel);
        }
        public ViewResult IdeasSelectedNewsList()
        {
            var viewModel = new IdeasSelectedNewsListViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(dataSource))
            {
                var newsList = _contentService.GetIdeasSelectedNewsList(dataSource);
                if (newsList != null)
                {
                    viewModel.Id = newsList.Id;
                    viewModel.Title = newsList.Title;
                    viewModel.ViewMoreLink = newsList.ViewMoreLink;
                    viewModel.ViewMoreLinkText = newsList.ViewMoreLinkText;
                    foreach (var news in newsList.SelectedArticles.Take(newsList.NumberOfLinks))
                    {
                        viewModel.SelectedArticles.Add(news);
                    }
                    if (viewModel.SelectedArticles.Count < newsList.NumberOfLinks)
                    {
                        foreach (var item in newsList.AllArticles.OrderByDescending(n => n.Date))
                        {
                            if (viewModel.SelectedArticles.Where(x => x.Id == item.Id).Count() == 0)
                            {
                                viewModel.SelectedArticles.Add(item);
                            }
                            if (viewModel.SelectedArticles.Count >= newsList.NumberOfLinks)
                                break;
                        }
                    }
                }
            }

            return View(viewModel);
        }


        public ViewResult IdeasNewsList()
        {
            var viewModel = new IdeasNewsListViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var newsHubPage = _contentService.GetIdeasNewsHubPage(Sitecore.Context.Item.ID.ToString());
            if (newsHubPage != null)
            {
                IdeasNewsHubPageContent newshubPage = new IdeasNewsHubPageContent();
                viewModel.Id = newsHubPage.Id;
                //viewModel.NewsHubPage.Id = newshubPage.Id;
                viewModel.Title = newsHubPage.Title;
                viewModel.NewsHubPage = newshubPage;
                viewModel.NewsHubPage.Title = newsHubPage.Title;
                viewModel.NewsHubPage.SubTitle = newsHubPage.SubTitle;
                viewModel.NewsHubPage.RichText = newsHubPage.RichText;
            }
            //foreach (var year in newsHubPage.Years)
            //{
            //    viewModel.NewsYears.Add(year);
            //}
            List<int> years = new List<int>();
            foreach (var news in newsHubPage.NewsArticles.OrderByDescending(n => n.Date))
            {
                viewModel.NewsArticles.Add(news);
                if (news.Date != DateTime.MinValue && !years.Contains(news.Date.Year))
                {
                    years.Add(news.Date.Year);
                }
            }
            viewModel.NewsYears = years;
            return View(viewModel);
        }
        private List<Guid> GetTagFilterFromQueryString(string key)
        {
            var filter = new List<Guid>();
            var qs = Request.QueryString[key];
            if (qs != null)
            {
                foreach (var f in Request.QueryString.GetValues(key))
                {
                    Guid guid = Guid.Empty;
                    if (Guid.TryParse(f, out guid))
                    {
                        if (guid != Guid.Empty)
                        {
                            filter.Add(guid);
                        }
                    }
                }
            }
            return filter;
        }

        private IEnumerable<Guid> GetTagGuids(IEnumerable<NewsArticle> articles)
        {
            List<Guid> guids = new List<Guid>();
            foreach (var a in articles)
            {
                foreach (var t in a.Tags)
                {
                    guids.Add(t);
                }
            }
            return guids.Distinct().ToList();
        }
    }
}