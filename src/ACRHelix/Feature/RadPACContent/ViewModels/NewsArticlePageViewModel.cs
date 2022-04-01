
using System;
using Sitecore.Data;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class NewsArticlePageViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RichText { get; set; }
        public string Topic { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        
    }
}