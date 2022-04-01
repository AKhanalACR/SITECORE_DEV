using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;


namespace ACRHelix.Feature.RelatedArticles.Models
{
    public interface IRelatedArticles : ICMSEntity
    {
		Guid Id { get; set; }
        IEnumerable<IRelatedArticlesItem> Articles { get; set; }
    }
}