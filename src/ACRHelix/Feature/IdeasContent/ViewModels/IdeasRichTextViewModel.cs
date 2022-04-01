using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
namespace ACRHelix.Feature.IdeasContent.ViewModels
{
    public class IdeasRichTextViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string RichText { get; set; }
    }
}