
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class SectionTitleWithPlaceholder : ISectionTitleWithPlaceholder
    {
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
    }
}