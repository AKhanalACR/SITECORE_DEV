using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class HonorRollViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string FilterText { get; set; }
        public string RichText { get; set; }
    }
}