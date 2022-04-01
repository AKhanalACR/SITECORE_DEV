using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.Decamp.Models
{
  public interface IDecampFooter : ICMSEntity
  {
    Guid Id { get; set; }

    string Copyright { get; set; }
    string Richtext { get; set; }

    Image LeftImage { get; set; }
    Link LeftLink { get; set; }

    Image CenterLeftImage { get; set; }
    Link CenterLeftLink { get; set; }

    Image CenterRightImage { get; set; }
    Link CenterRightLink { get; set; }

    Image RightImage { get; set; }
    Link RightLink { get; set; }
  }
}