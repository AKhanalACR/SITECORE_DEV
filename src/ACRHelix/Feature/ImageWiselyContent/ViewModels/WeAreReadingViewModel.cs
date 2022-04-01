using ACRHelix.Feature.ImageWiselyContent.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class WeAreReadingViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public Link Link { get; set; }
        public int PageSize { get; set; }
        public string Url { get; set; }
        public Image Image { get; set; }
        public IEnumerable<IArticlePage> ArticlesList { get; set; }

        public IEnumerable<IContentPage> ContentPagesList { get; set; }

        public List<List<IArticlePage>> ArticlePages
        {
            get
            {
                List<List<IArticlePage>> listofList = new List<List<IArticlePage>>();
                int added = 0;
                List<IArticlePage> allArticles = ArticlesList.OrderByDescending(x => x.Date).ToList();
                while (added < ArticlesList.Count())
                {
                    List<IArticlePage> mlist = new List<IArticlePage>();
                    mlist = allArticles.Skip(added).Take(PageSize).ToList();
                    listofList.Add(mlist);
                    added += mlist.Count;
                }
                return listofList;
            }
        }
        public IEnumerable<ITopicFolder> TopicList { get; set; }
        public IEnumerable<int> NewsYearList
        {
            get
            {
                return ArticlesList.OrderByDescending(d => d.Date.Year).Select(d => d.Date.Year).Distinct();
            }

        }

    }
}