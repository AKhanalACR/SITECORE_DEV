using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sitecore.Feature.XBlog.Areas.XBlog.Import;
using Sitecore.Mvc.Presentation;
using Sitecore.Feature.XBlog.Areas.XBlog.Models.Blog;
using Sitecore.Feature.XBlog.Areas.XBlog.General;
using Sitecore.Feature.XBlog.Areas.XBlog.Search;
using Sitecore.Feature.XBlog.Areas.XBlog.Items.Blog;
using Sitecore.Data.Items;
using Sitecore.Links;
using System.Text.RegularExpressions;
using Sitecore.Resources.Media;
using Sitecore.Feature.XBlog.Areas.XBlog.Models.Importer;
using Sitecore.Feature.XBlog.Areas.XBlog.Helpers;
using System.Net.Mail;
using System.Net;
using Sitecore.Security;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Controllers
{
  public class XBlogController : Controller
  {
    private string _datasource;

    [HttpPost]
    [AllowAnonymous]
    public JsonResult Create(string xBlogData)
    {
      try
      {
        if (Context.User.IsAdministrator)
        {
          xBlogData = xBlogData.Replace("[", "").Replace("]", "");

          if (string.IsNullOrEmpty(xBlogData))
            return Json(String.Format(""));

          JavaScriptSerializer serializer = new JavaScriptSerializer();
          XBCreator x = serializer.Deserialize<XBCreator>(xBlogData);

          BlogCreator.CreateBlog(x.blogName, x.blogType, x.uploadFile, x.blogParent);

          return Json(String.Format("success"));
        }
        else
        {
          string message = "XBlog Error - A non administrator attempted to create a blog";
          Log.Error(message, this);
          return Json(message);
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message, this);
        return Json(String.Format(ex.Message));
      }
    }

    [HttpGet]
    public ActionResult BlogListing()
    {
      var model = new BlogListingModel();
      try
      {       
        model.Initialize(RenderingContext.Current.Rendering);      
        model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
        BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);        
        string categoryID = "";
        string authorID = "";
        string tagID = "";
        string searchText = "";
        string urlCategoryName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBCategoryUrlPattern);
        if (!String.IsNullOrEmpty(urlCategoryName))
        {        
          Category categoryItem = CategoryManager.GetCategoryByName(Sitecore.Context.Item, urlCategoryName);
          if (categoryItem != null)
          {           
            categoryID = categoryItem.InnerItem.ID.ToString();

            if (settingsItem.DisplayFilterMessage)
            {
              model.SearchHeading = settingsItem.CategoryFilterTitle + categoryItem.CategoryName;
            }
          }
        }

        string urlAuthorName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBAuthorUrlPattern);
        if (!String.IsNullOrEmpty(urlAuthorName))
        {
          Author authorItem = AuthorManager.GetAuthorByName(Sitecore.Context.Item, urlAuthorName);
          if (authorItem != null)
          {
            authorID = authorItem.InnerItem.ID.ToString();

            if (settingsItem.DisplayFilterMessage)
            {
              model.SearchHeading = settingsItem.AuthorFilterTitle + authorItem.FullName;
            }
          }
        }

        string urlTagName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBTagsUrlPattern);
        if (!String.IsNullOrEmpty(urlTagName))
        {
          Tag tagItem = TagManager.GetTagByName(Sitecore.Context.Item, urlTagName);
          if (tagItem != null)
          {
            tagID = tagItem.InnerItem.ID.ToString();

            if (settingsItem.DisplayFilterMessage)
            {
              model.SearchHeading = settingsItem.TagFilterTitle + tagItem.TagName;
            }
          }
        }


        string urlSearchName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBSearchURLPattern);
        if (!String.IsNullOrEmpty(urlSearchName))
        {
          if (!String.IsNullOrEmpty(urlSearchName))
          {
            searchText = urlSearchName;

            if (settingsItem.DisplayFilterMessage)
            {
              model.SearchHeading = settingsItem.SearchFilterTitle + searchText;
            }
          }
        }

        //For excluding main featured blog and sub featured blogs
        Data.ID[] idFeaturedBLog = { new Data.ID("{11111111-1111-1111-1111-111111111111}"), new Data.ID("{11111111-1111-1111-1111-111111111111}"), new Data.ID("{11111111-1111-1111-1111-111111111111}"), new Data.ID("{11111111-1111-1111-1111-111111111111}") };//new Data.ID[4] can't declare with this because of null
        int indexItem = 0;
        if (string.IsNullOrEmpty(urlCategoryName))
        {
          var featuredBlogItem = Sitecore.Context.Database.Items.GetItem("{1F8FA1A1-3BDE-4473-B91B-2F6EC509705B}");
          Sitecore.Data.Fields.MultilistField mainMultiselectField = featuredBlogItem.Fields["Main Featured Blog"];
          Sitecore.Data.Fields.MultilistField subMultiselectField = featuredBlogItem.Fields["Sub Featured Blogs"];
          Sitecore.Data.Items.Item[] mainitems = mainMultiselectField.GetItems();
          Sitecore.Data.Items.Item[] subitems = subMultiselectField.GetItems();          
          if (mainitems != null && mainitems.Length > 0)
          {
            var item = mainitems.FirstOrDefault();
            idFeaturedBLog[indexItem] = item.ID;
            indexItem++;
          }
          if (subitems != null && subitems.Length > 0)
          {
            int length = subitems.Length;
            if (length > 3) { length = 3; }
            for (int itemIndex = 0; itemIndex < length; itemIndex++)
            {
              var item = subitems[itemIndex];
              idFeaturedBLog[indexItem] = item.ID;
              indexItem++;
            }
          }
        }
        //Get search results
        int currentPage = 1;
        int maximumRows = 5;
        int startRowIndex = 1;
        bool rowResult = Int32.TryParse(settingsItem.PageSize, out maximumRows);
        model.MaximumRows = maximumRows;
        if (!rowResult)
        {
          model.MaximumRows = 5;
        }

        if (!String.IsNullOrEmpty(Request.QueryString[XBSettings.XBPageQS]))
        {
          model.PageResult = Int32.TryParse(Request.QueryString[XBSettings.XBPageQS], out currentPage);
        }
        if (!model.PageResult)
        {
          currentPage = 1;
        }        
        startRowIndex = (currentPage - 1) * maximumRows;
        model.CurrentPage = currentPage;       
        model.BlogPosts = BlogManager.GetBlogPosts(Sitecore.Context.Item, urlCategoryName, authorID, tagID, searchText, startRowIndex, maximumRows, idFeaturedBLog);
        model.TotalRows = BlogManager.GetBlogsCount(Sitecore.Context.Item, urlCategoryName, authorID, tagID, searchText);
        model.TotalRows = model.TotalRows - indexItem;                
        if (model.SearchHeading != "")
        {
          model.SearchHeading = model.TotalRows.ToString() + " " + model.SearchHeading;
        }
      }
      catch (Exception ex)
      {
        Log.Error("Log Xblog Error in BlogListing:" + ex.Message, this);
      }
      return View("~/Areas/XBlog/Views/XBlog/BlogListing.cshtml", model);

    }

    public ActionResult BlogPost()
    {
      
      var model = new BlogPostModel();
      
      model.Initialize(RenderingContext.Current.Rendering);

      return View("~/Areas/XBlog/Views/XBlog/BlogPost.cshtml", model);
    }

    public ActionResult AuthorView()
    {
      _datasource = GetNavigationItemPath("Author View");
      return this.View("~/Areas/XBlog/Views/XBlog/AuthorView.cshtml");
    }

    public ActionResult AuthorList()
    {
      var model = new AuthorListModel();

      model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
      BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      model.authorCount = AuthorManager.GetAuthorCount(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      IEnumerable<Author> authors = null;
      if (settingsItem.OrderAuthorOnCount)
      {

        authors = AuthorManager.GetAuthorsOrderedByCount(model.authorCount);
      }
      else
      {
        authors = AuthorManager.GetAuthors(model.dataSourceItem != null ? model.dataSourceItem : Sitecore.Context.Item);
      }

      // Set max display
      authors = AuthorManager.SetAuthorDisplayLimit(settingsItem.AuthorListMaxAuthorsToDisplay, authors);
      model.authors = authors;
      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/AuthorList.cshtml", model);
    }

    public ActionResult AuthorViewList()
    {
      var model = new AuthorListModel();
      model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
      BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      model.authorCount = AuthorManager.GetAuthorCount(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      IEnumerable<Author> authors = null;
      if (settingsItem.OrderAuthorOnCount)
      {

        authors = AuthorManager.GetAuthorsOrderedByCount(model.authorCount);
      }
      else
      {
        authors = AuthorManager.GetAuthors(model.dataSourceItem != null ? model.dataSourceItem : Sitecore.Context.Item);
      }

      // Set max display
      authors = AuthorManager.SetAuthorDisplayLimit(settingsItem.AuthorListMaxAuthorsToDisplay, authors);
      model.authors = authors;
      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/AuthorViewList.cshtml", model);
    }

        public ActionResult CategoryList()
        {
            var model = new CategoryListModel();
            model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
            model.categoryCount = CategoryManager.GetCategoryCount(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);

            IEnumerable<Category> categories = null;
            if (settingsItem.OrderCategoryOnCount)
            {
        categories = CategoryManager.GetCategoriesOrderedByCount(model.categoryCount);
            }
            else
            {       
        categories = CategoryManager.GetCategories(model.dataSourceItem != null ? model.dataSourceItem : Sitecore.Context.Item);
            }
            model.categories = categories;
            return this.View("~/Areas/XBlog/Views/XBlog/Callouts/CategoryList.cshtml", model);
    }
    public ActionResult VORCategoryList()
    {
      var model = new CategoryListModel();
      model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
      BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      model.categoryCount = CategoryManager.VORGetCategoryCount(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      IEnumerable<Category> categories = null;
      if (settingsItem.OrderCategoryOnCount)
      {        
        categories = CategoryManager.GetCategoriesOrderedByCount(model.categoryCount);
      }
      else
      {       
        categories = CategoryManager.GetCategories(model.dataSourceItem != null ? model.dataSourceItem : Sitecore.Context.Item);
      }
      model.categories = categories;
      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/VORCategoryList.cshtml", model);
    }

    public ActionResult OGPostMeta()
    {
      var model = new MetaModel();
      Item dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
      BlogSettings settingsItem = DataManager.GetBlogSettingsItem(dataSourceItem != null ? dataSourceItem : Sitecore.Context.Item);
      BlogPost blogPost = Context.Item.CreateAs<BlogPost>();
      model.title = blogPost.Title;
      UrlOptions options = new UrlOptions();
      options.AlwaysIncludeServerUrl = true;
      model.ogURL = LinkManager.GetItemUrl(blogPost.InnerItem, options);

      if (!String.IsNullOrEmpty(blogPost.Summary))
      {
        model.description = Regex.Replace(blogPost.Summary, "<.*?>", String.Empty);
      }
      else
      {
        model.description = Regex.Replace(Sitecore.Feature.XBlog.Areas.XBlog.Helpers.Helper.SafeSubstring(blogPost.Summary, settingsItem.DisplaySummaryLength), "<.*?>", String.Empty);
      }

      if (blogPost.Authors.Any())
      {
        List<Sitecore.Data.ID> authorIds = new List<Sitecore.Data.ID>();
        foreach (Author a in blogPost.Authors)
        {
          authorIds.Add(a.ItemId);
        }

        List<Author> authors = AuthorManager.GetAuthorsForBlogPost(authorIds);
        if (authors[0].ProfileImage != null && authors[0].ProfileImage.MediaItem != null && settingsItem.DisplayAuthorImage)
        {
          MediaUrlOptions mediaOptions = new MediaUrlOptions();
          mediaOptions.AlwaysIncludeServerUrl = true;
          model.image = MediaManager.GetMediaUrl(authors[0].ProfileImage.MediaItem, mediaOptions);
        }
      }

      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/OGPostMeta.cshtml", model);
    }

    public ActionResult RecentBlog()
    {
      _datasource = GetNavigationItemPath("Recent Blog");
      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/RecentBlog.cshtml");
    }

    public ActionResult RelatedBlog()
    {
      _datasource = GetNavigationItemPath("Related Blog");
      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/RelatedBlog.cshtml");
    }

    public ActionResult TagCloud()
    {
      var model = new TagListModel();
      model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
      BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      model.tagCount = TagManager.GetTagCloud(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      model.tags = TagManager.GetTags(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/TagCloud.cshtml", model);
    }

    public ActionResult TagList()
    {
      var model = new TagListModel();
      model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
      BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      model.tagCount = TagManager.GetTagCloud(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      if (settingsItem.OrderTagOnCount)
      {
        model.tags = TagManager.GetTagsOrderedByCount(model.tagCount);
      }
      else
      {
        model.tags = TagManager.GetTags(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      }

      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/TagList.cshtml", model);
    }

    public ActionResult TextSearch()
    {
      _datasource = GetNavigationItemPath("Text Search");
      return this.View("~/Areas/XBlog/Views/XBlog/Callouts/TextSearch.cshtml");
    }
    private string GetNavigationItemPath(string navigationTypeName)
    {
      string datasource = RenderingContext.Current.Rendering.DataSource;

      if (string.IsNullOrWhiteSpace(datasource))
      {
        return null;
      }

      return datasource;
    }    

    public ActionResult BlogHeader()
    {
      var model = new BlogListingModel();
      model.Initialize(RenderingContext.Current.Rendering);

      model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
      BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      //string searchHeading = "";
      //string categoryID = "";
      //string authorID = "";
      //string tagID = "";
      //string searchText = "";
      Data.ID[] idFeaturedBLog = { new Data.ID("{11111111-1111-1111-1111-111111111111}") }; 
      string urlCategoryName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBCategoryUrlPattern);
      string urlAuthorName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBAuthorUrlPattern);
      string urlTagName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBTagsUrlPattern);
      string urlSearchName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBSearchURLPattern);

      //Get search results
      int currentPage = 1;
      int maximumRows = 5;
      int startRowIndex = 1;
      bool rowResult = Int32.TryParse(settingsItem.PageSize, out maximumRows);
      model.MaximumRows = maximumRows;
      if (!rowResult)
      {
        model.MaximumRows = 5;
      }

      if (!String.IsNullOrEmpty(Request.QueryString[XBSettings.XBPageQS]))
      {
        model.PageResult = Int32.TryParse(Request.QueryString[XBSettings.XBPageQS], out currentPage);
      }
      if (!model.PageResult)
      {
        currentPage = 1;
      }

      startRowIndex = (currentPage - 1) * maximumRows;
      model.CurrentPage = currentPage;
     // model.TotalRows = BlogManager.GetBlogsCount(Sitecore.Context.Item, urlCategoryName, authorID, tagID, searchText);

     // IEnumerable<BlogPost> allPost = BlogManager.GetBlogPosts(Sitecore.Context.Item, urlCategoryName, authorID, tagID, searchText, startRowIndex, maximumRows, idFeaturedBLog);
      List<BlogPost> featuredPost = new List<BlogPost>();
      // Not removed to check template field deletion, will be deleted later
      //foreach (BlogPost post in allPost)
      //{
      //  if (post.FeaturedPosition == "Sub-Featured" || post.FeaturedPosition == "Main-Featured")
      //    featuredPost.Add(post);
      //}

      model.BlogPosts = featuredPost;

      if (model.SearchHeading != "")
      {
        model.SearchHeading = model.TotalRows.ToString() + " " + model.SearchHeading;
      }
      return View("~/Areas/XBlog/Views/XBlog/BlogHeader.cshtml", model);
    }



    [HttpGet]
    public ActionResult VORBlogListing()
    {
      var model = new BlogListingModel();
      model.Initialize(RenderingContext.Current.Rendering);

      model.dataSourceItem = Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
      BlogSettings settingsItem = DataManager.GetBlogSettingsItem(model.dataSourceItem != null ? model.dataSourceItem : Context.Item);
      //string searchHeading = "";
      string categoryID = "";
      string authorID = "";
      string tagID = "";
      string searchText = "";
      string urlCategoryName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBCategoryUrlPattern);
      if (!String.IsNullOrEmpty(urlCategoryName))
      {       
        Category categoryItem = CategoryManager.GetCategoryByName(Sitecore.Context.Item, urlCategoryName);
        if (categoryItem != null)
        {         
          categoryID = categoryItem.InnerItem.ID.ToString();

          if (settingsItem.DisplayFilterMessage)
          {
            model.SearchHeading = settingsItem.CategoryFilterTitle + categoryItem.CategoryName;
          }
        }
      }

      string urlAuthorName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBAuthorUrlPattern);      
      if (!String.IsNullOrEmpty(urlAuthorName))
      {
        Author authorItem = AuthorManager.VORGetAuthorByName(Sitecore.Context.Item, urlAuthorName);
        if (authorItem != null)
        {
          authorID = authorItem.InnerItem.ID.ToString();
          if (settingsItem.DisplayFilterMessage)
          {
            model.SearchHeading = settingsItem.AuthorFilterTitle + authorItem.FullName;
          }
        }

      }

      string urlTagName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBTagsUrlPattern);
      if (!String.IsNullOrEmpty(urlTagName))
      {
        Tag tagItem = TagManager.GetTagByName(Sitecore.Context.Item, urlTagName);
        if (tagItem != null)
        {
          tagID = tagItem.InnerItem.ID.ToString();

          if (settingsItem.DisplayFilterMessage)
          {
            model.SearchHeading = settingsItem.TagFilterTitle + tagItem.TagName;
          }
        }
      }


      string urlSearchName = DataManager.GetUrlValByPattern(Request.Url.PathAndQuery, XBSettings.XBSearchURLPattern);
      if (!String.IsNullOrEmpty(urlSearchName))
      {
        if (!String.IsNullOrEmpty(urlSearchName))
        {
          searchText = urlSearchName;

          if (settingsItem.DisplayFilterMessage)
          {
            model.SearchHeading = settingsItem.SearchFilterTitle + searchText;
          }
        }
      }

      //For excluding featured blog
      Data.ID idFeaturedBLog=new Data.ID();
      if (string.IsNullOrEmpty(urlCategoryName) && string.IsNullOrEmpty(urlAuthorName))
      {
        var featuredBlogItem = Sitecore.Context.Database.Items.GetItem("{99218AC7-3CD9-4271-B061-56D60569FB13}");
        Sitecore.Data.Fields.MultilistField multiselectField = featuredBlogItem.Fields["Main Featured Blog"];
        Sitecore.Data.Items.Item[] items = multiselectField.GetItems();        
        if (items != null && items.Length > 0)
        {
          var item = items.FirstOrDefault();
          idFeaturedBLog = item.ID;
        }
        else
        {
          if (!string.IsNullOrEmpty(BlogManager.GetLatestVORBlogPost()))
          { 
          idFeaturedBLog = new Sitecore.Data.ID(BlogManager.GetLatestVORBlogPost());
          }
        }
      }
        //Get search results
        int currentPage = 1;
      int maximumRows = 6;
      int startRowIndex = 1;
      bool rowResult = Int32.TryParse(settingsItem.PageSize, out maximumRows);
      model.MaximumRows = maximumRows;
      if (!rowResult)
      {
        model.MaximumRows = 6;
      }

      if (!String.IsNullOrEmpty(Request.QueryString[XBSettings.XBPageQS]))
      {
        model.PageResult = Int32.TryParse(Request.QueryString[XBSettings.XBPageQS], out currentPage);
      }
      if (!model.PageResult || currentPage<1)
      {
        currentPage = 1;
      }
      model.TotalRows = BlogManager.GetVORBlogsCount(Sitecore.Context.Item, urlCategoryName, urlAuthorName, tagID, searchText);
      double decMaxPages = System.Convert.ToDouble(model.TotalRows) / System.Convert.ToDouble(maximumRows);
      int maxPages = System.Convert.ToInt32(Math.Ceiling(decMaxPages));
      if (currentPage > maxPages) { currentPage = maxPages; }      
      startRowIndex = (currentPage - 1) * maximumRows;

      model.CurrentPage = currentPage;
      model.BlogPosts = BlogManager.GetVORBlogPosts(Sitecore.Context.Item, urlCategoryName, urlAuthorName, tagID, searchText, startRowIndex, maximumRows, idFeaturedBLog, model.TotalRows);

      if (model.SearchHeading != "")
      {
        model.SearchHeading = model.TotalRows.ToString() + " " + model.SearchHeading;
      }

      if (!String.IsNullOrEmpty(urlAuthorName))
      {
        return View("~/Areas/XBlog/Views/XBlog/VORAuthorView.cshtml", model);
      }
      return View("~/Areas/XBlog/Views/XBlog/VORBlogListing.cshtml", model);
    }

    public ActionResult VORBlogPost()
    {
      var model = new BlogPostModel();
      model.Initialize(RenderingContext.Current.Rendering);

      return View("~/Areas/XBlog/Views/XBlog/VORBlogPost.cshtml", model);
    }
    public ActionResult VORBlogComments()
    {
      var model = new VorBlogCommentsModel();
      model.Title= Sitecore.Context.Item["Title"];
      model.VORBlogComments = BlogManager.GetVORComments(Sitecore.Context.Item);
      return View("~/Areas/XBlog/Views/XBlog/VORBlogComments.cshtml", model);
    }
    public ActionResult VORBlogCommentsForm()
    {
      return View("~/Areas/XBlog/Views/XBlog/VORBlogCommentsForm.cshtml");
    }
    [HttpPost]
    public ActionResult CommentSubmit(string comment, string name, string email, string capchaResponse, string ItemId)
    {
      bool isCaptchaValid = Helper.ValidateCaptcha(capchaResponse);
      if (isCaptchaValid && !string.IsNullOrEmpty(comment) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
      {
           

        string commentName = "Comment_" + Sitecore.DateUtil.IsoNow;
        try
        {
          bool itemCreated = Services.ClientService.CreateCommentItem(comment, name, email, ItemId, commentName);
          if (!itemCreated)
          {
            return Json(new { success = "unsuccessful", message = "Commentnotcreated" });
          }
        }
        catch (Exception ex)
        {
          Error.LogError("commentcreationException = " + ex);
          return Json(new { success = "unsuccessful", message = "Commentnotcreated" });
        }
          
        try {
           
          Sitecore.Data.Database masterDB = Sitecore.Context.Database;
          Item EmailContent = masterDB.GetItem(Data.ID.Parse("{D74EFB4B-BD7D-496C-B618-51472BA169D3}"));
          Item parentItem = masterDB.GetItem(Data.ID.Parse(ItemId));
          string blogUrl = Sitecore.Links.LinkManager.GetItemUrl(parentItem);
          string blogTitle = parentItem["Title"];
          string commentUrl = blogUrl + "/" + commentName;
          if (EmailContent!=null)
          {
            if (!string.IsNullOrEmpty(EmailContent["From"]) && !string.IsNullOrEmpty(EmailContent["To"]) && !string.IsNullOrEmpty(EmailContent["Body"]) && !string.IsNullOrEmpty(EmailContent["Subject"]))
            {

              MailAddress from = new MailAddress(EmailContent["From"].Replace("[Email]", email));
              MailAddress to = new MailAddress(EmailContent["To"].Replace("[Email]", email));
              MailMessage emailMessage = new MailMessage(from, to);
              var emailSubject = EmailContent["Subject"].Replace("[Name]", name).Replace("[Comment]", comment).Replace("[Email]", email).Replace("[BlogTitle]", blogTitle).Replace("[BlogUrl]", blogUrl).Replace("[CommenUrl]", commentUrl).Replace("[CommentTitle]", commentName);
              emailMessage.Subject = emailSubject;
              var emailBody = EmailContent["Body"].Replace("[Name]", name).Replace("[Comment]", comment).Replace("[Email]", email).Replace("[BlogTitle]", blogTitle).Replace("[BlogUrl]", blogUrl).Replace("[CommenUrl]", commentUrl).Replace("[CommentTitle]", commentName);
              emailMessage.Body = emailBody;
              emailMessage.IsBodyHtml = true;
              MainUtil.SendMail(emailMessage);
            }
          }
        
        }
        catch (Exception ex)
        {
          Error.LogError("commentEmailException = " + ex);
          return Json(new { success = "success", message = "Email not sent" });
        }
        return Json(new { success = "success", message = "comment submitted" });
      }
      return Json(new { success = "unsuccessful", message = "error" });

    }

    public ActionResult VORRelatedBlog()
    {
      _datasource = GetNavigationItemPath("Related Blog");
      return this.View("~/Areas/XBlog/Views/XBlog/VORRelatedBlog.cshtml");
    }
    }
}
