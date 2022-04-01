using ACRHelix.Feature.Toolkits.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Toolkits.ViewModels
{
  public class MesoNewFormViewModel
  {
    private MesoFormData _mesoFormData;

    public MesoNewFormViewModel()
    {
      _mesoFormData = new MesoFormData();
    }

    public Guid Id { get; set; }
    public Link ConfirmationPageUrl { get; set; }

    public Link ErrorPageUrl { get; set; }

    public string Email { get; set; }
    public string EmailFrom { get; set; }
    public string EmailBody { get; set; }
    public string EmailSubject { get; set; }

    public MesoFormData MesoFormData
    {
      get { return _mesoFormData; }
      set { value = _mesoFormData; }
    }

    public HttpPostedFileBase ResourceFile { get; set; }

    public string Disclaimer { get; set; }
    public string DisclaimerCheckboxText { get; set; }

  }
}