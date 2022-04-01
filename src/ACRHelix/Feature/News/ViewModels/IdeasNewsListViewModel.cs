using ACRHelix.Feature.News.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.News.ViewModels
{
    public class IdeasNewsListViewModel
    {
        public IdeasNewsListViewModel()
        {
            NewsArticles = new List<Models.IdeasNewsArticle>();
            NewsYears = new List<int>();
        }
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual IdeasNewsHubPageContent NewsHubPage { get; set; }
        public virtual List<IdeasNewsArticle> NewsArticles { get; set; }
        public virtual List<int> NewsYears { get; set; }
    }
}