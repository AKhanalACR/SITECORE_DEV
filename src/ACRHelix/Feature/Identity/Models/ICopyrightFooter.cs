using ACRHelix.Feature.Identity.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public interface ICopyrightFooter : ICMSEntity
    {
        Guid Id { get; set; }
        string Copyright { get; set; }

        Link Link { get; set; }

        [SitecoreField("Additional Text")]
        string AdditionalText { get; }
    }
}