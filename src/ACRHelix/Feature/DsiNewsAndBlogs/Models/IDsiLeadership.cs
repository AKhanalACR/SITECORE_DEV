using ACRHelix.Feature.Biography.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public interface IDsiLeadership : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        [SitecoreChildren]
        IEnumerable<IBiography> Biographies { get; set; }

        [SitecoreField(FieldName = "Hide Email Phone", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.Checkbox)]
        bool HideEmailPhone { get; set; }
    }
}