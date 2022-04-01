using ACRHelix.Feature.Toolkits.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Toolkits.ViewModels
{
  public class SignupWithEmailViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string Teaser { get; set; }
  }
}