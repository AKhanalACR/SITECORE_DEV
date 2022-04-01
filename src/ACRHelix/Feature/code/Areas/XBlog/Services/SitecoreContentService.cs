using ACRHelix.Foundation.Repository.Content;
using Sitecore.Feature.XBlog.Areas.XBlog.Items.Blog;
using Sitecore.Feature.XBlog.Areas.XBlog.Models.Blog;
using Sitecore.Feature.XBlog.Areas.XBlog.Constants;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public BlogPost GetBlogPostContent(string contentGuid)
    {
      return _repository.GetContentItem<BlogPost>(contentGuid);
    }

    public List<BlogSearchItem> GetBlogPostsByCategoryId(ID categoryId)
    {
      string strCategoryId = categoryId.ToString();
      return GetBlogPostsByCategoryId(strCategoryId);
    }

    public List<BlogSearchItem> GetBlogPostsByCategoryId(string categoryId)
    {
      var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(Indexes.DefaultIndex.IndexName);
      using (var context = searchIndex.CreateSearchContext())
      {    
        var blogs = context.GetQueryable<BlogSearchItem>().Where(x => x.Category.Contains(categoryId)).ToList();
        return blogs;
      }
    }
    public VORBlogEmail GetEmailData(string contentGuid)
    {
      return _repository.GetContentItem<VORBlogEmail>(contentGuid);
    }
    
  }
}