using ACRHelix.Feature.Social.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Social.Models
{
    public class SocialItem : ISocialItem
    {
        public virtual Guid Id { get; set; }
        public virtual string CSSClass { get; set; }
	    	public virtual Link Link { get; set; }
    }
}