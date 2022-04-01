
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Feature.RadPACContent.Models;
using System.Collections.Generic;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class NewsListViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<INewsArticle> NewsArticles { get; set; }
    }
}