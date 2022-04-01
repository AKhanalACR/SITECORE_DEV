using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Feature.XBlog.Areas.XBlog;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Feature.XBlog.Areas.XBlog.General;
using Sitecore.Feature.XBlog.Areas.XBlog.Models.Blog;
using Sitecore.Feature.XBlog.Areas.XBlog.Items.Blog;
using Sitecore.Exceptions;
using Sitecore.Buckets.Extensions;
using Sitecore.Data;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Feature.XBlog.Areas.XBlog.Helpers;
using System.Web;
using DataManager = Sitecore.Feature.XBlog.Areas.XBlog.General.DataManager;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Search
{
  public static class BlogManager
  {
    // Class to Map Solr indexed Publish_date to PublishDate for ordering      
    public class DSIBlogPostsSortedItem : SearchResultItem
    {
      [IndexField("publish_date")]
      public DateTime PublishDate { get; set; } 
    }
    public static IEnumerable<BlogPost> GetBlogPosts(Item currentItem, string categoryID, string authorID, string tagID, string searchText, int startRowIndex, int maximumRows, ID[] featuredBlog)
    {
      try
      {
        Item repositorySearchItem = XBlog.General.DataManager.GetBlogHomeItem(currentItem);

        ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("dsi_xblog_index");

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<DSIBlogPostsSortedItem, bool>> predicate = PredicateBuilder.True<DSIBlogPostsSortedItem>();
          predicate = predicate.And(item => item.TemplateName == BlogPost.BlogPostTemplate && item.Paths.Contains(repositorySearchItem.ID) && !featuredBlog.Contains(item.ItemId));

          if (!String.IsNullOrEmpty(categoryID))
          {
            predicate = predicate.And(c => c[BlogPost.BlogPostCategoryField] == categoryID);
          }

          return context.GetQueryable<DSIBlogPostsSortedItem>().Where(predicate)
                        .OrderByDescending(t => t.PublishDate)
                        .Slice(startRowIndex, maximumRows)
                        .CreateAs<BlogPost>().ToList();
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetBlogResults error", ex, new object());
      }
      return null;
    }

    public static IEnumerable<BlogPost> GetBlogPostsMK([NotNull] Item blogRoot, int startRowIndex, int maximumRows, bool descending)
    {
      try
      {
        ISearchIndex index = ContentSearchManager.GetIndex(new SitecoreIndexableItem(blogRoot));
        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<SearchResultItem, bool>> predicate = GetBlogItemsQueryPredicate(blogRoot);
          if (descending)
            return context.GetQueryable<SearchResultItem>().Where(predicate)
                         .OrderByDescending(result => result["TODO REPLACE THIS WITH THE PUBLISH DATE FIELD THAT LUCENE HAS"])
                         .CreateAs<BlogPost>();
          else
            return context.GetQueryable<SearchResultItem>().Where(predicate)
                     .OrderBy(result => result["TODO REPLACE THIS WITH THE PUBLISH DATE FIELD THAT LUCENE HAS"])
                     .CreateAs<BlogPost>();
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetBlogPosts error", ex, new object());
      }
      return Enumerable.Empty<BlogPost>();
    }

    public static IEnumerable<BlogPost> GetBlogPostsByTag(BlogHome blogRoot, IEnumerable<string> taxonomyItemNames, int startRowIndex, int maximumRows, bool matchAll, bool descending)
    {
      //TODO when copying XCore code...
      //.Slice(startRowIndex, maximumRows) Comes form XCore utilities
      return XBlogDataManager.GetItemsByTaxonomy(blogRoot.InnerItem, taxonomyItemNames, int.MaxValue, matchAll, descending).CreateAs<BlogPost>();
    }

    public static BlogHome GetBlogRootForBlogPost([NotNull] BlogPost blogPost)
    {
      Item parent = blogPost.InnerItem.GetParentBucketItemOrParent();
      if (parent != null && parent.IsValidType<BlogHome>())
        return parent.CreateAs<BlogHome>();

      Item currentItem = blogPost.InnerItem;
      while (!currentItem.IsValidType<BlogHome>())
      {
        if (!currentItem.Paths.IsContentItem)
          throw new ConfigurationException("No blog root found");
        currentItem = currentItem.Parent;
      }
      return currentItem.CreateAs<BlogHome>();

    }

    private static IEnumerable<ID> GetBlogFilterByTemplateIds()
    {
      return new ID[] { ID.Parse(BlogPost.BlogPostTemplateId) };
    }

    private static Expression<Func<SearchResultItem, bool>> GetBlogItemsQueryPredicate(Item blogRoot)
    {
      Expression<Func<SearchResultItem, bool>> predicate = PredicateBuilder.True<SearchResultItem>();
      predicate = predicate.And(p => p.Language == Context.Language.Name);

      predicate = predicate.And(p => p.TemplateId == ID.Parse(BlogPost.BlogPostTemplateId));

      if (blogRoot != null)
        predicate = predicate.And(p => p.Paths.Contains(blogRoot.ID));

      return predicate;
    }

    public static int GetBlogsCount(Item currentItem, string categoryID, string authorID, string tagID, string searchText)
    {
      try
      {
        Item repositorySearchItem = General.DataManager.GetBlogHomeItem(currentItem);
        ISearchIndex index = ContentSearchManager.GetIndex(new SitecoreIndexableItem(repositorySearchItem));

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<SearchResultItem, bool>> predicate = PredicateBuilder.True<SearchResultItem>();
          predicate = predicate.And(item => item.TemplateName == BlogPost.BlogPostTemplate && item.Paths.Contains(repositorySearchItem.ID));

          if (!String.IsNullOrEmpty(categoryID))
          {
            //predicate = predicate.And(c => c[BlogPost.BlogPostCategoryField].Contains(categoryID));
            predicate = predicate.And(c => c[BlogPost.BlogPostCategoryField]==categoryID);
          }
          if (!String.IsNullOrEmpty(authorID))
          {
            predicate = predicate.And(a => a[BlogPost.BlogPostAuthorField].Contains(authorID));
          }
          if (!String.IsNullOrEmpty(tagID))
          {
            predicate = predicate.And(t => t[BlogPost.BlogPostTagsField].Contains(tagID));
          }
          if (!String.IsNullOrEmpty(searchText))
          {
            predicate = predicate.And(t => t[BuiltinFields.Content].Contains(searchText));
          }

          return context.GetQueryable<SearchResultItem>().Where(predicate)
              .OrderByDescending(t => t[XBSettings.XBSearchPublishDate]).Count();
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetBlogsCount error", ex, new object());
      }
      return 0;
    }

    public static string GetBlogPagination(BlogSettings settingsItem, int currentPage, int totalRows, int maximumRows)
    {
      StringBuilder pagination = new StringBuilder();

      double decMaxPages = System.Convert.ToDouble(totalRows) / System.Convert.ToDouble(maximumRows);
      int maxPages = System.Convert.ToInt32(Math.Ceiling(decMaxPages));

      if (maxPages > 1)
      {

        if (currentPage > maxPages)
        {
          // outside our range, make first page
          currentPage = 1;
        }

        if (currentPage != 1)
        {
          pagination.Append(String.Format("<a href=\"?{0}={1}\">{2}</a> ", XBSettings.XBPageQS, "1", settingsItem.FirstPageText));
          pagination.Append(String.Format("<a href=\"?{0}={1}\">{2}</a> ", XBSettings.XBPageQS, System.Convert.ToString(currentPage - 1), settingsItem.PreviousPageText));
        }

        if (currentPage - 2 > 0)
          pagination.Append(String.Format("<a href=\"?{0}={1}\">{2}</a> ", XBSettings.XBPageQS, System.Convert.ToString(currentPage - 2), System.Convert.ToString(currentPage - 2)));

        if (currentPage - 1 > 0)
          pagination.Append(String.Format("<a href=\"?{0}={1}\">{2}</a> ", XBSettings.XBPageQS, System.Convert.ToString(currentPage - 1), System.Convert.ToString(currentPage - 1)));

        pagination.Append(String.Format("{0} ", System.Convert.ToString(currentPage)));

        if (currentPage + 1 <= maxPages)
          pagination.Append(String.Format("<a href=\"?{0}={1}\">{2}</a> ", XBSettings.XBPageQS, System.Convert.ToString(currentPage + 1), System.Convert.ToString(currentPage + 1)));

        if (currentPage + 2 <= maxPages)
          pagination.Append(String.Format("<a href=\"?{0}={1}\">{2}</a> ", XBSettings.XBPageQS, System.Convert.ToString(currentPage + 2), System.Convert.ToString(currentPage + 2)));

        if (currentPage + 1 <= maxPages)
        {
          pagination.Append(String.Format("<a href=\"?{0}={1}\">{2}</a> ", XBSettings.XBPageQS, System.Convert.ToString(currentPage + 1), settingsItem.NextPageText));
          pagination.Append(String.Format("<a href=\"?{0}={1}\">{2}</a> ", XBSettings.XBPageQS, System.Convert.ToString(maxPages), settingsItem.LastPageText));
        }
      }



      return pagination.ToString();
    }

    public static IList<BlogPost> GetBlogRelatedValues(BlogPost currentItem)
    {
      Dictionary<string, int> blogItems = new Dictionary<string, int>();
      IList<BlogPost> blogList = new List<BlogPost>();

      try
      {
        Item repositorySearchItem = XBlog.General.DataManager.GetBlogHomeItem(currentItem.InnerItem);
        BlogSettings settingsItem = XBlog.General.DataManager.GetBlogSettingsItem(currentItem.InnerItem);

        ISearchIndex index = ContentSearchManager.GetIndex(new SitecoreIndexableItem(repositorySearchItem));

        using (IProviderSearchContext context = index.CreateSearchContext())
        {

          // look at the pipe seperated list.  break them out and loop through.  Build dictionary based on Ids
          // create as blog post item
          // could even pass a max item as a dictionary definition
          Expression<Func<SearchResultItem, bool>> predicate = PredicateBuilder.True<SearchResultItem>();
          predicate = predicate.And(item => item.TemplateName == BlogPost.BlogPostTemplate && item.Paths.Contains(repositorySearchItem.ID));

          IEnumerable<BlogPost> resultList = context.GetQueryable<SearchResultItem>().Where(predicate).OrderBy(t => t.Name).CreateAs<BlogPost>();

          foreach (BlogPost item in resultList)
          {
            if (item.ItemId != currentItem.ItemId)
            {
              string itemID = item.ItemId.ToString();
              blogItems.Add(itemID, 0);
              foreach (Author author in item.Authors)
              {
                foreach (Author currentAuthor in currentItem.Authors)
                {
                  if (currentAuthor.ItemId == author.ItemId)
                  {
                    blogItems[itemID] = blogItems[itemID] + XBSettings.RelatedAuthorValue;
                  }
                }

              }

              foreach (Category category in item.Categories)
              {
                foreach (Category currenCategory in currentItem.Categories)
                {
                  if (currenCategory.ItemId == category.ItemId)
                  {
                    blogItems[itemID] = blogItems[itemID] + XBSettings.RelatedCategoryValue;
                  }
                }
              }


              foreach (Tag tag in item.Tags)
              {
                foreach (Tag currentTag in currentItem.Tags)
                {
                  if (currentTag.ItemId == tag.ItemId)
                  {
                    blogItems[itemID] = blogItems[itemID] + XBSettings.RelatedTagValue;
                  }
                }

              }
            }

          }
        }

        // order the count descending then build list based on this order.
        var items = from pair in blogItems
                    orderby pair.Value descending
                    select pair;

        Database current = Context.Database;
        foreach (KeyValuePair<string, int> pair in items)
        {
          if (ID.IsID(pair.Key))
          {
            BlogPost thisItem = current.GetItem(ID.Parse(pair.Key)).CreateAs<BlogPost>();
            if (!blogList.Contains(thisItem))
            {
              blogList.Add(thisItem);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetAuthorCount error", ex, new object());
      }
      return blogList;
    }

    public static IList<BlogPost> GetVORBlogRelatedValues(BlogPost currentItem)
    {
      Dictionary<string, int> blogItems = new Dictionary<string, int>();
      IList<BlogPost> blogList = new List<BlogPost>();

      try
      {
        Item repositorySearchItem = XBlog.General.DataManager.GetBlogHomeItem(currentItem.InnerItem);
        BlogSettings settingsItem = XBlog.General.DataManager.GetBlogSettingsItem(currentItem.InnerItem);

        ISearchIndex index = ContentSearchManager.GetIndex(new SitecoreIndexableItem(repositorySearchItem));

        /*using (*/
        IProviderSearchContext context = index.CreateSearchContext();//)
                                                                     //{

        // look at the pipe seperated list.  break them out and loop through.  Build dictionary based on Ids
        // create as blog post item
        // could even pass a max item as a dictionary definition
        Expression<Func<VORBlogPostsSortedItem, bool>> predicate = PredicateBuilder.True<VORBlogPostsSortedItem>();
        predicate = predicate.And(item => item.TemplateName == BlogPost.BlogPostTemplate && item.Paths.Contains(repositorySearchItem.ID));

        IEnumerable<BlogPost> resultList = context.GetQueryable<VORBlogPostsSortedItem>().Where(predicate).OrderByDescending(t => t.PublishDate).CreateAs<BlogPost>();

        foreach (BlogPost item in resultList)
        {
          if (item.ItemId != currentItem.ItemId)
          {
            string itemID = item.ItemId.ToString();
            blogItems.Add(itemID, 0);
            foreach (Author author in item.Authors)
            {
              foreach (Author currentAuthor in currentItem.Authors)
              {
                if (currentAuthor.ItemId == author.ItemId)
                {
                  blogItems[itemID] = blogItems[itemID] + XBSettings.RelatedAuthorValue;
                }
              }

            }

            foreach (Category category in item.Categories)
            {
              foreach (Category currenCategory in currentItem.Categories)
              {
                if (currenCategory.ItemId == category.ItemId)
                {
                  blogItems[itemID] = blogItems[itemID] + XBSettings.RelatedCategoryValue;
                }
              }
            }


            foreach (Tag tag in item.Tags)
            {
              foreach (Tag currentTag in currentItem.Tags)
              {
                if (currentTag.ItemId == tag.ItemId)
                {
                  blogItems[itemID] = blogItems[itemID] + XBSettings.RelatedTagValue;
                }
              }

            }
          }

        }
        //}

        // order the count descending then build list based on this order.
        var items = from pair in blogItems
                    orderby pair.Value descending
                    select pair;

        Database current = Context.Database;
        foreach (KeyValuePair<string, int> pair in items)
        {
          if (ID.IsID(pair.Key))
          {
            BlogPost thisItem = current.GetItem(ID.Parse(pair.Key)).CreateAs<BlogPost>();
            if (!blogList.Contains(thisItem))
            {
              blogList.Add(thisItem);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetAuthorCount error", ex, new object());
      }
      return blogList;
    }


    public static IEnumerable<BlogPost> SetBlogDisplayLimit(string maxDisplay, IEnumerable<BlogPost> blogs)
    {
      int number;
      bool result = Int32.TryParse(maxDisplay, out number);
      var blogsList = blogs.ToList();
      if (!result)
      {
        number = 99;
      }

      if (blogsList.Count < number)
      {
        number = blogsList.Count;
      }

      return blogsList.Take(number);
    }
    //Class to Map Solr indexed Publish_date to PublishDate for ordering  VOR Blogs
    public class VORBlogPostsSortedItem : SearchResultItem
    {
      [IndexField("publish_date")]
      public DateTime PublishDate { get; set; }
    }
    public static IEnumerable<BlogPost> GetVORBlogPosts(Item currentItem, string categoryID, string authorID, string tagID, string searchText, int startRowIndex, int maximumRows, ID featuredBlog,int totalRows)
    {
      try
      {
        Item repositorySearchItem = XBlog.General.DataManager.GetBlogHomeItem(currentItem);
        ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("vor_xblog_index1");

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<VORBlogPostsSortedItem, bool>> predicate = PredicateBuilder.True<VORBlogPostsSortedItem>();
          predicate = predicate.And(item => item.TemplateName == BlogPost.BlogPostTemplate && item.Paths.Contains(repositorySearchItem.ID)&& item.ItemId != featuredBlog);         
          if (!String.IsNullOrEmpty(categoryID))
          {
            predicate = predicate.And(c => c[BlogPost.BlogPostCategoryField] == categoryID);

          }
          
          if (!String.IsNullOrEmpty(authorID))
          {
            predicate = predicate.And(a => a[BlogPost.BlogPostAuthorField] == authorID);
            return context.GetQueryable<VORBlogPostsSortedItem>().Where(predicate)                       
                       .OrderByDescending(t => t.PublishDate)
                       .Slice(0, totalRows)
                       .CreateAs<BlogPost>().ToList();

          }        
          bool hasquery = HttpContext.Current.Request.QueryString.HasKeys();
          bool cat = String.IsNullOrEmpty(categoryID);
          if ((!HttpContext.Current.Request.QueryString.HasKeys()) && String.IsNullOrEmpty(categoryID))
          {
            return context.GetQueryable<VORBlogPostsSortedItem>().Where(predicate)                       
                        .OrderByDescending(t => t.PublishDate)
                        .Slice(startRowIndex, maximumRows+1)
                        .CreateAs<BlogPost>().ToList();
          }
          if (String.IsNullOrEmpty(categoryID) && String.IsNullOrEmpty(authorID) && startRowIndex > 0)
          {
            startRowIndex++;
          }
          return context.GetQueryable<VORBlogPostsSortedItem>().Where(predicate)
                        .OrderByDescending(t => t.PublishDate)
                        .Slice(startRowIndex, maximumRows)
                        .CreateAs<BlogPost>().ToList();
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetBlogResults error", ex, new object());
      }
      return null;
    }
    public class VORBlogCommentsSearchItem : SearchResultItem
    {
      [IndexField("_created")]
      public DateTime DateCreated { get; set; }
    }
    public static IEnumerable<VORBlogComment> GetVORComments(Item currentItem)
    {
      try
      {
        Item repositorySearchItem =currentItem;
        ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("vor_xblog_comments_index");

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<VORBlogCommentsSearchItem, bool>> predicate = PredicateBuilder.True<VORBlogCommentsSearchItem>();
          predicate = predicate.And(item => item.TemplateName == VORBlogComment.CommentTemplateName && item.Paths.Contains(repositorySearchItem.ID));

          return context.GetQueryable<VORBlogCommentsSearchItem>().Where(predicate)
                        .OrderByDescending(t => t.DateCreated)
                        .CreateAs<VORBlogComment>().ToList();
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetBlogResults error", ex, new object());
      }
      return null;
    }
    public static string GetLatestVORBlogPost()
    {
      try
      {
       
        ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("vor_xblog_index1");

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<VORBlogPostsSortedItem, bool>> predicate = PredicateBuilder.True<VORBlogPostsSortedItem>();
          var latestBlogPost = context.GetQueryable<VORBlogPostsSortedItem>().Where(predicate)
                        .OrderByDescending(t => t.PublishDate)
                        .Slice(0, 2)
                        .CreateAs<BlogPost>().Take(1);
          return latestBlogPost.First().ItemId.ToString();
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetBlogResults error", ex, new object());
      }
      return string.Empty; ;
    }

    public static string VORGetBlogPagination(BlogSettings settingsItem, int currentPage, int totalRows, int maximumRows)
    {
      string urlCategoryName =DataManager.GetUrlValByPattern(HttpContext.Current.Request.Url.PathAndQuery, XBSettings.XBCategoryUrlPattern);

      int firstpageCount = maximumRows;
      if (string.IsNullOrEmpty(urlCategoryName))
      {
        firstpageCount = maximumRows+2;
      }
      StringBuilder pagination = new StringBuilder();

      double decMaxPages = System.Convert.ToDouble(totalRows) / System.Convert.ToDouble(maximumRows);
      int maxPages = System.Convert.ToInt32(Math.Ceiling(decMaxPages));

      if (totalRows <= firstpageCount)
      {
        pagination.Append(String.Format("<li class='prev' style='display:none'><a href=\"?{0}={3}\"><</a></li><li style='display:none'><input value={4} type='text'onClick='this.select();' id='myInput' oninput='myFunction()' /></li><li style='display:none'> of <span class='total-page' style='display:none'><a href=\"?{0}={1}\">{2}</a></span></li><li class='next' style='display:none'><a href=\"?{0}={5}\">></a></li>", XBSettings.XBPageQS, maxPages, maxPages, System.Convert.ToString(currentPage - 1), currentPage.ToString(), System.Convert.ToString(currentPage + 1)));
      }

      if (totalRows > firstpageCount)
      {

        pagination.Append(String.Format("<li class='prev'style='margin-top: 3px;'><a href=\"?{0}={3}\"><</a></li><li><input value={4} type='text'onClick='this.select();' id='myInput' oninput='myFunction()' /></li><li style='margin-top: 4px;'> of <span class='total-page'><a href=\"?{0}={1}\">{2}</a></span></li><li class='next' style='margin-top: 3px;'><a href=\"?{0}={5}\">></a></li>", XBSettings.XBPageQS, maxPages, maxPages, System.Convert.ToString(currentPage - 1), currentPage.ToString(), System.Convert.ToString(currentPage + 1)));

      }

      return pagination.ToString();
    }

    public static int GetVORBlogsCount(Item currentItem, string categoryID, string authorID, string tagID, string searchText)
    {

      try
      {
        Item repositorySearchItem = XBlog.General.DataManager.GetBlogHomeItem(currentItem);
        ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("vor_xblog_index1");

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<SearchResultItem, bool>> predicate = PredicateBuilder.True<SearchResultItem>();
          predicate = predicate.And(item => item.TemplateName == BlogPost.BlogPostTemplate && item.Paths.Contains(repositorySearchItem.ID));

          if (!String.IsNullOrEmpty(categoryID))
          {
            predicate = predicate.And(c => c[BlogPost.BlogPostCategoryField] == categoryID);

          }

          return context.GetQueryable<SearchResultItem>().Where(predicate)
                        .OrderByDescending(t => t.CreatedDate)
                        .CreateAs<BlogPost>().ToList().Count();
        }
      }
      catch (Exception ex)
      {
        Log.Error("XBlog GetBlogResults error", ex, new object());
      }
      return 0;
    }

  }
}
