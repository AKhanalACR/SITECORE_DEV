using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.ACRDashboard.Entity;
using ACRHelix.Feature.ACRDashboard.Models;
using System.Data.SqlClient;

namespace ACRHelix.Feature.ACRDashboard.Services
{
  public class DashboardDataService
  {

    public static void AddBookmark(string personifyId, string sitecoreId)
    {
      using (var db = new ACRHelix_dashboardEntities())
      {
        Guid scid = Guid.Parse(sitecoreId);
        var bm = db.Bookmarks.FirstOrDefault(x => x.PersonifyID == personifyId && x.SitecoreID == scid);
        if (bm == null)
        {
          var bookmark = new Bookmark()
          {
            PersonifyID = personifyId,
            SitecoreID = scid,
            CreatedDate = DateTime.Now
          };
          db.Bookmarks.Add(bookmark);
          db.SaveChanges();
        }
      }

    }

    public static void AddRecommended(string personifyId, string sitecoreId)
    {
      using (var db = new ACRHelix_dashboardEntities())
      {
        Guid scid = Guid.Parse(sitecoreId);
        var bm = db.RecommendedArticles.FirstOrDefault(x => x.SitecoreID == scid);
        if (bm == null)
        {
          var bookmark = new RecommendedArticle()
          {
            PersonifyID = personifyId,
            SitecoreID = scid,
            CreatedDate = DateTime.Now
          };
          db.RecommendedArticles.Add(bookmark);
          db.SaveChanges();
        }
      }

    }

    public static IEnumerable<RecommendedArticle> GetRecommendedArticles()
    {
      List<RecommendedArticle> articles = new List<RecommendedArticle>();
      using (var db = new ACRHelix_dashboardEntities())
      {
        articles = db.RecommendedArticles.OrderByDescending(x => x.CreatedDate).Take(12).ToList();
      }
      return articles;


      }

    public static bool DeleteBookmark(int id)
    {
      using (var db = new ACRHelix_dashboardEntities())
      {
        var bm = db.Bookmarks.FirstOrDefault(x => x.BookmarkID == id);

        if (bm != null)
        {
          db.Bookmarks.Remove(bm);
          db.SaveChanges();
          return true;
        }
      }
      return false;
    }

    public static IEnumerable<Bookmark> GetMyBookmarks(string personifyId)
    {
      List<Bookmark> bookmarks = null;
      using (var db = new ACRHelix_dashboardEntities())
      {
      bookmarks = db.Bookmarks.Where(x => x.PersonifyID == personifyId).OrderByDescending(x => x.CreatedDate).ToList();
      }
      return bookmarks;
    }

    public static IEnumerable<QuickLink> GetDashboardLinks(string personifyId)
    {
      List<QuickLink> links = null;
      using (ACRHelix_dashboardEntities db = new ACRHelix_dashboardEntities())
      {
        links = db.QuickLinks.Where(x => x.PersonifyID == personifyId).ToList();
      }
      return links;
    }

    public static bool QuickLinksInitialized(string personifyId)
    {
      bool init = false;
      using (ACRHelix_dashboardEntities db = new ACRHelix_dashboardEntities())
      {
        var i = db.QuickLinksInitializeds.FirstOrDefault(x => x.PersonifyID == personifyId);
        if (i != null)
        {
          init = true;
        }
      }
      return init;
    }

    public static void InitializeQuickLinks(string personifyId)
    {
      try
      {
        using (ACRHelix_dashboardEntities db = new ACRHelix_dashboardEntities())
        {
          db.QuickLinksInitializeds.Add(new QuickLinksInitialized() { PersonifyID = personifyId });
          db.SaveChanges();
        }
      }
      catch (Exception) { }

    }

    public static void AddDashboardLinks(IEnumerable<DefaultQuickLink> links, string personifyId)
    {
      using (ACRHelix_dashboardEntities db = new ACRHelix_dashboardEntities())
      {
        foreach (var link in links)
        {

          //var dblink = db.QuickLinks.FirstOrDefault(x => x.LinkName == link.LinkText && x.LinkUrl == link.li

          var qlink = new QuickLink()
          {
            LinkName = link.LinkText,
            LinkUrl = link.Link.Url,
            PersonifyID = personifyId
          };
          db.QuickLinks.Add(qlink);
        }
        db.SaveChanges();
      }
    }
    public static void AddDashboardLinks(IEnumerable<QuickLink> links, string personifyId)
    {
      using (ACRHelix_dashboardEntities db = new ACRHelix_dashboardEntities())
      {
        foreach (var link in links)
        {
          var dblink = db.QuickLinks.FirstOrDefault(x => x.LinkUrl == link.LinkUrl && x.LinkName == link.LinkName && x.PersonifyID == personifyId);

          if (dblink == null)
          {

            var qlink = new QuickLink()
            {
              LinkName = link.LinkName,
              LinkUrl = link.LinkUrl,
              PersonifyID = personifyId
            };
            db.QuickLinks.Add(qlink);
          }
        }
        db.SaveChanges();
      }
    
    }

    public static void DeleteDashboardLinks(IEnumerable<QuickLink> links)
    {
      using (ACRHelix_dashboardEntities db = new ACRHelix_dashboardEntities())
      {
        foreach (var link in links)
        {
          var dbl = db.QuickLinks.FirstOrDefault(x => x.LinkId == link.LinkId);
          if (dbl != null)
          {
            db.QuickLinks.Remove(dbl);
          }
        }
        db.SaveChanges();
      }
    }

    public static void DeletePHYSICISTLinks(IEnumerable<QuickLink> links)
    {
      using (ACRHelix_dashboardEntities db = new ACRHelix_dashboardEntities())
      {
        foreach (var link in links)
        {
          var dbl = db.QuickLinks.FirstOrDefault(x => (x.LinkUrl == link.LinkUrl && x.LinkName == link.LinkName));
          if (dbl != null)
          {
            db.QuickLinks.Remove(dbl);
          }
        }
        db.SaveChanges();
      }
    }

    public static void Set_RoleBased_QuickLinks(string PersonifyID, string LinkName, string LinkUrl, bool IsPHYSICIST)
    {     
      List<QuickLink> PhysicistLink = new List<QuickLink>();
      PhysicistLink.Add(new QuickLink() { LinkName = LinkName, LinkUrl = LinkUrl, PersonifyID = PersonifyID });

      DeletePHYSICISTLinks(PhysicistLink);

      if (IsPHYSICIST)
      {
          AddDashboardLinks(PhysicistLink, PersonifyID);
      }
    }    
  }
}