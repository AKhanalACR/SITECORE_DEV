using ACRHelix.Feature.Toolkits.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Toolkits.ViewModels
{
  public class ResourceFormViewModel
  {
    private ResourceFormData _resourceFormData;

    public ResourceFormViewModel()
    {
      _resourceFormData = new ResourceFormData();
    }

    public Guid Id { get; set; }
    public Link ConfirmationPageUrl { get; set; }

    public Link ErrorPageUrl { get; set; }

    public string Email { get; set; }
    public string EmailFrom { get; set; }
    public string EmailBody { get; set; }
    public string EmailSubject { get; set; }

    public ResourceFormData ResourceFormData
    {
      get { return _resourceFormData; }
      set { value = _resourceFormData; }
    }

    public HttpPostedFileBase ResourceFile { get; set; }

  }
}