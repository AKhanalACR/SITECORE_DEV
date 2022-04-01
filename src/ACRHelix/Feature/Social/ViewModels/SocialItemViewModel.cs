using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Social.ViewModels
{
    public class SocialItemViewModel
    {
        public Guid Id { get; set; }
        public string CSSClass { get; set; }
        public Link Link { get; set; }
    }
}