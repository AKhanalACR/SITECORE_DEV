using ACRHelix.Feature.Advertisements.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Advertisements.Models
{
    public class Ad : IAd
    {
        public virtual Guid Id { get; }
        public virtual string Title { get; }
    }
}