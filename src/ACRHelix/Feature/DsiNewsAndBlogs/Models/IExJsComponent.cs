using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public interface IExJsComponent : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }
        string RichText { get; set; }
        Link ModuleUrl { get; set; }
        string ContainerClass { get; set; }
    }
}