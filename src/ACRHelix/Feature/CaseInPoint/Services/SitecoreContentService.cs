using ACR.Foundation.CaseInPointService;
using ACRHelix.Feature.CaseInPoint.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CaseInPoint.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public CaseInPointItem GetCaseInPointContent(CaseInPointContent content)
    {
      CaseInPointItem caseInPoint = new CaseInPointItem();
      var cipCache = Sitecore.Caching.CacheManager.FindCacheByName<string>("CIP Cache");
      try { 
        //Get data from CIP widget Api.
      ACR.Foundation.CaseInPointService.Models.CaseInPointItem item = GetCaseInpointData();
      if (item != null)
      {
        caseInPoint.Title = "ACR Case in Point";
        caseInPoint.Text = item.History;
        caseInPoint.Link = new Glass.Mapper.Sc.Fields.Link { Url = item.Url, Title = "Earn CME Credits Now" };
        caseInPoint.Image = new Glass.Mapper.Sc.Fields.Image { Src = item.ImageUrl };
        caseInPoint.Date = item.PublishDate.HasValue ? item.PublishDate.Value : DateTime.Now;
        caseInPoint.IntroText = "Start right now with the case of the day below, and then sign up to receive new cases delivered straight to your inbox every weekday.";
        // Data from sitecore item as required.
        if (content != null)
        {
          caseInPoint.Link.Title = content.LinkToolTipText;
          caseInPoint.Title = content.Title;
          caseInPoint.Link.Text = content.LinkText; 
          caseInPoint.IntroText = content.IntroText;
            caseInPoint.Content = new CaseInPointContent();
          caseInPoint.Content.HeaderLink = content.HeaderLink;
        }
        // Check if cache is available, if not then create new.
        if (cipCache == null)
        {
          cipCache = new Sitecore.Caching.Cache("CIP Cache", 20480);
        }
        //Fill data in cache for further requests.
        if (cipCache.GetValue("serviceHistory") == null) { cipCache.Add("serviceHistory", item.History); }
        if (cipCache.GetValue("serviceUrl") == null) { cipCache.Add("serviceUrl", item.Url); }
        if (cipCache.GetValue("serviceimageUrl") == null) { cipCache.Add("serviceimageUrl", item.ImageUrl); }
        if (cipCache.GetValue("serviceDate") == null) { cipCache.Add("serviceDate", item.PublishDate.HasValue ? item.PublishDate.Value : DateTime.Now); }
        if (cipCache.GetValue("itemTitle") == null) { cipCache.Add("itemTitle", content.Title); }
        if (cipCache.GetValue("itemLinkText") == null) { cipCache.Add("itemLinkText", content.LinkText); }
        if (cipCache.GetValue("itemIntroText") == null) { cipCache.Add("itemIntroText", content.IntroText); }
        if (cipCache.GetValue("itemHeaderLink") == null) { cipCache.Add("itemHeaderLink", content.HeaderLink); }
        if (cipCache.GetValue("itemTooltipText") == null) { cipCache.Add("itemTooltipText", content.LinkToolTipText); }
        if (cipCache.GetValue("cachedDate") == null) { cipCache.Add("cachedDate", DateTime.Now.ToString()); }


          return caseInPoint;
      }
    }
      catch(Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error in CIP data and cache" +ex,this);
        return null;
      }
      // Check if cache is available, if not then create new.
      if (cipCache == null)
      {
        cipCache = new Sitecore.Caching.Cache("CIP Cache", 20480);
      }      
      //If there is an error in APi call then update error in cache to check after one hour.
      if (cipCache.GetValue("serviceGetError") == null) { cipCache.Add("serviceGetError", DateTime.Now.ToString()); }
      Sitecore.Diagnostics.Log.Error("Error in CIP service","Error");
      return null;
    }

  

    private ACR.Foundation.CaseInPointService.Models.CaseInPointItem GetCaseInpointData()
    {
      CaseInPointClient client = new CaseInPointClient();
      try
      {
        //Get Api URL and key from config 
        string CipApiUrl = Sitecore.Configuration.Settings.GetSetting("CipApiUrl");
        string CipApiKey = Sitecore.Configuration.Settings.GetSetting("CipApiKey");
        var result = client.GetCaseInPoint(CipApiUrl, CipApiKey);
        return result;
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error in CIP service" +ex, "CIP Service");
        return null;
      }
      
    }

    public CaseInPointItem GetMiniCaseInPointContent(MiniCaseInPointContent content)
    {

      CaseInPointItem caseInPoint = new CaseInPointItem();
      var cipCache = Sitecore.Caching.CacheManager.FindCacheByName<string>("CIP Cache");
      try {
        //Get data from CIP widget Api.
        ACR.Foundation.CaseInPointService.Models.CaseInPointItem item = GetCaseInpointData();
      if (item != null)
      {
        caseInPoint.Title = "Case in Point";
        caseInPoint.Text = item.History;
        caseInPoint.Link = new Glass.Mapper.Sc.Fields.Link { Url = item.Url, Title = "Go to Case in Point" };
        caseInPoint.Image = new Glass.Mapper.Sc.Fields.Image { Src = item.ImageUrl };
        caseInPoint.Date = item.PublishDate.HasValue ? item.PublishDate.Value : DateTime.Now;

          // Data from sitecore item as required.
          if (content != null)
        {
          caseInPoint.Link.Title = content.LinkToolTipText;
          caseInPoint.Title = content.Title;
          caseInPoint.Link.Text = content.LinkText;

          caseInPoint.MiniContent = content;
        }
          // Check if cache is available, if not then create new.
          if (cipCache == null)
          {
            cipCache = new Sitecore.Caching.Cache("CIP Cache", 20480);
          }
          //Fill data in cache for further requests.
          if (cipCache.GetValue("serviceHistory") == null) { cipCache.Add("serviceHistory", item.History); }
          if (cipCache.GetValue("serviceUrl") == null) { cipCache.Add("serviceUrl", item.Url); }
          if (cipCache.GetValue("serviceimageUrl") == null) { cipCache.Add("serviceimageUrl", item.ImageUrl); }
          if (cipCache.GetValue("serviceDate") == null) { cipCache.Add("serviceDate", item.PublishDate.HasValue ? item.PublishDate.Value : DateTime.Now); }
          if (cipCache.GetValue("miniItemTitle") == null) { cipCache.Add("miniItemTitle", content.Title); }
          if (cipCache.GetValue("MiniItemLinkText") == null) { cipCache.Add("MiniItemLinkText", content.LinkText); }       
          if (cipCache.GetValue("miniItemTooltipText") == null) { cipCache.Add("miniItemTooltipText", content.LinkToolTipText); }
          if (cipCache.GetValue("cachedDate") == null) { cipCache.Add("cachedDate", DateTime.Now.ToString()); }
          return caseInPoint;
      }
    }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error in CIP data and cache mini widget" + ex, this);
        return null;
      }
      // Check if cache is available, if not then create new.
      if (cipCache == null)
      {
        cipCache = new Sitecore.Caching.Cache("CIP Cache", 20480);
      }
      //If there is an error in APi call then update error in cache to check after one hour.
      if (cipCache.GetValue("serviceGetError") == null) { cipCache.Add("serviceGetError", DateTime.Now.ToString()); }
      Sitecore.Diagnostics.Log.Error("Error in CIP service", "Error");

      return null;
    }

    public CaseInPointContent GetCaseInPointSCContent(string datasource)
    {
      return _repository.GetContentItem<CaseInPointContent>(datasource);
    }

    public MiniCaseInPointContent GetMiniCaseInPointSCContent(string datasource)
    {
      return _repository.GetContentItem<MiniCaseInPointContent>(datasource);
    }
  }
}