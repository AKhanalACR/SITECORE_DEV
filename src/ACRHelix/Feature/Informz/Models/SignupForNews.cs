using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Informz.Models
{
  public class SignupForNews : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Title { get; set; }

    public virtual Link Link { get; set; }

  }
}