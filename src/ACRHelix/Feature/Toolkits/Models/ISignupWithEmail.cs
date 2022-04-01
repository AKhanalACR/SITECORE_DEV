using ACRHelix.Feature.Toolkits.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ACRHelix.Feature.Toolkits.Models
{
    public interface ISignupWithEmail : ICMSEntity
    {
        Guid Id { get; set; }
        
        string Title { get; set; }
        string Teaser { get; set; }

  }
}