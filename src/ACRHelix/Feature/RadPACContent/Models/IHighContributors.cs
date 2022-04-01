using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public interface IHighContributors : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        Image RightTileImage { get; set; }
        string RightTileHeading { get; set; }
        
        Image LeftTileImage { get; set; }
        string LeftTileHeading { get; set; }
                
    }
}