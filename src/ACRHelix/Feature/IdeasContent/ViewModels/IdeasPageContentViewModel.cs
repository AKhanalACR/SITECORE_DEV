using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasContent.ViewModels
{
    public class IdeasPageContentViewModel
    {
        public IdeasPageContentViewModel()
        {
            Tags = new List<Models.IdeasDictionaryEntry>();
        }
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RichText { get; set; }
        public DateTime Date { get; set; }
        public bool EnableShareLink { get; set; }
        public List<Models.IdeasDictionaryEntry> Tags { get; set; }
    }
}