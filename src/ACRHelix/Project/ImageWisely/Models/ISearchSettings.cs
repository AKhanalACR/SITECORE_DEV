using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.ImageWisely.Models
{
    public interface ISearchSettings : ICMSEntity
    {
        Guid Id { get; }

        [SitecoreField("Main Search Page")]
        Link SeachPageUrl { get; set; }
    }
}