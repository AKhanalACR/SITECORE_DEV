using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.IdeasContent.Models
{
    [SitecoreType(TemplateId = "{D521A6F0-CA8F-4CB3-A366-7796BC3BD785}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public interface IIdeasMapWidget : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        [SitecoreField("Find by state link")]
        Link FindByStateLink { get; set; }

        [SitecoreField("Find by state link text")]
        string FindByStateLinkText { get; set; }

        [SitecoreField("Find by zip link")]
        Link FindByZipLink { get; set; }

        [SitecoreField("Find by zip link text")]
        string FindByZipLinkText { get; set; }

        [SitecoreField("Map Link")]
        string MapLink { get; set; }

        [SitecoreField("Map Image")]
        Image MapImage { get; set; }
  }
}