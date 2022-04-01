using System;
using System.Collections.Generic;


namespace ACRHelix.Feature.RelatedArticles.Models
{
    public class RelatedArticles : IRelatedArticles
    {
        public Guid Id { get; set; }
        public IEnumerable<IRelatedArticlesItem> Articles { get; set; }
    }
}