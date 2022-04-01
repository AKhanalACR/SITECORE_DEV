using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.MemberDirectory.Models;

namespace ACRHelix.Feature.MemberDirectory.ViewModels
{
    public class MemberDirectoryViewModel
    {
		public Guid Id { get; set; }
		public String Title { get; set; }
		public String SubTitle { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String Zip { get; set; }
        public List<MemberViewModel> Members { get; set; }
    }
}