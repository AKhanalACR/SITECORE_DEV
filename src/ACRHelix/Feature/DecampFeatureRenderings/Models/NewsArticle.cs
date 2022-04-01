using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using System.Text.RegularExpressions;

namespace ACRHelix.Feature.DecampFeatureRenderings.Models
{
    public class NewsArticle : INewsArticle
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RichText { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public string LinkOverride { get; set; }    
    }
}