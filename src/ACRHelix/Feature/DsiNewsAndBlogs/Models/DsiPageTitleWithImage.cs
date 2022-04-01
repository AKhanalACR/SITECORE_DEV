
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public class DsiPageTitleWithImage : IDsiPageTitleWithImage
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public Image TitleImage { get; set; }
        public Image TitleBackgroundImage { get; set; }
    }
}