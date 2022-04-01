using ACRHelix.Feature.Ideas.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Ideas.Models
{
    public class Ideas : IIdeas
    {
        public Guid Id { get; }
        public string Title { get; }
    }
}