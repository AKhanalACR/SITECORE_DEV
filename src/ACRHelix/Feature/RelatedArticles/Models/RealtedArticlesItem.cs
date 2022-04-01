using Sitecore.Data;
using System;

namespace ACRHelix.Feature.RelatedArticles.Models
{
    public class RelatedArticlesItem : IRelatedArticlesItem
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public override bool Equals(object other) //note parameter is of type object
        {
            RelatedArticlesItem t = other as RelatedArticlesItem;
            return (t != null) ? Id.Equals(t.Id) : false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}