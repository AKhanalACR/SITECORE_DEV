using ACRHelix.Foundation.Model;
using Sitecore.Data;
using System;


namespace ACRHelix.Feature.RelatedArticles.Models
{
    public interface IRelatedArticlesItem : ICMSEntity
    {
        ID Id { get; }
        string Title { get; set; }
        string Url { get; set; }
        DateTime Date { get; set; }
        bool Equals(object other);
        int GetHashCode();
    }
}