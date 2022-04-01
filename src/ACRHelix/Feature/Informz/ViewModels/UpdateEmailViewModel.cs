using ACR.Foundation.Personify.Models.Informz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Informz.ViewModels
{
  public class UpdateEmailViewModel
  {
        public Models.InformzPage InformzContent { get; set; }
        public string Email { get; set; }    
        public InformzCustomerData CustomerData { get; set; }
        public bool Error { get; set; } = false;
        public int Count { get; set; }
        public string ErrorMessage { get; set; }
  }
}