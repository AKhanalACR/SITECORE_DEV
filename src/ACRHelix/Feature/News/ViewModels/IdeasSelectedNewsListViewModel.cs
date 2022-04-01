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
    public class IdeasSelectedNewsListViewModel
    {
        public IdeasSelectedNewsListViewModel()
        {
            SelectedArticles = new List<Models.IdeasNewsArticle>();
        }
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }

        public virtual Link ViewMoreLink { get; set; }

        public virtual string ViewMoreLinkText { get; set; }
        public virtual List<IdeasNewsArticle> SelectedArticles { get; set; }
    }
}