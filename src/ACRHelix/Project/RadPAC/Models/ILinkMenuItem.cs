using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{   
    public interface ILinkMenuItem : ICMSEntity
    {
        Guid Id { get; set; }
        string Title { get; set; }
        Link Link { get; set; }

        [SitecoreField("Icon CSS Class")]
        string IconCssClass { get; set; }
        
    }
}