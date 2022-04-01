using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SocialMedia.ViewModels
{
    public class SocialMediaFeedViewModel
    {
		public Guid Id { get; set; }
		public String EmbeddedHTML { get; set; }
    }
}