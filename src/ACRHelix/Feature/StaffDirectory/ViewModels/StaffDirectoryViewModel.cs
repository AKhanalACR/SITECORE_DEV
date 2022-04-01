using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.Biography.ViewModels;
using Sitecore.Data;

namespace ACRHelix.Feature.StaffDirectory.ViewModels
{
    public class StaffDirectoryViewModel
    {
		public ID Id { get; set; }
		public String Title { get; set; }
    public IEnumerable<BiographyViewModel> Biographies { get; set; }

    public bool HideEmailPhone { get; set; }

    public bool UserAuthenticated { get; set; }
    }
}