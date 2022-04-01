using System.Collections.Generic;
using Sitecore.Feature.XBlog.Areas.XBlog.Items.Blog;
using Sitecore.Feature.XBlog.Areas.XBlog.Models.Blog;
using Sitecore.Data;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Services
{
  public interface IContentService
  {
    BlogPost GetBlogPostContent(string contentGuid);

    List<BlogSearchItem> GetBlogPostsByCategoryId(ID categoryId);
    VORBlogEmail GetEmailData(string contentGuid);

  }
}