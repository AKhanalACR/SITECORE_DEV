using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{    
    
    public interface IPageTitleWithImage : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }        
        Image Image { get; set; }
    }
}