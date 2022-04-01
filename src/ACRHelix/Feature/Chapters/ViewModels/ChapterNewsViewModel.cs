using System.Collections.Generic;
using System.Linq;
using ACRHelix.Feature.Chapters.Models;
using Sitecore.Data;

namespace ACRHelix.Feature.Chapters.ViewModels
{
  public class ChapterNewsViewModel
  {
    public ID Id { get; set; }
    public List<ChapterNews> ChapterNews { get; set; } = new List<Models.ChapterNews>();


    //Paging client side lists
    public int PageSize = 8;
    public List<List<ChapterNews>> NewsPages
    {
      get
      {
        if (Sitecore.Context.PageMode.IsExperienceEditor)
        {
          PageSize = ChapterNews.Count;
        }

        List<List<ChapterNews>> listofList = new List<List<ChapterNews>>();
        int added = 0;
        List<ChapterNews> allNews = ChapterNews;
        while (added < ChapterNews.Count)
        {
          List<ChapterNews> mlist = new List<ChapterNews>();
          mlist = allNews.Skip(added).Take(PageSize).ToList();
          listofList.Add(mlist);
          added += mlist.Count;
        }
        return listofList;
      }
    }

  }
}