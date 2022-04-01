using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class RliPageTitleSection : IRliPageTitleSection
    {
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual Image BannerBackgroundImage { get; set; }        
        public virtual Image RliLogo { get; set; }
        public virtual string RightCalloutText { get; set; }
        public virtual Link RightCalloutLink { get; set; }
        public virtual Image RightCalloutImage { get; set; }
    }
}