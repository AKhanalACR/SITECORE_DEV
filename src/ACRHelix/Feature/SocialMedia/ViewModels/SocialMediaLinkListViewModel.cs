using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.SocialMedia.Models;

namespace ACRHelix.Feature.SocialMedia.ViewModels
{
    public class SocialMediaLinkListViewModel
    {
		public Guid Id { get; set; }
		public String Title { get; set; }
        public IEnumerable<ISocialMediaLink> Links { get; set; }
    }
}