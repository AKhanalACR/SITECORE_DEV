using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.MeetingsCalendar.Models;
using ACR.Foundation.Personify.Models.Products;
using Sitecore.Data;

namespace ACRHelix.Feature.MeetingsCalendar.ViewModels
{
  public class RegistrationTableViewModel
  {
		public ID Id { get; set; }
		public String Title { get; set; }
    public IEnumerable<ProductStubItem> Products { get; set; }
  }
}