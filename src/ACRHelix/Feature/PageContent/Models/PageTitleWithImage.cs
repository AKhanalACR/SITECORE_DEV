
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class PageTitleWithImage : IPageTitleWithImage
    {
        public virtual ID Id { get; set; }
        public virtual Image TitleImage { get; set; }
    }
}