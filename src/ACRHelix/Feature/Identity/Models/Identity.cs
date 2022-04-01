using ACRHelix.Feature.Identity.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public class Identity : IIdentity
    {
        public Guid Id { get; }
        public string Title { get; }
    }
}