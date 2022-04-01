using ACRHelix.Feature.Bulletin.Helpers;
using ACRHelix.Feature.Bulletin.Models;

namespace ACRHelix.Feature.Bulletin.ViewModels
{
  public class ArticleViewModel
  {
    public ArticleViewModel()
    {
    }

    public ArticleViewModel(Article article, BulletinHelper helper)
    {
      this.Article = article;
      this.ParalaxImageUrl = helper.GetImageUrl(article.ParallaxImage);
      this.ParalaxMobileImageUrl = helper.GetImageUrl(article.MobileParallaxImage);
      this.LiveArticleText = helper.InsertBulletinBlockQuote(article.ArticleText, article.Quote, article.QuoteBy);
    }

    public Article Article { get; set; }

    public string ParalaxImageUrl { get; set; }

    public string ParalaxMobileImageUrl { get; set; }

    public string LiveArticleText { get; set; }
  }
}