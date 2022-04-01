using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class RichTextSection : IRichTextSection
    {
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string RichText { get; set; }
    }
}