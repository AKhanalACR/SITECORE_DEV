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
    public interface ICalloutCards : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        string LeftCardTitle { get; set; }
        string LeftCardDescription { get; set; }
        Link LeftCardLink { get; set; }

        string RightCardTitle { get; set; }
        string RightCardDescription { get; set; }
        Link RightCardLink { get; set; }
    }
}