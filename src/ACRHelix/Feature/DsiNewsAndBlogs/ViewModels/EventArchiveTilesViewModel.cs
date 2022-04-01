using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.DsiNewsAndBlogs.ViewModels
{
    public class EventArchiveTilesViewModel
    {        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IEnumerable<Guid> TagFilter { get; set; }
        public MultiSelectList TagList { get; set; }
        public IEnumerable<NewsArticle> NewsArticles { get; set; }
        public int PageSize = 4;
        public List<List<NewsArticle>> NewsTilePages
        {            
            get
            {
                List<List<NewsArticle>> listofList = new List<List<NewsArticle>>();

                int added = 0;
                List<NewsArticle> allEvents = NewsArticles.ToList();
                while (added < NewsArticles.Count())
                {
                    List<NewsArticle> elist = new List<NewsArticle>();
                    elist = allEvents.Skip(added).Take(PageSize).ToList();
                    listofList.Add(elist);
                    added += elist.Count;
                }
                return listofList;
            } 
        }
    }
}