using ACRHelix.Feature.RelatedArticles.Models;
using ACRHelix.Foundation.Index.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RelatedArticles.Services
{
    public interface IContentService
    {
        IRelatedArticles GetRelatedArticlesContent(string contentGuid);
        IEnumerable<TagSearchResult> SearchArticleTags(IEnumerable<string> tags);
    }
}