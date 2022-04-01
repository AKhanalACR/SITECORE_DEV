using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;


namespace ACRHelix.Feature.IdeasContent.Models
{
    [SitecoreType(TemplateId = "{D521A6F0-CA8F-4CB3-A366-7796BC3BD785}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasMapWidget : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("Title")]
        public virtual string Title { get; set; }

        [SitecoreField("Find by state link")]
        public virtual Link FindByStateLink { get; set; }

        [SitecoreField("Find by state link text")]
        public virtual string FindByStateLinkText { get; set; }

        [SitecoreField("Find by zip link")]
        public virtual Link FindByZipLink { get; set; }

        [SitecoreField("Find by zip link text")]
        public virtual string FindByZipLinkText { get; set; }

        [SitecoreField("Map Link")]
        public virtual Link MapLink { get; set; }

        [SitecoreField("Map Image")]
        public virtual Image MapImage { get; set; }
  }
}