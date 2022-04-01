using ACRHelix.Feature.ImageWiselyContent.Models;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class NewsTilesViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int ItemsToDisplay { get; set; }
        public string Url { get; set; }
        public IEnumerable<INewsArticlePage> NewsArticles { get; set; }
        public List<List<INewsArticlePage>> NewsArticlePages
        {
            get
            {
                List<List<INewsArticlePage>> listofList = new List<List<INewsArticlePage>>();
                int added = 0;
                List<INewsArticlePage> allNews = NewsArticles.OrderByDescending(x => x.Date).ToList();
                while (added < NewsArticles.Count())
                {
                    List<INewsArticlePage> mlist = new List<INewsArticlePage>();
                    mlist = allNews.Skip(added).Take(ItemsToDisplay).ToList();
                    listofList.Add(mlist);
                    added += mlist.Count;
                }
                return listofList;
            }
        }
        public IEnumerable<ITopicFolder> NewsTopicList { get; set; }        
        public IEnumerable<int> NewsYearList
        {
            get
            {
                return NewsArticles.OrderByDescending(d => d.Date.Year).Select(d => d.Date.Year).Distinct();
            }
            
        }
    }
}