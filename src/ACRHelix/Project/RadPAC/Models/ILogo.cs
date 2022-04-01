using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{
    [SitecoreType(AutoMap = true)]
    public interface ILogo : ICMSEntity
    {
        Guid Id { get; set; }
        Link Link { get; set; }
        Image Image { get; set; }
    }
}