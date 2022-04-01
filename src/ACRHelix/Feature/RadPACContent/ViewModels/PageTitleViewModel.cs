
using System;
using Sitecore.Data;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class PageTitleViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RichText { get; set; }
        public DateTime Date { get; set; }
    }
}