using ACRHelix.Feature.CaseInPoint.Services;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.CaseInPoint
{
  public class CaseInPointController : Controller
  {
    private readonly IContentService _contentService;

    public CaseInPointController(IContentService contentService)
    {
      _contentService = contentService;
    }


    public ViewResult CaseInPoint()
    {
      try
      {        
        string removeCache = Request.QueryString["removecache"];
        // Check for query string removecache, if present and value is true then cache is not used to display data
        if (string.IsNullOrEmpty(removeCache) || removeCache.ToLower() != "true")
        {    
        //Check if cache is available.
        var cipCache = Sitecore.Caching.CacheManager.FindCacheByName<string>("CIP Cache");
        if (cipCache != null)
        {
          if (cipCache.GetValue("cachedDate") != null)
          {
            var publishDate = ToDateTime(cipCache.GetValue("cachedDate").ToString());
            var cacheddate = publishDate.HasValue ? publishDate.Value : DateTime.Now.AddDays(-2);
             // Check if cached data is older than current date, if true then clear cache.
            if (cacheddate.DayOfYear < DateTime.Now.DayOfYear)
            {
              cipCache.Clear();
            }
          }
            // Check if preveously if there was an error in retrieving data from service.
           //if true then call service to check afer an hour of preveous call (by clearing cache). 
            if (cipCache.GetValue("serviceGetError") != null)
          {
            var errorDate = ToDateTime(cipCache.GetValue("serviceGetError").ToString());
            var errortime = errorDate.HasValue ? errorDate.Value.AddHours(1) : DateTime.Now.AddDays(-2);
            if (DateTime.Compare(errortime, DateTime.Now) > 0)
            {
              return null;
            }
            else
            {
              cipCache.Clear();
            }
          }

        }
        //Check if  cache is available and all required keys for data are present in it.
        if (cipCache != null && cipCache.GetValue("serviceHistory") != null && cipCache.GetValue("serviceUrl") != null && cipCache.GetValue("serviceimageUrl") != null && cipCache.GetValue("itemTitle") != null && cipCache.GetValue("itemLinkText") != null && cipCache.GetValue("itemIntroText") != null && cipCache.GetValue("itemHeaderLink") != null)
        {
          Models.CaseInPointItem CaseInPointCacheContent = new Models.CaseInPointItem();
          CaseInPointCacheContent.Title = cipCache.GetValue("itemTitle").ToString();
          CaseInPointCacheContent.Text = cipCache.GetValue("serviceHistory").ToString();
          CaseInPointCacheContent.Link = new Glass.Mapper.Sc.Fields.Link { Url = cipCache.GetValue("serviceUrl").ToString(), Title = cipCache.GetValue("itemTooltipText").ToString(), Text = cipCache.GetValue("itemLinkText").ToString() };
          CaseInPointCacheContent.Image = new Glass.Mapper.Sc.Fields.Image { Src = cipCache.GetValue("serviceimageUrl").ToString() };
          DateTime? publishDate = DateTime.Now;
          if (cipCache.GetValue("serviceDate") != null)
          {
            publishDate = ToDateTime(cipCache.GetValue("serviceDate").ToString());
          }
          CaseInPointCacheContent.Date = publishDate.HasValue ? publishDate.Value : DateTime.Now;
          CaseInPointCacheContent.IntroText = cipCache.GetValue("itemIntroText").ToString();
          CaseInPointCacheContent.Content = new Models.CaseInPointContent();
          CaseInPointCacheContent.Content.HeaderLink = cipCache.GetValue("itemHeaderLink").ToString();
          // return view with model filled with cached content without calling service or querying database.
          return View(CaseInPointCacheContent);
        }
      }
        // Clear cahche as not used due to query string parameter.
        else
        {
          var cipCaches = Sitecore.Caching.CacheManager.FindCacheByName<string>("CIP Cache");
          if (cipCaches != null)
          {
            cipCaches.Clear();
          }
        }
       
        Models.CaseInPointContent caseInPointSC = null;
        var datasource = RenderingContext.Current.Rendering.DataSource;

        if (!string.IsNullOrWhiteSpace(datasource))
        {
          caseInPointSC = _contentService.GetCaseInPointSCContent(datasource);
        }

        var CaseInPointContent = _contentService.GetCaseInPointContent(caseInPointSC);
        if (CaseInPointContent != null)
        {
          return View(CaseInPointContent);
        }
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error displaying case in point" + ex, this);
      }
      return null;
    }

    public ViewResult MiniCaseInPoint()
    {
      try
      {
        // Check for query string removecache, if present and value is true then cache is not used to display data
        string removeCache = Request.QueryString["removecache"];
        if (string.IsNullOrEmpty(removeCache) || removeCache.ToLower() != "true")
        {
          //Check if cache is available.
          var cipCache = Sitecore.Caching.CacheManager.FindCacheByName<string>("CIP Cache");
          if (cipCache != null)
          {
            if (cipCache.GetValue("cachedDate") != null)
            {
              var publishDate = ToDateTime(cipCache.GetValue("cachedDate").ToString());
              var cacheddate = publishDate.HasValue ? publishDate.Value : DateTime.Now.AddDays(-2);
              // Check if cached data is older than current date, if true then clear cache.
              if (cacheddate.DayOfYear < DateTime.Now.DayOfYear)
              {
                cipCache.Clear();
              }
            }
            if (cipCache.GetValue("serviceGetError") != null)
            {
              var errorDate = ToDateTime(cipCache.GetValue("serviceGetError").ToString());
              var errortime = errorDate.HasValue ? errorDate.Value.AddHours(1) : DateTime.Now.AddDays(-2);
              // Check if preveously if there was an error in retrieving data from service.
              //if true then call service to check afer an hour of preveous call (by clearing cache). 
              if (DateTime.Compare(errortime, DateTime.Now) > 0)
              {
                return null;
              }
              else
              {
                cipCache.Clear();
              }
            }

          }
          //Check if  cache is available and all required keys for data are present in it.
          if (cipCache != null && cipCache.GetValue("serviceHistory") != null && cipCache.GetValue("serviceUrl") != null && cipCache.GetValue("serviceimageUrl") != null && cipCache.GetValue("miniItemTitle") != null && cipCache.GetValue("MiniItemLinkText") != null)
          {
            Models.CaseInPointItem CaseInPointCacheContent = new Models.CaseInPointItem();
            CaseInPointCacheContent.Title = cipCache.GetValue("miniItemTitle").ToString();
            CaseInPointCacheContent.Text = cipCache.GetValue("serviceHistory").ToString();
            CaseInPointCacheContent.Link = new Glass.Mapper.Sc.Fields.Link { Url = cipCache.GetValue("serviceUrl").ToString(), Title = cipCache.GetValue("miniItemTooltipText").ToString(), Text = cipCache.GetValue("MiniItemLinkText").ToString() };
            CaseInPointCacheContent.Image = new Glass.Mapper.Sc.Fields.Image { Src = cipCache.GetValue("serviceimageUrl").ToString() };
            DateTime? publishDate = DateTime.Now;
            if (cipCache.GetValue("serviceDate") != null)
            {
              publishDate = ToDateTime(cipCache.GetValue("serviceDate").ToString());
            }
            CaseInPointCacheContent.Date = publishDate.HasValue ? publishDate.Value : DateTime.Now;           
            CaseInPointCacheContent.Content = new Models.CaseInPointContent();        
            // return view with model filled with cached content without calling service or querying database.
            return View(CaseInPointCacheContent);
          }
        }
        else
        {
          // Clear cahche as not used due to query string parameter.
          var cipCaches = Sitecore.Caching.CacheManager.FindCacheByName<string>("CIP Cache");
          if (cipCaches != null)
          {
            cipCaches.Clear();
          }
        }
      

        Models.MiniCaseInPointContent caseInPointSC = null;

        var datasource = RenderingContext.Current.Rendering.DataSource;
        if (!string.IsNullOrWhiteSpace(datasource))
        {
          caseInPointSC = _contentService.GetMiniCaseInPointSCContent(datasource);
        }
        var CaseInPointContent = _contentService.GetMiniCaseInPointContent(caseInPointSC);
        if (CaseInPointContent != null)
        {
          return View(CaseInPointContent);
        }

      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error displaying mini case in point" +ex , this);
      }
      return null;
    }

    private static DateTime? ToDateTime(string datetime)
    {
      DateTime d;
      if (DateTime.TryParse(datetime, out d))
      {
        return d;
      }
      return null;
    }
  }
}