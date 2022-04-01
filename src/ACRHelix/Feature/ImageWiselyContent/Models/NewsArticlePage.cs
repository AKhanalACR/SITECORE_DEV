using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class NewsArticlePage : INewsArticlePage
    {
        public ID Id { get; }

        public string Title { get; set; }

        public string TileText { get; set; }

        public string Url { get; set; }

        public DateTime Date { get; set; }

        public string Topic { get; set; }
    }
}