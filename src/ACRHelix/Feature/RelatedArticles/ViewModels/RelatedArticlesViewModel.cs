using System;
using System.Collections.Generic;
using ACRHelix.Feature.RelatedArticles.Models;

namespace ACRHelix.Feature.RelatedArticles.ViewModels
{
    public class RelatedArticlesViewModel
    {
		public Guid Id { get; set; }
        public IEnumerable<IRelatedArticlesItem> Articles { get; set; }
    }
}