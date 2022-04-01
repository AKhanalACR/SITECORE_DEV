using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class RichTextWithImage : IRichTextWithImage
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string RichText { get; set; }
        public Image Image { get; set; }
        public Link Link { get; set; }         
        public string ImageLocaton { get; set; }

    }
}