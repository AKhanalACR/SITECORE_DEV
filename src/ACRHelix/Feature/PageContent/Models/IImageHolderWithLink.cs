using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface IImageHolderWithLink : ICMSEntity
    {
        ID Id { get; }
        IEnumerable<Image> Images { get; set; }
        string RedirectUrl { get; set; }
    }
}