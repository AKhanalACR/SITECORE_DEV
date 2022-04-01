using ACRHelix.Feature.RadPACContent.Services;
using ACRHelix.Feature.RadPACContent.Services.Entities;
using ACRHelix.Feature.RadPACContent.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.RadPACContent
{
    public class RadPACContentController : Controller
    {
        private readonly IContentService _contentService;
        private string _stages = "{AB7089C6-DBE6-4642-9434-615B1EEFFED5}";
        private ContributionService _contributionService;
        public RadPACContentController(IContentService contentService)
        {
            _contentService = contentService;
            _contributionService = new ContributionService();
        }

        public ViewResult RadPACContent()
        {
            var viewModel = new RadPACContentViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var RadPACContentContent = _contentService.GetRadPACContentContent(RenderingContext.Current.Rendering.DataSource);
                if (RadPACContentContent != null)
                {
                    viewModel.Title = RadPACContentContent.Title;
                }
            }
            return View(viewModel);
        }

        public ViewResult PageTitle()
        {
            var viewModel = new PageTitleViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var PageTitleContent = _contentService.GetPageTitleContent(dataSource);
            if (PageTitleContent != null)
            {
                viewModel.Id = PageTitleContent.Id;
                viewModel.Title = PageTitleContent.Title;
                viewModel.SubTitle = PageTitleContent.SubTitle;
                viewModel.RichText = PageTitleContent.RichText;
                viewModel.Date = PageTitleContent.Date == null ? DateTime.MinValue : PageTitleContent.Date;

            }

            return View(viewModel);
        }

        public ViewResult HomeBanner()
        {
            var viewModel = new HomeBannerViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetHomeBannerContent(dataSource);
                if (content != null)
                {
                    viewModel.HomeBanner.Id = content.Id;
                    viewModel.HomeBanner.Title = content.Title;
                    viewModel.HomeBanner.YouTubeEmbedLink = content.YouTubeEmbedLink;
                    viewModel.HomeBanner.ContributorsList = content.ContributorsList;
                    viewModel.HomeBanner.Link = content.Link;
                    viewModel.HomeBanner.Image = content.Image;
                    viewModel.HomeBanner.BannerBackground = content.BannerBackground;
                    //Sitecore.Diagnostics.Log.Info(" -- Image: " + viewModel.HomeBanner.Image.Src, this);                
                }
            }
            

            return View(viewModel);
        }

        public ViewResult RichtextSection()
        {
            var viewModel = new RichtextSectionViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var content = _contentService.GetRichtextSectionContent(dataSource);
            if (content != null)
            {
                viewModel.Id = content.Id;
                viewModel.Title = content.Title;
                viewModel.SubTitle = content.SubTitle;
                viewModel.RichText = content.RichText;
            }
            return View(viewModel);
        }

        public ViewResult CalloutCardsSection()
        {
            var viewModel = new CalloutCardsViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetCalloutCardsContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.LeftCardTitle = content.LeftCardTitle;
                    viewModel.LeftCardDescription = content.LeftCardDescription;
                    viewModel.LeftCardLink = content.LeftCardLink;
                    viewModel.RightCardTitle = content.RightCardTitle;
                    viewModel.RightCardDescription = content.RightCardDescription;
                    viewModel.RightCardLink = content.RightCardLink;
                }
            }
            return View(viewModel);
        }

        public ViewResult LatestNewsList()
        {
            var viewModel = new LatestNewsListViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetLatestNewsArticlesContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.Link = content.Link;
                    viewModel.NewsArticles = content.NewsArticlesList.OrderByDescending(x => x.Date).Take(content.DisplayNumber);
                                  
                }
            }
            return View(viewModel);
        }

        public ViewResult NewsList()
        {
            var viewModel = new NewsListViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetNewsListContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.PageSize = content.PageSize;
                    viewModel.NewsArticles = content.NewsArticlesList.OrderByDescending(x => x.Date);

                }
            }
            return View(viewModel);
        }

        public ViewResult NewsArticlePage()
        {
            var viewModel = new NewsArticlePageViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (string.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var content = _contentService.GetNewsArticleContent(dataSource);
            if (content != null)
            {
                viewModel.Id = content.Id;
                viewModel.Title = content.Title;
                viewModel.Author = content.Author;
                viewModel.SubTitle = content.SubTitle;
                viewModel.RichText = content.RichText;
                viewModel.Date = content.Date == null ? DateTime.MinValue : content.Date;

            }

            return View(viewModel);
        }

        public ViewResult TwitterFeeds()
        {
            var viewModel = new TwitterFeedsViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetTweetsContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.TimelineUrl = content.TimelineUrl;
                    viewModel.TweetsDisplay = content.TweetsDisplay;
                    viewModel.Width = content.Width;
                    viewModel.Height = content.Height;
                }
            }
            return View(viewModel);
        }

        public ViewResult StateByState()
        {
            var viewModel = new StateByStateViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetStateByStateContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.StateDdlLabel = content.StateDdlLabel;
                    viewModel.ShowStateDdl = content.ShowStateDdl;
                    viewModel.ParentPage = content.ParentPage;
                }
            }
            return View(viewModel);
        }

        public ViewResult RichtextWithGrayBg()
        {
            var viewModel = new RichtextSectionViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var content = _contentService.GetRichtextSectionContent(dataSource);
            if (content != null)
            {
                viewModel.Id = content.Id;
                viewModel.Title = content.Title;
                viewModel.RichText = content.RichText;
            }
            return View(viewModel);
        }

        public ViewResult RichtextWithVideo()
        {
            var viewModel = new RichtextSectionViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var content = _contentService.GetRichtextSectionContent(dataSource);
            if (content != null)
            {
                viewModel.Id = content.Id;
                viewModel.Title = content.Title;
                viewModel.RichText = content.RichText;
                viewModel.YouTubeEmbedUrl = content.YouTubeEmbedUrl;
                viewModel.DefaultImageLocation = content.DefaultImageLocation;

            }
            return View(viewModel);
        }

        public ViewResult RichtextWithImage()
        {
            var viewModel = new RichtextSectionViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var content = _contentService.GetRichtextSectionContent(dataSource);
            if (content != null)
            {
                viewModel.Id = content.Id;
                viewModel.Title = content.Title;
                viewModel.SubTitle = content.SubTitle;
                viewModel.RichText = content.RichText;
                viewModel.Image = content.Image;
                viewModel.DefaultImageLocation = content.DefaultImageLocation;

            }
            return View(viewModel);
        }

        public ViewResult EventTiles()
        { 
            var viewModel = new EventTilesViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetEventTilesContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.TilesDisplayNumber = content.TilesDisplayNumber;
                    viewModel.Tiles = content.Tiles.Take(content.TilesDisplayNumber);
                                       
                }
            }
            return View(viewModel);
        }

        public ViewResult PastEventTiles()
        {
            var viewModel = new EventTilesViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetEventTilesContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.TilesDisplayNumber = content.TilesDisplayNumber;
                    viewModel.Tiles = content.Tiles;
                }
            }
            return View(viewModel);
        }

        public ViewResult ChallengeBracket()
        {
            var viewModel = new ChallengeBracketViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetChapterChallengeContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Chapters = content.Chapters;
                    viewModel.Divisions = content.Chapters.Select(x => x.Division).Distinct().OrderBy(x => x).ToList();
                    viewModel.Stages = _contentService.GetBracketStagesContent(_stages).Stages.ToList();
                    viewModel.DivisionSelectList = viewModel.Divisions.Select(x => new SelectListItem
                    {
                        Value = x.ToLower().Replace(' ', '-'),
                        Text = x
                    });
                      
                }
            }
            return View(viewModel);
        }

        public ViewResult Highlights()
        {
            var viewModel = new HighlightsViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetHighlightsContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;

                    viewModel.LeftTileHeading = content.LeftTileHeading;
                    viewModel.LeftTileText = content.LeftTileText;
                    viewModel.LeftTileImage = content.LeftTileImage;
                    viewModel.LeftTileLink = content.LeftTileLink;

                    viewModel.RightTileHeading = content.RightTileHeading;
                    viewModel.RightTileText = content.RightTileText;
                    viewModel.RightTileImage = content.RightTileImage;
                    viewModel.RightTileLink = content.RightTileLink;

                    viewModel.AdditionalTextSectionHeading = content.AdditionalTextSectionHeading;
                    viewModel.AdditionalText = content.AdditionalText;
                }
            }
            return View(viewModel);
        }

        public ViewResult StateContributions()
        {
            var viewModel = new StateContributionsViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            var date = DateTime.Today.AddMonths(-1);
            decimal s;
            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetStateContributionsContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.MarchMadness = content.MarchMadness;
                    viewModel.ContributionAmount = content.ContributionAmount;
                    viewModel.Rank = content.Rank;
                    viewModel.FundraisingForTheMonth = content.FundraisingForTheMonth.Replace("[Month]", date.ToString("MMMM", CultureInfo.InvariantCulture));
                    viewModel.HardMoneyTotal = content.HardMoneyTotal.Replace("[Year]", date.Year.ToString());
                    viewModel.ParentPage = content.ParentPage;
                    var state = EntityItems.States.Where(x => x.Text == PageContext.Current.Item.Name).Single().Value;
                    var cont = _contributionService.GetStateContribution(state, date.Month.ToString(), date.Year.ToString());

                    if (!string.IsNullOrWhiteSpace(cont.MonthsContribution))
                        viewModel.Ranked = "#" + cont.Ranked;
                    else
                        viewModel.Ranked = "NA";

                    if (!string.IsNullOrWhiteSpace(cont.MonthsContribution) && Decimal.TryParse(cont.MonthsContribution, out s))
                        viewModel.TheMonthsAmount = string.Format("{0:#,###,###.##}", Convert.ToDecimal(cont.MonthsContribution));
                    else
                        viewModel.TheMonthsAmount = "0";

                    if (!string.IsNullOrWhiteSpace(cont.MonthsContribution) && Decimal.TryParse(cont.YearsTotal, out s))
                        viewModel.MoneyTotal = string.Format("{0:#,###,###.##}", Convert.ToDecimal(cont.YearsTotal));
                    else
                        viewModel.TheMonthsAmount = "0";
                }
            }
            return View(viewModel);
        }

        public ViewResult Biography()
        {
            var viewModel = new BiographyViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetBiographyContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.RichText = content.RichText;
                    viewModel.FacebookUrl = content.FacebookUrl;
                    viewModel.TwitterUrl = content.TwitterUrl;
                    viewModel.LinkedInUrl = content.LinkedInUrl;
                    viewModel.Image = content.Image;
                    
                }
            }
            return View(viewModel);
        }

        public ViewResult FAQList()
        {
            var viewModel = new FAQListViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetFAQContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.AdditionalText = content.AdditionalText;
                    viewModel.UnderlineSectionTitle = content.UnderlineSectionTitle;
                    viewModel.FAQItems = content.FAQItems;

                }
            }
            return View(viewModel);
        }

        public ViewResult HighContributors()
        {
            var viewModel = new HighContributorsViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (!String.IsNullOrEmpty(dataSource))
            {
                var content = _contentService.GetHighlightsContent(dataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.LeftTileHeading = content.LeftTileHeading;
                    viewModel.LeftTileImage = content.LeftTileImage;
                    viewModel.RightTileHeading = content.RightTileHeading;
                    viewModel.RightTileImage = content.RightTileImage;
                    viewModel.Contributors = _contributionService.GetStateHighContributors(EntityItems.States.Where(x => x.Text == PageContext.Current.Item.Name).Single().Value, DateTime.Today.Year.ToString()).ToList();

                }
            }
            return View(viewModel);
        }

        public ViewResult RichtextTableSection()
        {
            var viewModel = new RichtextSectionViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var content = _contentService.GetRichtextSectionContent(dataSource);
            if (content != null)
            {
                viewModel.Id = content.Id;
                viewModel.Title = content.Title;
                viewModel.RichText = content.RichText;
            }
            return View(viewModel);
        }

    }
}