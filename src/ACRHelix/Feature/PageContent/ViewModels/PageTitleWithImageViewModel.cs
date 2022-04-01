using Glass.Mapper.Sc.Fields;
using System;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.ViewModels
{
    public class PageTitleWithImageViewModel
    {
        public ID Id { get; set; }
        public Image TitleImage { get; set; }
        public PageTitleViewModel PageTitle { get; set; }
    }
}