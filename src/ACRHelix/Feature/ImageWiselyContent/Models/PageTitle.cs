using ACRHelix.Feature.ImageWiselyContent.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class PageTitle : IPageTitle
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RichText { get; set; }
        public DateTime Date { get; set; }
                
        public Image TitleImage { get; set; }
    }
}