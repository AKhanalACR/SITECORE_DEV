using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.Data;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ACRHelix.Feature.Bulletin.Tasks
{
  public class UpdateArticlePageViews
  {
    public void Run()
    {
      Sitecore.Diagnostics.Log.Info("Starting task to update bulletin article page views", this);

      var masterDB = Database.GetDatabase("master");
      var webDB = Database.GetDatabase("web");

      var bulletinArticles = webDB.SelectItems($"fast:/sitecore/content//*[@@templateid='{Constants.BulletinTemplates.Article.TemplateID}']");
      foreach (var article in bulletinArticles)
      {
        article.Editing.BeginEdit();
        var viewCount = GetArticleViewCount(article.ID);
        article.Fields["{1620C717-2163-4BF4-AD57-DA95E5D3473C}"].SetValue(viewCount.ToString(), true);
        article.Editing.EndEdit();

        var masterArticle = masterDB.GetItem(article.ID);
        if (masterArticle != null)
        {
          masterArticle.Editing.BeginEdit();
          masterArticle.Fields["{1620C717-2163-4BF4-AD57-DA95E5D3473C}"].SetValue(viewCount.ToString(), true);
          masterArticle.Editing.EndEdit();
        }
      }
      IndexCustodian.FullRebuild(ContentSearchManager.GetIndex(Constants.Indexes.BulletinArticleIndex.IndexName));
      Sitecore.Diagnostics.Log.Info("Bulletin article page views updated", this);
    }

    private int GetArticleViewCount(ID articleId)
    {
      string query = "SELECT A.ItemId, A.DailyCount FROM (SELECT ItemId, SUM([Visits]) AS DailyCount FROM Fact_PageViews WHERE ItemID = '" + articleId.ToString() + "' and Date >= DATEADD(DAY, -30, GETDATE()) GROUP BY ItemId) AS A ORDER BY A.DailyCount DESC";
      //var sqlServerDataApi = new SqlServerDataApi(Sitecore.Configuration.Settings.GetConnectionString("reporting"));
      int dailyCount = 0;
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["reporting"].ConnectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          dailyCount = Convert.ToInt32(reader[1]);
        }
        reader.Close();
      }

      return dailyCount;
    }
  }
}