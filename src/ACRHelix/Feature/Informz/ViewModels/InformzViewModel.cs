using ACR.Foundation.Personify.Models.Informz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Informz.ViewModels
{
  public class InformzViewModel
  {
    public Models.InformzPage InformzContent { get; set; }
    public string Email { get; set; }  
    public List<ViewModelCheckbox> Checkboxes { get; set; }

    public InformzCustomerData CustomerData { get; set; }

    public string HiddenCaptcha { get; set; }

    public InformzRegisterData RegistrationData { get; set; }

    public string FormSubmitted { get; set; }

    public bool Error { get; set; } = false;

    public string ErrorMessage { get; set; }


  }
}