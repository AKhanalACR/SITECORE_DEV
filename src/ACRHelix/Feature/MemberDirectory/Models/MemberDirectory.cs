using ACRHelix.Feature.MemberDirectory.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MemberDirectory.Models
{
    public class MemberDirectory : IMemberDirectory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }
}