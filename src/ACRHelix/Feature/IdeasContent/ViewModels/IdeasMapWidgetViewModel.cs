using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.IdeasContent.ViewModels
{
    public class IdeasMapWidgetViewModel
    {
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual Link FindByStateLink { get; set; }
        public virtual string FindByStateLinkText { get; set; }
        public virtual Link FindByZipLink { get; set; }
        public virtual string FindByZipLinkText { get; set; }
        public virtual Link MapLink { get; set; }
        public virtual Image MapImage { get; set; }
  }
}