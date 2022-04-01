using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.Decamp.ViewModels
{
  public class LogoViewModel
  {
    public Guid Id { get; set; }
    public Link Link { get; set; }
    public Image Image { get; set; }
  }
}