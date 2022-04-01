using ACRHelix.Feature.ImageWiselyContent.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class BlockWithTextCalloutViewModel
    {
        public ID Id { get; set; }

        public string RichText { get; set; }

        public Link Link { get; set; }

    }
}