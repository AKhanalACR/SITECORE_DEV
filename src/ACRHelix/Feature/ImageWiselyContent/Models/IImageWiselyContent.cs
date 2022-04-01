using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public interface IImageWiselyContent : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }
    }
}