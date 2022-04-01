using ACRHelix.Feature.Toolkits.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Toolkits.ViewModels
{
  public class ReviewFormViewModel
  {
    private ReviewFormData _reviewFormData;
    private IEnumerable<SelectListItem> _reviewersList;

    public ReviewFormViewModel()
    {
      _reviewFormData = new ReviewFormData();
      _reviewersList = new List<SelectListItem>();
    }

    public Guid Id { get; set; }
    public Link ConfirmationPageUrl { get; set; }

    public Link ErrorPageUrl { get; set; }

    public string Email { get; set; }
    public string EmailFrom { get; set; }
    public string EmailBody { get; set; }
    public string EmailSubject { get; set; }

    public ReviewFormData ReviewFormData
    {
      get { return _reviewFormData; }
      set { value = _reviewFormData; }
    }

    public HttpPostedFileBase ResourceFile { get; set; }

    public string Reviewer { get; set; }

    public IEnumerable<SelectListItem> ReviewersList
    {
      get { return _reviewersList; }
      set { value = _reviewersList; }
    }

    public string Status { get; set; }

    public string CustomerType { get; set; }

  }
}