using ACR.Foundation.ExpressUrls.Data;
using ACR.Foundation.ExpressUrls.Logger;
using ACR.Foundation.ExpressUrls.Redirector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.IO;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.Sites;
using Sitecore.StringExtensions;
using Sitecore.Web;
using Sitecore.Feature.XBlog.Areas.XBlog.General;

namespace ACR.Foundation.ExpressUrls.Processors
{
  public class ExpressUrlProcessor : Sitecore.Pipelines.HttpRequest.HttpRequestProcessor
  {
    private enum BlogFilterType { None = 0, Category, Tag, Author, AuthorView, Search };
    public override void Process(Sitecore.Pipelines.HttpRequest.HttpRequestArgs args)
    {
      //RLI & VORBlog content url redirect 
      if (Sitecore.Context.Site.Name == "RLI" || Sitecore.Context.Site.Name == "VORBlog")
      {
          try
          {                 
              Sitecore.Context.SetActiveSite("website");                   
              ExpressUrlRedirector redirector = new ExpressUrlRedirector();
              redirector.TryPerformRedirect(HttpContext.Current);
          }
          catch (Exception ex)
          {
              ExpressUrlLogger.Logger.Error("Error performing redirect for: " + HttpContext.Current.Request.Path, ex);
          }
          return;
      }

      //Mammography Saves Lives content redirect to ACR Accreditation 
      if (Sitecore.Context.Site.Name == "MammographySavesLives")
      {
          try
          {
              Sitecore.Context.SetActiveSite("accreditation");
              ExpressUrlRedirector redirector = new ExpressUrlRedirector();
              redirector.TryPerformRedirect(HttpContext.Current);
          }
          catch (Exception ex)
          {
              ExpressUrlLogger.Logger.Error("Error performing MSL redirect for: " + HttpContext.Current.Request.Path, ex);
          }
          return;
      }

      if (HttpContext.Current.Request.Path.ToLower().StartsWith("/dsiblog/category/") )
      {
        
        Assert.ArgumentNotNull(args, "args");
        if (((Context.Item == null) && (Context.Database != null)) && !string.IsNullOrWhiteSpace(args.Url.ItemPath))
        {
          
          Profiler.StartOperation("Resolve blog item.");
          string qsValue = string.Empty;
          string decodedItemName = MainUtil.DecodeName(args.Url.ItemPath);

          string blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBCategoryUrlPattern, out qsValue);
          BlogFilterType filter = BlogFilterType.None;
          if (!string.IsNullOrEmpty(blogItemPath))
            filter = BlogFilterType.Category;
          else
          {
            
            blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBAuthorUrlPattern, out qsValue);
            if (!string.IsNullOrEmpty(blogItemPath))
              filter = BlogFilterType.Author;
            else
            {
              
              blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBTagsUrlPattern, out qsValue);
              if (!string.IsNullOrEmpty(blogItemPath))
                filter = BlogFilterType.Tag;
              else
              {
                
                blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBAuthorViewUrlPattern, out qsValue);
                if (!string.IsNullOrEmpty(blogItemPath))
                  filter = BlogFilterType.AuthorView;
                else
                {
                  
                  blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBSearchURLPattern, out qsValue);
                  if (!string.IsNullOrEmpty(blogItemPath))
                    filter = BlogFilterType.Search;
                }
              }
            }
          }
          if (!string.IsNullOrEmpty(blogItemPath) && filter != BlogFilterType.None)
          {
            Item blogRoot = Sitecore.Context.Database.Items.GetItem("{CB9F0773-0231-4B46-AB82-3C6D633CEF0F}");
            

            if (blogRoot != null)
            {
              
              Context.Item = blogRoot;
              NameValueCollection nv = StringUtil.ParseNameValueCollection(args.Url.QueryString, '&', '=');
              switch (filter)
              {
                case BlogFilterType.Category:
                  nv.Add(XBSettings.XBCategoryQS, qsValue);
                  break;
                case BlogFilterType.Author:
                  nv.Add(XBSettings.XBAuthorQS, qsValue);
                  break;
                case BlogFilterType.AuthorView:
                  nv.Add(XBSettings.XBAuthorViewQS, qsValue);
                  break;
                case BlogFilterType.Tag:
                  nv.Add(XBSettings.XBTagQS, qsValue);
                  break;
                case BlogFilterType.Search:
                  nv.Add(XBSettings.XBSearchQS, qsValue);
                  break;
                case BlogFilterType.None:
                default:
                  break;
              }
              args.Url.QueryString = StringUtil.NameValuesToString(nv, "&");
              
            }
          }
          Profiler.EndOperation();
        }
      }

      if (HttpContext.Current.Request.Path.ToLower().StartsWith("/advocacy-and-economics/voice-of-radiology-blog/category/"))
      //if (HttpContext.Current.Request.Path.ToLower().Contains("/category/"))
      //{
      //  var blogHomeUrl = "#";
      //  try
      //  {
      //    string filter = string.Format("contains('{0}', @@templatename)", "Blog Home");
      //    // blogHomeUrl = Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Database.Item.Axes.SelectSingleItem("ancestor-or-self::*[" + filter + "]"));
      //    blogHomeUrl = Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Database.Items.GetItem("{A878956A-EB90-4320-9E50-911FB29A950D}")); 
      //    blogHomeUrl = blogHomeUrl + "/category/";
      //  }
      //  catch
      //  {
      //  }
      //  if(HttpContext.Current.Request.Path.ToLower().StartsWith(blogHomeUrl.ToLower()))
      { 
        Assert.ArgumentNotNull(args, "args");
        if (((Context.Item == null) && (Context.Database != null)) && !string.IsNullOrWhiteSpace(args.Url.ItemPath))
        {

          Profiler.StartOperation("Resolve blog item.");
          string qsValue = string.Empty;
          string decodedItemName = MainUtil.DecodeName(args.Url.ItemPath);

          string blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBCategoryUrlPattern, out qsValue);
          BlogFilterType filter = BlogFilterType.None;
          if (!string.IsNullOrEmpty(blogItemPath))
            filter = BlogFilterType.Category;
          else
          {

            blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBAuthorUrlPattern, out qsValue);
            if (!string.IsNullOrEmpty(blogItemPath))
              filter = BlogFilterType.Author;
            else
            {

              blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBTagsUrlPattern, out qsValue);
              if (!string.IsNullOrEmpty(blogItemPath))
                filter = BlogFilterType.Tag;
              else
              {

                blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBAuthorViewUrlPattern, out qsValue);
                if (!string.IsNullOrEmpty(blogItemPath))
                  filter = BlogFilterType.AuthorView;
                else
                {

                  blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBSearchURLPattern, out qsValue);
                  if (!string.IsNullOrEmpty(blogItemPath))
                    filter = BlogFilterType.Search;
                }
              }
            }
          }
          if (!string.IsNullOrEmpty(blogItemPath) && filter != BlogFilterType.None)
          {
            Item blogRoot = Sitecore.Context.Database.Items.GetItem("{A878956A-EB90-4320-9E50-911FB29A950D}");


            if (blogRoot != null)
            {

              Context.Item = blogRoot;
              NameValueCollection nv = StringUtil.ParseNameValueCollection(args.Url.QueryString, '&', '=');
              switch (filter)
              {
                case BlogFilterType.Category:
                  nv.Add(XBSettings.XBCategoryQS, qsValue);
                  break;
                case BlogFilterType.Author:
                  nv.Add(XBSettings.XBAuthorQS, qsValue);
                  break;
                case BlogFilterType.AuthorView:
                  nv.Add(XBSettings.XBAuthorViewQS, qsValue);
                  break;
                case BlogFilterType.Tag:
                  nv.Add(XBSettings.XBTagQS, qsValue);
                  break;
                case BlogFilterType.Search:
                  nv.Add(XBSettings.XBSearchQS, qsValue);
                  break;
                case BlogFilterType.None:
                default:
                  break;
              }
              args.Url.QueryString = StringUtil.NameValuesToString(nv, "&");

            }
          }
          Profiler.EndOperation();
        }
      }
      

      if (HttpContext.Current.Request.Path.ToLower().StartsWith("/advocacy-and-economics/voice-of-radiology-blog/author/"))
      //if (HttpContext.Current.Request.Path.ToLower().Contains("/author/"))
      //{
      //  var blogHomeUrl = "#";
      //  try
      //  {
      //    string filter = string.Format("contains('{0}', @@templatename)", "Blog Home");
      //    // blogHomeUrl = Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item.Axes.SelectSingleItem("ancestor-or-self::*[" + filter + "]"));
      //    blogHomeUrl = Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Database.Items.GetItem("{A878956A-EB90-4320-9E50-911FB29A950D}"));
      //    blogHomeUrl = blogHomeUrl + "/author/";
      //  }
      //  catch
      //  {
      //  }
      //  if(HttpContext.Current.Request.Path.ToLower().StartsWith(blogHomeUrl.ToLower()))
      {
          Assert.ArgumentNotNull(args, "args");
          if (((Context.Item == null) && (Context.Database != null)) && !string.IsNullOrWhiteSpace(args.Url.ItemPath))
          {

            Profiler.StartOperation("Resolve blog item.");
            string qsValue = string.Empty;
            string decodedItemName = MainUtil.DecodeName(args.Url.ItemPath);

            string blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBCategoryUrlPattern, out qsValue);
            BlogFilterType filter = BlogFilterType.None;
            if (!string.IsNullOrEmpty(blogItemPath))
              filter = BlogFilterType.Category;
            else
            {

              blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBAuthorUrlPattern, out qsValue);
              if (!string.IsNullOrEmpty(blogItemPath))
                filter = BlogFilterType.Author;
              else
              {

                blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBTagsUrlPattern, out qsValue);
                if (!string.IsNullOrEmpty(blogItemPath))
                  filter = BlogFilterType.Tag;
                else
                {

                  blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBAuthorViewUrlPattern, out qsValue);
                  if (!string.IsNullOrEmpty(blogItemPath))
                    filter = BlogFilterType.AuthorView;
                  else
                  {

                    blogItemPath = ResolveBlogItemPath(decodedItemName, XBSettings.XBSearchURLPattern, out qsValue);
                    if (!string.IsNullOrEmpty(blogItemPath))
                      filter = BlogFilterType.Search;
                  }
                }
              }
            }
            if (!string.IsNullOrEmpty(blogItemPath) && filter != BlogFilterType.None)
            {
              Item blogRoot = Sitecore.Context.Database.Items.GetItem("{A878956A-EB90-4320-9E50-911FB29A950D}");


              if (blogRoot != null)
              {

                Context.Item = blogRoot;
                NameValueCollection nv = StringUtil.ParseNameValueCollection(args.Url.QueryString, '&', '=');
                switch (filter)
                {
                  case BlogFilterType.Category:
                    nv.Add(XBSettings.XBCategoryQS, qsValue);
                    break;
                  case BlogFilterType.Author:
                    nv.Add(XBSettings.XBAuthorQS, qsValue);
                    break;
                  case BlogFilterType.AuthorView:
                    nv.Add(XBSettings.XBAuthorViewQS, qsValue);
                    break;
                  case BlogFilterType.Tag:
                    nv.Add(XBSettings.XBTagQS, qsValue);
                    break;
                  case BlogFilterType.Search:
                    nv.Add(XBSettings.XBSearchQS, qsValue);
                    break;
                  case BlogFilterType.None:
                  default:
                    break;
                }
                args.Url.QueryString = StringUtil.NameValuesToString(nv, "&");

              }
            }
            Profiler.EndOperation();
          }
        }
      

      if (HttpContext.Current.Request.Path.ToLower().StartsWith("/for-patients"))
      {
        if (HttpContext.Current.Request.Cookies["PatientSiteLang"] != null)
        {
          if (HttpContext.Current.Request.Cookies["PatientSiteLang"].Value.ToString()=="Spanish")
          {
            string redirectUrl = "/Spanish" + HttpContext.Current.Request.Path;
            HttpContext.Current.Response.Redirect(redirectUrl);
          }         
        }
      }
      if (HttpContext.Current.Request.Path.ToLower().StartsWith("/spanish/for-patients"))
      {
        if (HttpContext.Current.Request.Cookies["PatientSiteLang"] == null || HttpContext.Current.Request.Cookies["PatientSiteLang"].Value.ToString() != "Spanish")
        {                  
            string redirectUrl =HttpContext.Current.Request.Path;
          redirectUrl = redirectUrl.Substring(8);
            HttpContext.Current.Response.Redirect(redirectUrl);
        }
      }
      if (Sitecore.Context.Item != null || Sitecore.Context.Site == null || Sitecore.Context.Database == null)
      {
         if (bool.Parse(Sitecore.Configuration.Settings.GetSetting("jacr_redirect_flag")))
         {
             if (HttpContext.Current.Request.Url.PathAndQuery == Sitecore.Configuration.Settings.GetSetting("jacr_redirect_src"))
             {
                 HttpContext.Current.Response.Redirect(Sitecore.Configuration.Settings.GetSetting("jacr_redirect_to"));
                 return;
             }
         }
         //return;       
      }

      if (HttpContext.Current.Request.Path.ToLower().StartsWith("/services") || HttpContext.Current.Request.Path.ToLower().StartsWith("/sitecore"))
      {
        return;
      }

      if (File.Exists(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.Path)))
      {
        return;
      }
      
      //check expressUrl list and attemp redirect
      try
      {
        ExpressUrlRedirector redirector = new ExpressUrlRedirector();
        if (!redirector.TryPerformRedirect(HttpContext.Current))
        {
          //correction for home page forced redirect 
          if (Sitecore.Context.Site.Name == "website" && HttpContext.Current.Request.RawUrl == "/")
          {
            return;
          }

          //check for no page found
          if (Sitecore.Context.Site.Name == "website")
          {
            PageNotFoundRedirector pageNotFoundRedirector = new PageNotFoundRedirector();
            pageNotFoundRedirector.PageNotFoundRedirect(HttpContext.Current);
          }
        }
      }
      catch (Exception ex)
      {
        ExpressUrlLogger.Logger.Error("Error performing redirect for: " + HttpContext.Current.Request.Path, ex);
      }
      return;
      // Try expressUrl   
    }


    private string ResolveBlogItemPath(string decodedItemName, string urlPattern, out string qsValue)
    {
      
      qsValue = string.Empty;
      try
      {
        string pattern = urlPattern.FormatWith(@"(^.+)", @"(.+)/$");
        Match match = Regex.Match(StringUtil.EnsurePostfix('/', decodedItemName), @pattern, RegexOptions.IgnoreCase);

        if (match.Success)
        {
          qsValue = WebUtil.UrlEncode(match.Groups[2].Value);
          return match.Groups[1].Value;
        }

      }
      catch (Exception ex)
      {
        Log.Error("XBlog could not resolve url to a blog item", ex, new object());
      }
      return string.Empty;
    }

  }

}