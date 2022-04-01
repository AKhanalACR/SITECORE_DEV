using ACRHelix.Feature.Bulletin.Models;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.ViewModels
{
  public class ArticleListModel
  {
    public List<ArticleSearchItem> Articles { get; set; } = new List<ArticleSearchItem>();
  }
}