using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.Decamp.ViewModels
{
  public class DecampFooterViewModel
  {
    public Guid Id { get; set; }
    public string Copyright { get; set; }

    public string Richtext { get; set; }

    public Image LeftImage { get; set; }
    public Link LeftLink { get; set; }

    public Image CenterLeftImage { get; set; }
    public Link CenterLeftLink { get; set; }

    public Image CenterRightImage { get; set; }
    public Link CenterRightLink { get; set; }

    public Image RightImage { get; set; }
    public Link RightLink { get; set; }
  }
}