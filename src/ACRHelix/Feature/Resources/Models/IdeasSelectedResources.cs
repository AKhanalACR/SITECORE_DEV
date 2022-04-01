using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.IdeasResources.Models
{
    [SitecoreType(TemplateId = "{8D226409-F699-4893-82CF-A848FDD402A3}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasSelectedResources : ICMSEntity
    {
        public IdeasSelectedResources()
        {
            SelectedResources = new List<Models.IdeasResource>();
            AllResources = new List<Models.IdeasResource>();
        }
        public virtual ID Id { get; set; }
        [SitecoreField("Title")]
        public virtual string Title { get; set; }

        [SitecoreField("Subtitle")]
        public virtual string Subtitle { get; set; }

        [SitecoreField("View More Link")]
        public virtual Link ViewMoreLink { get; set; }

        [SitecoreField("View More Link Text")]
        public virtual string ViewMoreLinkText { get; set; }

        [SitecoreField("Number of resources to be displayed")]
        public virtual int NumberOfResources { get; set; }

        [SitecoreField("Selected Resources")]
        public virtual IEnumerable<IdeasResource> SelectedResources { get; set; }

        //[SitecoreQuery("/sitecore/content/Ideas/Educational Resources/*[@@templateid = '{2EAD1608-9E8C-444F-AF66-766578E687F8}']", IsRelative = false)]
        [SitecoreQuery("/sitecore/content/Ideas/Educational Resources/*[@@templateid = '{2EAD1608-9E8C-444F-AF66-766578E687F8}']|/sitecore/content/Ideas/Educational Resources/*[@@templateid = '{97021C60-4F16-47D3-B256-0D2AA6B10747}']|/sitecore/content/Ideas/Educational Resources/*[@@templateid = '{642560E4-E4F3-4A1B-AB9D-9740676DB06A}']", IsRelative = false)]
        public virtual IEnumerable<IdeasResource> AllResources { get; set; }
    }
}