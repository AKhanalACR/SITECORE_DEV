using Glass.Mapper.Sc.Fields;
using System;
using Sitecore.Data;

namespace ACRHelix.Feature.DsiNewsAndBlogs.ViewModels
{
    public class DsiPageTitleWithImageViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public Image TitleImage { get; set; }
        public Image TitleBackgroundImage { get; set; }
    }
}