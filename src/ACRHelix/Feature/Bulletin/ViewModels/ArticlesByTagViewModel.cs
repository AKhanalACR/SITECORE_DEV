using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.ViewModels
{
  public class ArticlesByTagViewModel
  {
    public List<int> Years { get; set; } = new List<int>();

    public string Title { get; set; }

    public string CurrentTagID { get; set; }

    //public List<ArticleSearchItem> Articles { get; set; }
  }
}