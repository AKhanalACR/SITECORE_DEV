using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MemberDirectory.Models
{
    public interface IMemberDirectory : ICMSEntity
    {
		Guid Id { get; set; }
		String Title { get; set; }
		String SubTitle { get; set; }
    }
}