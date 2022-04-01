using ACRHelix.Feature.ImageWiselyContent.Models;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class RichTextSectionViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string RichText { get; set; }
        public IRichTextSection RichTextSect { get; set; }

    }
}