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
    public interface IBiography : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
       
        string RichText { get; set; }

        string FacebookUrl { get; set; }

        string TwitterUrl { get; set; }

        string LinkedInUrl { get; set; }

        Image Image { get; set; }

    }
}