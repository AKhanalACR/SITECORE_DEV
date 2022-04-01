using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class PageTitle : IPageTitle
    {
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual string RichText { get; set; }
        public virtual DateTime Date { get; set; }
    }
}