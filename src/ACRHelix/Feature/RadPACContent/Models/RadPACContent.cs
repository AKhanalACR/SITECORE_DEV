using ACRHelix.Feature.RadPACContent.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public class RadPACContent : IRadPACContent
    {
        public Guid Id { get; }
        public string Title { get; }
    }
}