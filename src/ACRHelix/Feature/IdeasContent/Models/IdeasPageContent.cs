using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;


namespace ACRHelix.Feature.IdeasContent.Models
{
    public class IdeasPageContent : IIdeasPageContent
    {
        public IdeasPageContent()
        {
            Tags = new List<IdeasDictionaryEntry>();
        }
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RichText { get; set; }
        public DateTime Date { get; set; }
        public  bool EnableShareLink { get; set; }
        public IEnumerable<IdeasDictionaryEntry> Tags { get; set; }
    }
}